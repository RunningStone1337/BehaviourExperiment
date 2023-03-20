using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class AgentBase<TAgent, TReaction, TFeature, TState, TSensor> : SerializedMonoBehaviour, IAgent,
        ICurrentStateHandler<TState>
        where TAgent : ICurrentStateHandler<TState>, IAgent
        where TReaction : IReaction
        where TFeature : IFeature
        where TState : IState
        where TSensor : ISensor
    {
        [Header("Systems")]
        #region systems

        [SerializeField] private BrainBase<TAgent, TReaction, TFeature, TState, TSensor> brain;
        [SerializeField] private CharacterSystem<TAgent, TReaction, TFeature, TState, TSensor> characterSystem;
        [SerializeField] private FeaturesSystem<TAgent, TReaction, TFeature, TState, TSensor> featuresSystem;
        [SerializeField] private ObservationsSystem<TAgent, TReaction, TFeature, TState, TSensor> observationsSystem;
        [SerializeField] private RelationsSystem<TAgent, TReaction, TFeature, TState, TSensor> relationsSystem;
        public BrainBase<TAgent, TReaction, TFeature, TState, TSensor> Brain { get => brain; protected set => brain = value; }
        public CharacterSystem<TAgent, TReaction, TFeature, TState, TSensor> CharacterSystem { get => characterSystem; protected set => characterSystem = value; }
        public FeaturesSystem<TAgent, TReaction, TFeature, TState, TSensor> FeaturesSystem { get => featuresSystem; protected set => featuresSystem = value; }
        public ObservationsSystem<TAgent, TReaction, TFeature, TState, TSensor> ObservationsSystem => observationsSystem;
        public RelationsSystem<TAgent, TReaction, TFeature, TState, TSensor> RelationsSystem => relationsSystem;

        #endregion systems
        [Space]
        #region fields
        [SerializeField] protected TState currentState;

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

        protected virtual void Awake()
        {
            //observationsSystem = GetComponent<ObservationsSystem<TAgent, TReaction, TFeature, TState, TSensor>>();
        }

        /// <summary>
        /// Observations handling routine.
        /// </summary>
        /// <returns></returns>
        private IEnumerator ObservationsRoutine()
        {
            Brain.Clear();
            while (IsActing)
            {
                if (CollectObservations)
                {
                    if (observationsSystem.CollectMode == ActionsMode.ByInterval)
                    {
                        var observationSources = observationsSystem.CreatePhenomenons();
                        yield return Brain.ProceedPhenomenons(observationSources);
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
        public abstract void SetDefaultState();

        /// <summary>
        /// Actions realizing routine.
        /// </summary>
        /// <returns></returns>
        private IEnumerator AgentActingRoutine()
        {
            while (IsActing)
            {
                if (autoMakeActions)
                {
                    yield return Brain.TryReactAtSomePhenom();
                }
                else
                {
                    yield return Brain.ManuallySettedAction();
                }
            }
        }

        public bool CollectObservations { get => collectObservations; set => collectObservations = value; }
        public TState CurrentState { get => currentState; set => currentState = value; }
        /// <summary>
        /// If true, state machine is running
        /// </summary>
        public bool IsActing { get => isActing; private set => isActing = value; }
        public Coroutine ObservationsCoroutine { get; private set; }
        public Coroutine AgentActingCoroutine { get; private set; }

        public virtual void Initiate<
            TLowAnx, TMidAnx, THighAnx,
            TLowSoc, TMidSoc, THighSoc,
            TLowStab, TMidStab, THighStab,
            TLowNonc, TMidNonc, THighNonc,
            TLowNorm, TMidNorm, THighNorm,
            TLowRad, TMidRad, THighRad,
            TLowSelf, TMidSelf, THighSelf,
            TLowSens, TMidSens, THighSens,
            TLowSusp, TMidSusp, THighSusp,
            TLowTens, TMidTens, THighTens,
            TLowExpre, TMidExpre, THighExpre,
            TLowInt, TMidInt, THighInt,
            TLowDrea, TMidDrea, THighDrea,
            TLowDom, TMidDom, THighDom,
            TLowDipl, TMidDipl, THighDipl,
            TLowCour, TMidCour, THighCour
            >(IAgentInitData<TFeature> data)
             where TLowAnx : LowAnxiety
            where TMidAnx : MiddleAnxiety
            where THighAnx : HighAnxiety

            where TLowSoc : LowClosenessSociability
            where TMidSoc : MiddleClosenessSociability
            where THighSoc : HighClosenessSociability

            where TLowStab : LowEmotionalStability
            where TMidStab : MiddleEmotionalStability
            where THighStab : HighEmotionalStability

            where TLowNonc : LowNonconformism
            where TMidNonc : MiddleNonconformism
            where THighNonc : HighNonconformism

            where TLowNorm : LowNormativityOfBehaviour
            where TMidNorm : MiddleNormativityOfBehaviour
            where THighNorm : HighNormativityOfBehaviour

            where TLowRad : LowRadicalism
            where TMidRad : MiddleRadicalism
            where THighRad : HighRadicalism

            where TLowSelf : LowSelfcontrol
            where TMidSelf : MiddleSelfcontrol
            where THighSelf : HighSelfcontrol

            where TLowSens : LowSensetivity
            where TMidSens : MiddleSensetivity
            where THighSens : HighSensetivity

            where TLowSusp : LowSuspicion
            where TMidSusp : MiddleSuspicion
            where THighSusp : HighSuspicion

            where TLowTens : LowTension
            where TMidTens : MiddleTension
            where THighTens : HighTension

            where TLowExpre : LowExpressiveness
            where TMidExpre : MiddleExpressiveness
            where THighExpre : HighExpressiveness

            where TLowInt : LowIntelligence
            where TMidInt : MiddleIntelligence
            where THighInt : HighIntelligence

            where TLowDrea : LowDreaminess
            where TMidDrea : MiddleDreaminess
            where THighDrea : HighDreaminess

            where TLowDom : LowDomination
            where TMidDom : MiddleDomination
            where THighDom : HighDomination

            where TLowDipl : LowDiplomacy
            where TMidDipl : MiddleDiplomacy
            where THighDipl : HighDiplomacy

            where TLowCour : LowCourage
            where TMidCour : MiddleCourage
            where THighCour : HighCourage

        {
            CharacterSystem.Initiate<
            TLowAnx, TMidAnx, THighAnx,
            TLowSoc, TMidSoc, THighSoc,
            TLowStab, TMidStab, THighStab,
            TLowNonc, TMidNonc, THighNonc,
            TLowNorm, TMidNorm, THighNorm,
            TLowRad, TMidRad, THighRad,
            TLowSelf, TMidSelf, THighSelf,
            TLowSens, TMidSens, THighSens,
            TLowSusp, TMidSusp, THighSusp,
            TLowTens, TMidTens, THighTens,
            TLowExpre, TMidExpre, THighExpre,
            TLowInt, TMidInt, THighInt,
            TLowDrea, TMidDrea, THighDrea,
            TLowDom, TMidDom, THighDom,
            TLowDipl, TMidDipl, THighDipl,
            TLowCour, TMidCour, THighCour
            >(data);
            FeaturesSystem.Initiate(data);
        }
        public void BreakCurrentActing()
        {
            StopCoroutine(AgentActingCoroutine);
            AgentActingCoroutine = StartCoroutine(AgentActingRoutine());
        }

        public void StartStateMachine()
        {
            IsActing = true;            
            ObservationsCoroutine = StartCoroutine(ObservationsRoutine());
            AgentActingCoroutine = StartCoroutine(AgentActingRoutine());
        }

        public void StopStateMachine()
        {
            IsActing = false;
            //Brain.Clear();
            StopCoroutine(AgentActingCoroutine);
            StopCoroutine(ObservationsCoroutine);
            //StopCoroutine(ReactionsCoroutine);
        }

        public abstract TNewState SetState<TNewState>() where TNewState : TState, new();
    }
}