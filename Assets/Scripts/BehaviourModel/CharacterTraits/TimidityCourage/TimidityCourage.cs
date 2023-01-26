using System;

namespace BehaviourModel
{
    /// <summary>
    /// ��� ������� �������� ����������: �������, �������������, ������������� ������������,
    /// ������������, ���������� �����������, ������������, �������������� � ������, ���������� ���������������� � ������,
    /// ������������ ��������������� ����� ������������ � ������� � ����� ������ (2�3 ��������).
    /// ��� �������� �������� ����������: ��������, ����������������, ����������;
    /// ������� ����� ������������� ��������, ���������� � ����� � �������������� � ����������� ������
    /// � ���������� ���������������, ����������� ��������� ���������������, ������������ �������,
    /// ���������� � ����������� � ���������� ��������� �������.
    /// ������ H � ����� ������������ ������, ������� ������������� ������� ���������� � ���������� ���������.
    /// ��� ���� ���� ���������, ��� ���� ������ ����� ������������ ������������� � �������� ����������
    /// ��������� � ����������� ������������.���� � �������� �������� ����� ������� ����� ���������� � ���������� �����
    /// (�������-����������), ������, �����������, ����� ����������� ������������� ��������, ��� ����� ������ �� ��������.
    /// ������ ������ ����� ������� ������������� ����� �����������, ������, �� ������������,
    /// ������ ����������� ��������������� �������.
    /// </summary>
    public abstract class TimidityCourage : CharacterTraitBase, IComparable<TimidityCourage>
    {
        public static bool operator <(TimidityCourage c1, TimidityCourage c2) =>
            Char1LessChar2<LowCourage, MiddleCourage, HighCourage, TimidityCourage>(c1, c2);

        public static bool operator <=(TimidityCourage c1, TimidityCourage c2) =>
            Char1LessOrEqualChar2<LowCourage, MiddleCourage, HighCourage, TimidityCourage>(c1, c2);

        public static bool operator >(TimidityCourage c1, TimidityCourage c2) =>
            Char1MoreChar2<LowCourage, MiddleCourage, HighCourage, TimidityCourage>(c1, c2);

        public static bool operator >=(TimidityCourage c1, TimidityCourage c2) =>
            Char1MoreOrEqualChar2<LowCourage, MiddleCourage, HighCourage, TimidityCourage>(c1, c2);
        public int CompareTo(TimidityCourage other)
        {
            if (this > other)
                return -1;
            if (this < other)
                return 1;
            return 0;
        }
    }
}