using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// ��� ������� �������� ����������: ������������ � ��������� ���������� ��������, �����������
    /// � ������� ����������� �����, ��������� ������������� ��������, ������������� ������� ����� ���������� ��������.
    /// ��� �������� �������� ����������: �������� ����������� ��������, �������������, �����������������,
    /// ������� �����������.���������� ������� ������� ����� ��������, �������� ����������.
    /// ������ � �� ���������� ������� ����������, �� ������������ �� ��������� ������������� ��������
    /// � ������ ������ ���������� �������� � ��������.������� ��������,
    /// ��� ������ ������ �� ����� ������� ����� �������� �� ������ ������������� ��������:
    /// �����������, �����������������, ������� ���������������� �����.
    /// </summary>
    public abstract class Intelligence : CharacterTraitBase,
        IComparable<Intelligence>, IIntellectualTrait
    {
        public static bool operator <(Intelligence c1,
            Intelligence c2) =>
         Char1LessChar2<LowIntelligence,
             MiddleIntelligence,
             HighIntelligence,
             Intelligence>(c1, c2);

        public static bool operator <=(Intelligence c1,
            Intelligence c2) =>
            Char1LessOrEqualChar2<LowIntelligence,
                MiddleIntelligence,
                HighIntelligence,
                Intelligence>(c1, c2);

        public static bool operator >(Intelligence c1,
            Intelligence c2) =>
            Char1MoreChar2<LowIntelligence,
                MiddleIntelligence,
                HighIntelligence,
                Intelligence>(c1, c2);

        public static bool operator >=(Intelligence c1,
            Intelligence c2) =>
            Char1MoreOrEqualChar2<LowIntelligence,
                MiddleIntelligence,
                HighIntelligence,
                Intelligence>(c1, c2);

        public int CompareTo(Intelligence other)
        {
            if (this > other)
                return -1;
            if (this < other)
                return 1;
            return 0;
        }
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisCharType = CharTraitType.Intelligence;
        }
       

        public override string ToString()
        {
            return $"���������: �������� {RawCharacterValue}, grade {CharacterGrade}";
        }
    }
}