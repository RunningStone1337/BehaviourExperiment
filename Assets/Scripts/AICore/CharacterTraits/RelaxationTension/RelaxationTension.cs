using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// ��� ������� �������� ����������: ���������������, �������, �����������, �����������,
    /// ������ ���������, �������� �����������������, ��������������.
    /// ��� �������� �������� ����������: �����������, ������������, �������������, �����������������,
    /// ���������� ���������, ������������, �������������, �����������������.
    /// ������� ������ ���������������� ��� �������������� ��������������, ������� �������
    /// ������������ ��������; ������ ��� ��������� ����� ������������ � ����������������� ���������:
    /// ��������� ������������� ������������, ���������� ����������, ����� ����������� �������������.
    /// ����� ���� ����� ���������� ��������.
    /// ������������ ��������, ��� ������ ������ (0�5 ������) ���������� ��� ����� � ��������� �������
    /// ��������� ����������, ���������������� ���������. ���� �� ���������� ����� ������� �� 5 �� 8 ������
    /// ��������������� ����������� ������������� ������� � ��������������������.
    /// </summary>
    public abstract class RelaxationTension<TReaction, TFeature, TState> : CharacterTraitBase<TReaction, TFeature, TState>,
        IComparable<RelaxationTension<TReaction, TFeature, TState>>
         where TReaction : IReaction
         where TFeature : IFeature where TState : IState
    {
        public static bool operator <(RelaxationTension<TReaction, TFeature, TState> c1,
            RelaxationTension<TReaction, TFeature, TState> c2) =>
         Char1LessChar2<LowTension<TReaction, TFeature, TState>,
             MiddleTension<TReaction, TFeature, TState>,
             HighTension<TReaction, TFeature, TState>,
             RelaxationTension<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator <=(RelaxationTension<TReaction, TFeature, TState> c1,
            RelaxationTension<TReaction, TFeature, TState> c2) =>
            Char1LessOrEqualChar2<LowTension<TReaction, TFeature, TState>,
                MiddleTension<TReaction, TFeature, TState>,
                HighTension<TReaction, TFeature, TState>,
                RelaxationTension<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator >(RelaxationTension<TReaction, TFeature, TState> c1,
            RelaxationTension<TReaction, TFeature, TState> c2) =>
            Char1MoreChar2<LowTension<TReaction, TFeature, TState>,
                MiddleTension<TReaction, TFeature, TState>,
                HighTension<TReaction, TFeature, TState>,
                RelaxationTension<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator >=(RelaxationTension<TReaction, TFeature, TState> c1,
            RelaxationTension<TReaction, TFeature, TState> c2) =>
            Char1MoreOrEqualChar2<LowTension<TReaction, TFeature, TState>,
                MiddleTension<TReaction, TFeature, TState>,
                HighTension<TReaction, TFeature, TState>,
                RelaxationTension<TReaction, TFeature, TState>>(c1, c2);
        public int CompareTo(RelaxationTension<TReaction, TFeature, TState> other)
        {
            if (this > other)
                return -1;
            if (this < other)
                return 1;
            return 0;
        }
        public override string ToString()
        {
            return $"���������������-�������������: �������� {RawCharacterValue}, grade {CharacterGrade}";
        }
        public override List<CharacterTraitBase<TReaction, TFeature, TState> > 
            GetInterestedTraitsForCharacter(AgentBase<TReaction, TFeature, TState> agent)
        {
            var cs = agent.CharacterSystem;
            return new List<CharacterTraitBase<TReaction, TFeature, TState> >() { 
                cs.RelaxationTension,
                cs.CalmnessAnxiety,
                cs.ConservatismRadicalism,
                cs.CredulitySuspicion,
                cs.EmotionalInstabilityStability,
                cs.RestraintExpressiveness,
                cs.SubordinationDomination,
                cs.TimidityCourage
            };
        }
    }
}