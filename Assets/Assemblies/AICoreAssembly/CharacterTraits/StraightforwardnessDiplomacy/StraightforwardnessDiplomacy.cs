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
    public abstract class StraightforwardnessDiplomacy<TAgent, TReaction, TFeature, TState, TSensor> : CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>,
        IComparable<StraightforwardnessDiplomacy<TAgent, TReaction, TFeature, TState, TSensor>>
         where TAgent : ICurrentStateHandler<TState> where TReaction : IReaction
         where TFeature : IFeature where TState : IState where TSensor : ISensor
    {
        public static bool operator <(StraightforwardnessDiplomacy<TAgent, TReaction, TFeature, TState, TSensor> c1,
            StraightforwardnessDiplomacy<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
         Char1LessChar2<LowDiplomacy<TAgent, TReaction, TFeature, TState, TSensor>,
             MiddleDiplomacy<TAgent, TReaction, TFeature, TState, TSensor>,
             HighDiplomacy<TAgent, TReaction, TFeature, TState, TSensor>,
             StraightforwardnessDiplomacy<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator <=(StraightforwardnessDiplomacy<TAgent, TReaction, TFeature, TState, TSensor> c1,
            StraightforwardnessDiplomacy<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1LessOrEqualChar2<LowDiplomacy<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleDiplomacy<TAgent, TReaction, TFeature, TState, TSensor>,
                HighDiplomacy<TAgent, TReaction, TFeature, TState, TSensor>,
                StraightforwardnessDiplomacy<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator >(StraightforwardnessDiplomacy<TAgent, TReaction, TFeature, TState, TSensor> c1,
            StraightforwardnessDiplomacy<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1MoreChar2<LowDiplomacy<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleDiplomacy<TAgent, TReaction, TFeature, TState, TSensor>,
                HighDiplomacy<TAgent, TReaction, TFeature, TState, TSensor>,
                StraightforwardnessDiplomacy<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator >=(StraightforwardnessDiplomacy<TAgent, TReaction, TFeature, TState, TSensor> c1,
            StraightforwardnessDiplomacy<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1MoreOrEqualChar2<LowDiplomacy<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleDiplomacy<TAgent, TReaction, TFeature, TState, TSensor>,
                HighDiplomacy<TAgent, TReaction, TFeature, TState, TSensor>,
                StraightforwardnessDiplomacy<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public int CompareTo(StraightforwardnessDiplomacy<TAgent, TReaction, TFeature, TState, TSensor> other)
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
            ThisCharType = CharTraitType.StraightforwardnessDiplomacy;
        }
        public override List<CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>>
            GetCorrelatedTraitsForCharacter(AgentBase<TAgent, TReaction, TFeature, TState, TSensor> agent)
        {
            var cs = agent.CharacterSystem;
            return new List<CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>>()
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