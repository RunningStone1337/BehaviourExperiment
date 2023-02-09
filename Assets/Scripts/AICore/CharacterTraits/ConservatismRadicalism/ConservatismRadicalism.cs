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
    public abstract class ConservatismRadicalism<TReaction, TFeature, TState>  : CharacterTraitBase<TReaction, TFeature, TState> , 
        IComparable<ConservatismRadicalism<TReaction, TFeature, TState> >
         where   TReaction: IReaction
         where TFeature : IFeature 
        where TState : IState
    {
        public static bool operator <(ConservatismRadicalism<TReaction, TFeature, TState>  c1,
            ConservatismRadicalism<TReaction, TFeature, TState>  c2) =>
         Char1LessChar2<LowRadicalism<TReaction, TFeature, TState>  ,
             MiddleRadicalism<TReaction, TFeature, TState>  ,
             HighRadicalism<TReaction, TFeature, TState>  ,
             ConservatismRadicalism<TReaction, TFeature, TState> >(c1, c2);

        public static bool operator <=(ConservatismRadicalism<TReaction, TFeature, TState>  c1,
            ConservatismRadicalism<TReaction, TFeature, TState>  c2) =>
            Char1LessOrEqualChar2<LowRadicalism<TReaction, TFeature, TState>  ,
                MiddleRadicalism<TReaction, TFeature, TState>  ,
                HighRadicalism<TReaction, TFeature, TState>  ,
                ConservatismRadicalism<TReaction, TFeature, TState> >(c1, c2);

        public static bool operator >(ConservatismRadicalism<TReaction, TFeature, TState>  c1,
            ConservatismRadicalism<TReaction, TFeature, TState>  c2) =>
            Char1MoreChar2<LowRadicalism<TReaction, TFeature, TState>  ,
                MiddleRadicalism<TReaction, TFeature, TState>  ,
                HighRadicalism<TReaction, TFeature, TState>  ,
                ConservatismRadicalism<TReaction, TFeature, TState> >(c1, c2);

        public static bool operator >=(ConservatismRadicalism<TReaction, TFeature, TState>  c1,
            ConservatismRadicalism<TReaction, TFeature, TState>  c2) =>
            Char1MoreOrEqualChar2<LowRadicalism<TReaction, TFeature, TState>  ,
                MiddleRadicalism<TReaction, TFeature, TState>  ,
                HighRadicalism<TReaction, TFeature, TState>  ,
                ConservatismRadicalism<TReaction, TFeature, TState> >(c1, c2);
        public int CompareTo(ConservatismRadicalism<TReaction, TFeature, TState>  other)
        {
            if (this > other)
                return -1;
            if (this < other)
                return 1;
            return 0;
        }
        public override List<CharacterTraitBase<TReaction, TFeature, TState> >
            GetInterestedTraitsForCharacter(AgentBase<TReaction, TFeature, TState>agent)
        {
            var cs = agent.CharacterSystem;
            return new List<CharacterTraitBase<TReaction, TFeature, TState> >() {
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