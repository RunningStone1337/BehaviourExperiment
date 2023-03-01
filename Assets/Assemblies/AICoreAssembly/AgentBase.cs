using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class AgentBase<TAgent, TReaction, TFeature, TState, TSensor> : SerializedMonoBehaviour, IAgent,
        ICurrentStateHandler<TState>
        where TAgent : ICurrentStateHandler<TState>
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
             where TLowAnx : LowAnxiety<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidAnx : MiddleAnxiety<TAgent, TReaction, TFeature, TState, TSensor>
            where THighAnx : HighAnxiety<TAgent, TReaction, TFeature, TState, TSensor>

            where TLowSoc : LowClosenessSociability<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidSoc : MiddleClosenessSociability<TAgent, TReaction, TFeature, TState, TSensor>
            where THighSoc : HighClosenessSociability<TAgent, TReaction, TFeature, TState, TSensor>

            where TLowStab : LowEmotionalStability<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidStab : MiddleEmotionalStability<TAgent, TReaction, TFeature, TState, TSensor>
            where THighStab : HighEmotionalStability<TAgent, TReaction, TFeature, TState, TSensor>

            where TLowNonc : LowNonconformism<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidNonc : MiddleNonconformism<TAgent, TReaction, TFeature, TState, TSensor>
            where THighNonc : HighNonconformism<TAgent, TReaction, TFeature, TState, TSensor>

            where TLowNorm : LowNormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidNorm : MiddleNormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor>
            where THighNorm : HighNormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor>

            where TLowRad : LowRadicalism<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidRad : MiddleRadicalism<TAgent, TReaction, TFeature, TState, TSensor>
            where THighRad : HighRadicalism<TAgent, TReaction, TFeature, TState, TSensor>

            where TLowSelf : LowSelfcontrol<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidSelf : MiddleSelfcontrol<TAgent, TReaction, TFeature, TState, TSensor>
            where THighSelf : HighSelfcontrol<TAgent, TReaction, TFeature, TState, TSensor>

            where TLowSens : LowSensetivity<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidSens : MiddleSensetivity<TAgent, TReaction, TFeature, TState, TSensor>
            where THighSens : HighSensetivity<TAgent, TReaction, TFeature, TState, TSensor>

            where TLowSusp : LowSuspicion<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidSusp : MiddleSuspicion<TAgent, TReaction, TFeature, TState, TSensor>
            where THighSusp : HighSuspicion<TAgent, TReaction, TFeature, TState, TSensor>

            where TLowTens : LowTension<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidTens : MiddleTension<TAgent, TReaction, TFeature, TState, TSensor>
            where THighTens : HighTension<TAgent, TReaction, TFeature, TState, TSensor>

            where TLowExpre : LowExpressiveness<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidExpre : MiddleExpressiveness<TAgent, TReaction, TFeature, TState, TSensor>
            where THighExpre : HighExpressiveness<TAgent, TReaction, TFeature, TState, TSensor>

            where TLowInt : LowIntelligence<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidInt : MiddleIntelligence<TAgent, TReaction, TFeature, TState, TSensor>
            where THighInt : HighIntelligence<TAgent, TReaction, TFeature, TState, TSensor>

            where TLowDrea : LowDreaminess<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidDrea : MiddleDreaminess<TAgent, TReaction, TFeature, TState, TSensor>
            where THighDrea : HighDreaminess<TAgent, TReaction, TFeature, TState, TSensor>

            where TLowDom : LowDomination<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidDom : MiddleDomination<TAgent, TReaction, TFeature, TState, TSensor>
            where THighDom : HighDomination<TAgent, TReaction, TFeature, TState, TSensor>

            where TLowDipl : LowDiplomacy<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidDipl : MiddleDiplomacy<TAgent, TReaction, TFeature, TState, TSensor>
            where THighDipl : HighDiplomacy<TAgent, TReaction, TFeature, TState, TSensor>

            where TLowCour : LowCourage<TAgent, TReaction, TFeature, TState, TSensor>
            where TMidCour : MiddleCourage<TAgent, TReaction, TFeature, TState, TSensor>
            where THighCour : HighCourage<TAgent, TReaction, TFeature, TState, TSensor>

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


        public void StartStateMachine()
        {
            IsActing = true;
            AgentActingCoroutine = StartCoroutine(AgentActingRoutine());
            ObservationsCoroutine = StartCoroutine(ObservationsRoutine());
            //ReactionsCoroutine = StartCoroutine(ReactionsRoutine());
        }

        public void StopStateMachine()
        {
            IsActing = false;
            StopCoroutine(AgentActingCoroutine);
            StopCoroutine(ObservationsCoroutine);
            //StopCoroutine(ReactionsCoroutine);
        }

        public abstract void SetState<TNewState>() where TNewState : TState, new();
    }
}