using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// ��� ������� �������� ����������: �������������, ��������, ���������, ���������������,
    /// ������������, ��������������, ������������������, ���������������, ����������������������,
    /// �������� ������������� ������ ��������, ���������� ����������������, �������� ������, ����������� ���������.
    /// ��� �������� �������� ����������: ������������, ������ ����� ���� � ��������, � ������� ���������������,
    /// ������������� �������������, ����������������, ������������, ��������, ������������ ������������,
    /// ������ ������������, ������ �������� ����� �� ������� ��������, �������������.
    /// ������ ������������ �� ��������� ��������� �������� � ����� � ���������� ����������������.
    /// ���� ���� ������ ������������ ����������.������ ����� �������� � ���, ��� ������ �������������
    /// ��������� ����� ������������ ���������� ��������(������ ������������ ����������� � �����������
    /// ������������� � �������������� � � ������������ �������������� �������� � ����).
    /// ������� ������ �� ����� ������� ������������� ���������� � ����������������� �������������� � ��������������
    /// �������� � ������� ������������� ������������, �������� � �����������������.
    /// ���������� ������ � ���, ��� ���� � ������� �������� �� ����� ������� ��������
    /// ������ ������� � ��������, �������� � �����. ����� � �������� �������� ����� ����������������
    /// ��� ����������������, �����������, �� ������� �������. � ������������� ������������� ���� �������� �����
    /// ������� ����������� �� ����� ������� �� ������������ � ��������� � ������������ �������������.
    /// �� ������������ ��������������� ���� � �������� ������������ �������� �������� � �������������,
    /// ���������������� ��������� � � ������������ �������������� ��������� �������
    /// (� ����������� ����������, ��������������, ���������� ��� ������� ������� ������ �� ����� �������).
    /// </summary>
    public abstract class StraightforwardnessDiplomacy<TReaction, TFeature, TState> : CharacterTraitBase<TReaction, TFeature, TState>,
        IComparable<StraightforwardnessDiplomacy<TReaction, TFeature, TState>>
         where TReaction : IReaction
         where TFeature : IFeature where TState : IState
    {
        public static bool operator <(StraightforwardnessDiplomacy<TReaction, TFeature, TState> c1,
            StraightforwardnessDiplomacy<TReaction, TFeature, TState> c2) =>
         Char1LessChar2<LowDiplomacy<TReaction, TFeature, TState>,
             MiddleDiplomacy<TReaction, TFeature, TState>,
             HighDiplomacy<TReaction, TFeature, TState>,
             StraightforwardnessDiplomacy<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator <=(StraightforwardnessDiplomacy<TReaction, TFeature, TState> c1,
            StraightforwardnessDiplomacy<TReaction, TFeature, TState> c2) =>
            Char1LessOrEqualChar2<LowDiplomacy<TReaction, TFeature, TState>,
                MiddleDiplomacy<TReaction, TFeature, TState>,
                HighDiplomacy<TReaction, TFeature, TState>,
                StraightforwardnessDiplomacy<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator >(StraightforwardnessDiplomacy<TReaction, TFeature, TState> c1,
            StraightforwardnessDiplomacy<TReaction, TFeature, TState> c2) =>
            Char1MoreChar2<LowDiplomacy<TReaction, TFeature, TState>,
                MiddleDiplomacy<TReaction, TFeature, TState>,
                HighDiplomacy<TReaction, TFeature, TState>,
                StraightforwardnessDiplomacy<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator >=(StraightforwardnessDiplomacy<TReaction, TFeature, TState> c1,
            StraightforwardnessDiplomacy<TReaction, TFeature, TState> c2) =>
            Char1MoreOrEqualChar2<LowDiplomacy<TReaction, TFeature, TState>,
                MiddleDiplomacy<TReaction, TFeature, TState>,
                HighDiplomacy<TReaction, TFeature, TState>,
                StraightforwardnessDiplomacy<TReaction, TFeature, TState>>(c1, c2);
        public int CompareTo(StraightforwardnessDiplomacy<TReaction, TFeature, TState> other)
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
          cs.StraightforwardnessDiplomacy,
                cs.EmotionalInstabilityStability,
                cs.PracticalityDreaminess,
                cs.RelaxationTension,
                cs.RestraintExpressiveness,
            };
        }
              
        public override string ToString()
        {
            return $"������.-��������.: �������� {RawCharacterValue}, grade {CharacterGrade}";
        }
    }
}