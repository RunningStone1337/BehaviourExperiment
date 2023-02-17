using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// ������ ������������� �������� � ����� ������� � ����������� ������������ ���������.
    /// ������ �������� - �������������, ���������� � ������ � ���������������. ������� �������� - �������������,
    /// ���������� � ��������� � �������.
    /// ��� ������� �������� ����������: ����������, ��������������, �������������, ��������������, ���������������,
    /// �����������, �����������, ���������� � �������������, ����������, � �������� ��������� � ������ �����.
    /// ��������� � ������������ �������������, ���������������� ���������.
    /// ��� �������� �������� ����������: �������������, ����������, ��������������, ����������������,
    /// ���������� � ��������������, �����������������, �������� � �����, ���������� � ���������� ������,
    /// ���������� � ���������� ���������� � ������, ���������� ���� �� ������.�������� � ������������ ����������������,
    /// ������������� ���������
    /// </summary>
    public abstract class ClosenessSociability<TAgent, TReaction, TFeature, TState, TSensor> : CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>
        , IComparable<ClosenessSociability<TAgent, TReaction, TFeature, TState, TSensor>>
         where TAgent : ICurrentStateHandler<TState> where TReaction : IReaction
         where TFeature : IFeature
         where TState : IState where TSensor : ISensor

    {
        public static bool operator <(ClosenessSociability<TAgent, TReaction, TFeature, TState, TSensor> c1, ClosenessSociability<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
        Char1LessChar2<LowClosenessSociability<TAgent, TReaction, TFeature, TState, TSensor>,
            MiddleClosenessSociability<TAgent, TReaction, TFeature, TState, TSensor>,
            HighClosenessSociability<TAgent, TReaction, TFeature, TState, TSensor>,
            ClosenessSociability<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator <=(ClosenessSociability<TAgent, TReaction, TFeature, TState, TSensor> c1, ClosenessSociability<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1LessOrEqualChar2<LowClosenessSociability<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleClosenessSociability<TAgent, TReaction, TFeature, TState, TSensor>,
                HighClosenessSociability<TAgent, TReaction, TFeature, TState, TSensor>,
                ClosenessSociability<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator >(ClosenessSociability<TAgent, TReaction, TFeature, TState, TSensor> c1, ClosenessSociability<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1MoreChar2<LowClosenessSociability<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleClosenessSociability<TAgent, TReaction, TFeature, TState, TSensor>,
                HighClosenessSociability<TAgent, TReaction, TFeature, TState, TSensor>,
                ClosenessSociability<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator >=(ClosenessSociability<TAgent, TReaction, TFeature, TState, TSensor> c1, ClosenessSociability<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1MoreOrEqualChar2<LowClosenessSociability<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleClosenessSociability<TAgent, TReaction, TFeature, TState, TSensor>,
                HighClosenessSociability<TAgent, TReaction, TFeature, TState, TSensor>,
                ClosenessSociability<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);
        public override void Initiate(int characterValue, TAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisCharType = CharTraitType.ClosenessSociability;
        }
        public int CompareTo(ClosenessSociability<TAgent, TReaction, TFeature, TState, TSensor> other)
        {
            if (this > other)
                return -1;
            if (this < other)
                return 1;
            return 0;
        }

        public override List<CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>> GetCorrelatedTraitsForCharacter(AgentBase<TAgent, TReaction, TFeature, TState, TSensor> agent)
        {
            var cs = agent.CharacterSystem;
            return new List<CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>>() {
                cs.ClosenessSociability,
                cs.ConservatismRadicalism,
                cs.ConformismNonconformism,
                cs.CredulitySuspicion,
                cs.StraightforwardnessDiplomacy,
                cs.TimidityCourage
            };
        }

        public override string ToString()
        {
            return $"����������-�������������: �������� {RawCharacterValue}, grade {CharacterGrade}";
        }
    }
}