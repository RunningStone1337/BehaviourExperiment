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
    public abstract class EmotionalInstabilityStability<TReaction, TFeature, TState> : 
        CharacterTraitBase<TReaction, TFeature, TState> ,
        IComparable<EmotionalInstabilityStability<TReaction, TFeature, TState>>
            where TReaction : IReaction
        where TFeature : IFeature
        where TState : IState
    {
        public static bool operator <(EmotionalInstabilityStability<TReaction, TFeature, TState>  c1,
            EmotionalInstabilityStability<TReaction, TFeature, TState>  c2) =>
         Char1LessChar2<LowEmotionalStability<TReaction, TFeature, TState> ,
             MiddleEmotionalStability<TReaction, TFeature, TState> ,
             HighEmotionalStability<TReaction, TFeature, TState> , 
             EmotionalInstabilityStability<TReaction, TFeature, TState> >(c1, c2);

        public static bool operator <=(EmotionalInstabilityStability<TReaction, TFeature, TState>  c1,
            EmotionalInstabilityStability<TReaction, TFeature, TState>  c2) =>
            Char1LessOrEqualChar2<LowEmotionalStability<TReaction, TFeature, TState> ,
                MiddleEmotionalStability<TReaction, TFeature, TState> ,
                HighEmotionalStability<TReaction, TFeature, TState> ,
                EmotionalInstabilityStability<TReaction, TFeature, TState> >(c1, c2);

        public static bool operator >(EmotionalInstabilityStability<TReaction, TFeature, TState>  c1,
            EmotionalInstabilityStability<TReaction, TFeature, TState>  c2) =>
            Char1MoreChar2<LowEmotionalStability<TReaction, TFeature, TState> ,
                MiddleEmotionalStability<TReaction, TFeature, TState> ,
                HighEmotionalStability<TReaction, TFeature, TState> ,
                EmotionalInstabilityStability<TReaction, TFeature, TState> >(c1, c2);

        public static bool operator >=(EmotionalInstabilityStability<TReaction, TFeature, TState>  c1,
            EmotionalInstabilityStability<TReaction, TFeature, TState>  c2) =>
            Char1MoreOrEqualChar2<LowEmotionalStability<TReaction, TFeature, TState> ,
                MiddleEmotionalStability<TReaction, TFeature, TState> ,
                HighEmotionalStability<TReaction, TFeature, TState> ,
                EmotionalInstabilityStability<TReaction, TFeature, TState> >(c1, c2);
        public int CompareTo(EmotionalInstabilityStability<TReaction, TFeature, TState>  other)
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
            return new List<CharacterTraitBase<TReaction, TFeature, TState> >()
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