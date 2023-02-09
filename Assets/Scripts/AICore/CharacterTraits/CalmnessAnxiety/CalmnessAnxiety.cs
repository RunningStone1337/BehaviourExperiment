using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// �����������-�����������. ������ ������ ���������� ��� �����,
    /// ������� ���������� ������ ���������. �������� � �������� �������� �� ����� �������
    /// ��������� ���� ��������������, ������������� � ������� ��������� ���������,
    /// ����� ������ ����������� ����, ����� ��������� � �����������;
    /// ��� ��� ���������� ���������� ��������� ���������� � ����������� � ������������� �������.
    /// ���� ������ ����, ��� ������� ���� � ������������ ������.
    /// </summary>
    public abstract class CalmnessAnxiety<TReaction, TFeature, TState>  : CharacterTraitBase<TReaction, TFeature, TState> , 
        IComparable<CalmnessAnxiety<TReaction, TFeature, TState>>
        where TReaction:IReaction
        where TFeature : IFeature where TState : IState

    {
        public override List<CharacterTraitBase<TReaction, TFeature, TState> > 
            GetInterestedTraitsForCharacter(AgentBase<TReaction, TFeature, TState> agent)
        {
            var cs = agent.CharacterSystem;
            return new List<CharacterTraitBase<TReaction, TFeature, TState> >() {
                cs.CalmnessAnxiety,
                cs.ClosenessSociability,
                cs.EmotionalInstabilityStability,
                cs.RelaxationTension,
                cs.RestraintExpressiveness,
                cs.RigiditySensetivity,
                cs.SubordinationDomination
            };
        }
        public override string ToString()
        {
            return $"�����������-�����������: �������� {RawCharacterValue}, grade {CharacterGrade}";
        }
        public static bool operator <(CalmnessAnxiety<TReaction, TFeature, TState>  c1,
            CalmnessAnxiety<TReaction, TFeature, TState>  c2) =>
                  Char1LessChar2<LowAnxiety<TReaction, TFeature, TState>,
                      MiddleAnxiety<TReaction, TFeature, TState>, 
                      HighAnxiety<TReaction, TFeature, TState>,
                      CalmnessAnxiety<TReaction, TFeature, TState> >(c1, c2);

        public static bool operator <=(CalmnessAnxiety<TReaction, TFeature, TState>  c1,
            CalmnessAnxiety<TReaction, TFeature, TState>  c2) =>
            Char1LessOrEqualChar2<LowAnxiety<TReaction, TFeature, TState>, 
                MiddleAnxiety<TReaction, TFeature, TState>, 
                HighAnxiety<TReaction, TFeature, TState>,
                CalmnessAnxiety<TReaction, TFeature, TState> >(c1, c2);

        public static bool operator >(CalmnessAnxiety<TReaction, TFeature, TState>  c1,
            CalmnessAnxiety<TReaction, TFeature, TState>  c2) =>
            Char1MoreChar2<LowAnxiety<TReaction, TFeature, TState>,
                MiddleAnxiety<TReaction, TFeature, TState>,
                HighAnxiety<TReaction, TFeature, TState>,
                CalmnessAnxiety<TReaction, TFeature, TState> >(c1, c2);

        public static bool operator >=(CalmnessAnxiety<TReaction, TFeature, TState>  c1,
            CalmnessAnxiety<TReaction, TFeature, TState>  c2) =>
            Char1MoreOrEqualChar2<LowAnxiety<TReaction, TFeature, TState>,
                MiddleAnxiety<TReaction, TFeature, TState>,
                HighAnxiety<TReaction, TFeature, TState>, 
                CalmnessAnxiety<TReaction, TFeature, TState> >(c1, c2);

        public int CompareTo(CalmnessAnxiety<TReaction, TFeature, TState>  other)
        {
            if (this > other)
                return -1;
            if (this < other)
                return 1;
            return 0;
        }
    }
}