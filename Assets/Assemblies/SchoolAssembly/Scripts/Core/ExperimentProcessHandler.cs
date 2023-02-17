using BehaviourModel;
using BuildingModule;
using Events;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core
{
    public class ExperimentProcessHandler : EnvironmentInfoSource
    {
        public class CurrentEventChangedEventArgs
        {
          public GlobalEvent newEvent;
        }
        public delegate void CurrentEventChangedDelegate(CurrentEventChangedEventArgs args);
        public event CurrentEventChangedDelegate OnGlobalEventChanged;
        #region fields

        [SerializeField] private AgentsSpawner spawner;
        [SerializeField] protected SelectedAgentsHandler agentsHandler;
        [SerializeField] protected List<PupilAgent> experimenAgents;
        [SerializeField] protected ScheduleHandler schedule;
        [SerializeField] protected TeacherAgent teacher;

        #endregion fields

        private void CreateAgents()
        {
            var placingRooms = EntranceRoot.Root.Rooms.Where(x => x.Role is ExitRole).ToList();
            PupilAgent agent;
            foreach (var pup in agentsHandler.Agents)
            {
                var placingPoints = placingRooms[Random.Range(0, placingRooms.Count)];
                agent = spawner.CreateAgent<PupilAgent>(pup, placingPoints.RandomEntrance().transform);
                OnGlobalEventChanged += agent.OnGlobalEventChangedCallback;
                experimenAgents.Add(agent);
            }
            var pp = placingRooms[Random.Range(0, placingRooms.Count)];
            teacher = spawner.CreateAgent<TeacherAgent>(agentsHandler.Teacher, pp.RandomEntrance().transform);
            OnGlobalEventChanged += teacher.OnGlobalEventChangedCallback;
        }

        private void InitGlobalSystems()
        {
            schedule.CreateSchedule();
            schedule.SetDefaultCurrentDayAndLesson();
            breakEvent.Initiate(schedule);
            lessonEvent.Initiate(schedule);
            currentEvent = lessonEvent;
        }

        private void InitStartStates()
        {
            Teacher.MovementTarget = InterierHandler.Handler.Boards[0];
            Teacher.SetState<MoveToTargetState<TeacherAgent>>();
            foreach (var ag in experimenAgents)
                ag.SetState<FindFreeChairState<PupilAgent>>();
        }

        private void StartAgents()
        {
            foreach (var ag in experimenAgents)
                ag.StartStateMachine();
            teacher.StartStateMachine();
        }

        public override GlobalEvent CurrentGlobalEvent => currentEvent;
        public TeacherAgent Teacher { get => teacher; private set => teacher = value; }
        public override List<TemporaryEffect> TemporaryEffects { get => temporaryEffects; }

        [ContextMenu("Start experiment")]
        public void StartExperiment()
        {
            InitGlobalSystems();
            CreateAgents();
            InitStartStates();
            StartAgents();
        }
    }
}