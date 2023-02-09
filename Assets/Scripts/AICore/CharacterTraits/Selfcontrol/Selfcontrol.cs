using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// ��� ������� �������� ����������: ������ ��������������������, ������� ����� ��������,
    /// ����������� �� ����������, �������� �������������� ���� ������ � ���������.
    /// ��� �������� �������� ����������: ������������������, ������� ����, ������ �������������� ���� ������ � ���������.
    /// ������ ������ �� ����� ������� ��������� �� ������ ���� � ������ ������������.
    /// ������������ ����� ����� ������������� � �����������.�������� � �������� �������� �� ����� �������
    /// ����� ��������� ���������� ��������������: ������������, �������������, ��������������, ����������
    /// � ���������� �������. ��� ����, ����� ��������������� ����� ����������, �� �������� ��������� ����������
    /// ������������ ������, ������� ������ ���������, ��������� � ���� ������������� ������.
    /// ���� ������ �������� ������� ����������� �������� ���������, ����������������� ��������.
    /// </summary>
    public abstract class Selfcontrol<TReaction, TFeature, TState> : CharacterTraitBase<TReaction, TFeature, TState>,
        IComparable<Selfcontrol<TReaction, TFeature, TState>>
         where TReaction : IReaction
         where TFeature : IFeature where TState : IState
    {
        

        public static bool operator <(Selfcontrol<TReaction, TFeature, TState> c1,
                    Selfcontrol<TReaction, TFeature, TState> c2) =>
         Char1LessChar2<LowSelfcontrol<TReaction, TFeature, TState>,
             MiddleSelfcontrol<TReaction, TFeature, TState>,
             HighSelfcontrol<TReaction, TFeature, TState>,
             Selfcontrol<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator <=(Selfcontrol<TReaction, TFeature, TState> c1,
            Selfcontrol<TReaction, TFeature, TState> c2) =>
            Char1LessOrEqualChar2<LowSelfcontrol<TReaction, TFeature, TState>,
                MiddleSelfcontrol<TReaction, TFeature, TState>,
                HighSelfcontrol<TReaction, TFeature, TState>,
                Selfcontrol<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator >(Selfcontrol<TReaction, TFeature, TState> c1,
            Selfcontrol<TReaction, TFeature, TState> c2) =>
            Char1MoreChar2<LowSelfcontrol<TReaction, TFeature, TState>,
                MiddleSelfcontrol<TReaction, TFeature, TState>,
                HighSelfcontrol<TReaction, TFeature, TState>,
                Selfcontrol<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator >=(Selfcontrol<TReaction, TFeature, TState> c1,
            Selfcontrol<TReaction, TFeature, TState> c2) =>
            Char1MoreOrEqualChar2<LowSelfcontrol<TReaction, TFeature, TState>,
                MiddleSelfcontrol<TReaction, TFeature, TState>,
                HighSelfcontrol<TReaction, TFeature, TState>,
                Selfcontrol<TReaction, TFeature, TState>>(c1, c2);

        public int CompareTo(Selfcontrol<TReaction, TFeature, TState> other)
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
                cs.Selfcontrol,
                cs.EmotionalInstabilityStability,
                cs.Selfcontrol,
                cs.RestraintExpressiveness,
                cs.RigiditySensetivity,
                cs.SubordinationDomination
            };
        }
        public override string ToString()
        {
            return $"������������: �������� {RawCharacterValue}, grade {CharacterGrade}";
        }
    }
}