using Events;
using System;
using System.Collections.Generic;
using System.Linq;
using UI;
using UnityEngine;

namespace Core
{
    public class ScheduleHandler : MonoBehaviour
    {
        [SerializeField] private int breaksLength;
        [SerializeField] private LengthConfigurator breaksLengthSlider;
        [SerializeField] private int experimentLength;
        [SerializeField] private LengthConfigurator experimentLengthSlider;
        [SerializeField] private List<DaySchedule> workDays;
        [SerializeField] private WorkDaysSelector workDaysSelector;
        [SerializeField] DaySchedule currentDay;
        [SerializeField] DisciplineBase currentLesson;
        public DaySchedule CurrentDay => currentDay;
        public DisciplineBase CurrentLesson => currentLesson;
        private void Awake()
        {
            experimentLengthSlider.ValueChangedEvent.AddListener(OnExperimentLengthChangedCallback);
            breaksLengthSlider.ValueChangedEvent.AddListener(OnBreaksLengthChangedCallback);
            //workDaysSelector.DaySelectionChangedEvent += OnDaySelectionChangedCallback;
        }

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

        public void CreateSchedule()
        {
            workDays.Clear();
            workDays.AddRange(workDaysSelector.GetWorkDays());
            foreach (var day in WorkDays)
                day.CreateSchedule();
        }

        private void OnExperimentLengthChangedCallback(int newVal)
        {
            experimentLength = newVal;
        }

        public void SetCurrentDayAndLesson()
        {
            currentDay = WorkDays[0];
            currentLesson = CurrentDay.CurrentLesson = CurrentDay.Lessons[0];
        }

        public int BreaksLength => breaksLength;
        public int ExperimentLength => experimentLength;
        public List<DaySchedule> WorkDays => workDays;
        public WorkDaysSelector WorkDaysSelector => workDaysSelector;
    }
}