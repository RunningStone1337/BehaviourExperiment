using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// �����������-�����������. ������ ������ ���������� ��� �����,
    /// ������� ���������� ������ ���������. �������� � �������� �������� �� ����� �������
    /// ��������� ���� ��������������, ������������� � ������� ��������� ���������,
    /// ����� ������ ����������� ����, ����� ��������� � �����������;
    /// ��� ��� ���������� ���������� ��������� ���������� � ����������� � ������������� �������.
    /// ���� ������ ����, ��� ������� ���� � ������������ ������.
    /// </summary>
    public abstract class CalmnessAnxiety : CharacterTraitBase, IComparable<CalmnessAnxiety>
    {
        protected override List<CharacterTraitBase> GetInterestedTraitsForCharacter(AgentBase agent)
        {
            var cs = agent.CharacterSystem;
            return new List<CharacterTraitBase>() {
                cs.CalmnessAnxiety,
                cs.ClosenessSociability,
                cs.EmotionalInstabilityStability,
                cs.RelaxationTension,
                cs.RestraintExpressiveness,
                cs.RigiditySensetivity,
                cs.SubordinationDomination
            };
        }

        public static bool operator <(CalmnessAnxiety c1, CalmnessAnxiety c2) =>
                  Char1LessChar2<LowAnxiety, MiddleAnxiety, HighAnxiety, CalmnessAnxiety>(c1, c2);

        public static bool operator <=(CalmnessAnxiety c1, CalmnessAnxiety c2) =>
            Char1LessOrEqualChar2<LowAnxiety, MiddleAnxiety, HighAnxiety, CalmnessAnxiety>(c1, c2);

        public static bool operator >(CalmnessAnxiety c1, CalmnessAnxiety c2) =>
            Char1MoreChar2<LowAnxiety, MiddleAnxiety, HighAnxiety, CalmnessAnxiety>(c1, c2);

        public static bool operator >=(CalmnessAnxiety c1, CalmnessAnxiety c2) =>
            Char1MoreOrEqualChar2<LowAnxiety, MiddleAnxiety, HighAnxiety, CalmnessAnxiety>(c1, c2);

        public int CompareTo(CalmnessAnxiety other)
        {
            if (this > other)
                return -1;
            if (this < other)
                return 1;
            return 0;
        }
    }
}