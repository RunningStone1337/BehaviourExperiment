using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BehaviourModel
{
    /// <summary>
    /// Репрезентация нервной системы человека.
    /// Нижний уровень обработки поступающей информации, формирующий тенденцию отклика на ситуации и
    /// создающий новые импульсы, являющися основой для действий.
    /// Уровень органических предпосылок личности.
    /// </summary>
    public abstract class NervousSystem<TReaction, TFeature, TState> : SystemBase<TReaction, TFeature, TState>
        where TReaction :IReaction
        where TFeature : IFeature 
        where TState : IState
    {
        [SerializeField] private bool actionSelected;
        [SerializeField] private TReaction lastReaction;
        [SerializeField] private List<IPhenomenon> newPhenomens;
        [SerializeField] [Range(0f, 10f)] private float observationPause = 1f;
        [SerializeField] private Dictionary<IPhenomenon, float> phenomensToReact;
        [SerializeField] private List<TReaction> temporaryReactions;
        private List<IPhenomenon> NewPhenomens { get => newPhenomens; }
        private Dictionary<IPhenomenon, float> PhenomensToReact { get => phenomensToReact; }

        /// <summary>
        /// Добавляет явления в список обрабатываемых если их там ещё нет
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

        private void Awake()
        {
            temporaryReactions = new List<TReaction>();
            newPhenomens = new List<IPhenomenon>();
            phenomensToReact = new Dictionary<IPhenomenon, float>();
        }

        /// <summary>
        /// Значимость для явления при текущих условиях.
        /// (базоваяСила+личныеОсобенности)*реактивность
        /// </summary>
        /// <param name="ph"></param>
        /// <returns></returns>
        public abstract float CalculateCurrentImportance<T>(T ph) where T : IPhenomenon;
        //{
        //    return thisAgent.CharacterSystem.RelaxationTension.RawCharacterValue/10f * (ph.PhenomenonPower
        //        //Важность явления для черт личности и особенностей
        //        + CalculatePersonellImportanceValue(ph)
        //        /*+ CalculateContextImportanceValue(ph)*/);
        //}

        /// <summary>
        /// Возвращает значимость для явления с точки зрения личных особенностей.
        /// Влияние на значимость может быть как положительной, так и отрицательной, или отсутствовать вовсе.
        /// </summary>
        /// <param name="ph"></param>
        /// <returns></returns>
        private float CalculatePersonellImportanceValue<T>(T ph) where T : IPhenomenon
        {
            //float res = 0f;
            /////Черты характера оценивают значимость явления - эмоций,
            /////событий, особенностей, ЛЮДЕЙ! В зависимости от текущего
            /////контекста, глобального и временного.
            //foreach (var charTrait in thisAgent.CharacterSystem)
            //    res += charTrait.GetImportanceValueFor(ph);
            //return res;
            throw new NotImplementedException();
        }

        /// <summary>
        /// Первичная обработка обнаруженных явлений - фильтрация незначимых.
        /// </summary>
        private IEnumerator FilterNewPhenomenons()
        {
            foreach (var ph in NewPhenomens)
            {
                if (IsPhenomenonValuable(ph, out float calculated))
                {
                    if (!PhenomensToReact.ContainsKey(ph))
                    {
                        PhenomensToReact.Add(ph, calculated);
                        Debug.Log($"Interest value {calculated}/{CalculateInterestThreshold()} for phenom {ph}. Interested, added");
                    }
                    else
                    {

                        Debug.Log($"Interest value {calculated}/{CalculateInterestThreshold()} for phenom {ph}. Interested, yet added");
                    }
                }
                else
                    Debug.Log($"Interest value {calculated}/{CalculateInterestThreshold()} for phenom {ph}. Not interested.");
                yield return null;
            }
            NewPhenomens.Clear();
        }

        /// <summary>
        /// Определение значимости явления в момент времени.
        /// Значимость - СТОИТ ЛИ реагировать на это явление?
        /// </summary>
        /// <param name="ph"></param>
        /// <returns></returns>
        private bool IsPhenomenonValuable<T>(T ph, out float calculatedImportance) where T : IPhenomenon
        {
            //абсолютная значимость явления
            calculatedImportance = CalculateCurrentImportance(ph);
            int interestThreshold = CalculateInterestThreshold();
            if (calculatedImportance > interestThreshold)
                return true;
            return false;
        }

        private int CalculateInterestThreshold()
        {
            var cs = ThisAgent.CharacterSystem;
            var rawExpress = cs.RestraintExpressiveness.RawCharacterValue;
            var rawEmitions = cs.EmotionalInstabilityStability.RawCharacterValue;
            var expressVal = rawExpress > 5 ? rawExpress - 5 : 5 - rawExpress;
            var emotionsVal = rawEmitions > 5 ? rawEmitions - 5 : 5 - rawEmitions;
            var interestThreshold = (cs.Selfcontrol.RawCharacterValue - expressVal + emotionsVal);
            return interestThreshold;
        }

        private IEnumerator ObservationsDelayRoutine()
        {
            yield return new WaitForSeconds(observationPause + Random.Range(0f, observationPause/10f));
        }

        private int PhenonemonComparer((IPhenomenon, float) x, (IPhenomenon, float) y)
        {
            if (x.Item2 > y.Item2)
                return -1;
            if (x.Item2 < y.Item2)
                return 1;
            return 0;
        }
        private int PhenonemonComparer(KeyValuePair<IPhenomenon, float> x, KeyValuePair<IPhenomenon, float> y)
        {
            if (x.Value > y.Value)
                return -1;
            if (x.Value < y.Value)
                return 1;
            return 0;
        }

        internal IEnumerator DecisionsRoutine()
        {
            if (phenomensToReact.Count > 0)
            {
                //вникнуть здесь
                var sorted = phenomensToReact.ToList();
                sorted.Sort(PhenonemonComparer);
                var selected = sorted[0].Key;
                var reaction = EmotionalReactAtPhenomenon(selected);
            }
            yield return new WaitForFixedUpdate();
        }
        
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

        /// <summary>
        /// Реакция на явление <paramref name="phenom"/>
        /// </summary>
        /// <param name="phenom"></param>
        private List<TReaction> EmotionalReactAtPhenomenon<TPhenom>(TPhenom phenom) 
            where TPhenom: IPhenomenon
        {
            //отсортированные явления начинают обрабатываться в порядке приоритета.
            //явления вызывают сложные эмоции. Сложные эмоции являются источниками действий.
            //сейчас сюда прилетают люди и интерьер
            //var reactions = new List<TReaction>();
            //foreach (var charTrait in thisAgent.CharacterSystem)
            //{
                var type = ThisAgent.GetType();
                var interfaces = type.GetInterfaces();
                var correctIface = typeof(ICanReactOnPhenomenon<TPhenom, TReaction>);
                foreach (var iface in interfaces)
                {
                    if (iface.IsEquivalentTo(correctIface))
                    {
                        var method = iface.GetMethod("HasReactionOn");
                        object[] parameters = new object[] { phenom, null }; 
                        bool result = (bool)method.Invoke(ThisAgent, parameters);
                        if (result)
                            return (List<TReaction>)parameters[1];
                    }
                }
                //if (charTrait.HasReactionOn(phenom, out List<IReaction> reaction))
            //}
            return default;
        }

        public bool ActionSelected { get => actionSelected; set => actionSelected = value; }
    
        public IReaction LastReaction => lastReaction;
        public List<TReaction> TemporaryReactions => temporaryReactions;

        public void AddReaction(TReaction newEmotion)
        {
            TemporaryReactions.Add(newEmotion);
            lastReaction = newEmotion;
        }

        /// <summary>
        /// Обработка явлений. Фильтрация.
        /// События, временные явления, объекты интерьера, люди.
        /// </summary>
        internal IEnumerator ProceedPhenomenons(List<IPhenomenon> observationSources)
        {
            yield return AddNewPhenomenons(observationSources);
            yield return FilterNewPhenomenons();
            yield return ObservationsDelayRoutine();
            DecreasePhenomsValue();
            Debug.Log($"Phenoms to react count {PhenomensToReact.Count}");
        }

        private void DecreasePhenomsValue()
        {
            if (PhenomensToReact.Count > 0)
            {
                var anxietyVal = (10- ThisAgent.CharacterSystem.CalmnessAnxiety.RawCharacterValue) / 50f;
                var lst = PhenomensToReact.ToList();
                for (int i = 0; i < lst.Count; i++)
                {
                    var temp = lst[i];
                    if (temp.Value - anxietyVal <= 0)
                        PhenomensToReact.Remove(temp.Key);
                    else
                        PhenomensToReact[temp.Key] -= anxietyVal;
                }
            }
        }
    }
}