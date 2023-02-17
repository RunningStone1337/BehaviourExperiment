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
    public abstract class SubordinationDomination<TAgent, TReaction, TFeature, TState, TSensor> : CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>,
        IComparable<SubordinationDomination<TAgent, TReaction, TFeature, TState, TSensor>>
         where TAgent : ICurrentStateHandler<TState> where TReaction : IReaction
         where TFeature : IFeature where TState : IState where TSensor : ISensor
    {
        public static bool operator <(SubordinationDomination<TAgent, TReaction, TFeature, TState, TSensor> c1,
            SubordinationDomination<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
         Char1LessChar2<LowDomination<TAgent, TReaction, TFeature, TState, TSensor>,
             MiddleDomination<TAgent, TReaction, TFeature, TState, TSensor>,
             HighDomination<TAgent, TReaction, TFeature, TState, TSensor>,
             SubordinationDomination<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator <=(SubordinationDomination<TAgent, TReaction, TFeature, TState, TSensor> c1,
            SubordinationDomination<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1LessOrEqualChar2<LowDomination<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleDomination<TAgent, TReaction, TFeature, TState, TSensor>,
                HighDomination<TAgent, TReaction, TFeature, TState, TSensor>,
                SubordinationDomination<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator >(SubordinationDomination<TAgent, TReaction, TFeature, TState, TSensor> c1,
            SubordinationDomination<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1MoreChar2<LowDomination<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleDomination<TAgent, TReaction, TFeature, TState, TSensor>,
                HighDomination<TAgent, TReaction, TFeature, TState, TSensor>,
                SubordinationDomination<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator >=(SubordinationDomination<TAgent, TReaction, TFeature, TState, TSensor> c1,
            SubordinationDomination<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1MoreOrEqualChar2<LowDomination<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleDomination<TAgent, TReaction, TFeature, TState, TSensor>,
                HighDomination<TAgent, TReaction, TFeature, TState, TSensor>,
                SubordinationDomination<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public int CompareTo(SubordinationDomination<TAgent, TReaction, TFeature, TState, TSensor> other)
        {
            if (this > other)
                return -1;
            if (this < other)
                return 1;
            return 0;
        }

        public override List<CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>>
            GetCorrelatedTraitsForCharacter(AgentBase<TAgent, TReaction, TFeature, TState, TSensor> agent)
        {
            var cs = agent.CharacterSystem;
            return new List<CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>>()
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