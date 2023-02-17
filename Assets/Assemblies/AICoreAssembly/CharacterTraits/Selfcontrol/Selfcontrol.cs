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
    public abstract class Selfcontrol<TAgent, TReaction, TFeature, TState, TSensor> : CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>,
        IComparable<Selfcontrol<TAgent, TReaction, TFeature, TState, TSensor>>
         where TAgent : ICurrentStateHandler<TState> where TReaction : IReaction
         where TFeature : IFeature where TState : IState where TSensor : ISensor
    {
        public static bool operator <(Selfcontrol<TAgent, TReaction, TFeature, TState, TSensor> c1,
                    Selfcontrol<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
         Char1LessChar2<LowSelfcontrol<TAgent, TReaction, TFeature, TState, TSensor>,
             MiddleSelfcontrol<TAgent, TReaction, TFeature, TState, TSensor>,
             HighSelfcontrol<TAgent, TReaction, TFeature, TState, TSensor>,
             Selfcontrol<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator <=(Selfcontrol<TAgent, TReaction, TFeature, TState, TSensor> c1,
            Selfcontrol<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1LessOrEqualChar2<LowSelfcontrol<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleSelfcontrol<TAgent, TReaction, TFeature, TState, TSensor>,
                HighSelfcontrol<TAgent, TReaction, TFeature, TState, TSensor>,
                Selfcontrol<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator >(Selfcontrol<TAgent, TReaction, TFeature, TState, TSensor> c1,
            Selfcontrol<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1MoreChar2<LowSelfcontrol<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleSelfcontrol<TAgent, TReaction, TFeature, TState, TSensor>,
                HighSelfcontrol<TAgent, TReaction, TFeature, TState, TSensor>,
                Selfcontrol<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator >=(Selfcontrol<TAgent, TReaction, TFeature, TState, TSensor> c1,
            Selfcontrol<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1MoreOrEqualChar2<LowSelfcontrol<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleSelfcontrol<TAgent, TReaction, TFeature, TState, TSensor>,
                HighSelfcontrol<TAgent, TReaction, TFeature, TState, TSensor>,
                Selfcontrol<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public int CompareTo(Selfcontrol<TAgent, TReaction, TFeature, TState, TSensor> other)
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
            ThisCharType = CharTraitType.Selfcontrol;
        }
        public override List<CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>>
            GetCorrelatedTraitsForCharacter(AgentBase<TAgent, TReaction, TFeature, TState, TSensor> agent)
        {
            var cs = agent.CharacterSystem;
            return new List<CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>>() {
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