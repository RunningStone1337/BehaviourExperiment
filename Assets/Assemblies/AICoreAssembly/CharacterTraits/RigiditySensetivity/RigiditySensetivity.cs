using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// ��� ������� �������� ����������: �������������������, ���������������, ���������,
    /// �������������, �������� � ���������, ������������, ������ ��������� ���������
    /// � ���������� �� ��������� � ����������, ��������������, ����������.
    /// ��� �������� �������� ����������: ����������������, �����������������, ���������
    /// ������������� �����������, ���������� � ����������, �������������� ���������� ����,
    /// �������� ������������ ��������, �������������, �������������, ���������� � �������, ����������,
    /// ������������� � ��������� ������ �����, ���������� ���������������.
    /// ���� ������ �������� �������� � ���������� ������ � ������������ ��������������� ��������.
    /// ��������� ��� ����, ��� ���� � ������� ������������ �� ����� ������� ������ ������, ����� ����������,
    /// ���� ���������� �������, ���������.
    /// �������������� ����� ������� ����� � ������� ������� ������� ������� ���������������
    /// � ������� ����������������; ������ ������ �������� ��� ��������������.
    /// �������� � �������� ������������ �� ����� ������� ��������������� ��� ��������� � ��������� ����������,
    /// �������� � ���������, �������������� ��� ������ �������� � ������ ��������� �������.
    /// </summary>
    public abstract class RigiditySensetivity<TAgent, TReaction, TFeature, TState, TSensor> : CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>
        , IComparable<RigiditySensetivity<TAgent, TReaction, TFeature, TState, TSensor>>
        where TAgent : ICurrentStateHandler<TState> where TReaction : IReaction
        where TFeature : IFeature where TState : IState where TSensor : ISensor
    {
        public static bool operator <(RigiditySensetivity<TAgent, TReaction, TFeature, TState, TSensor> c1,
                    RigiditySensetivity<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
         Char1LessChar2<LowSensetivity<TAgent, TReaction, TFeature, TState, TSensor>,
             MiddleSensetivity<TAgent, TReaction, TFeature, TState, TSensor>,
             HighSensetivity<TAgent, TReaction, TFeature, TState, TSensor>,
             RigiditySensetivity<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator <=(RigiditySensetivity<TAgent, TReaction, TFeature, TState, TSensor> c1,
            RigiditySensetivity<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1LessOrEqualChar2<LowSensetivity<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleSensetivity<TAgent, TReaction, TFeature, TState, TSensor>,
                HighSensetivity<TAgent, TReaction, TFeature, TState, TSensor>,
                RigiditySensetivity<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator >(RigiditySensetivity<TAgent, TReaction, TFeature, TState, TSensor> c1,
            RigiditySensetivity<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1MoreChar2<LowSensetivity<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleSensetivity<TAgent, TReaction, TFeature, TState, TSensor>,
                HighSensetivity<TAgent, TReaction, TFeature, TState, TSensor>,
                RigiditySensetivity<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator >=(RigiditySensetivity<TAgent, TReaction, TFeature, TState, TSensor> c1,
            RigiditySensetivity<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1MoreOrEqualChar2<LowSensetivity<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleSensetivity<TAgent, TReaction, TFeature, TState, TSensor>,
                HighSensetivity<TAgent, TReaction, TFeature, TState, TSensor>,
                RigiditySensetivity<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);
        public override void Initiate(int characterValue, TAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisCharType = CharTraitType.RigiditySensetivity;
        }
        public int CompareTo(RigiditySensetivity<TAgent, TReaction, TFeature, TState, TSensor> other)
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
                cs.RigiditySensetivity,
                cs.EmotionalInstabilityStability,
                cs.PracticalityDreaminess,
                cs.RestraintExpressiveness,
                cs.RigiditySensetivity,
                cs.SubordinationDomination
            };
        }

        public override string ToString()
        {
            return $"���������-����������������: �������� {RawCharacterValue}, grade {CharacterGrade}";
        }
    }
}