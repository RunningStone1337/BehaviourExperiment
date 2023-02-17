using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// ��� ������� �������� ����������: �������, �������������, ������������� ������������,
    /// ������������, ���������� �����������, ������������, �������������� � ������, ���������� ���������������� � ������,
    /// ������������ ��������������� ����� ������������ � ������� � ����� ������ (2�3 ��������).
    /// ��� �������� �������� ����������: ��������, ����������������, ����������;
    /// ������� ����� ������������� ��������, ���������� � ����� � �������������� � ����������� ������
    /// � ���������� ���������������, ����������� ��������� ���������������, ������������ �������,
    /// ���������� � ����������� � ���������� ��������� �������.
    /// ������ H � ����� ������������ ������, ������� ������������� ������� ���������� � ���������� ���������.
    /// ��� ���� ���� ���������, ��� ���� ������ ����� ������������ ������������� � �������� ����������
    /// ��������� � ����������� ������������.���� � �������� �������� ����� ������� ����� ���������� � ���������� �����
    /// (�������-����������), ������, �����������, ����� ����������� ������������� ��������, ��� ����� ������ �� ��������.
    /// ������ ������ ����� ������� ������������� ����� �����������, ������, �� ������������,
    /// ������ ����������� ��������������� �������.
    /// </summary>
    public abstract class TimidityCourage<TAgent, TReaction, TFeature, TState, TSensor> :
        CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>, IComparable<TimidityCourage<TAgent, TReaction, TFeature, TState, TSensor>>
        where TAgent : ICurrentStateHandler<TState> where TReaction : IReaction
        where TFeature : IFeature where TState : IState where TSensor : ISensor

    {
        public static bool operator <(TimidityCourage<TAgent, TReaction, TFeature, TState, TSensor> c1,
            TimidityCourage<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
         Char1LessChar2<LowCourage<TAgent, TReaction, TFeature, TState, TSensor>,
             MiddleCourage<TAgent, TReaction, TFeature, TState, TSensor>,
             HighCourage<TAgent, TReaction, TFeature, TState, TSensor>,
             TimidityCourage<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator <=(TimidityCourage<TAgent, TReaction, TFeature, TState, TSensor> c1,
            TimidityCourage<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1LessOrEqualChar2<LowCourage<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleCourage<TAgent, TReaction, TFeature, TState, TSensor>,
                HighCourage<TAgent, TReaction, TFeature, TState, TSensor>,
                TimidityCourage<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator >(TimidityCourage<TAgent, TReaction, TFeature, TState, TSensor> c1,
            TimidityCourage<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1MoreChar2<LowCourage<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleCourage<TAgent, TReaction, TFeature, TState, TSensor>,
                HighCourage<TAgent, TReaction, TFeature, TState, TSensor>,
                TimidityCourage<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator >=(TimidityCourage<TAgent, TReaction, TFeature, TState, TSensor> c1,
            TimidityCourage<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1MoreOrEqualChar2<LowCourage<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleCourage<TAgent, TReaction, TFeature, TState, TSensor>,
                HighCourage<TAgent, TReaction, TFeature, TState, TSensor>,
                TimidityCourage<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public int CompareTo(TimidityCourage<TAgent, TReaction, TFeature, TState, TSensor> other)
        {
            if (this > other)
                return -1;
            if (this < other)
                return 1;
            return 0;
        }
        public override void Initiate(int characterValue, TAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisCharType = CharTraitType.TimidityCourage;
        }
        public override List<CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>>
            GetCorrelatedTraitsForCharacter(AgentBase<TAgent, TReaction, TFeature, TState, TSensor> agent)
        {
            var cs = agent.CharacterSystem;
            return new List<CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>>()
            {
                cs.TimidityCourage,
                cs.ClosenessSociability,
                cs.PracticalityDreaminess,
                cs.RelaxationTension,
                cs.StraightforwardnessDiplomacy
            };
        }

        public override string ToString()
        {
            return $"�������-��������: �������� {RawCharacterValue}, grade {CharacterGrade}";
        }
    }
}