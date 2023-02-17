using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// ��� ������� �������� ����������: ���������� � �������������, �������������� ������� ������,
    /// ������ � �������������. ������������ ����� ��������, �� ������ ������ �� ���������� ���������
    /// ���������� � ����. ������������������, ������������������, ��������������, ���������� ��������
    /// � ������������� ���������� ��������� � �����������, �������� �� ��������� � ���������� ������,
    /// ������� �� �� �������, ������ ��������������� � ���������� � ������������ ���������.
    /// ��� �������� �������� ����������: ����������������, ���������������, ������������, ����������������,
    /// �������������, ���������� � ���������������, ����������, �������������.
    /// �������� ������� ����� � ���������������, ���������� ���������� ������������ ��������� ������ � ����,
    /// ������������� � ���������� ����, ������� ��������������.
    /// </summary>
    public abstract class NormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor> : CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>,
        IComparable<NormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor>>
         where TAgent : ICurrentStateHandler<TState> where TReaction : IReaction
         where TFeature : IFeature where TState : IState where TSensor : ISensor
    {
        public static bool operator <(NormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor> c1,
            NormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
         Char1LessChar2<LowNormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor>,
             MiddleNormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor>,
             HighNormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor>,
             NormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator <=(NormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor> c1,
            NormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1LessOrEqualChar2<LowNormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleNormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor>,
                HighNormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor>,
                NormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator >(NormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor> c1,
            NormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1MoreChar2<LowNormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleNormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor>,
                HighNormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor>,
                NormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator >=(NormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor> c1,
            NormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1MoreOrEqualChar2<LowNormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleNormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor>,
                HighNormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor>,
                NormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public int CompareTo(NormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor> other)
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
            ThisCharType = CharTraitType.NormativityOfBehaviour;
        }
        public override List<CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>>
            GetCorrelatedTraitsForCharacter(AgentBase<TAgent, TReaction, TFeature, TState, TSensor> agent)
        {
            var cs = agent.CharacterSystem;
            return new List<CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>>()
            {
                cs.NormativityOfBehaviour,
                cs.CalmnessAnxiety,
                cs.NormativityOfBehaviour,
                cs.PracticalityDreaminess,
                cs.RelaxationTension,
                cs.Selfcontrol
            };
        }

        public override string ToString()
        {
            return $"������������� ���������: �������� {RawCharacterValue}, grade {CharacterGrade}";
        }
    }
}