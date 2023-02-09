using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// ������� �������������, ������� �� ������ ������ �����.
    /// ��� ������� �������� ����������: ����������� �� ������ � ���������� ������, ��������������, ���������� �� ������������ �������, ���������� �������� � ��������� ������� ������ � ������� ������, ������ �����������������, ���������� �� ���������� ���������.
    /// ��� �������� �������� ����������: �������������, ���������� �� ����������� �������,
    /// �����������������, ������������, ���������� ����� ����������� ������.
    /// ��� ������� ������� ������� ���������� � ������������������ ���� ������ � ������� � ��� ������������.
    /// ������ ������ �� ����� ������� ����� �������� �����������, ��� ������� ����� ������ ��������� ��������,
    /// ��� �������� ����.
    /// ������� ������ ����� ����, ������� ����� ��������� � ������� � �� ���� ������� �������� ���������������� � ��������,
    /// ������ � �����������.
    /// </summary>
    public abstract class ConformismNonconformism<TReaction, TFeature, TState> : CharacterTraitBase<TReaction, TFeature, TState>,
        IComparable<ConformismNonconformism<TReaction, TFeature, TState>>
         where TReaction : IReaction
         where TFeature : IFeature
        where TState : IState
    {
        public static bool operator <(ConformismNonconformism<TReaction, TFeature, TState> c1,
            ConformismNonconformism<TReaction, TFeature, TState> c2) =>
         Char1LessChar2<LowNonconformism<TReaction, TFeature, TState>,
             MiddleNonconformism<TReaction, TFeature, TState>,
             HighNonconformism<TReaction, TFeature, TState>,
             ConformismNonconformism<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator <=(ConformismNonconformism<TReaction, TFeature, TState> c1,
            ConformismNonconformism<TReaction, TFeature, TState> c2) =>
            Char1LessOrEqualChar2<LowNonconformism<TReaction, TFeature, TState>,
                MiddleNonconformism<TReaction, TFeature, TState>,
                HighNonconformism<TReaction, TFeature, TState>,
                ConformismNonconformism<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator >(ConformismNonconformism<TReaction, TFeature, TState> c1,
            ConformismNonconformism<TReaction, TFeature, TState> c2) =>
            Char1MoreChar2<LowNonconformism<TReaction, TFeature, TState>,
                MiddleNonconformism<TReaction, TFeature, TState>,
                HighNonconformism<TReaction, TFeature, TState>,
                ConformismNonconformism<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator >=(ConformismNonconformism<TReaction, TFeature, TState> c1,
            ConformismNonconformism<TReaction, TFeature, TState> c2) =>
            Char1MoreOrEqualChar2<LowNonconformism<TReaction, TFeature, TState>,
                MiddleNonconformism<TReaction, TFeature, TState>,
                HighNonconformism<TReaction, TFeature, TState>,
                ConformismNonconformism<TReaction, TFeature, TState>>(c1, c2);
        public int CompareTo(ConformismNonconformism<TReaction, TFeature, TState> other)
        {
            if (this > other)
                return -1;
            if (this < other)
                return 1;
            return 0;
        }
        public override string ToString()
        {
            return $"����������-��������������: �������� {RawCharacterValue}, grade {CharacterGrade}";
        }
        public override List<CharacterTraitBase<TReaction, TFeature, TState> > 
            GetInterestedTraitsForCharacter(AgentBase<TReaction, TFeature, TState> agent)
        {
            var cs = agent.CharacterSystem;
            return new List<CharacterTraitBase<TReaction, TFeature, TState> >() { 
                cs.ConformismNonconformism,
                cs.ClosenessSociability,
                cs.ConservatismRadicalism,
                cs.Intelligence,
                cs.NormativityOfBehaviour,
                cs.PracticalityDreaminess,
                cs.Selfcontrol,
                cs.StraightforwardnessDiplomacy,
                cs.SubordinationDomination,
                cs.TimidityCourage,
            };
        }
    }
}