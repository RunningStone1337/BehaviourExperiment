using System.Collections;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class AgentBase<TAgent, TAction, TFeature, TSensor> : MonoBehaviour, IAgent
        where TAgent : IAgent
        where TAction : IAction
        where TFeature : IFeature
        where TSensor : ISensor
    {
        [Header("Systems")]
        #region systems

        [SerializeField] private BrainSystem<TAgent, TAction> brain;
        [SerializeField] private CharacterSystem<TAgent> characterSystem;
        [SerializeField] private FeaturesSystem<TAgent, TFeature> featuresSystem;
        [SerializeField] private ObservationsSystem<TAgent, TSensor> observationsSystem;
        [SerializeField] private RelationsSystem<TAgent> relationsSystem;
        [SerializeField] private ActionsExecutorSystem<TAgent, TAction> executorSystem;
        public BrainSystem<TAgent, TAction> Brain { get => brain; protected set => brain = value; }
        public CharacterSystem<TAgent> CharacterSystem { get => characterSystem; protected set => characterSystem = value; }
        public FeaturesSystem<TAgent, TFeature> FeaturesSystem { get => featuresSystem; protected set => featuresSystem = value; }
        public ObservationsSystem<TAgent, TSensor> ObservationsSystem { get => observationsSystem; protected set => observationsSystem = value; }
        public RelationsSystem<TAgent> RelationsSystem { get => relationsSystem; protected set => relationsSystem = value; }
        public ActionsExecutorSystem<TAgent, TAction> Executor { get => executorSystem; protected set => executorSystem = value; }

        #endregion systems
        [Space]
        #region fields

        [Tooltip("If true, the agent will collect observations after calling StartStateMachine, otherwise not." +
            " You can safely switch this flag during the main process to temporarily disable the monitoring functionality.")]
        [SerializeField] protected bool collectObservations = true;

        [SerializeField] [HideInInspector] private bool isActing;
        [Tooltip("If true, the agent will make decisions and control behavior after calling StartStateMachine, otherwise not." +
            " You can safely switch this flag during the main process to temporarily disable the agent behavior.")]
        [SerializeField] protected bool autoMakeActions = true;
        public bool AutoMakeActions { get => autoMakeActions; 
            set => autoMakeActions = value; }
        
        #endregion


        /// <summary>
        /// Observations handling routine.
        /// </summary>
        /// <returns></returns>
        protected virtual IEnumerator ObservationsRoutine()
        {
            Brain.Clear();
            while (IsActing)
            {
                if (CollectObservations)
                {
                    if (observationsSystem.CollectMode == ActionsMode.ByInterval)
                    {
                        var observations = observationsSystem.CollectObservations();
                        yield return Brain.HandleNewPhenomenons(observations);
                        yield return observationsSystem.CollectingDelay();
                    }
                    else
                        yield return new WaitForFixedUpdate();
                }
                else
                    yield return new WaitForFixedUpdate();
                //Debug.Log($"Observations collected, count {Brain.PhenomensToReact.Count}");
            }
        }

        /// <summary>
        /// Actions realizing routine.
        /// </summary>
        /// <returns></returns>
        private IEnumerator AgentActingRoutine()
        {
            while (IsActing)
            {
                if (autoMakeActions)
                    yield return executorSystem.ExecutePossible(Brain);
                else
                    yield return executorSystem.ExecureManuallySetted();
            }
        }

        public bool CollectObservations { get => collectObservations; set => collectObservations = value; }
        /// <summary>
        /// If true, agent is running
        /// </summary>
        public bool IsActing { get => isActing; private set => isActing = value; }
        public Coroutine ObservationsCoroutine { get; private set; }
        public Coroutine AgentActingCoroutine { get; private set; }

        public void BreakCurrentActing()
        {
            StopCoroutine(AgentActingCoroutine);
            AgentActingCoroutine = StartCoroutine(AgentActingRoutine());
        }

        public void StartActing()
        {
            IsActing = true;  
            //if (characterSystem == null)
            //    Awake();
            ObservationsCoroutine = StartCoroutine(ObservationsRoutine());
            AgentActingCoroutine = StartCoroutine(AgentActingRoutine());
        }

        public void StopActing()
        {
            IsActing = false;
            StopCoroutine(AgentActingCoroutine);
            StopCoroutine(ObservationsCoroutine);
        }

        protected virtual void Awake()
        {
            brain = GetComponent<BrainSystem<TAgent,TAction>>();
            characterSystem = GetComponent<CharacterSystem<TAgent>>();
            featuresSystem = GetComponent<FeaturesSystem<TAgent, TFeature>>();
            observationsSystem = GetComponent<ObservationsSystem<TAgent, TSensor>>();
            relationsSystem = GetComponent<RelationsSystem<TAgent>>();
            executorSystem = GetComponent<ActionsExecutorSystem<TAgent, TAction>>();
        }
    }
}