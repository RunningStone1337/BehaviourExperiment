using System;

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
    public abstract class ClosenessSociability : CharacterTraitBase, IComparable<ClosenessSociability>
    {
        public static bool operator <(ClosenessSociability c1, ClosenessSociability c2) =>
        Char1LessChar2<LowClosenessSociability, MiddleClosenessSociability, HighClosenessSociability, ClosenessSociability>(c1, c2);

        public static bool operator <=(ClosenessSociability c1, ClosenessSociability c2) =>
            Char1LessOrEqualChar2<LowClosenessSociability, MiddleClosenessSociability, HighClosenessSociability, ClosenessSociability>(c1, c2);

        public static bool operator >(ClosenessSociability c1, ClosenessSociability c2) =>
            Char1MoreChar2<LowClosenessSociability, MiddleClosenessSociability, HighClosenessSociability, ClosenessSociability>(c1, c2);

        public static bool operator >=(ClosenessSociability c1, ClosenessSociability c2) =>
            Char1MoreOrEqualChar2<LowClosenessSociability, MiddleClosenessSociability, HighClosenessSociability, ClosenessSociability>(c1, c2);

        public int CompareTo(ClosenessSociability other)
        {
            if (this > other)
                return -1;
            if (this < other)
                return 1;
            return 0;
        }
    }
}