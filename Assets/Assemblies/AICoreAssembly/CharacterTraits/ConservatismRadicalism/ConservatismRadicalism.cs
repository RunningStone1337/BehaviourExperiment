using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// ��� ������� �������� ����������: ����������������, ������������ �� ��������� � ���������, ��������
    /// � ��������� � ����� ���� � ���������, ���������� � ����������� � ������������,
    /// ������������� ���������, ������ ���������������� ���������, ���������� �� ���������� �������� ������������.
    /// ��� �������� �������� ����������: �������������, �������������������,
    /// ������� ���������������� ���������, �������� ������������� ��������,
    /// ��������������� � ���������, � ����� �����, ��������� � �����������, ����� ��������� ���-���� �� ����,
    /// �������������� �� �������������, ������������� ������������.
    /// � ������������� ���� �������� �������������� ����, ��� �������� � �������� ������������
    /// �� ����� ������� ����� �������������, ������ ������� � ���������������, �������� ������� ������� � �����,
    /// ������ � ������.����� ����, ��� ������ � ��������� �������� � ����������� ��������,
    /// �� ����������� ������������� ��������, �������� � ���������.
    /// ������ ���������� �����������, ����������������, ������������ � ����������� ���������.
    /// </summary>
    public abstract class ConservatismRadicalism<TAgent, TReaction, TFeature, TState, TSensor> : CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>,
        IComparable<ConservatismRadicalism<TAgent, TReaction, TFeature, TState, TSensor>>
         where TAgent : ICurrentStateHandler<TState> where TReaction : IReaction
         where TFeature : IFeature
        where TState : IState where TSensor : ISensor
    {
        public static bool operator <(ConservatismRadicalism<TAgent, TReaction, TFeature, TState, TSensor> c1,
            ConservatismRadicalism<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
         Char1LessChar2<LowRadicalism<TAgent, TReaction, TFeature, TState, TSensor>,
             MiddleRadicalism<TAgent, TReaction, TFeature, TState, TSensor>,
             HighRadicalism<TAgent, TReaction, TFeature, TState, TSensor>,
             ConservatismRadicalism<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator <=(ConservatismRadicalism<TAgent, TReaction, TFeature, TState, TSensor> c1,
            ConservatismRadicalism<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1LessOrEqualChar2<LowRadicalism<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleRadicalism<TAgent, TReaction, TFeature, TState, TSensor>,
                HighRadicalism<TAgent, TReaction, TFeature, TState, TSensor>,
                ConservatismRadicalism<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator >(ConservatismRadicalism<TAgent, TReaction, TFeature, TState, TSensor> c1,
            ConservatismRadicalism<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1MoreChar2<LowRadicalism<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleRadicalism<TAgent, TReaction, TFeature, TState, TSensor>,
                HighRadicalism<TAgent, TReaction, TFeature, TState, TSensor>,
                ConservatismRadicalism<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator >=(ConservatismRadicalism<TAgent, TReaction, TFeature, TState, TSensor> c1,
            ConservatismRadicalism<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1MoreOrEqualChar2<LowRadicalism<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleRadicalism<TAgent, TReaction, TFeature, TState, TSensor>,
                HighRadicalism<TAgent, TReaction, TFeature, TState, TSensor>,
                ConservatismRadicalism<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public int CompareTo(ConservatismRadicalism<TAgent, TReaction, TFeature, TState, TSensor> other)
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
            ThisCharType = CharTraitType.ConservatismRadicalism;
        }
        public override List<CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>>
            GetCorrelatedTraitsForCharacter(AgentBase<TAgent, TReaction, TFeature, TState, TSensor> agent)
        {
            var cs = agent.CharacterSystem;
            return new List<CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>>() {
                cs.ConservatismRadicalism,
                cs.Intelligence,
                cs.NormativityOfBehaviour,
                cs.StraightforwardnessDiplomacy,
                cs.TimidityCourage
            };
        }

        public override string ToString()
        {
            return $"������������-����������: �������� {RawCharacterValue}, grade {CharacterGrade}";
        }
    }
}