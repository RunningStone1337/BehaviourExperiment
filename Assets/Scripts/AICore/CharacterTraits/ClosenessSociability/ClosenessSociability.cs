using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// ������ ������������� �������� � ����� ������� � ����������� ������������ ���������.
    /// ������ �������� - �������������, ���������� � ������ � ���������������. ������� �������� - �������������,
    /// ���������� � ��������� � �������.
    /// ��� ������� �������� ����������: ����������, ��������������, �������������, ��������������, ���������������,
    /// �����������, �����������, ���������� � �������������, ����������, � �������� ��������� � ������ �����.
    /// ��������� � ������������ �������������, ���������������� ���������.
    /// ��� �������� �������� ����������: �������������, ����������, ��������������, ����������������,
    /// ���������� � ��������������, �����������������, �������� � �����, ���������� � ���������� ������,
    /// ���������� � ���������� ���������� � ������, ���������� ���� �� ������.�������� � ������������ ����������������,
    /// ������������� ���������
    /// </summary>
    public abstract class ClosenessSociability<TReaction, TFeature, TState> : CharacterTraitBase<TReaction, TFeature, TState> 
        ,IComparable<ClosenessSociability<TReaction, TFeature, TState>>
         where TReaction:IReaction
         where TFeature:IFeature
         where TState : IState
        
    {
        public override List<CharacterTraitBase<TReaction, TFeature, TState> > GetInterestedTraitsForCharacter(AgentBase<TReaction, TFeature, TState>agent)
        {
            var cs = agent.CharacterSystem;
            return new List<CharacterTraitBase<TReaction, TFeature, TState> >() { 
                cs.ClosenessSociability,
                cs.ConservatismRadicalism,
                cs.ConformismNonconformism,
                cs.CredulitySuspicion,
                cs.StraightforwardnessDiplomacy,
                cs.TimidityCourage
            };
        }
        public static bool operator <(ClosenessSociability<TReaction, TFeature, TState> c1, ClosenessSociability<TReaction, TFeature, TState> c2) =>
        Char1LessChar2<LowClosenessSociability<TReaction, TFeature, TState>,
            MiddleClosenessSociability<TReaction, TFeature, TState>,
            HighClosenessSociability<TReaction, TFeature, TState>,
            ClosenessSociability<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator <=(ClosenessSociability<TReaction, TFeature, TState> c1, ClosenessSociability<TReaction, TFeature, TState> c2) =>
            Char1LessOrEqualChar2<LowClosenessSociability<TReaction, TFeature, TState>, 
                MiddleClosenessSociability<TReaction, TFeature, TState>, 
                HighClosenessSociability<TReaction, TFeature, TState>,
                ClosenessSociability<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator >(ClosenessSociability<TReaction, TFeature, TState> c1, ClosenessSociability<TReaction, TFeature, TState> c2) =>
            Char1MoreChar2<LowClosenessSociability<TReaction, TFeature, TState>,
                MiddleClosenessSociability<TReaction, TFeature, TState>,
                HighClosenessSociability<TReaction, TFeature, TState>, 
                ClosenessSociability<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator >=(ClosenessSociability<TReaction, TFeature, TState> c1, ClosenessSociability<TReaction, TFeature, TState> c2) =>
            Char1MoreOrEqualChar2<LowClosenessSociability<TReaction, TFeature, TState>, 
                MiddleClosenessSociability<TReaction, TFeature, TState>,
                HighClosenessSociability<TReaction, TFeature, TState>,
                ClosenessSociability<TReaction, TFeature, TState>>(c1, c2);
        public override string ToString()
        {
            return $"����������-�������������: �������� {RawCharacterValue}, grade {CharacterGrade}";
        }
        public int CompareTo(ClosenessSociability<TReaction, TFeature, TState> other)
        {
            if (this > other)
                return -1;
            if (this < other)
                return 1;
            return 0;
        }
    }
}