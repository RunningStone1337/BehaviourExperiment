using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// ��� ������� �������� ����������: ��������, ������������, �����������,
    /// ���������, ����������, �����������, �������������, ������������, ��������������, �������������,
    /// ���������� ����� ���� �� ����, ����������, ���������������, ���������� ����� �������� �� ����������.
    /// ��� �������� �������� ����������: �����������������, �������������, �������������, ���������, ������������,
    /// ����������, ������ �������������, �������������, ����� �� ��������� ������� ������, ���������� � ������������� ���������,
    /// ����� ����������, �������.
    /// ������ � �� ����� ����������� ����������� � ������������ ���������,
    /// ������ ������ � ���������� �������� � ���� � �������, ��� � ��������������.
    /// ���������� �������������, ��� ������ �� ����� ������� � ��������� �������� � ������� �� ���� �����������.
    /// � ����� ��������� ���� � �������� �������� (�� ����� �������) ���������� ����������� � ���������.
    /// </summary>
    public abstract class SubordinationDomination<TReaction, TFeature, TState> : CharacterTraitBase<TReaction, TFeature, TState>,
        IComparable<SubordinationDomination<TReaction, TFeature, TState>>
         where TReaction : IReaction
         where TFeature : IFeature where TState : IState
    {
        public static bool operator <(SubordinationDomination<TReaction, TFeature, TState> c1,
            SubordinationDomination<TReaction, TFeature, TState> c2) =>
         Char1LessChar2<LowDomination<TReaction, TFeature, TState>,
             MiddleDomination<TReaction, TFeature, TState>,
             HighDomination<TReaction, TFeature, TState>,
             SubordinationDomination<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator <=(SubordinationDomination<TReaction, TFeature, TState> c1,
            SubordinationDomination<TReaction, TFeature, TState> c2) =>
            Char1LessOrEqualChar2<LowDomination<TReaction, TFeature, TState>,
                MiddleDomination<TReaction, TFeature, TState>,
                HighDomination<TReaction, TFeature, TState>,
                SubordinationDomination<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator >(SubordinationDomination<TReaction, TFeature, TState> c1,
            SubordinationDomination<TReaction, TFeature, TState> c2) =>
            Char1MoreChar2<LowDomination<TReaction, TFeature, TState>,
                MiddleDomination<TReaction, TFeature, TState>,
                HighDomination<TReaction, TFeature, TState>,
                SubordinationDomination<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator >=(SubordinationDomination<TReaction, TFeature, TState> c1,
            SubordinationDomination<TReaction, TFeature, TState> c2) =>
            Char1MoreOrEqualChar2<LowDomination<TReaction, TFeature, TState>,
                MiddleDomination<TReaction, TFeature, TState>,
                HighDomination<TReaction, TFeature, TState>,
                SubordinationDomination<TReaction, TFeature, TState>>(c1, c2);
        public int CompareTo(SubordinationDomination<TReaction, TFeature, TState> other)
        {
            if (this > other)
                return -1;
            if (this < other)
                return 1;
            return 0;
        }

        public override List<CharacterTraitBase<TReaction, TFeature, TState> >
            GetInterestedTraitsForCharacter(AgentBase<TReaction, TFeature, TState>agent)
        {
            var cs = agent.CharacterSystem;
            return new List<CharacterTraitBase<TReaction, TFeature, TState> >()
            {
      cs.SubordinationDomination,
                cs.ConformismNonconformism,
                cs.CredulitySuspicion,
                cs.EmotionalInstabilityStability,
                cs.RelaxationTension,
                cs.RigiditySensetivity,
                cs.TimidityCourage,
            };
        }
      
                
        public override string ToString()
        {
            return $"����������-�������������: �������� {RawCharacterValue}, grade {CharacterGrade}";
        }
    }
}