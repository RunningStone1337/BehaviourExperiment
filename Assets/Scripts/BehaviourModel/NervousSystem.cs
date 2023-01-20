using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    /// <summary>
    /// Репрезентация нервной системы человека.
    /// Нижний уровень обработки поступающей информации, формирующий тенденцию отклика на ситуации и
    /// создающий новые импульсы, являющися основой для действий.
    /// Уровень органических предпосылок личности.
    /// </summary>
    public class NervousSystem : MonoBehaviour
    {
        #region main

        [SerializeField] [Range(1, 10)] private int activity;
        [SerializeField] [Range(1f, 10f)] private float currentActivity;
        [SerializeField] [Range(1f, 10f)] private float currentExcitement;
        [SerializeField] [Range(1f, 10f)] private float currentReactivity;
        [SerializeField] private NervousBalanceType nervousBalance;
        [SerializeField] [Range(1, 10)] private int nervousMobility;
        [SerializeField] [Range(1, 10)] private int nervousPower;
        [SerializeField] [Range(1, 10)] private int reactivity;
        /// <summary>
        /// Степень активности воздействия на мир и целеустремлённость.
        /// </summary>
        public int Activity { get => activity; private set => activity = Mathf.Clamp(value, 1, 10); }

        /// <summary>
        /// Отношение активности к реактивности, определяет мотивы действий - зависимость от внешних сили или внутренних побуждений.
        /// При == 1 вероятность 0.5, выше 1 - высокая активность, ниже 1 - высокая реактивность.
        /// </summary>
        public float ActReactRelation { get => ((float)activity) / reactivity; }

        public float CurrentActivity { get => currentActivity; private set => currentActivity = Mathf.Clamp(value, 1f, 10f); }
        /// <summary>
        /// Текущая степень возбуждённости.
        /// </summary>
        public float CurrentExcitement { get => currentExcitement; private set => currentExcitement = Mathf.Clamp(value, 1f, 10f); }

        public float CurrentReactivity { get => currentReactivity; private set => currentReactivity = Mathf.Clamp(value, 1f, 10f); }

        internal void StartThinking()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Уравновешенность НС — свойство нервной системы, выражающее соотношение между возбуждением
        /// и торможением, баланс этих процессов. Является самостоятельным свойством нервной системы,
        /// образующее в сочетании с другими (с силой и подвижностью) определенный тип высшей нервной деятельности.
        /// </summary>
        public NervousBalanceType NervousBalance { get => nervousBalance; private set => nervousBalance = value; }

        /// <summary>
        /// Подвижность НС - свойство нервной системы, состоящее в способности быстро реагировать на изменения в окружающей среде,
        /// способности переключаться с возбудительного процесса на тормозный и наоборот.
        /// </summary>
        public int NervousMobility { get => nervousMobility; private set => nervousMobility = Mathf.Clamp(value, 1, 10); }

        /// <summary>
        /// Сила НС - свойство нервной системы, отражающее предел работоспособности клеток коры головного мозга,
        /// т.е. их способность выдерживать, не переходя в тормозное состояние (торможение),
        /// либо очень сильное, либо длительно действующее (хотя и не сильное) возбуждение.
        /// Cила нервной системы связана также с чувствительностью анализаторов:
        /// более слабая нервная система является и более чувствительной, т.е.
        /// она способна реагировать на стимулы более низкой интенсивности, чем сильная.
        /// </summary>
        public int NervousPower { get => nervousPower; private set => nervousPower = Mathf.Clamp(value, 1, 10); }

        /// <summary>
        /// Степень непроизвольности реакций на внешние и внутренние импульсы.
        /// </summary>
        public int Reactivity { get => reactivity; private set => reactivity = Mathf.Clamp(value, 1, 10); }

        #endregion main

        [SerializeField] private List<IPhenomenon> newProceedPhenomens;
        [SerializeField] private List<(IPhenomenon, float)> phenomensToReact;
        [SerializeField] private AgentBase thisAgent;      

        private List<IPhenomenon> NewPhenomens { get => newProceedPhenomens; set => newProceedPhenomens = value; }
        private List<(IPhenomenon, float)> PhenomensToReact { get => phenomensToReact; set => phenomensToReact = value; }

        /// <summary>
        /// Значение важности для явления для текущих внешних условий (контекст, события, проч)
        /// </summary>
        /// <param name="ph"></param>
        /// <returns></returns>
        //private float CalculateContextImportanceValue<T>(T ph) where T : IPhenomenon
        //{
        //    float res = default;
        //    foreach (var charTrait in thisAgent.CharacterSystem)
        //    {
        //        if (charTrait.HasImportanceFor(ph))
        //            res += charTrait.GetImportanceValueFor(ph);
        //        foreach (var c in CurrentAdditionalContext)
        //        {
        //            if (charTrait.HasImportanceFor(ph))
        //                res += charTrait.GetImportanceValueFor(ph);
        //        }
        //    }
        //    return res;
        //}

        /// <summary>
        /// Значимость для явления при текущих условиях.
        /// (базоваяСила+личныеОсобенности)*реактивность/10
        /// </summary>
        /// <param name="ph"></param>
        /// <returns></returns>
        private float CalculateCurrentImportance<T>(T ph) where T : IPhenomenon
        {
            return CurrentReactivity / 10f * (ph.PhenomenonPower +
                //Важность явления для черт личности и особенностей
                CalculatePersonellImportanceValue(ph) 
                /*+ CalculateContextImportanceValue(ph)*/);
        }

        /// <summary>
        /// Возвращает значимость для явления с точки зрения личных особенностей.
        /// Влияние на значимость может быть как положительной, так и отрицательной, или отсутствовать вовсе.
        /// </summary>
        /// <param name="ph"></param>
        /// <returns></returns>
        private float CalculatePersonellImportanceValue<T>(T ph) where T : IPhenomenon
        {
            float res = 0f;
            ///Черты характера оценивают значимость явления - эмоций,
            ///событий, особенностей, ЛЮДЕЙ! В зависимости от текущего
            ///контекста, глобального и временного.
            foreach (var charTrait in thisAgent.CharacterSystem)
                if (charTrait.HasImportanceFor(ph))
                    res += charTrait.GetImportanceValueFor(ph);
            foreach (var feature in thisAgent.FeaturesSystem)
                if (feature.HasImportanceFor(ph))
                    res += feature.GetImportanceValueFor(ph);
            return res;
        }

        /// <summary>
        /// Первичная обработка обнаруженных явлений - фильтрация незначимых
        /// и реакция на значимые.
        /// </summary>
        private void FilterNewPhenomenons()
        {
            foreach (var ph in NewPhenomens)
                if (IsPhenomenonValuable(ph, out float calculated))
                    PhenomensToReact.Add((ph, calculated));
            NewPhenomens.Clear();
            PhenomensToReact.Sort(PhenonemonComparer);
        }

        /// <summary>
        /// Определение значимости явления в момент времени.
        /// Значимость - СТОИТ ЛИ реагировать на это явление?
        /// Значимость определяется Реактивностью, Текущей возбуждённостью (состояние сейчас),
        /// Индивидуальными особенностями (черты характера, фичи, воспоминания) и текущими условиями.
        /// </summary>
        /// <param name="ph"></param>
        /// <returns></returns>
        private bool IsPhenomenonValuable<T>(T ph, out float calculatedImportance) where T : IPhenomenon
        {
            //абсолютная значимость явления
            calculatedImportance = CalculateCurrentImportance(ph);
            if (calculatedImportance >= CurrentExcitement)
                return true;
            return false;
        }

        private int PhenonemonComparer((IPhenomenon, float) x, (IPhenomenon, float) y)
        {
            if (x.Item2 > y.Item2)
                return -1;
            if (x.Item2 < y.Item2)
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

        /// <summary>
        /// Обработка явлений, воспринятых как значимые.
        /// Результатом может быть формализованное действие(как простое, так и сложное), возникновение мыслей,
        /// новых особенностей, изменение текущего эмоционального состояния - всё, что угодно.
        /// Обработкой явлений на высшем уровне занимаются черты характера.
        /// Различные черты "высказывают" своё отношение к явлению, наиболее явная реакция
        /// выражается, менее выраженные добавляются в качестве эмоциональной окраски или игнорируются.
        /// </summary>
        private void ReactAtNewPhenomenons()
        {
            foreach (var ph in PhenomensToReact)
                ReactAtPhenomenon(ph);
            PhenomensToReact.Clear();
        }

        /// <summary>
        /// Реакция на явление <paramref name="phenomPrioritPair"/>
        /// </summary>
        /// <param name="phenomPrioritPair"></param>
        private void ReactAtPhenomenon((IPhenomenon phenom, float priority) phenomPrioritPair)
        {
            //отсортированные явления начинают обрабатываться в порядке приоритета.
            //явления вызывают сложные эмоции. Сложные эмоции являются источниками действий.
            //сейчас сюда прилетают события и что видим - люди и интерьер
            var reactions = new List<(List<EmotionBase> reaction, float reactionImportance)>();
            foreach (var charTrait in thisAgent.CharacterSystem)
            {
                if (charTrait.HasReactionOn(phenomPrioritPair.phenom, out List<EmotionBase> reaction))
                    reactions.Add((reaction, CalculateCurrentImportance(EmotionsToPhenom(reaction))));
            }
            foreach (var feature in thisAgent.FeaturesSystem)
            {
                if (feature.HasReactionOn(phenomPrioritPair.phenom, out List<EmotionBase> reaction))
                    reactions.Add((reaction, CalculateCurrentImportance(EmotionsToPhenom(reaction))));
            }
            var c = reactions.Count;
            if (c > 0)
            {
                //reactions.Sort(PhenonemonComparer);
                //var (reaction, importance) = reactions[c - 1];
                //if (importance >= CurrentExcitement)//возможно нужно другое условие
                //    RealizeAction(reaction);
            }
            else
            {
                //нет реакций на явление?
                Debug.Log($"Не было выявлено ни одной реакции на явление {phenomPrioritPair.phenom}");
            }

            //if (ActReactRelation < 1f)//высокая реактивность
            //{
            //    //высокая вероятность непроизвольной реакции
            //    //низкая - обдуманного действия
            //}
            //else if (ActReactRelation > 1f)//высокая активность
            //{
            //    //низкая вероятность непроизвольной реакции
            //    //высокая - обдуманного действия
            //}
            //else
            //{
            //}//равное соотношение
        }

        private IPhenomenon EmotionsToPhenom(List<EmotionBase> reaction)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Выполнение действия, чем бы оно ни было.
        /// <paramref name="reaction"/> может быть формализованным действием(как простым, так и сложным), возникновением мыслей,
        /// новых особенностей, изменением текущего эмоционального состояния - всё, что угодно.
        /// </summary>
        /// <param name="reaction"></param>
        private void RealizeAction(IPhenomenon reaction)
        {
            //if (reaction is ComplexAction ca)
            //{
            //}
            //else if (reaction is SimpleAction sa)
            //{
            //}
            //else if (reaction is MindSource m)
            //{
            //}
        }

        /// <summary>
        /// Текущий дополнительный контекст ситуации. Различные небольшие происшествия и явления.
        /// </summary>
        public List<IPhenomenon> CurrentAdditionalContext { get; private set; }

        /// <summary>
        /// Текущий главный контекст ситуации. Как правило, это текущее глобальное событие.
        /// </summary>
        public IPhenomenon CurrentGlobalContext { get; set; }

        /// <summary>
        /// Добавляет явления в список обрабатываемых если их там ещё нет
        /// </summary>
        /// <param name="phenomens"></param>
        public void AddNewPhenomenons(List<IPhenomenon> phenomens)
        {
            foreach (var p in phenomens)
            {
                if (!newProceedPhenomens.Contains(p))
                    NewPhenomens.Add(p);
            }
            NewPhenomens.Sort(PhenonemonComparer);
        }

        public void Initiate(HumanRawData data)
        {
            CurrentActivity = Activity = data.NsActivity;
            NervousBalance = data.NsType;
            NervousMobility = data.NsMoveability;
            NervousPower = data.NsPower;
            CurrentReactivity = Reactivity = data.NsReactivity;
        }

        /// <summary>
        /// Обработка явлений. Фильтрация, реакция.
        /// События, временные явления, объекты интерьера, люди.
        /// </summary>
        public void ProceedPhenomenons()
        {
            FilterNewPhenomenons();
            ReactAtNewPhenomenons();
        }

        /// <summary>
        /// Осуществляет выбор действия из потенциальных действий.
        /// </summary>
        /// <returns></returns>
        public Func<IEnumerator> SelectAction()
        {
            //foreach (var pa in ProbablyActions)
            //{
            //}
            throw new NotImplementedException();
        }
    }
}