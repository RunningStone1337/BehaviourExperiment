using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// ��� ������� �������� ����������: ��������, ������������, �����������,
    /// ���������, ����������, �����������, �������������, ������������, ��������������, �������������,
    /// ���������� ����� ���� �� ����, ����������, ���������������, ���������� ����� �������� �� ����������.
    /// ��� �������� �������� ����������: �����������������, �������������, �������������, ���������, ������������,
    /// ����������, ������ �������������, �������������, ����� �� ��������� ������� ������, ���������� � ������������� ���������,
    /// ����� ����������, �������.
    /// ������ � �� ����� ����������� ����������� � ������������ ���������,
    /// ������ ������ � ���������� �������� � ���� � �������, ��� � ��������������.
    /// ���������� �������������, ��� ������ �� ����� ������� � ��������� �������� � ������� �� ���� �����������.
    /// � ����� ��������� ���� � �������� �������� (�� ����� �������) ���������� ����������� � ���������.
    /// </summary>
    public abstract class SubordinationDomination : CharacterTraitBase, IComparable<SubordinationDomination>, ICommunicationalTrait
    {
        public static bool operator <(SubordinationDomination c1,
            SubordinationDomination c2) =>
         Char1LessChar2<LowDomination,
             MiddleDomination,
             HighDomination,
             SubordinationDomination>(c1, c2);

        public static bool operator <=(SubordinationDomination c1,
            SubordinationDomination c2) =>
            Char1LessOrEqualChar2<LowDomination,
                MiddleDomination,
                HighDomination,
                SubordinationDomination>(c1, c2);

        public static bool operator >(SubordinationDomination c1,
            SubordinationDomination c2) =>
            Char1MoreChar2<LowDomination,
                MiddleDomination,
                HighDomination,
                SubordinationDomination>(c1, c2);

        public static bool operator >=(SubordinationDomination c1,
            SubordinationDomination c2) =>
            Char1MoreOrEqualChar2<LowDomination,
                MiddleDomination,
                HighDomination,
                SubordinationDomination>(c1, c2);

        public int CompareTo(SubordinationDomination other)
        {
            if (this > other)
                return -1;
            if (this < other)
                return 1;
            return 0;
        }

      

        public override string ToString()
        {
            return $"����������-�������������: �������� {RawCharacterValue}, grade {CharacterGrade}";
        }
    }
}