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
        public T CreateAgent<T>(HumanRawData pupData, Vector3 spawnPoint)
           where T : SchoolAgentBase<T>
        {
            GameObject prefab;
            if (typeof(T).IsEquivalentTo(typeof(PupilAgent)))
                prefab = pupilPrefab;
            else
                prefab = teacherPrefab;
            var agent = Instantiate(prefab, spawnPoint, Quaternion.identity).GetComponent<T>();

            agent.Initiate<
            LowAnxiety,  MiddleAnxiety,  HighAnxiety,
            LowClosenessSociability,  MiddleClosenessSociability,  HighClosenessSociability,
            LowEmotionalStability,  MiddleEmotionalStability,  HighEmotionalStability,
            LowNonconformism,  MiddleNonconformism,  HighNonconformism,
            LowNormativityOfBehaviour,  MiddleNormativityOfBehaviour,  HighNormativityOfBehaviour,
            LowRadicalism,  MiddleRadicalism,  HighRadicalism,
            LowSelfcontrol,  MiddleSelfcontrol,  HighSelfcontrol,
            LowSensetivity,  MiddleSensetivity,  HighSensetivity,
            LowSuspicion,  MiddleSuspicion,  HighSuspicion,
            LowTension,  MiddleTension,  HighTension,
            LowExpressiveness,  MiddleExpressiveness,  HighExpressiveness,
            LowIntelligence,  MiddleIntelligence,  HighIntelligence,
            LowDreaminess,  MiddleDreaminess,  HighDreaminess,
            LowDomination,  MiddleDomination,  HighDomination,
            LowDiplomacy,  MiddleDiplomacy,  HighDiplomacy,
            LowCourage,  MiddleCourage,  HighCourage>(pupData);
            
            return agent;
        }

        internal IEnumerator SpawnAgent<TAgent, TData>(TData agentData, bool startOnSpawn)
              where TAgent : SchoolAgentBase<TAgent>
              where TData : HumanRawData
        {
            TAgent agent;
            var placer = new PlaceFinder(()=> {
                var placingRooms = EntranceRoot.Root.Rooms.Where(x => x.Role is ExitRole).ToList();
                return placingRooms.GetRandom().RandomEntrance().transform.position;
            }, placerParams);
            while (!placer.TryFindPlace())
                yield return new WaitForFixedUpdate();

            agent = CreateAgent<TAgent>(agentData, placer.Place);
            GlobalEventsHandler.Instance.OnGlobalEventChanged.AddListener(((SchoolObservationsSystem<TAgent>)agent.ObservationsSystem).EventsSensor.OnGlobalEventChangedCallback);
            //GlobalEventsHandler.Instance.OnGlobalEventChanged.AddListener(agent.OnGlobalEventChangedCallback);
            LastCreatedAgents.Add(agent);
            if (startOnSpawn)
                agent.StartStateMachine();
        }

        internal IEnumerator SpawnAgents<T, TData>(List<TData> agentsData, bool startOnSpawn)
              where T : SchoolAgentBase<T>
              where TData : HumanRawData
        {
            Debug.Log($"Agents to spawn: {agentsData.Count}");
            for (int i = 0; i < agentsData.Count; i++)
            {
                yield return SpawnAgent<T, TData>(agentsData[i], startOnSpawn);
                Debug.Log($"Agent spawned: {i+1}");
            }
            Debug.Log($"Agents created count after spawn: {LastCreatedAgents.Count}");
        }
    }
}