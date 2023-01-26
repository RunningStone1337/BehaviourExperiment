using System;

namespace BehaviourModel
{
    /// <summary>
    /// ��� ������� �������� ����������: �������������, ��������, ���������, ���������������,
    /// ������������, ��������������, ������������������, ���������������, ����������������������,
    /// �������� ������������� ������ ��������, ���������� ����������������, �������� ������, ����������� ���������.
    /// ��� �������� �������� ����������: ������������, ������ ����� ���� � ��������, � ������� ���������������,
    /// ������������� �������������, ����������������, ������������, ��������, ������������ ������������,
    /// ������ ������������, ������ �������� ����� �� ������� ��������, �������������.
    /// ������ ������������ �� ��������� ��������� �������� � ����� � ���������� ����������������.
    /// ���� ���� ������ ������������ ����������.������ ����� �������� � ���, ��� ������ �������������
    /// ��������� ����� ������������ ���������� ��������(������ ������������ ����������� � �����������
    /// ������������� � �������������� � � ������������ �������������� �������� � ����).
    /// ������� ������ �� ����� ������� ������������� ���������� � ����������������� �������������� � ��������������
    /// �������� � ������� ������������� ������������, �������� � �����������������.
    /// ���������� ������ � ���, ��� ���� � ������� �������� �� ����� ������� ��������
    /// ������ ������� � ��������, �������� � �����. ����� � �������� �������� ����� ����������������
    /// ��� ����������������, �����������, �� ������� �������. � ������������� ������������� ���� �������� �����
    /// ������� ����������� �� ����� ������� �� ������������ � ��������� � ������������ �������������.
    /// �� ������������ ��������������� ���� � �������� ������������ �������� �������� � �������������,
    /// ���������������� ��������� � � ������������ �������������� ��������� �������
    /// (� ����������� ����������, ��������������, ���������� ��� ������� ������� ������ �� ����� �������).
    /// </summary>
    public abstract class StraightforwardnessDiplomacy : CharacterTraitBase, IComparable<StraightforwardnessDiplomacy>
    {
        public static bool operator <(StraightforwardnessDiplomacy c1, StraightforwardnessDiplomacy c2) =>
           Char1LessChar2<LowDiplomacy, MiddleDiplomacy, HighDiplomacy, StraightforwardnessDiplomacy>(c1, c2);

        public static bool operator <=(StraightforwardnessDiplomacy c1, StraightforwardnessDiplomacy c2) =>
            Char1LessOrEqualChar2<LowDiplomacy, MiddleDiplomacy, HighDiplomacy, StraightforwardnessDiplomacy>(c1, c2);

        public static bool operator >(StraightforwardnessDiplomacy c1, StraightforwardnessDiplomacy c2) =>
                    Char1MoreChar2<LowDiplomacy, MiddleDiplomacy, HighDiplomacy, StraightforwardnessDiplomacy>(c1, c2);

        public static bool operator >=(StraightforwardnessDiplomacy c1, StraightforwardnessDiplomacy c2) =>
            Char1MoreOrEqualChar2<LowDiplomacy, MiddleDiplomacy, HighDiplomacy, StraightforwardnessDiplomacy>(c1, c2);

        public int CompareTo(StraightforwardnessDiplomacy other)
        {
            if (this > other)
                return -1;
            if (this < other)
                return 1;
            return 0;
        }
    }
}