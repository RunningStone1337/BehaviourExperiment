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
    public abstract class TimidityCourage<TReaction, TFeature, TState> :
        CharacterTraitBase<TReaction, TFeature, TState>, IComparable<TimidityCourage<TReaction, TFeature, TState>>
        where TReaction : IReaction
        where TFeature : IFeature where TState : IState
     
    {
        public static bool operator <(TimidityCourage<TReaction, TFeature, TState> c1,
            TimidityCourage<TReaction, TFeature, TState> c2) =>
         Char1LessChar2<LowCourage<TReaction, TFeature, TState>,
             MiddleCourage<TReaction, TFeature, TState>,
             HighCourage<TReaction, TFeature, TState>,
             TimidityCourage<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator <=(TimidityCourage<TReaction, TFeature, TState> c1,
            TimidityCourage<TReaction, TFeature, TState> c2) =>
            Char1LessOrEqualChar2<LowCourage<TReaction, TFeature, TState>,
                MiddleCourage<TReaction, TFeature, TState>,
                HighCourage<TReaction, TFeature, TState>,
                TimidityCourage<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator >(TimidityCourage<TReaction, TFeature, TState> c1,
            TimidityCourage<TReaction, TFeature, TState> c2) =>
            Char1MoreChar2<LowCourage<TReaction, TFeature, TState>,
                MiddleCourage<TReaction, TFeature, TState>,
                HighCourage<TReaction, TFeature, TState>,
                TimidityCourage<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator >=(TimidityCourage<TReaction, TFeature, TState> c1,
            TimidityCourage<TReaction, TFeature, TState> c2) =>
            Char1MoreOrEqualChar2<LowCourage<TReaction, TFeature, TState>,
                MiddleCourage<TReaction, TFeature, TState>,
                HighCourage<TReaction, TFeature, TState>,
                TimidityCourage<TReaction, TFeature, TState>>(c1, c2);
        public int CompareTo(TimidityCourage<TReaction, TFeature, TState> other)
        {
            if (this > other)
                return -1;
            if (this < other)
                return 1;
            return 0;
        }

        public override List<CharacterTraitBase<TReaction, TFeature, TState>>
            GetInterestedTraitsForCharacter(AgentBase<TReaction, TFeature, TState> agent)
        {
            var cs = agent.CharacterSystem;
            return new List<CharacterTraitBase<TReaction, TFeature, TState>>()
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