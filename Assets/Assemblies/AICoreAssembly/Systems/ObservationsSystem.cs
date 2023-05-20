using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BehaviourModel
{
    public class ObservationsSystem<TAgent, TSensor> : 
        SystemBase<TAgent>,
        ISensor
        where TAgent :  IAgent
        where TSensor : ISensor
    {
        [Tooltip("If manual - you need to call \"CreatePhenomenons\" manually, else Brain will do it automatically by timer.")]
        [SerializeField] ActionsMode observationsCollectingMode;
        [Space]
        [Tooltip("Interval of collectiong observations in scalled seconds.")]
        [SerializeField] [Range(0f,256f)] float observationsCollectingInterval;
        [Space]
        [Tooltip("Seed of collecting interval for some randomizing in scalled seconds." +
            " Value is random between negative and positive. Cant be more then observationsCollectingInterval")]
        [SerializeField] [Range(0f,256f)] float observationsCollectingIntervalSeed;
        [Space]
        [Tooltip("Sensors that your implementation use for collecting observations.")]
        [SerializeField] private List<TSensor> sensors;
        /// <summary>
        /// Sensors that your implementation use for collecting observations.
        /// </summary>
        public List<TSensor> Sensors => sensors;
        public ActionsMode CollectMode { get => observationsCollectingMode; set => observationsCollectingMode = value; }
        public float ObservationsCollectingInterval { get => observationsCollectingInterval;
            set => observationsCollectingInterval = value; }
        public float ObservationsCollectingIntervalSeed { get => observationsCollectingIntervalSeed;
            set => observationsCollectingIntervalSeed = Mathf.Clamp(value,0, observationsCollectingInterval); }

        public List<IPhenomenon> CollectObservations()
        {
            List<IPhenomenon> res = new List<IPhenomenon>();
            foreach (var s in sensors)
            {
                res.AddRange(s.CollectObservations());
            }
            return res;
        }

        internal IEnumerator CollectingDelay()
        {
            var time = ObservationsCollectingInterval
                           + Random.Range(-ObservationsCollectingIntervalSeed,
                           ObservationsCollectingIntervalSeed);
            yield return new WaitForSeconds(time);
        }
    }
}