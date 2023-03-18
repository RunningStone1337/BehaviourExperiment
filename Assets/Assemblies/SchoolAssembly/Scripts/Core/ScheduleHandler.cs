using Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UI;
using UnityEngine;
using UnityEngine.Events;

namespace Core
{
    public class CurrentEventChangedEventArgs : EventArgs
    {
        public GlobalEvent newEvent;
        public int eventTimer;
    }
    public class CurrentDayChangedEventArgs : EventArgs
    {
        public DaySchedule newDay;
    }

    public class ScheduleHandler : MonoBehaviour
    {
        #region settings
        [SerializeField, Range(1f, 60f)] float timeScale;
        #endregion
        #region codeData
        [Space, Header("Init from code")]
        [SerializeField] private int breaksLength;
        [SerializeField] private int experimentLengthDays;
        [SerializeField] private List<DaySchedule> workDays;
        [SerializeField] DaySchedule currentDay;
        [SerializeField] DisciplineBase currentLesson;
        public DaySchedule CurrentDay
        {
            get => currentDay;
            private set
            {
                currentDay = value;
                if (currentDay.DayIndex < experimentLengthDays)
                    OnDayStarted?.Invoke(new CurrentDayChangedEventArgs() { newDay = currentDay });
            }
        }
        public DisciplineBase CurrentLesson => currentLesson;
        #endregion
        #region refs
        [Space, Header("References")]
        [SerializeField] private LengthConfigurator breaksLengthSlider;
        [SerializeField] private LengthConfigurator experimentLengthSlider;
        [SerializeField] private WorkDaysSelector workDaysSelector;
        [SerializeField] GlobalEventsHandler eventsHandler;
        [SerializeField] ExperimentProcessHandler experimentProcess;
        #endregion

        #region events
        [Space, Header("Events")]
        [SerializeField] UnityEvent<CurrentDayChangedEventArgs> onDayStarted;
        [SerializeField] UnityEvent<CurrentEventChangedEventArgs> onEventTimerChanged;
        public UnityEvent<CurrentDayChangedEventArgs> OnDayStarted => onDayStarted;
        public UnityEvent<CurrentEventChangedEventArgs> OnEventTimerChanged => onEventTimerChanged;
        
        #endregion events

        private Coroutine eventsRoutine;

        private void Awake()
        {
            experimentLengthSlider.ValueChangedEvent.AddListener(OnExperimentLengthChangedCallback);
            breaksLengthSlider.ValueChangedEvent.AddListener(OnBreaksLengthChangedCallback);
        }

        #region experiment
        public void StartSchedule()
        {
            eventsRoutine = StartCoroutine(StartExecuting());
        }

        private IEnumerator StartExecuting()
        {
            var start = workDays[0];
            start.DayIndex = 0;
            CurrentDay = start;
            for (int day = 0; day < ExperimentLengthDays; day++)
            {
                for (int lesson = 0; lesson < currentDay.Lessons.Count; lesson++)
                    yield return LessonCycle(lesson);

                var dOver = eventsHandler.DayOverEvent;
                dOver.Initiate(this);
                eventsHandler.CurrentGlobalEvent = dOver;
                //перерыв до следующего дн€
                //пока все агенты не покинули сцену
                while (IsAnyActiveAgentOnScene())
                    yield return new WaitForFixedUpdate();
                //пауза перед новым днЄм
                yield return new WaitForSeconds(1f);

                var next = currentDay.NextDay;
                next.DayIndex = day+1;
                CurrentDay = next;
            }
        }

        private bool IsAnyActiveAgentOnScene()
        {
            foreach (var pupil in experimentProcess.Pupils)
            {
                if (pupil.IsActing || !pupil.IsHidedVisual)
                    return true;
            }
            if (experimentProcess.Teacher.IsActing || !experimentProcess.Teacher.IsHidedVisual)
                return true;
            return false;
        }

        IEnumerator LessonCycle(int lesson)
        {
            currentLesson = currentDay.Lessons[lesson];
            //зан€тие
            var les = eventsHandler.LessonEvent;
            les.Initiate(this);
            eventsHandler.CurrentGlobalEvent = les;
            yield return EventCycle();

            if (lesson != currentDay.Lessons.Count - 1)//не последний урок
            {
                //перерыв
                var br = eventsHandler.BreakEvent;
                br.Initiate(this);
                eventsHandler.CurrentGlobalEvent = br;
                yield return EventCycle();
            }
        }

        private IEnumerator EventCycle()
        {
            var duration = eventsHandler.CurrentGlobalEvent.EventDuration;
            for (int min = 0; min < duration; min++)
            {
                yield return new WaitForSeconds(60 / timeScale);
                OnEventTimerChanged?.Invoke(new CurrentEventChangedEventArgs() { eventTimer = min });
            }
        }

        public void CreateSchedule()
        {
            workDays.Clear();
            workDays.AddRange(workDaysSelector.GetWorkDays());
            foreach (var day in WorkDays)
                day.CreateSchedule();
            for (int day = 0; day < WorkDays.Count-1; day++)
                WorkDays[day].NextDay = WorkDays[day + 1];
            WorkDays[WorkDays.Count-1].NextDay = WorkDays[0];
        }
        
        #endregion
        private void OnBreaksLengthChangedCallback(int newVal)
        {
            breaksLength = newVal;
        }

        private void OnDaySelectionChangedCallback(DaySwitcher sender, bool newValue)
        {
            if (newValue)
                workDays.Add(sender.ThisDaySchedule);
            else
                workDays.Remove(sender.ThisDaySchedule);
        }

        private void OnDestroy()
        {
            experimentLengthSlider.ValueChangedEvent.RemoveListener(OnExperimentLengthChangedCallback);
            breaksLengthSlider.ValueChangedEvent.RemoveListener(OnBreaksLengthChangedCallback);
            //workDaysSelector.DaySelectionChangedEvent -= OnDaySelectionChangedCallback;
        }
        private void OnExperimentLengthChangedCallback(int newVal)
        {
            experimentLengthDays = newVal;
        }
        public int BreaksLengthMins => breaksLength;
        public int ExperimentLengthDays => experimentLengthDays;

        /// <summary>
        /// ¬се дни недели, участвующие в цикле
        /// </summary>
        public List<DaySchedule> WorkDays => workDays;
        public WorkDaysSelector WorkDaysSelector => workDaysSelector;

       
    }
}