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
    public abstract class RestraintExpressiveness<TAgent, TReaction, TFeature, TState, TSensor> : CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>,
        IComparable<RestraintExpressiveness<TAgent, TReaction, TFeature, TState, TSensor>>
         where TAgent : ICurrentStateHandler<TState> where TReaction : IReaction
         where TFeature : IFeature where TState : IState where TSensor : ISensor
    {
        public static bool operator <(RestraintExpressiveness<TAgent, TReaction, TFeature, TState, TSensor> c1,
            RestraintExpressiveness<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
         Char1LessChar2<LowExpressiveness<TAgent, TReaction, TFeature, TState, TSensor>,
             MiddleExpressiveness<TAgent, TReaction, TFeature, TState, TSensor>,
             HighExpressiveness<TAgent, TReaction, TFeature, TState, TSensor>,
             RestraintExpressiveness<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator <=(RestraintExpressiveness<TAgent, TReaction, TFeature, TState, TSensor> c1,
            RestraintExpressiveness<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1LessOrEqualChar2<LowExpressiveness<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleExpressiveness<TAgent, TReaction, TFeature, TState, TSensor>,
                HighExpressiveness<TAgent, TReaction, TFeature, TState, TSensor>,
                RestraintExpressiveness<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator >(RestraintExpressiveness<TAgent, TReaction, TFeature, TState, TSensor> c1,
            RestraintExpressiveness<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1MoreChar2<LowExpressiveness<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleExpressiveness<TAgent, TReaction, TFeature, TState, TSensor>,
                HighExpressiveness<TAgent, TReaction, TFeature, TState, TSensor>,
                RestraintExpressiveness<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator >=(RestraintExpressiveness<TAgent, TReaction, TFeature, TState, TSensor> c1,
            RestraintExpressiveness<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1MoreOrEqualChar2<LowExpressiveness<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleExpressiveness<TAgent, TReaction, TFeature, TState, TSensor>,
                HighExpressiveness<TAgent, TReaction, TFeature, TState, TSensor>,
                RestraintExpressiveness<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public int CompareTo(RestraintExpressiveness<TAgent, TReaction, TFeature, TState, TSensor> other)
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
            ThisCharType = CharTraitType.RestraintExpressiveness;
        }
        public override List<CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>>
            GetCorrelatedTraitsForCharacter(AgentBase<TAgent, TReaction, TFeature, TState, TSensor> agent)
        {
            var cs = agent.CharacterSystem;
            return new List<CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>>()
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