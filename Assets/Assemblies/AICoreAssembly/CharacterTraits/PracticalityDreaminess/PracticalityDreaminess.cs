using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// ��� ������� �������� ����������: ������� �������� ������� ������������ �����,
    /// ������������, ���������� �� ������� ����������, �������� ���������� �����������, ������������, ��������������.
    /// ��� �������� �������� ����������: ������� �����������, ������������� ������ ������,
    /// ����������� ���������(������� � ��������), �������� ������ �� ������������ ��������,
    /// ������ ����������� ������������ ���������, ����������������� �� ���� ���������� ���; ��������������.
    /// � ����� ������ ������������ �� ��������� ������������ �����������, ������������ � �������� ��������� ��������,
    /// �����, ��� ������������, �������������� ���, ��������, ��������� �������� � ��������, ������������� ��������� � �����.
    /// </summary>
    public abstract class PracticalityDreaminess<TAgent, TReaction, TFeature, TState, TSensor> : CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>,
        IComparable<PracticalityDreaminess<TAgent, TReaction, TFeature, TState, TSensor>>
         where TAgent : ICurrentStateHandler<TState> where TReaction : IReaction
         where TFeature : IFeature where TState : IState where TSensor : ISensor
    {
        public static bool operator <(PracticalityDreaminess<TAgent, TReaction, TFeature, TState, TSensor> c1,
                    PracticalityDreaminess<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
         Char1LessChar2<LowDreaminess<TAgent, TReaction, TFeature, TState, TSensor>,
             MiddleDreaminess<TAgent, TReaction, TFeature, TState, TSensor>,
             HighDreaminess<TAgent, TReaction, TFeature, TState, TSensor>,
             PracticalityDreaminess<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator <=(PracticalityDreaminess<TAgent, TReaction, TFeature, TState, TSensor> c1,
            PracticalityDreaminess<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1LessOrEqualChar2<LowDreaminess<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleDreaminess<TAgent, TReaction, TFeature, TState, TSensor>,
                HighDreaminess<TAgent, TReaction, TFeature, TState, TSensor>,
                PracticalityDreaminess<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator >(PracticalityDreaminess<TAgent, TReaction, TFeature, TState, TSensor> c1,
            PracticalityDreaminess<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1MoreChar2<LowDreaminess<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleDreaminess<TAgent, TReaction, TFeature, TState, TSensor>,
                HighDreaminess<TAgent, TReaction, TFeature, TState, TSensor>,
                PracticalityDreaminess<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator >=(PracticalityDreaminess<TAgent, TReaction, TFeature, TState, TSensor> c1,
            PracticalityDreaminess<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1MoreOrEqualChar2<LowDreaminess<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleDreaminess<TAgent, TReaction, TFeature, TState, TSensor>,
                HighDreaminess<TAgent, TReaction, TFeature, TState, TSensor>,
                PracticalityDreaminess<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public int CompareTo(PracticalityDreaminess<TAgent, TReaction, TFeature, TState, TSensor> other)
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
            ThisCharType = CharTraitType.PracticalityDreaminess;
        }
        public override List<CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>>
            GetCorrelatedTraitsForCharacter(AgentBase<TAgent, TReaction, TFeature, TState, TSensor> agent)
        {
            var cs = agent.CharacterSystem;
            return new List<CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>>()
            {
                cs.PracticalityDreaminess,
                cs.ConservatismRadicalism,
                cs.CredulitySuspicion,
                cs.Intelligence,
                cs.PracticalityDreaminess
            };
        }

        public override string ToString()
        {
            return $"������������-��������������: �������� {RawCharacterValue}, grade {CharacterGrade}";
        }
    }
}