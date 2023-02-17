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
    public abstract class CredulitySuspicion<TAgent, TReaction, TFeature, TState, TSensor> : CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>,
        IComparable<CredulitySuspicion<TAgent, TReaction, TFeature, TState, TSensor>>
         where TAgent : ICurrentStateHandler<TState> where TReaction : IReaction
         where TFeature : IFeature
        where TState : IState where TSensor : ISensor
    {
        public static bool operator <(CredulitySuspicion<TAgent, TReaction, TFeature, TState, TSensor> c1,
            CredulitySuspicion<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
         Char1LessChar2<LowSuspicion<TAgent, TReaction, TFeature, TState, TSensor>,
             MiddleSuspicion<TAgent, TReaction, TFeature, TState, TSensor>,
             HighSuspicion<TAgent, TReaction, TFeature, TState, TSensor>,
             CredulitySuspicion<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator <=(CredulitySuspicion<TAgent, TReaction, TFeature, TState, TSensor> c1,
            CredulitySuspicion<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1LessOrEqualChar2<LowSuspicion<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleSuspicion<TAgent, TReaction, TFeature, TState, TSensor>,
                HighSuspicion<TAgent, TReaction, TFeature, TState, TSensor>,
                CredulitySuspicion<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator >(CredulitySuspicion<TAgent, TReaction, TFeature, TState, TSensor> c1,
            CredulitySuspicion<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1MoreChar2<LowSuspicion<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleSuspicion<TAgent, TReaction, TFeature, TState, TSensor>,
                HighSuspicion<TAgent, TReaction, TFeature, TState, TSensor>,
                CredulitySuspicion<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator >=(CredulitySuspicion<TAgent, TReaction, TFeature, TState, TSensor> c1,
            CredulitySuspicion<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1MoreOrEqualChar2<LowSuspicion<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleSuspicion<TAgent, TReaction, TFeature, TState, TSensor>,
                HighSuspicion<TAgent, TReaction, TFeature, TState, TSensor>,
                CredulitySuspicion<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public int CompareTo(CredulitySuspicion<TAgent, TReaction, TFeature, TState, TSensor> other)
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
            ThisCharType = CharTraitType.CredulitySuspicion;
        }
        public override List<CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>>
            GetCorrelatedTraitsForCharacter(AgentBase<TAgent, TReaction, TFeature, TState, TSensor> agent)
        {
            var cs = agent.CharacterSystem;
            return new List<CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>>() {
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