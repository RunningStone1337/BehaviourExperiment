using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// ��� ������� �������� ����������: ������������, ������������, ���������������� � ������ �������� �� �������.
    /// ���������� � �������������, ������������ � �������, ���������������� � ���������� ����������������,
    /// ������������ � ���������� ������.
    /// ��� �������� �������� ����������: ����������������, ��������������, ��������������, �����������,
    /// �������������� � ������ ��������� �� �������, ������������� ���������� ���������� ���������,
    /// ���������������, ��������������, ������������� ������� � ���������� ����� ������, ������������ �������,
    /// ������� ������������ ������������� ��������� � �������
    /// ������ ������ ������������ ����� ��������� �������� ������� ������� ��������� ������� ��������.
    /// ��������� ��� ����, ��� � ������ ���������� �������������� � ����������� ���������� ���������,
    /// ��� ����� ������������� ��� ������������� ������������ ������������� ��������.
    /// � ����� ������ F ������������ �� ��������� ������������� ������������ � ������������ � ��������� �������.
    /// ������: ������, ����������� ������ ����� ����� ������� ������, ���������, ������������� � ����� ������.
    /// </summary>
    public abstract class RestraintExpressiveness<TReaction, TFeature, TState> : CharacterTraitBase<TReaction, TFeature, TState>,
        IComparable<RestraintExpressiveness<TReaction, TFeature, TState>>
         where TReaction : IReaction
         where TFeature : IFeature where TState : IState
    {
        public static bool operator <(RestraintExpressiveness<TReaction, TFeature, TState> c1,
            RestraintExpressiveness<TReaction, TFeature, TState> c2) =>
         Char1LessChar2<LowExpressiveness<TReaction, TFeature, TState>,
             MiddleExpressiveness<TReaction, TFeature, TState>,
             HighExpressiveness<TReaction, TFeature, TState>,
             RestraintExpressiveness<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator <=(RestraintExpressiveness<TReaction, TFeature, TState> c1,
            RestraintExpressiveness<TReaction, TFeature, TState> c2) =>
            Char1LessOrEqualChar2<LowExpressiveness<TReaction, TFeature, TState>,
                MiddleExpressiveness<TReaction, TFeature, TState>,
                HighExpressiveness<TReaction, TFeature, TState>,
                RestraintExpressiveness<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator >(RestraintExpressiveness<TReaction, TFeature, TState> c1,
            RestraintExpressiveness<TReaction, TFeature, TState> c2) =>
            Char1MoreChar2<LowExpressiveness<TReaction, TFeature, TState>,
                MiddleExpressiveness<TReaction, TFeature, TState>,
                HighExpressiveness<TReaction, TFeature, TState>,
                RestraintExpressiveness<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator >=(RestraintExpressiveness<TReaction, TFeature, TState> c1,
            RestraintExpressiveness<TReaction, TFeature, TState> c2) =>
            Char1MoreOrEqualChar2<LowExpressiveness<TReaction, TFeature, TState>,
                MiddleExpressiveness<TReaction, TFeature, TState>,
                HighExpressiveness<TReaction, TFeature, TState>,
                RestraintExpressiveness<TReaction, TFeature, TState>>(c1, c2);
        public int CompareTo(RestraintExpressiveness<TReaction, TFeature, TState> other)
        {
            if (this > other)
                return -1;
            if (this < other)
                return 1;
            return 0;
        }
        public override List<CharacterTraitBase<TReaction, TFeature, TState> >
            GetInterestedTraitsForCharacter(AgentBase<TReaction, TFeature, TState> agent)
        {
            var cs = agent.CharacterSystem;
            return new List<CharacterTraitBase<TReaction, TFeature, TState> >()
            {
                cs.RestraintExpressiveness,
                cs.CalmnessAnxiety,
                cs.EmotionalInstabilityStability,
                cs.NormativityOfBehaviour,
                cs.RelaxationTension,
                cs.Selfcontrol,
                cs.StraightforwardnessDiplomacy
            };
        }
        public override string ToString()
        {
            return $"���������������: �������� {RawCharacterValue}, grade {CharacterGrade}";
        }
    }
}