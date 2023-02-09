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
        #region fields
        [SerializeField] protected SelectedAgentsHandler agentsHandler;
        [SerializeField] protected ScheduleHandler schedule;
        [SerializeField] protected List<PupilAgent> experimenAgents;
        [SerializeField] protected TeacherAgent teacher;
        [SerializeField] protected GameObject teacherPrefab;
        [SerializeField] protected GameObject pupilPrefab;
        #endregion
        private T CreateAgent<T>(HumanRawData pup, GameObject prefab)
            where T : SchoolAgentBase
        {
            var placingRooms = EntranceRoot.Root.Rooms.Where(x => x.Role is ExitRole).ToList();
            var placingPoints = placingRooms[Random.Range(0, placingRooms.Count)];
            var pupGO = Instantiate(prefab, placingPoints.RandomEntrance().transform, true).GetComponent<T>();
            pupGO.Initiate(pup, this);
            return pupGO;
        }

        private void CreateAgents()
        {
            SchoolAgentBase agent;
            foreach (var pup in agentsHandler.Agents)
            {
                agent = CreateAgent<PupilAgent>(pup, pupilPrefab);
                experimenAgents.Add((PupilAgent)agent);
            }
            teacher = CreateAgent<TeacherAgent>(agentsHandler.Teacher, teacherPrefab);
            //experimenAgents.Add(teacher);
        }

        private void InitGlobalSystems()
        {
            schedule.CreateSchedule();
            schedule.SetCurrentDayAndLesson();
            breakEvent.Initiate(schedule);
            lessonEvent.Initiate(schedule);
            currentEvent = lessonEvent;
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

        private void StartAgents()
        {
            foreach (var ag in experimenAgents)
                ag.StartStateMachine();
            teacher.StartStateMachine();
        }

        private void InitStartStates()
        {
            Teacher.MovementTarget = InterierHandler.Handler.Boards[0];
            Teacher.SetState<MoveToTargetState>();
            foreach (var ag in experimenAgents)
                ag.SetState<FindFreeChairState>();
        }
    }
}