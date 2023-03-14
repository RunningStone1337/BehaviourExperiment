using BehaviourModel;
using BuildingModule;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core
{
    public class AgentsSpawner : MonoBehaviour
    {
        [SerializeField] protected GameObject pupilPrefab;
        [SerializeField] protected GameObject teacherPrefab;
        [SerializeField] float overlapRadius;
        [SerializeField] float spawnRadius;
        [SerializeField] ContactFilter2D spawnContactFilter;

        public List<IAgent> LastCreatedAgents { get; private set; }
        private void Start()
        {
            LastCreatedAgents = new List<IAgent>();
        }
        public T CreateAgent<T>(HumanRawData pup, Vector3 spawnPoint)
           where T : SchoolAgentBase<T>
        {
            GameObject prefab;
            if (typeof(T).IsEquivalentTo(typeof(PupilAgent)))
                prefab = pupilPrefab;
            else
                prefab = teacherPrefab;
            var pupGO = Instantiate(prefab, spawnPoint, Quaternion.identity).GetComponent<T>();
            if (pupGO is PupilAgent p)
            {
                p.Initiate<
            PupilLowAnxiety, PupilMiddleAnxiety, PupilHighAnxiety,
            PupilLowClosenessSociability, PupilMiddleClosenessSociability, PupilHighClosenessSociability,
            PupilLowEmotionalStability, PupilMiddleEmotionalStability, PupilHighEmotionalStability,
            PupilLowNonconformism, PupilMiddleNonconformism, PupilHighNonconformism,
            PupilLowNormativityOfBehaviour, PupilMiddleNormativityOfBehaviour, PupilHighNormativityOfBehaviour,
            PupilLowRadicalism, PupilMiddleRadicalism, PupilHighRadicalism,
            PupilLowSelfcontrol, PupilMiddleSelfcontrol, PupilHighSelfcontrol,
            PupilLowSensetivity, PupilMiddleSensetivity, PupilHighSensetivity,
            PupilLowSuspicion, PupilMiddleSuspicion, PupilHighSuspicion,
            PupilLowTension, PupilMiddleTension, PupilHighTension,
            PupilLowExpressiveness, PupilMiddleExpressiveness, PupilHighExpressiveness,
            PupilLowIntelligence, PupilMiddleIntelligence, PupilHighIntelligence,
            PupilLowDreaminess, PupilMiddleDreaminess, PupilHighDreaminess,
            PupilLowDomination, PupilMiddleDomination, PupilHighDomination,
            PupilLowDiplomacy, PupilMiddleDiplomacy, PupilHighDiplomacy,
            PupilLowCourage, PupilMiddleCourage, PupilHighCourage>(pup);
            }
            else if (pupGO is TeacherAgent t)
            {
                t.Initiate<
           TeacherLowAnxiety, TeacherMiddleAnxiety, TeacherHighAnxiety,
           TeacherLowClosenessSociability, TeacherMiddleClosenessSociability, TeacherHighClosenessSociability,
           TeacherLowEmotionalStability, TeacherMiddleEmotionalStability, TeacherHighEmotionalStability,
           TeacherLowNonconformism, TeacherMiddleNonconformism, TeacherHighNonconformism,
           TeacherLowNormativityOfBehaviour, TeacherMiddleNormativityOfBehaviour, TeacherHighNormativityOfBehaviour,
           TeacherLowRadicalism, TeacherMiddleRadicalism, TeacherHighRadicalism,
           TeacherLowSelfcontrol, TeacherMiddleSelfcontrol, TeacherHighSelfcontrol,
           TeacherLowSensetivity, TeacherMiddleSensetivity, TeacherHighSensetivity,
           TeacherLowSuspicion, TeacherMiddleSuspicion, TeacherHighSuspicion,
           TeacherLowTension, TeacherMiddleTension, TeacherHighTension,
           TeacherLowExpressiveness, TeacherMiddleExpressiveness, TeacherHighExpressiveness,
           TeacherLowIntelligence, TeacherMiddleIntelligence, TeacherHighIntelligence,
           TeacherLowDreaminess, TeacherMiddleDreaminess, TeacherHighDreaminess,
           TeacherLowDomination, TeacherMiddleDomination, TeacherHighDomination,
           TeacherLowDiplomacy, TeacherMiddleDiplomacy, TeacherHighDiplomacy,
           TeacherLowCourage, TeacherMiddleCourage, TeacherHighCourage>(pup);
            }
            return pupGO;
        }

        internal IEnumerator SpawnAgent<T, TData>(TData  agentData, EnvironmentInfoSource envInfo)
              where T : SchoolAgentBase<T>
              where TData : HumanRawData
        {
            var placingRooms = EntranceRoot.Root.Rooms.Where(x => x.Role is ExitRole).ToList();
            var isPlaced = false;
            Vector3 startPoint= placingRooms.GetRandom().RandomEntrance().transform.position;
            Vector3 tempPoint = startPoint;
            T agent;
            int counter = 0;
            List<Collider2D> results = new List<Collider2D>();
            while (!isPlaced)
            {
                if (counter == 10)
                {
                    counter = 0;
                    startPoint = placingRooms.GetRandom().RandomEntrance().transform.position;
                    yield return new WaitForFixedUpdate();
                }
                    //есть пересечения
                if (Physics2D.OverlapCircle(tempPoint, overlapRadius, spawnContactFilter, results) > 0)
                {
                    tempPoint = startPoint+(Vector3)(UnityEngine.Random.insideUnitCircle * spawnRadius);
                    counter++;
                }
                else//нет
                {
                    agent = CreateAgent<T>(agentData, tempPoint);
                    envInfo.OnGlobalEventChanged += ((SchoolObservationsSystem<T>)agent.ObservationsSystem).EventsSensor.OnGlobalEventChangedCallback;
                    LastCreatedAgents.Add(agent);
                    isPlaced = true;
                }
            }
        }

        internal IEnumerator SpawnAgents<T, TData>(List<TData> agentsData, EnvironmentInfoSource envInfo)
              where T : SchoolAgentBase<T>
              where TData : HumanRawData
        {
            foreach (var pup in agentsData)
                yield return SpawnAgent<T,TData>(pup, envInfo);
        }
    }
}