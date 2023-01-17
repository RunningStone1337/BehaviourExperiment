using BehaviourModel;
using BuildingModule;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core
{
    public class ExperimentProcessHandler : MonoBehaviour
    {
        #region events

        [SerializeField] private BreakEvent breakEvent;
        [SerializeField] private GlobalEvent currentEvent;
        [SerializeField] private LessonEvent lessonEvent;

        #endregion events

        [SerializeField] private SelectedAgentsHandler agentsHandler;
        [SerializeField] private GameObject pupilPrefab;
        [SerializeField] private ScheduleHandler schedule;
        [SerializeField] private GameObject teacherPrefab;
        [SerializeField] List<TemporaryEffect> temporaryEffects;
        public GlobalEvent CurrentGlobalEvent => currentEvent;

        public List<TemporaryEffect> TemporaryEffects { get=> temporaryEffects;  }

        private T CreateAgent<T>(HumanRawData pup, GameObject prefab) where T : AgentBase
        {
            var placingRooms = EntranceRoot.Root.Rooms.Where(x => x.Role is ExitRole).ToList();
            var placingPoints = placingRooms[Random.Range(0, placingRooms.Count)];
            var pupGO = Instantiate(prefab, placingPoints.RandomEntrance().transform).GetComponent<T>();
            pupGO.Initiate(pup);
            return pupGO;
        }

        public void StartExperiment()
        {
            InitGlobalSystems();
            //создать GO агентов
            AgentBase agent;
            foreach (var pup in agentsHandler.Agents)
            {
                agent = CreateAgent<PupilAgent>(pup, pupilPrefab);
                agent.StartActing(this);
            }
            agent = CreateAgent<TeacherAgent>(agentsHandler.Teacher, teacherPrefab);
            agent.StartActing(this);
        }

        private void InitGlobalSystems()
        {
            breakEvent.Initiate(schedule);
            lessonEvent.Initiate(schedule);
            currentEvent = lessonEvent;
        }
    }
}