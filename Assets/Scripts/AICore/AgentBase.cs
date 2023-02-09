using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class AgentBase<TReaction, TFeature, TState> : MonoBehaviour, 
        ICurrentStateHandler<TState>
        where TFeature: IFeature
        where TReaction : IReaction
        where TState : IState
    {
        #region systems

        [SerializeField] CharacterSystem<TReaction, TFeature, TState> characterSystem;
        [SerializeField] FeaturesSystem<TReaction, TFeature, TState> featuresSystem;
        [SerializeField] NervousSystem<TReaction, TFeature, TState> nervousSystem;
        [SerializeField] ObservationsSystem<TReaction, TFeature, TState> observationsSystem;
        [SerializeField] RelationsSystem<TReaction, TFeature, TState> relationsSystem;

        #endregion systems
        [SerializeField] private bool isActing;
        public bool IsActing { get => isActing; private set => isActing = value; }
        [SerializeField] protected TState currentState;
        public NervousSystem<TReaction, TFeature, TState> NervousSystem { get => nervousSystem; protected set => nervousSystem = value; }
        public TState CurrentState { get => currentState; set => currentState = value; }
        public CharacterSystem<TReaction, TFeature, TState> CharacterSystem { get => characterSystem; protected set => characterSystem = value; }
        public FeaturesSystem<TReaction, TFeature, TState> FeaturesSystem { get => featuresSystem; protected set => featuresSystem = value; }
        public RelationsSystem<TReaction, TFeature, TState> RelationsSystem => relationsSystem;
        public Coroutine StateExecutingCoroutine { get; private set; }
        public Coroutine ObservationsCoroutine { get; private set; }
        public Coroutine DecisionsCoroutine { get; private set; }
        /// <summary>
        /// Главный процесс агента. Здесь производятся действия.
        /// </summary>
        /// <returns></returns>
        private IEnumerator ObservationsRoutine()
        {
            while (IsActing)
            {
                var observationSources = observationsSystem.CreatePhenomenons();
                yield return NervousSystem.ProceedPhenomenons(observationSources);
            }
        }
        IEnumerator StateExecutingRoutine()
        {
            while (IsActing)
                yield return CurrentState.StartState();
        }
        //public RelationshipBase GetCurrentRelationTo<TAgent,TFeat>(TAgent ab)
        //    where TAgent : AgentBase<TFeat>
        //    where TFeat: IFeature
        //{
        //   return relationsSystem.GetCurrentRelationTo<TAgent, TFeat>(ab);
        //}

        public abstract void SetState<S2>() where S2 : TState;
        public virtual void Initiate(IAgentInitData<TFeature> data)
        {
            CharacterSystem.Initiate(data);
            FeaturesSystem.Initiate(data);
        }

        public void StartStateMachine()
        {
            IsActing = true;
            StateExecutingCoroutine = StartCoroutine(StateExecutingRoutine());
            ObservationsCoroutine = StartCoroutine(ObservationsRoutine());
            DecisionsCoroutine = StartCoroutine(DecisionsRoutine());
        }
        public void StopStateMachine()
        {
            IsActing = false;
            StopCoroutine(StateExecutingCoroutine);
            StopCoroutine(ObservationsCoroutine);
            StopCoroutine(DecisionsCoroutine);
        }

        IEnumerator DecisionsRoutine()
        {
            while (IsActing)
            {
                yield return NervousSystem.DecisionsRoutine();
            }
        }
    }
}
