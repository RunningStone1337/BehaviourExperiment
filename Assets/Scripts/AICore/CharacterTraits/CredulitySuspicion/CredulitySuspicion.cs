using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// ������������-����������������.
    /// ��� ������� �������� ����������: ����������, �����������, ����������, �������������;
    /// ������� �� �������, ������������. ����� ���� ������� ����������� ����������������.
    /// ��� �������� �������� ����������: ������������, ���������������, ��������������� �� ��������� � �����;
    /// ���������� � ��������, ���������� ��������� ��������������� �� ������ �� ����������,
    /// �����������������.������ ������������, ����������������� � ������������� � ���������� ���������.
    /// � ����� ������ �������� ������������� ��������� � �����.
    /// ����� ������� ������ �� ����� ������� ������� �� �������� ������ � ������������� �������������,
    /// ����������������� ��������. ������ ����� ������������� �������� �����������, �� �������� � �����������.
    /// </summary>
    public abstract class CredulitySuspicion<TReaction, TFeature, TState> : CharacterTraitBase<TReaction, TFeature, TState>,
        IComparable<CredulitySuspicion<TReaction, TFeature, TState>>
         where TReaction : IReaction
         where TFeature : IFeature
        where TState : IState
    {
        public static bool operator <(CredulitySuspicion<TReaction, TFeature, TState> c1,
            CredulitySuspicion<TReaction, TFeature, TState> c2) =>
         Char1LessChar2<LowSuspicion<TReaction, TFeature, TState>,
             MiddleSuspicion<TReaction, TFeature, TState>,
             HighSuspicion<TReaction, TFeature, TState>,
             CredulitySuspicion<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator <=(CredulitySuspicion<TReaction, TFeature, TState> c1,
            CredulitySuspicion<TReaction, TFeature, TState> c2) =>
            Char1LessOrEqualChar2<LowSuspicion<TReaction, TFeature, TState>,
                MiddleSuspicion<TReaction, TFeature, TState>,
                HighSuspicion<TReaction, TFeature, TState>,
                CredulitySuspicion<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator >(CredulitySuspicion<TReaction, TFeature, TState> c1,
            CredulitySuspicion<TReaction, TFeature, TState> c2) =>
            Char1MoreChar2<LowSuspicion<TReaction, TFeature, TState>,
                MiddleSuspicion<TReaction, TFeature, TState>,
                HighSuspicion<TReaction, TFeature, TState>,
                CredulitySuspicion<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator >=(CredulitySuspicion<TReaction, TFeature, TState> c1,
            CredulitySuspicion<TReaction, TFeature, TState> c2) =>
            Char1MoreOrEqualChar2<LowSuspicion<TReaction, TFeature, TState>,
                MiddleSuspicion<TReaction, TFeature, TState>,
                HighSuspicion<TReaction, TFeature, TState>,
                CredulitySuspicion<TReaction, TFeature, TState>>(c1, c2);
        public int CompareTo(CredulitySuspicion<TReaction, TFeature, TState> other)
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
            return new List<CharacterTraitBase<TReaction, TFeature, TState> >() {
                cs.CredulitySuspicion,
                cs.CalmnessAnxiety,
                cs.ClosenessSociability,
                cs.ConservatismRadicalism,
                cs.EmotionalInstabilityStability,
                cs.RestraintExpressiveness,
                cs.RigiditySensetivity,
                cs.Selfcontrol,
                cs.StraightforwardnessDiplomacy
            };
        }
        public override string ToString()
        {
            return $"������������-����������������: �������� {RawCharacterValue}, grade {CharacterGrade}";
        }
    }
}