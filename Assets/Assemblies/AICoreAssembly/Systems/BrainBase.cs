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
        ICanReactOnPhenomenon<IPhenomenon, TReaction>,
        IAttentionCalculator<IPhenomenon>

        where TAgent : ICurrentStateHandler<TState>
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

        [Tooltip("Interval of trying setting new state in scalled seconds."), SerializeField, Range(0f, 256f)]
        private float actionsTakingInterval;

        [Space, SerializeField, Range(0f, 256f), Tooltip("Seed of trying setting new state interval for some randomizing in scalled seconds." +
            " Value is random between negative and positive. Can't be more then actionsTakingInterval")]
        private float actionsTakingIntervalSeed;
        
        [SerializeField] private bool actionSelected;

        public float ActionsTakingInterval { get => actionsTakingInterval; set => actionsTakingInterval = value; }
        public float ActionsTakingIntervalSeed
        {
            get => actionsTakingIntervalSeed;
            set => actionsTakingIntervalSeed = Mathf.Clamp(value, 0, actionsTakingInterval);
        }
        public ActionsMode ActionsMode { get => actionsMode; set => actionsMode = value; }


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

        private Dictionary<IPhenomenon, float> phenomensToReact;
        private List<TReaction> temporaryReactions;
        protected List<IPhenomenon> NewPhenomens { get => newPhenomens; }
        /// <summary>
        /// Contains phenomenons to react at and current interest value for it.
        /// </summary>
        protected Dictionary<IPhenomenon, float> PhenomensToReact { get => phenomensToReact; }

      

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
                yield return null;
            }
            NewPhenomens.Sort(PhenonemonComparer);
        }

        private int PhenonemonComparer((IPhenomenon, float) x, (IPhenomenon, float) y)
        {
            if (x.Item2 > y.Item2)
                return -1;
            if (x.Item2 < y.Item2)
                return 1;
            return 0;
        }

        //{
        //    var type = ThisAgent.GetType();
        //    var interfaces = type.GetInterfaces();
        //    var correctIface = typeof(ICanReactOnPhenomenon<TPhenom, TReaction>);
        //    foreach (var iface in interfaces)
        //    {
        //        if (iface.IsEquivalentTo(correctIface))
        //        {
        //            var method = iface.GetMethod("HasReactionOn");
        //            object[] parameters = new object[] { phenom, null };
        //            bool result = (bool)method.Invoke(ThisAgent, parameters);
        //            if (result)
        //                return (List<TReaction>)parameters[1];
        //        }
        //    }
        //    //if (charTrait.HasReactionOn(phenom, out List<IReaction> reaction))
        //    //}
        //    return default;
        //}
        private int PhenonemonComparer(KeyValuePair<IPhenomenon, float> x, KeyValuePair<IPhenomenon, float> y)
        {
            if (x.Value > y.Value)
                return -1;
            if (x.Value < y.Value)
                return 1;
            return 0;
        }

        //protected abstract List<TReaction> ReactAtPhenomenon<TPhenom>(TPhenom phenom) where TPhenom : IPhenomenon;
        private int PhenonemonComparer(IPhenomenon x, IPhenomenon y)
        {
            if (x.PhenomenonPower > y.PhenomenonPower)
                return -1;
            if (x.PhenomenonPower < y.PhenomenonPower)
                return 1;
            return 0;
        }

        /// <summary>
        /// Обработка явлений, воспринятых как значимые.
        /// Результатом может быть формализованное действие(как простое, так и сложное), возникновение мыслей,
        /// новых особенностей, изменение текущего эмоционального состояния - всё, что угодно.
        /// Обработкой явлений на высшем уровне занимаются черты характера.
        /// Различные черты "высказывают" своё отношение к явлению, наиболее явная реакция
        /// выражается, менее выраженные добавляются в качестве эмоциональной окраски или игнорируются.
        /// </summary>
        private IEnumerator ReactAtNewPhenomenons()
        {
            //foreach (var ph in PhenomensToReact)
            //{
            //    ReactAtPhenomenon(ph);
            //}
            //PhenomensToReact.Clear();
            yield return null;
        }

      

     

        protected virtual void Awake()
        {
            temporaryReactions = new List<TReaction>();
            newPhenomens = new List<IPhenomenon>();
            phenomensToReact = new Dictionary<IPhenomenon, float>();
        }

        /// <summary>
        /// Redefine this method to implement logic that determines when detected phenomena become interesting to the agent.
        /// The default value is 0.
        /// </summary>
        /// <returns></returns>
        protected virtual float CalculateAttentionThreshold() => default;

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        protected abstract bool CanSetNewState();

        /// <summary>
        /// Used to reduce the importance of the phenomenon over time. When the importance reaches 0,
        /// the phenomenon is removed from the processing queue.
        /// Redefine your own logic for reducing interest in the processed phenomena for a specific implementation.
        /// </summary>
        protected virtual void DecreasePhenomsValue()
        {
            if (PhenomensToReact.Count > 0)
            {
                var decreaseValue = DecreaseStep;
                var lst = PhenomensToReact.ToList();
                for (int i = 0; i < lst.Count; i++)
                {
                    var temp = lst[i];
                    if (temp.Value - decreaseValue <= 0)
                        PhenomensToReact.Remove(temp.Key);
                    else
                        PhenomensToReact[temp.Key] -= decreaseValue;
                }
            }
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
                if (!PhenomensToReact.ContainsKey(np))
                    PhenomensToReact.Add(np, np.PhenomenonPower);
                yield return null;
            }
            NewPhenomens.Clear();
        }

        /// <summary>
        /// Implementation of reaction that have arisen.
        /// </summary>
        /// <param name="reason"></param>
        /// <param name="reaction"></param>
        /// <returns></returns>
        protected abstract void MakeReaction(TReaction reactions);

        /// <summary>
        /// Обработка явлений. Фильтрация.
        /// События, временные явления, объекты интерьера, люди.
        /// </summary>
        internal IEnumerator ProceedPhenomenons(List<IPhenomenon> observationSources)
        {
            yield return AddNewPhenomenons(observationSources);
            //Debug.Log($"Phenoms detected {NewPhenomens.Count}");
            yield return FilterNewPhenomenons();
            Debug.Log($"Phenoms after filtering {PhenomensToReact.Count}");
            if (autoDecreasePhenomsValuePerStep)
            {
                DecreasePhenomsValue();
            }
            Debug.Log($"Phenoms to react count {PhenomensToReact.Count}");
        }

        /// <summary>
        /// React if has observable phenomena to react and current state is able to force change it
        /// </summary>
        public void TryReactAtSomePhenom()
        {
            if (phenomensToReact.Count > 0)
            {
                var lsPhToReact = phenomensToReact.ToList();
                while (lsPhToReact.Count > 0)
                {
                    var normalized = lsPhToReact.Normalize();
                    var selected = normalized.SelectRandom();
                    //lstPhenomsTOReact.Sort(PhenonemonComparer);
                    if (HasReactionsOnPhenom(selected.Key, out List<TReaction> rs))
                    {
                        if (rs.Count == 0)
                            throw new System.Exception(
                                "HasReactionsOnPhenom return true but has no reactions to do, make sure your implementation" +
                                $"returns at least one {typeof(TReaction)} at phenom {selected.Key}.");

                        for (int i = 0; i < rs.Count; i++)
                            MakeReaction(rs[i]);
                        phenomensToReact.Remove(selected.Key);
                        break;
                    }
                    else
                        lsPhToReact.Remove(selected);
                }
            }
        }


        public IReaction LastReaction => lastReaction;

        public List<TReaction> TemporaryReactions => temporaryReactions;

        public void AddReaction(TReaction reaction)
        {
            TemporaryReactions.Add(reaction);
            lastReaction = reaction;
        }

        public abstract bool HasReactionsOnPhenom(IPhenomenon reason, out List<TReaction> reaction);
        public abstract float CalculateAttentionForPhenomenon(IPhenomenon phenom);
    }
}