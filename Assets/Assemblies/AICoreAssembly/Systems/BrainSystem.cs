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
    public abstract class BrainSystem<TAgent, TAction, TFeature, TSensor>
        : SystemBase<TAgent, TAction, TFeature, TSensor>,
        ICanReactOnPhenomenon<IPhenomenon, TAction>
        where TAgent : IAgent
        where TAction : IAction
        where TFeature : IFeature
        where TSensor : ISensor
    {
        #region fields
        
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

        private int PhenonemonComparer(IPhenomenon x, IPhenomenon y)
        {
            if (x.PhenomValue > y.PhenomValue)
                return -1;
            if (x.PhenomValue < y.PhenomValue)
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

        internal IEnumerator ProceedPhenomenons(List<IPhenomenon> observationSources)
        {
            yield return AddNewPhenomenons(observationSources);
            yield return FilterNewPhenomenons();
        }

        /// <summary>
        /// React if has observable phenomena to react and current state is able to force change it
        /// </summary>
        public virtual IEnumerator TryReactAtSomePhenom()
        {
            while (PhenomensToReact.Count > 0)
            {
                var selectedPhenom = SelectPhenomToReact(PhenomensToReact);
               
                if (TryReactOnPhenom(selectedPhenom, out List<TAction> allReactions))
                {
                    //если реакция есть, необязательно, что её можно реализовать в текущий момент по определенным причинам
                    if (allReactions.Count == 0)
                    {
                        PhenomensToReact.Remove(selectedPhenom);
                        continue;
                    }
                    TAction selectedReaction;
                    do
                    {
                        selectedReaction = SelectActionFromList(allReactions);
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

        /// <summary>
        /// Defines what phenomena will be proceeded next
        /// </summary>
        /// <param name="phenomensToReact"></param>
        /// <returns></returns>
        protected abstract IPhenomenon SelectPhenomToReact(List<IPhenomenon> phenomensToReact);
        /// <summary>
        /// Defines if agent can react at abstract <paramref name="reason"/> and what probably actions presented to proceed.
        /// Implement ICanReactOnPhenomenon<TConcretePhenom, TAction> in realized class for class typematching
        /// </summary>
        /// <param name="reason"></param>
        /// <param name="reaction"></param>
        /// <returns></returns>
        public abstract bool TryReactOnPhenom(IPhenomenon reason, out List<TAction> reaction);
        /// <summary>
        /// Defines haw action selected from list
        /// </summary>
        /// <param name="reactions"></param>
        /// <returns></returns>
        protected abstract TAction SelectActionFromList(List<TAction> reactions);

        internal void Clear()
        {
            PhenomensToReact.Clear();
            NewPhenomens.Clear();
        }
    }
}