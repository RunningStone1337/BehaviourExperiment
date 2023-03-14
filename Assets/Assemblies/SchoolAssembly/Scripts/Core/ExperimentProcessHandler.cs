using BehaviourModel;
using Events;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Pathfinding;

namespace Core
{
    public class ExperimentProcessHandler : EnvironmentInfoSource
    {

        #region fields
        [SerializeField] private AgentsSpawner spawner;
        [SerializeField] protected SelectedAgentsHandler agentsHandler;
        [SerializeField] protected List<PupilAgent> experimentAgents;
        [SerializeField] protected TeacherAgent teacher;
        [SerializeField] protected ScheduleHandler schedule;
        [SerializeField] AstarPath pathFinder;

        #endregion fields

        private IEnumerator CreateAgents()
        {
            yield return spawner.SpawnAgents<PupilAgent, PupilRawData>(agentsHandler.Agents, this);
            experimentAgents.AddRange(spawner.LastCreatedAgents.Cast<PupilAgent>());
            spawner.LastCreatedAgents.Clear();
            yield return spawner.SpawnAgent<TeacherAgent, TeacherRawData>(agentsHandler.Teacher, this);
            teacher = (TeacherAgent)spawner.LastCreatedAgents[0];
            spawner.LastCreatedAgents.Clear();
        }        

        private void InitGlobalSystems()
        {
            schedule.CreateSchedule();
            schedule.SetDefaultCurrentDayAndLesson();
            breakEvent.Initiate(schedule);
            lessonEvent.Initiate(schedule);
        }

        //private void InitStartStates()
        //{
        //    Teacher.MovementTarget = InterierHandler.Handler.Boards[0];
        //    Teacher.SetState<IdleTeacherState>();
        //    //Teacher.SetState<MoveToTargetState<TeacherAgent>>();
        //    foreach (var ag in experimenAgents)
        //        ag.SetState<PupilChooseActionState>();
        //        //ag.SetState<FindFreeChairState<PupilAgent>>();
        //}

        private void StartAgents()
        {
            foreach (var ag in experimentAgents)
                ag.StartStateMachine();
            teacher.StartStateMachine();
        }

        public override GlobalEvent CurrentGlobalEvent
        {
            get => currentEvent;
            protected set
            {
                currentEvent = value;
                RaiseOnGlobalEventChanged(value);
            }
        }

       

        public TeacherAgent Teacher { get => teacher; private set => teacher = value; }

        [ContextMenu("Start experiment")]
        public void StartExperiment()
        {
            StartCoroutine(ExperimentRoutine());
        }

        private IEnumerator ExperimentRoutine()
        {
            InitGlobalSystems();
            pathFinder.Scan();
            yield return CreateAgents();
            //InitStartStates();
            CurrentGlobalEvent = lessonEvent;
            StartAgents();
        }
    }
}