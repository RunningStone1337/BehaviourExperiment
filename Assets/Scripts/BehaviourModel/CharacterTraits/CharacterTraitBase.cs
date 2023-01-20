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
        /// ��������� �������� ���������:
        /// ������ �����: 1:3
        /// ������� �����: -1:1
        /// ������� �����: 1:3
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
                    return 4 - characterValue;//0 ��� -1
                else//6 7
                    return characterValue - 6;//0 ��� 1
            }
            else if (characterValue > 7)
                return characterValue - 7;
            else throw new ArgumentOutOfRangeException($"{nameof(characterValue)} was out of range [1;10] with value {characterValue}");
        }

        protected Dictionary<Type, float> ImportanceInfluencHandlersDict { get; set; }
        public int CharacterValue { get => characterValue; protected set => characterValue = Mathf.Clamp(value, 1, 10); }

        /// <summary>
        /// �������� �������� ������� <paramref name="phenomenon"/> ��� ������ ����� ���������.
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
        /// ���������� �������� ��� ���� ����� ���������, �������
        /// �������� <paramref name="ab"/> � ������ ������ � ������ �������������.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected abstract float GetImportanceForAgent(AgentBase ab);

        public virtual bool HasImportanceFor<T>(T phenomenon) where T : IPhenomenon
        {
            ///��������� �������� ������ ��� ����� ��-������
            if (phenomenon is AgentBase ab)
                return CanBeImportantForAgent(ab);
            ///��� ������� ����� ���������� ����������� ������� �������
            if (ImportanceInfluencHandlersDict.ContainsKey(typeof(T)))
                return true;
            return default;
        }

        /// <summary>
        /// ���� �� ������� �� �������� ��� ���� ����� ��������� �� ������� ��������?
        /// ������ ������� ����� ���� ���������/�������� �������?
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected abstract bool CanBeImportantForAgent(AgentBase ab);

        /// <summary>
        /// ����� �� ������ ����� ��������� ������ �� <paramref name="action"/>?
        /// </summary>
        /// <param name="action">�������, �� ������� ����� ���� �������</param>
        /// <param name="reaction">������� �� <paramref name="action"/></param>
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