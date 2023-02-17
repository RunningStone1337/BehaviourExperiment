using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// ��� ������� �������� ����������: ������������� ��������������, ��������������;
    /// ������� ��������� ��� �������� ������, ���������� � �����������, ����� ��������������,
    /// ���������� � ���������. ������ ������������� �� ��������� � ����������, �����������������, ������������.
    /// ��� �������� �������� ����������: ������������� ������������, �������������;
    /// ������� ������������ ������, ���������, �������� � ���������, ���������������, ����� ���� ��������, ������������ �� ����������.
    /// ���� ������ ������������� ������������ ��������� � �������� ������ � ����������������� �������������� ���������������.
    /// </summary>
    public abstract class EmotionalInstabilityStability<TAgent, TReaction, TFeature, TState, TSensor> :
        CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>,
        IComparable<EmotionalInstabilityStability<TAgent, TReaction, TFeature, TState, TSensor>>
            where TAgent : ICurrentStateHandler<TState> where TReaction : IReaction
        where TFeature : IFeature
        where TState : IState where TSensor : ISensor
    {
        public static bool operator <(EmotionalInstabilityStability<TAgent, TReaction, TFeature, TState, TSensor> c1,
            EmotionalInstabilityStability<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
         Char1LessChar2<LowEmotionalStability<TAgent, TReaction, TFeature, TState, TSensor>,
             MiddleEmotionalStability<TAgent, TReaction, TFeature, TState, TSensor>,
             HighEmotionalStability<TAgent, TReaction, TFeature, TState, TSensor>,
             EmotionalInstabilityStability<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator <=(EmotionalInstabilityStability<TAgent, TReaction, TFeature, TState, TSensor> c1,
            EmotionalInstabilityStability<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1LessOrEqualChar2<LowEmotionalStability<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleEmotionalStability<TAgent, TReaction, TFeature, TState, TSensor>,
                HighEmotionalStability<TAgent, TReaction, TFeature, TState, TSensor>,
                EmotionalInstabilityStability<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator >(EmotionalInstabilityStability<TAgent, TReaction, TFeature, TState, TSensor> c1,
            EmotionalInstabilityStability<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1MoreChar2<LowEmotionalStability<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleEmotionalStability<TAgent, TReaction, TFeature, TState, TSensor>,
                HighEmotionalStability<TAgent, TReaction, TFeature, TState, TSensor>,
                EmotionalInstabilityStability<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator >=(EmotionalInstabilityStability<TAgent, TReaction, TFeature, TState, TSensor> c1,
            EmotionalInstabilityStability<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1MoreOrEqualChar2<LowEmotionalStability<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleEmotionalStability<TAgent, TReaction, TFeature, TState, TSensor>,
                HighEmotionalStability<TAgent, TReaction, TFeature, TState, TSensor>,
                EmotionalInstabilityStability<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public int CompareTo(EmotionalInstabilityStability<TAgent, TReaction, TFeature, TState, TSensor> other)
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
            ThisCharType = CharTraitType.EmotionalInstabilityStability;
        }
        public override List<CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>>
            GetCorrelatedTraitsForCharacter(AgentBase<TAgent, TReaction, TFeature, TState, TSensor> agent)
        {
            var cs = agent.CharacterSystem;
            return new List<CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>>()
            {
                cs.EmotionalInstabilityStability,
                cs.ClosenessSociability,
                cs.CredulitySuspicion,
                cs.NormativityOfBehaviour,
                cs.RelaxationTension,
                cs.RigiditySensetivity,
                cs.Selfcontrol,
                cs.StraightforwardnessDiplomacy
            };
        }

        public override string ToString()
        {
            return $"��. ������������: �������� {RawCharacterValue}, grade {CharacterGrade}";
        }
    }
}