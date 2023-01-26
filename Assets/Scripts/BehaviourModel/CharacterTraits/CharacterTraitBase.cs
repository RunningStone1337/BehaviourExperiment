using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BehaviourModel
{
    public abstract class CharacterTraitBase : MonoBehaviour, IImportanceInfluenceHandler, ICanReactOnPhenomenon
    {
        [SerializeField] [Range(1, 10)] private int characterValue;
        [SerializeField] private AgentBase thisAgent;

        /// <summary>
        /// Возможные значения характера:
        /// Слабый трейт: 1:3
        /// Средний трейт: -1:1
        /// Сильный трейт: 1:3
        /// </summary>
        /// <param name="characterValue"></param>
        /// <returns></returns>
        private int CalculateThisTraitValue(int characterValue)
        {
            if (characterValue < 4)
                return Mathf.Abs(characterValue - 4);
            else if (characterValue > 3 && characterValue < 8)
            {
                if (characterValue < 6)// 4 5
                    return 4 - characterValue;//0 или -1
                else//6 7
                    return characterValue - 6;//0 или 1
            }
            else if (characterValue > 7)
                return characterValue - 7;
            else throw new ArgumentOutOfRangeException($"{nameof(characterValue)} was out of range [1;10] with value {characterValue}");
        }

        protected Dictionary<Type, float> ImportanceInfluencHandlersDict { get; set; }

        protected AgentBase ThisAgent => thisAgent;

        #region operators overloading

        /// <summary>
        /// Универсальная проверка сравнения двух черт характера
        /// </summary>
        /// <typeparam name="TL"></typeparam>
        /// <typeparam name="TM"></typeparam>
        /// <typeparam name="TH"></typeparam>
        /// <typeparam name="TBASE"></typeparam>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        protected static bool Char1LessChar2<TL, TM, TH, TBASE>(TBASE c1, TBASE c2)
             where TL : TBASE
             where TM : TBASE
             where TH : TBASE
             where TBASE : CharacterTraitBase
        {
            var left = c1 is TL;
            var left2 = c2 is TL;
            if (left && !left2)
                return true;
            var mid = c1 is TM;
            if (mid && c2 is TH)
                return true;
            return false;
        }

        protected static bool Char1LessOrEqualChar2<TL, TM, TH, TBASE>(TBASE c1, TBASE c2)
                    where TL : TBASE
                    where TM : TBASE
                    where TH : TBASE
                    where TBASE : CharacterTraitBase
        {
            return Char1LessChar2<TL, TM, TH, TBASE>(c1, c2) || c1.GetType().IsEquivalentTo(c2.GetType());
        }

        protected static bool Char1MoreChar2<TL, TM, TH, TBASE>(TBASE c1, TBASE c2)
                      where TL : TBASE
                     where TM : TBASE
                     where TH : TBASE
                     where TBASE : CharacterTraitBase
        {
            var right = c1 is TH;
            var right2 = c2 is TH;
            if (right && !right2)
                return true;
            var mid = c1 is TM;
            if (mid && c2 is TL)
                return true;
            return false;
        }

        protected static bool Char1MoreOrEqualChar2<TL, TM, TH, TBASE>(TBASE c1, TBASE c2)
                    where TL : TBASE
                    where TM : TBASE
                    where TH : TBASE
                    where TBASE : CharacterTraitBase
        {
            return Char1MoreChar2<TL, TM, TH, TBASE>(c1, c2) || c1.GetType().IsEquivalentTo(c2.GetType());
        }

        #endregion operators overloading

        /// <summary>
        /// Значение важности <paramref name="agent"/> для черты характера
        /// в зависимости от уровня знакомства с <paramref name="agent"/>.
        /// </summary>
        /// <param name="agent"></param>
        /// <returns></returns>
        protected virtual float CalculateImportanceForFamiliar(AgentBase agent)=>default;//сделать abstract после компиляции

        /// <summary>
        /// Значение важности <paramref name="agent"/> для черты характера
        /// при условии что агент не знаком с <paramref name="agent"/>.
        /// </summary>
        /// <param name="agent"></param>
        /// <returns></returns>
        protected float CalculateImportanceForStranger(AgentBase agent)
        {
            TryDiscoverAgentTraits(agent);
            //здесь какое-то отношение уже есть
            return CalculateImportanceForFamiliar(agent);
        }

        /// <summary>
        /// Есть ли влияние на важность для этой черты характера со стороны человека?
        /// Почему человек может быть интересен/вызывать интерес?
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected abstract bool CanBeImportantForAgent(AgentBase ab);

        /// <summary>
        /// Возвращает важность для этой черты характера, которую
        /// вызывает <paramref name="ab"/> в данный момент с учётом обстоятельств.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected float GetImportanceForAgent(AgentBase ab)
        {
            float res = default;
            //анализ уровня знакомства
            if (ThisAgent.RelationsSystem.GetCurrentRelationTo(ab) != null)
                res += CalculateImportanceForFamiliar(ab);
            else
                res += CalculateImportanceForStranger(ab);

            return res;
        }

        /// <summary>
        /// Список "интересующих" данную черту черт личности <paramref name="agent"/>.
        /// Это черты, коррелирующие с данной и включающие оценивающую.
        /// </summary>
        /// <param name="agent"></param>
        /// <returns></returns>
        protected virtual List<CharacterTraitBase> GetInterestedTraitsForCharacter(AgentBase agent) => default;//сделать abstract после компиляции

        protected float GetRecognitionChanceForMiddle()
        {
            if (CharacterValue == 1)
                return 0.4f;
            if (CharacterValue == -1)
                return 0.7f;
            if (CharacterValue == 0)
                return Random.Range(0f, 1f) >= 0.5f ? 0.5f : 0.6f;
            throw new Exception($"Неожиданное значение {nameof(CharacterValue)} для {ToString()}: {CharacterValue}");
        }

        /// <summary>
        /// Попробовать распознать "интересующие" черты <paramref name="agent"/> для данной черты характера.
        /// </summary>
        /// <param name="agent"></param>
        protected void TryDiscoverAgentTraits(AgentBase agent)
        {
            var potentialTraits = GetInterestedTraitsForCharacter(agent);
            var cs = agent.CharacterSystem;
            var selfControl = cs.Selfcontrol.RecognitionChance;
            var recognitionAbility = ThisAgent.CharacterSystem.RigiditySensetivity.RecognitionChance;
            if (selfControl - recognitionAbility > 0f)//восприятие выше скрытности - вероятность выше 0
            {
                var prob = recognitionAbility - selfControl;
                foreach (var tr in potentialTraits)
                {
                    var random = Random.Range(0f, 1f);
                    if (random <= prob)
                    {
                        //распознали - получаем новую информацию о человеке.
                        //он ещё не знаком, но впечатление составлено.
                        ThisAgent.RelationsSystem.AddInfoAboutAgentIfNew(agent, tr);
                    }
                }
            }
        }

        public int CharacterValue { get => characterValue; protected set => characterValue = Mathf.Clamp(value, 1, 10); }

        /// <summary>
        /// Значение важности явления <paramref name="phenomenon"/> для данной черты характера.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="phenomenon"></param>
        /// <returns></returns>
        public float GetImportanceValueFor<T>(T phenomenon) where T : IPhenomenon
        {
            if (phenomenon is AgentBase ab)
                return GetImportanceForAgent(ab);
            return ImportanceInfluencHandlersDict[typeof(T)];
        }

        public bool HasImportanceFor<T>(T phenomenon) where T : IPhenomenon
        {
            ///Оценивать человека каждый раз нужно по-новому
            if (phenomenon is AgentBase ab)
                return CanBeImportantForAgent(ab);
            ///Для простых вещей достаточно определённых простых реакций
            if (ImportanceInfluencHandlersDict.ContainsKey(typeof(T)))
                return true;
            return default;
        }

        /// <summary>
        /// Имеет ли данная черта характера отклик на <paramref name="action"/>?
        /// </summary>
        /// <param name="action">Явление, на которое может быть реакция</param>
        /// <param name="reaction">Реакция на <paramref name="action"/></param>
        /// <returns></returns>
        public virtual bool HasReactionOn<T>(T action, out List<EmotionBase> reaction) where T : IPhenomenon
        {
            reaction = default;
            return default;
        }

        public virtual void Initiate(int characterValue, AgentBase agent)
        {
            thisAgent = agent;
            CharacterValue = CalculateThisTraitValue(characterValue);
            ImportanceInfluencHandlersDict = new Dictionary<Type, float>();
            //ImportanceInfluencHandlersDict.Add(typeof(AgentBase), 5);
        }
    }
}