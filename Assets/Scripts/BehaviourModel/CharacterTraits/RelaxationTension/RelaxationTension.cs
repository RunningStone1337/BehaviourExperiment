using System;

namespace BehaviourModel
{
    /// <summary>
    /// ��� ������� �������� ����������: ���������������, �������, �����������, �����������,
    /// ������ ���������, �������� �����������������, ��������������.
    /// ��� �������� �������� ����������: �����������, ������������, �������������, �����������������,
    /// ���������� ���������, ������������, �������������, �����������������.
    /// ������� ������ ���������������� ��� �������������� ��������������, ������� �������
    /// ������������ ��������; ������ ��� ��������� ����� ������������ � ����������������� ���������:
    /// ��������� ������������� ������������, ���������� ����������, ����� ����������� �������������.
    /// ����� ���� ����� ���������� ��������.
    /// ������������ ��������, ��� ������ ������ (0�5 ������) ���������� ��� ����� � ��������� �������
    /// ��������� ����������, ���������������� ���������. ���� �� ���������� ����� ������� �� 5 �� 8 ������
    /// ��������������� ����������� ������������� ������� � ��������������������.
    /// </summary>
    public abstract class RelaxationTension : CharacterTraitBase, IComparable<RelaxationTension>
    {
        public static bool operator <(RelaxationTension c1, RelaxationTension c2) =>
            Char1LessChar2<LowTension, MiddleTension, HighTension, RelaxationTension>(c1, c2);

        public static bool operator <=(RelaxationTension c1, RelaxationTension c2) =>
            Char1LessOrEqualChar2<LowTension, MiddleTension, HighTension, RelaxationTension>(c1, c2);

        public static bool operator >(RelaxationTension c1, RelaxationTension c2) =>
            Char1MoreChar2<LowTension, MiddleTension, HighTension, RelaxationTension>(c1, c2);

        public static bool operator >=(RelaxationTension c1, RelaxationTension c2) =>
            Char1MoreOrEqualChar2<LowTension, MiddleTension, HighTension, RelaxationTension>(c1, c2);
        public int CompareTo(RelaxationTension other)
        {
            if (this > other)
                return -1;
            if (this < other)
                return 1;
            return 0;
        }
    }
}