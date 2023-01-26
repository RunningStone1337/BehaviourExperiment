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

        protected AgentBase ThisAgent => thisAgent;

        #region operators overloading

        /// <summary>
        /// ������������� �������� ��������� ���� ���� ���������
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
        /// �������� �������� <paramref name="agent"/> ��� ����� ���������
        /// � ����������� �� ������ ���������� � <paramref name="agent"/>.
        /// </summary>
        /// <param name="agent"></param>
        /// <returns></returns>
        protected virtual float CalculateImportanceForFamiliar(AgentBase agent)=>default;//������� abstract ����� ����������

        /// <summary>
        /// �������� �������� <paramref name="agent"/> ��� ����� ���������
        /// ��� ������� ��� ����� �� ������ � <paramref name="agent"/>.
        /// </summary>
        /// <param name="agent"></param>
        /// <returns></returns>
        protected float CalculateImportanceForStranger(AgentBase agent)
        {
            TryDiscoverAgentTraits(agent);
            //����� �����-�� ��������� ��� ����
            return CalculateImportanceForFamiliar(agent);
        }

        /// <summary>
        /// ���� �� ������� �� �������� ��� ���� ����� ��������� �� ������� ��������?
        /// ������ ������� ����� ���� ���������/�������� �������?
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected abstract bool CanBeImportantForAgent(AgentBase ab);

        /// <summary>
        /// ���������� �������� ��� ���� ����� ���������, �������
        /// �������� <paramref name="ab"/> � ������ ������ � ������ �������������.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected float GetImportanceForAgent(AgentBase ab)
        {
            float res = default;
            //������ ������ ����������
            if (ThisAgent.RelationsSystem.GetCurrentRelationTo(ab) != null)
                res += CalculateImportanceForFamiliar(ab);
            else
                res += CalculateImportanceForStranger(ab);

            return res;
        }

        /// <summary>
        /// ������ "������������" ������ ����� ���� �������� <paramref name="agent"/>.
        /// ��� �����, ������������� � ������ � ���������� �����������.
        /// </summary>
        /// <param name="agent"></param>
        /// <returns></returns>
        protected virtual List<CharacterTraitBase> GetInterestedTraitsForCharacter(AgentBase agent) => default;//������� abstract ����� ����������

        protected float GetRecognitionChanceForMiddle()
        {
            if (CharacterValue == 1)
                return 0.4f;
            if (CharacterValue == -1)
                return 0.7f;
            if (CharacterValue == 0)
                return Random.Range(0f, 1f) >= 0.5f ? 0.5f : 0.6f;
            throw new Exception($"����������� �������� {nameof(CharacterValue)} ��� {ToString()}: {CharacterValue}");
        }

        /// <summary>
        /// ����������� ���������� "������������" ����� <paramref name="agent"/> ��� ������ ����� ���������.
        /// </summary>
        /// <param name="agent"></param>
        protected void TryDiscoverAgentTraits(AgentBase agent)
        {
            var potentialTraits = GetInterestedTraitsForCharacter(agent);
            var cs = agent.CharacterSystem;
            var selfControl = cs.Selfcontrol.RecognitionChance;
            var recognitionAbility = ThisAgent.CharacterSystem.RigiditySensetivity.RecognitionChance;
            if (selfControl - recognitionAbility > 0f)//���������� ���� ���������� - ����������� ���� 0
            {
                var prob = recognitionAbility - selfControl;
                foreach (var tr in potentialTraits)
                {
                    var random = Random.Range(0f, 1f);
                    if (random <= prob)
                    {
                        //���������� - �������� ����� ���������� � ��������.
                        //�� ��� �� ������, �� ����������� ����������.
                        ThisAgent.RelationsSystem.AddInfoAboutAgentIfNew(agent, tr);
                    }
                }
            }
        }

        public int CharacterValue { get => characterValue; protected set => characterValue = Mathf.Clamp(value, 1, 10); }

        /// <summary>
        /// �������� �������� ������� <paramref name="phenomenon"/> ��� ������ ����� ���������.
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
            ///��������� �������� ������ ��� ����� ��-������
            if (phenomenon is AgentBase ab)
                return CanBeImportantForAgent(ab);
            ///��� ������� ����� ���������� ����������� ������� �������
            if (ImportanceInfluencHandlersDict.ContainsKey(typeof(T)))
                return true;
            return default;
        }

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