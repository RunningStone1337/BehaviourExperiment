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
        [SerializeField] AgentsPlacerParams placerParams;
        [SerializeField] protected GameObject pupilPrefab;
        [SerializeField] protected GameObject teacherPrefab;

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

        internal IEnumerator SpawnAgent<T, TData>(TData agentData, bool startOnSpawn)
              where T : SchoolAgentBase<T>
              where TData : HumanRawData
        {

            T agent;
            var placer = new PlaceFinder(placerParams);
            while (!placer.TryFindPlace())
                yield return new WaitForFixedUpdate();

            agent = CreateAgent<T>(agentData, placer.Place);
            GlobalEventsHandler.Instance.OnGlobalEventChanged.AddListener(((SchoolObservationsSystem<T>)agent.ObservationsSystem).EventsSensor.OnGlobalEventChangedCallback);
            LastCreatedAgents.Add(agent);
            if (startOnSpawn)
                agent.StartStateMachine();
        }

        internal IEnumerator SpawnAgents<T, TData>(List<TData> agentsData, bool startOnSpawn)
              where T : SchoolAgentBase<T>
              where TData : HumanRawData
        {
            for (int i = 0; i < agentsData.Count; i++)
                yield return SpawnAgent<T,TData>(agentsData[i], startOnSpawn);
        }
    }
}