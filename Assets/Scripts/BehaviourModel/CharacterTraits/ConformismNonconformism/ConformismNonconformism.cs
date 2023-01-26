using System;

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
    public abstract class ConformismNonconformism : CharacterTraitBase, IComparable<ConformismNonconformism>
    {
        public static bool operator <(ConformismNonconformism c1, ConformismNonconformism c2) =>
           Char1LessChar2<LowNonconformism, MiddleNonconformism, HighNonconformism, ConformismNonconformism>(c1, c2);

        public static bool operator <=(ConformismNonconformism c1, ConformismNonconformism c2) =>
            Char1LessOrEqualChar2<LowNonconformism, MiddleNonconformism, HighNonconformism, ConformismNonconformism>(c1, c2);

        public static bool operator >(ConformismNonconformism c1, ConformismNonconformism c2) =>
                    Char1MoreChar2<LowNonconformism, MiddleNonconformism, HighNonconformism, ConformismNonconformism>(c1, c2);

        public static bool operator >=(ConformismNonconformism c1, ConformismNonconformism c2) =>
            Char1MoreOrEqualChar2<LowNonconformism, MiddleNonconformism, HighNonconformism, ConformismNonconformism>(c1, c2);

        public int CompareTo(ConformismNonconformism other)
        {
            if (this > other)
                return -1;
            if (this < other)
                return 1;
            return 0;
        }
    }
}