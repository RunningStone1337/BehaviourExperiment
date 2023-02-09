using System;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    /// <summary>
    /// ��� ������� �������� ����������: �������������������, ���������������, ���������,
    /// �������������, �������� � ���������, ������������, ������ ��������� ���������
    /// � ���������� �� ��������� � ����������, ��������������, ����������.
    /// ��� �������� �������� ����������: ����������������, �����������������, ���������
    /// ������������� �����������, ���������� � ����������, �������������� ���������� ����,
    /// �������� ������������ ��������, �������������, �������������, ���������� � �������, ����������,
    /// ������������� � ��������� ������ �����, ���������� ���������������.
    /// ���� ������ �������� �������� � ���������� ������ � ������������ ��������������� ��������.
    /// ��������� ��� ����, ��� ���� � ������� ������������ �� ����� ������� ������ ������, ����� ����������,
    /// ���� ���������� �������, ���������.
    /// �������������� ����� ������� ����� � ������� ������� ������� ������� ���������������
    /// � ������� ����������������; ������ ������ �������� ��� ��������������.
    /// �������� � �������� ������������ �� ����� ������� ��������������� ��� ��������� � ��������� ����������,
    /// �������� � ���������, �������������� ��� ������ �������� � ������ ��������� �������.
    /// </summary>
    public abstract class RigiditySensetivity<TReaction, TFeature, TState> : CharacterTraitBase<TReaction, TFeature, TState>
        ,IComparable<RigiditySensetivity<TReaction, TFeature, TState>>
        where TReaction : IReaction
        where TFeature : IFeature where TState : IState
    {


        public static bool operator <(RigiditySensetivity<TReaction, TFeature, TState> c1,
                    RigiditySensetivity<TReaction, TFeature, TState> c2) =>
         Char1LessChar2<LowSensetivity<TReaction, TFeature, TState>,
             MiddleSensetivity<TReaction, TFeature, TState>,
             HighSensetivity<TReaction, TFeature, TState>,
             RigiditySensetivity<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator <=(RigiditySensetivity<TReaction, TFeature, TState> c1,
            RigiditySensetivity<TReaction, TFeature, TState> c2) =>
            Char1LessOrEqualChar2<LowSensetivity<TReaction, TFeature, TState>,
                MiddleSensetivity<TReaction, TFeature, TState>,
                HighSensetivity<TReaction, TFeature, TState>,
                RigiditySensetivity<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator >(RigiditySensetivity<TReaction, TFeature, TState> c1,
            RigiditySensetivity<TReaction, TFeature, TState> c2) =>
            Char1MoreChar2<LowSensetivity<TReaction, TFeature, TState>,
                MiddleSensetivity<TReaction, TFeature, TState>,
                HighSensetivity<TReaction, TFeature, TState>,
                RigiditySensetivity<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator >=(RigiditySensetivity<TReaction, TFeature, TState> c1,
            RigiditySensetivity<TReaction, TFeature, TState> c2) =>
            Char1MoreOrEqualChar2<LowSensetivity<TReaction, TFeature, TState>,
                MiddleSensetivity<TReaction, TFeature, TState>,
                HighSensetivity<TReaction, TFeature, TState>,
                RigiditySensetivity<TReaction, TFeature, TState>>(c1, c2);

        public int CompareTo(RigiditySensetivity<TReaction, TFeature, TState> other)
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
            return new List<CharacterTraitBase<TReaction, TFeature, TState> >()
            {  
                cs.RigiditySensetivity,
                cs.EmotionalInstabilityStability,
                cs.PracticalityDreaminess,
                cs.RestraintExpressiveness,
                cs.RigiditySensetivity,
                cs.SubordinationDomination
            };
        }
        public override string ToString()
        {
            return $"���������-����������������: �������� {RawCharacterValue}, grade {CharacterGrade}";
        }
              
    }
}