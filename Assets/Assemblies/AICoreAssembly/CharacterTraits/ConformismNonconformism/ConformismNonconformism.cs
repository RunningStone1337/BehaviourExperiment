using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// ������� �������������, ������� �� ������ ������ �����.
    /// ��� ������� �������� ����������: ����������� �� ������ � ���������� ������, ��������������, ���������� �� ������������ �������, ���������� �������� � ��������� ������� ������ � ������� ������, ������ �����������������, ���������� �� ���������� ���������.
    /// ��� �������� �������� ����������: �������������, ���������� �� ����������� �������,
    /// �����������������, ������������, ���������� ����� ����������� ������.
    /// ��� ������� ������� ������� ���������� � ������������������ ���� ������ � ������� � ��� ������������.
    /// ������ ������ �� ����� ������� ����� �������� �����������, ��� ������� ����� ������ ��������� ��������,
    /// ��� �������� ����.
    /// ������� ������ ����� ����, ������� ����� ��������� � ������� � �� ���� ������� �������� ���������������� � ��������,
    /// ������ � �����������.
    /// </summary>
    public abstract class ConformismNonconformism<TAgent, TReaction, TFeature, TState, TSensor> : CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>,
        IComparable<ConformismNonconformism<TAgent, TReaction, TFeature, TState, TSensor>>
        where TAgent : ICurrentStateHandler<TState> 
        where TReaction : IReaction
         where TFeature : IFeature
        where TState : IState where TSensor : ISensor
    {
        public static bool operator <(ConformismNonconformism<TAgent, TReaction, TFeature, TState, TSensor> c1,
            ConformismNonconformism<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
         Char1LessChar2<LowNonconformism<TAgent, TReaction, TFeature, TState, TSensor>,
             MiddleNonconformism<TAgent, TReaction, TFeature, TState, TSensor>,
             HighNonconformism<TAgent, TReaction, TFeature, TState, TSensor>,
             ConformismNonconformism<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator <=(ConformismNonconformism<TAgent, TReaction, TFeature, TState, TSensor> c1,
            ConformismNonconformism<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1LessOrEqualChar2<LowNonconformism<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleNonconformism<TAgent, TReaction, TFeature, TState, TSensor>,
                HighNonconformism<TAgent, TReaction, TFeature, TState, TSensor>,
                ConformismNonconformism<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator >(ConformismNonconformism<TAgent, TReaction, TFeature, TState, TSensor> c1,
            ConformismNonconformism<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1MoreChar2<LowNonconformism<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleNonconformism<TAgent, TReaction, TFeature, TState, TSensor>,
                HighNonconformism<TAgent, TReaction, TFeature, TState, TSensor>,
                ConformismNonconformism<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator >=(ConformismNonconformism<TAgent, TReaction, TFeature, TState, TSensor> c1,
            ConformismNonconformism<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1MoreOrEqualChar2<LowNonconformism<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleNonconformism<TAgent, TReaction, TFeature, TState, TSensor>,
                HighNonconformism<TAgent, TReaction, TFeature, TState, TSensor>,
                ConformismNonconformism<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public int CompareTo(ConformismNonconformism<TAgent, TReaction, TFeature, TState, TSensor> other)
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
            ThisCharType = CharTraitType.ConformismNonconformism;
        }
        public override List<CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>>
            GetCorrelatedTraitsForCharacter(AgentBase<TAgent, TReaction, TFeature, TState, TSensor> agent)
        {
            var cs = agent.CharacterSystem;
            return new List<CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>>() {
                cs.ConformismNonconformism,
                cs.ClosenessSociability,
                cs.ConservatismRadicalism,
                cs.Intelligence,
                cs.NormativityOfBehaviour,
                cs.PracticalityDreaminess,
                cs.Selfcontrol,
                cs.StraightforwardnessDiplomacy,
                cs.SubordinationDomination,
                cs.TimidityCourage,
            };
        }

        public override string ToString()
        {
            return $"����������-��������������: �������� {RawCharacterValue}, grade {CharacterGrade}";
        }
    }
}