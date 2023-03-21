using BehaviourModel;
using BuildingModule;
using Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UI;
using UnityEngine;

namespace Core
{
    public class ExperimentProcessHandler : EnvironmentInfoSource
    {

        #region fields
        [SerializeField] AgentsPlacerParams placerParams;
        [SerializeField] protected SelectedAgentsHandler agentsHandler;
        [SerializeField] private AgentsSpawner spawner;
        [SerializeField] protected ScheduleHandler schedule;
        [SerializeField] private AstarPath pathFinder;
        [SerializeField] protected List<PupilAgent> experimentAgents;
        [SerializeField] protected TeacherAgent teacher;
        public List<PupilAgent> Pupils => experimentAgents;
        public TeacherAgent Teacher => teacher;
        #endregion fields

        private IEnumerator CreateAgents()
        {
            yield return spawner.SpawnAgents<PupilAgent, PupilRawData>(agentsHandler.AgentsData, true);
            experimentAgents.AddRange(spawner.LastCreatedAgents.Cast<PupilAgent>());
            spawner.LastCreatedAgents.Clear();
            Debug.Log($"LastCreatedAgents count after clearing: {spawner.LastCreatedAgents.Count}");

            yield return spawner.SpawnAgent<TeacherAgent, TeacherRawData>(agentsHandler.TeacherData, true);
            teacher = (TeacherAgent)spawner.LastCreatedAgents[0];
            spawner.LastCreatedAgents.Clear();
            Debug.Log($"LastCreatedAgents count after clearing: {spawner.LastCreatedAgents.Count}");
            StartAgents();
        }

        private void InitGlobalSystems()
        {
            schedule.CreateSchedule();
            schedule.StartSchedule();
        }
        

        private void StartAgents()
        {
            foreach (var ag in experimentAgents)
            {
                if (!ag.IsActing)
                    ag.StartStateMachine();
            }
            if (!teacher.IsActing)
                teacher.StartStateMachine();
        }

      

        [ContextMenu("Start experiment")]
        public void StartExperiment()
        {
            pathFinder.Scan();
            CanvasController.Controller.CurrentState = CanvasController.Controller.ExperimentProcessScreen;
            InitGlobalSystems();
        }      

        public void OnScheduleCompletedCallback()
        {
            Debug.Log("Experiment ended");
            //показ статистики
        }
        public void OnDayStartedCallback(CurrentDayChangedEventArgs args)
        {
            if (args.newDay.DayIndex == 1)
                StartCoroutine(CreateAgents());
            else
            {
                //GlobalEventsHandler.Instance.CurrentGlobalEvent = GlobalEventsHandler.Instance.LessonEvent;
                //вернуть скрытых агентов на сцену
                StartCoroutine(PlaceExistAgents());
            }
        }

        private IEnumerator PlaceExistAgents()
        {
            var placer = new PlaceFinder(() => {
                var placingRooms = EntranceRoot.Root.Rooms.Where(x => x.Role is ExitRole).ToList();
                return placingRooms.GetRandom().RandomEntrance().transform.position;
            }, placerParams);

            foreach (var pup in Pupils)
            {
                while (!placer.TryFindPlace())
                    yield return new WaitForFixedUpdate();
                pup.transform.position = placer.Place;
                pup.StartStateMachine();
                pup.StartAppearing();
                yield return new WaitForSeconds(.05f);
            }

            while (!placer.TryFindPlace())
                yield return new WaitForFixedUpdate();
            Teacher.transform.position = placer.Place;
            Teacher.StartStateMachine();
            Teacher.StartAppearing();
        }       
    }
}