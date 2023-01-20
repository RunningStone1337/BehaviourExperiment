using System;
using System.Collections.Generic;
using UnityEngine;

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
        public int CharacterValue { get => characterValue; protected set => characterValue = Mathf.Clamp(value, 1, 10); }

        /// <summary>
        /// Значение важности явления <paramref name="phenomenon"/> для данной черты характера.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="phenomenon"></param>
        /// <returns></returns>
        public virtual float GetImportanceValueFor<T>(T phenomenon) where T : IPhenomenon
        {
            if (phenomenon is AgentBase ab)
                return GetImportanceForAgent(ab);
            return ImportanceInfluencHandlersDict[typeof(T)];
        }
        /// <summary>
        /// Возвращает важность для этой черты характера, которую
        /// вызывает <paramref name="ab"/> в данный момент с учётом обстоятельств.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected abstract float GetImportanceForAgent(AgentBase ab);

        public virtual bool HasImportanceFor<T>(T phenomenon) where T : IPhenomenon
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
        /// Есть ли влияние на важность для этой черты характера со стороны человека?
        /// Почему человек может быть интересен/вызывать интерес?
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected abstract bool CanBeImportantForAgent(AgentBase ab);

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