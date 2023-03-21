using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

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
        //IAttentionCalculator<IPhenomenon>

        where TAgent : ICurrentStateHandler<TState>, IAgent
        where TReaction : IReaction
        where TFeature : IFeature
        where TState : IState
        where TSensor : ISensor
    {
        #region fields

        #region actions
        [Header("Actions taking settings")]
        [Tooltip("If manually, you need to call \"TryReactAtSomePhenom\" yourself from external code." +
            " Otherwise, the call will occur according to the time interval."), SerializeField]
        private ActionsMode actionsMode;


        #endregion
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
        private List<TReaction> temporaryReactions;
        protected List<IPhenomenon> NewPhenomens { get => newPhenomens; }

        /// <summary>
        /// Contains phenomenons to react at and current interest value for it.
        /// </summary>
        public List<IPhenomenon> PhenomensToReact { get => phenomensToReact; protected set => phenomensToReact = value; }
        public float DecreaseStep { get => decreaseStep; set => decreaseStep = value; }

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
            {
                yield return manualAction;
                //Debug.Log("Manually setted action routine end");
            }
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
            temporaryReactions = new List<TReaction>();
            newPhenomens = new List<IPhenomenon>();
            phenomensToReact = new List<IPhenomenon>();
        }



        /// <summary>
        /// Used to reduce the importance of the phenomenon over time. When the importance reaches 0,
        /// the phenomenon is removed from the processing queue.
        /// Redefine your own logic for reducing interest in the processed phenomena for a specific implementation.
        /// </summary>
        protected virtual void DecreasePhenomsValue()
        {
            //if (PhenomensToReact.Count > 0)
            //{
            //    var decreaseValue = DecreaseStep;
            //    var lst = PhenomensToReact.ToList();
            //    for (int i = 0; i < lst.Count; i++)
            //    {
            //        var temp = lst[i];
            //        if (temp.Value - decreaseValue <= 0)
            //            PhenomensToReact.Remove(temp.Key);
            //        else
            //            PhenomensToReact[temp.Key] -= decreaseValue;
            //    }
            //}
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
        /// Implementation of reaction that have arisen.
        /// </summary>
        /// <param name="reason"></param>
        /// <param name="reaction"></param>
        /// <returns></returns>
        //protected abstract void MakeReaction(TReaction reactions);

        /// <summary>
        /// Обработка явлений. Фильтрация.
        /// События, временные явления, объекты интерьера, люди.
        /// </summary>
        internal IEnumerator ProceedPhenomenons(List<IPhenomenon> observationSources)
        {
            yield return AddNewPhenomenons(observationSources);
            //Debug.Log($"Phenoms detected {NewPhenomens.Count}");
            yield return FilterNewPhenomenons();
            //Debug.Log($"Phenoms after filtering {PhenomensToReact.Count}");
            //if (autoDecreasePhenomsValuePerStep)
            //{
            //    DecreasePhenomsValue();
            //}
            //Debug.Log($"Phenoms to react count {PhenomensToReact.Count}");
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
                        //Debug.Log($"Trying perform action: {selectedReaction}");
                        yield return selectedReaction.TryPerformAction();
                        allReactions.Remove(selectedReaction);
                    } while (!selectedReaction.WasPerformed && allReactions.Count > 0);
#if DEBUG
                    //if (selectedReaction.WasPerformed) {
                    //    ActionsStatistics.AddPerformed(selectedReaction);
                    //    ActionsStatistics.Log();
                    //}
                    //Debug.Log($"Some reaction performed! Reaction was: \n{selectedReaction}");
#endif
                    PhenomensToReact.Remove(selectedPhenom);
                    break;
                }
                else
                {
                    PhenomensToReact.Remove(selectedPhenom);
                }
            }
        }

        protected abstract IPhenomenon SelectPhenomToReact(List<IPhenomenon> phenomensToReact);
        protected abstract TReaction SelectReaction(List<TReaction> reactions);

        public IReaction LastReaction => lastReaction;

        public List<TReaction> TemporaryReactions => temporaryReactions;

       

        public void AddReaction(TReaction reaction)
        {
            TemporaryReactions.Add(reaction);
            lastReaction = reaction;
        }

        public abstract bool HasReactionsOnPhenom(IPhenomenon reason, out List<TReaction> reaction);

        internal void Clear()
        {
            PhenomensToReact.Clear();
            NewPhenomens.Clear();
        }
    }
}