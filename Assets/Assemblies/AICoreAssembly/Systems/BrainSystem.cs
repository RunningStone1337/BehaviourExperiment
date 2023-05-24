using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{

    public abstract class BrainSystem<TAgent, TAction>
        : SystemBase<TAgent>,
        ICanReactOnPhenomenon<IPhenomenon, TAction>
        where TAgent : IAgent
        where TAction : IAction
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
        protected virtual IEnumerator AddNewPhenomenons(List<IPhenomenon> phenomens)
        {
            foreach (var p in phenomens)
            {
                if (!newPhenomens.Contains(p))
                    NewPhenomens.Add(p);
                yield return new WaitForFixedUpdate();
            }
            NewPhenomens.Sort(PhenonemonComparer);
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

        internal IEnumerator HandleNewPhenomenons(List<IPhenomenon> observationSources)
        {
            yield return AddNewPhenomenons(observationSources);
            yield return FilterNewPhenomenons();
        }
        

        /// <summary>
        /// Defines what phenomena will be proceeded next
        /// </summary>
        /// <param name="phenomensToReact"></param>
        /// <returns></returns>
        public abstract IPhenomenon SelectPhenomToReact(List<IPhenomenon> phenomensToReact);
        /// <summary>
        /// Defines if agent can react at abstract <paramref name="reason"/> and what probably actions presented to proceed.
        /// Implement ICanReactOnPhenomenon<TConcretePhenom, TAction> in realized class for class typematching
        /// </summary>
        /// <param name="reason"></param>
        /// <param name="reaction"></param>
        /// <returns></returns>
        public abstract bool TryGetActionsOnPhenom(IPhenomenon reason, out List<TAction> reaction);
        /// <summary>
        /// Defines how action selected from list
        /// </summary>
        /// <param name="reactions"></param>
        /// <returns></returns>
        public abstract TAction SelectActionFromList(List<TAction> reactions);

        internal void Clear()
        {
            PhenomensToReact.Clear();
            NewPhenomens.Clear();
        }
    }
}