using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public enum ActionsMode
    {
        Manual,
        ByInterval
    }

    /// <summary>
    /// Brain that proceed main process loop:
    /// collect observations, processing, make action.
    /// </summary>
    public abstract class BrainBase<TAgent, TReaction, TFeature, TState, TSensor>
        : SystemBase<TAgent, TReaction, TFeature, TState, TSensor>,
        ICanReactOnPhenomenon<IPhenomenon, TReaction>
        where TAgent : ICurrentStateHandler<TState>, IAgent
        where TReaction : IReaction
        where TFeature : IFeature
        where TState : IState
        where TSensor : ISensor
    {
        #region fields
        [Space, SerializeField, Tooltip("If true, decrease phenomenons interest value per decreaseStep every step after calling " +
            "\"FilterNewPhenomenons\" on observations handling routine. Else you should call it manually from outer code.")]
        private bool autoDecreasePhenomsValuePerStep;
        public bool AutoDecreasePhenomsValuePerStep
        {
            get => autoDecreasePhenomsValuePerStep;
            set => autoDecreasePhenomsValuePerStep = value;
        }
        [SerializeField, Range(0f, 256f)] private float decreaseStep;
        [SerializeField] private TReaction lastReaction;
        private List<IPhenomenon> newPhenomens;

        private List<IPhenomenon> phenomensToReact;
        protected List<IPhenomenon> NewPhenomens { get => newPhenomens; }

        /// <summary>
        /// Contains phenomenons to react at and current interest value for it.
        /// </summary>
        public List<IPhenomenon> PhenomensToReact { get => phenomensToReact; protected set => phenomensToReact = value; }

        #endregion fields

        /// <summary>
        /// Adds phenomenons to processing list if not contains yet.
        /// </summary>
        /// <param name="phenomens"></param>
        private IEnumerator AddNewPhenomenons(List<IPhenomenon> phenomens)
        {
            foreach (var p in phenomens)
            {
                if (!newPhenomens.Contains(p))
                    NewPhenomens.Add(p);
                yield return new WaitForFixedUpdate();
            }
            NewPhenomens.Sort(PhenonemonComparer);
        }

        
        IEnumerator manualAction;
        public IEnumerator ManualAction { get=> manualAction; set => manualAction = value; }
        internal IEnumerator ManuallySettedAction()
        {
            if(manualAction != null)
                yield return manualAction;
            manualAction = null;
        }
        
        private int PhenonemonComparer(KeyValuePair<IPhenomenon, float> x, KeyValuePair<IPhenomenon, float> y)
        {
            if (x.Value > y.Value)
                return -1;
            if (x.Value < y.Value)
                return 1;
            return 0;
        }

        private int PhenonemonComparer(IPhenomenon x, IPhenomenon y)
        {
            if (x.PhenomenonPower > y.PhenomenonPower)
                return -1;
            if (x.PhenomenonPower < y.PhenomenonPower)
                return 1;
            return 0;
        }

        protected override void Awake()
        {
            base.Awake();
            newPhenomens = new List<IPhenomenon>();
            phenomensToReact = new List<IPhenomenon>();
        }

        /// <summary>
        /// This method runs after collecting observations.
        /// This is a place to filter detected phenomena into significant and insignificant ones.
        /// Do not forget to clear the list of new phenomena after processing.
        /// If you don't want to filter phenomena, just leave the default implementation.
        /// </summary>
        /// <returns></returns>
        protected virtual IEnumerator FilterNewPhenomenons()
        {
            foreach (var np in NewPhenomens)
            {
                if (!PhenomensToReact.Contains(np))
                    PhenomensToReact.Add(np);
            }
            yield return new WaitForFixedUpdate();
            NewPhenomens.Clear();
        }

        /// <summary>
        /// Обработка явлений. Фильтрация.
        /// События, временные явления, объекты интерьера, люди.
        /// </summary>
        internal IEnumerator ProceedPhenomenons(List<IPhenomenon> observationSources)
        {
            yield return AddNewPhenomenons(observationSources);
            yield return FilterNewPhenomenons();
        }

        /// <summary>
        /// React if has observable phenomena to react and current state is able to force change it
        /// </summary>
        public IEnumerator TryReactAtSomePhenom()
        {
            while (PhenomensToReact.Count > 0)
            {
                var selectedPhenom = SelectPhenomToReact(PhenomensToReact);
               
                if (HasReactionsOnPhenom(selectedPhenom, out List<TReaction> allReactions))
                {
                    //если реакция есть, необязательно, что её можно реализовать в текущий момент по определенным причинам
                    if (allReactions.Count == 0)
                    {
                        PhenomensToReact.Remove(selectedPhenom);
                        continue;
                    }
                    TReaction selectedReaction;
                    do
                    {
                        selectedReaction = SelectReaction(allReactions);
                        yield return selectedReaction.TryPerformAction();
                        allReactions.Remove(selectedReaction);
                    } while (!selectedReaction.WasPerformed && allReactions.Count > 0);
                    PhenomensToReact.Remove(selectedPhenom);
                    break;
                }
                else
                    PhenomensToReact.Remove(selectedPhenom);
            }
        }

        protected abstract IPhenomenon SelectPhenomToReact(List<IPhenomenon> phenomensToReact);
        protected abstract TReaction SelectReaction(List<TReaction> reactions);

        public abstract bool HasReactionsOnPhenom(IPhenomenon reason, out List<TReaction> reaction);

        internal void Clear()
        {
            PhenomensToReact.Clear();
            NewPhenomens.Clear();
        }
    }
}