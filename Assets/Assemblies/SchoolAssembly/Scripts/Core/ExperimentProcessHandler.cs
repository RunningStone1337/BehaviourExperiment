using BehaviourModel;
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

            yield return spawner.SpawnAgent<TeacherAgent, TeacherRawData>(agentsHandler.TeacherData, true);
            teacher = (TeacherAgent)spawner.LastCreatedAgents[0];
            spawner.LastCreatedAgents.Clear();
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

        public void OnDayStartedCallback(CurrentDayChangedEventArgs args)
        {
            if (args.dayIndex == 0)
                StartCoroutine(CreateAgents());
            else
            {
                //вернуть скрытых агентов на сцену
                StartCoroutine(PlaceExistAgents());
            }
        }

        private IEnumerator PlaceExistAgents()
        {
            var placer = new PlaceFinder(placerParams);
            foreach (var pup in Pupils)
            {
                while (!placer.TryFindPlace())
                    yield return null;
                pup.transform.position = placer.Place;
                pup.StartStateMachine();
            }

            while (!placer.TryFindPlace())
                yield return null;
            Teacher.transform.position = placer.Place;
            Teacher.StartStateMachine();
        }       
    }
}