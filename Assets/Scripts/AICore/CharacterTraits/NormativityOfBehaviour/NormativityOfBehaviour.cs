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
    public abstract class NormativityOfBehaviour<TReaction, TFeature, TState> : CharacterTraitBase<TReaction, TFeature, TState>,
        IComparable<NormativityOfBehaviour<TReaction, TFeature, TState>>
         where TReaction : IReaction
         where TFeature : IFeature where TState : IState
    {
        public static bool operator <(NormativityOfBehaviour<TReaction, TFeature, TState> c1,
            NormativityOfBehaviour<TReaction, TFeature, TState> c2) =>
         Char1LessChar2<LowNormativityOfBehaviour<TReaction, TFeature, TState>,
             MiddleNormativityOfBehaviour<TReaction, TFeature, TState>,
             HighNormativityOfBehaviour<TReaction, TFeature, TState>,
             NormativityOfBehaviour<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator <=(NormativityOfBehaviour<TReaction, TFeature, TState> c1,
            NormativityOfBehaviour<TReaction, TFeature, TState> c2) =>
            Char1LessOrEqualChar2<LowNormativityOfBehaviour<TReaction, TFeature, TState>,
                MiddleNormativityOfBehaviour<TReaction, TFeature, TState>,
                HighNormativityOfBehaviour<TReaction, TFeature, TState>,
                NormativityOfBehaviour<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator >(NormativityOfBehaviour<TReaction, TFeature, TState> c1,
            NormativityOfBehaviour<TReaction, TFeature, TState> c2) =>
            Char1MoreChar2<LowNormativityOfBehaviour<TReaction, TFeature, TState>,
                MiddleNormativityOfBehaviour<TReaction, TFeature, TState>,
                HighNormativityOfBehaviour<TReaction, TFeature, TState>,
                NormativityOfBehaviour<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator >=(NormativityOfBehaviour<TReaction, TFeature, TState> c1,
            NormativityOfBehaviour<TReaction, TFeature, TState> c2) =>
            Char1MoreOrEqualChar2<LowNormativityOfBehaviour<TReaction, TFeature, TState>,
                MiddleNormativityOfBehaviour<TReaction, TFeature, TState>,
                HighNormativityOfBehaviour<TReaction, TFeature, TState>,
                NormativityOfBehaviour<TReaction, TFeature, TState>>(c1, c2);
        public int CompareTo(NormativityOfBehaviour<TReaction, TFeature, TState> other)
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