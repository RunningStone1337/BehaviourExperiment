using System;

namespace BehaviourModel
{
    /// <summary>
    /// ��� ������� �������� ����������: ������� �������� ������� ������������ �����,
    /// ������������, ���������� �� ������� ����������, �������� ���������� �����������, ������������, ��������������.
    /// ��� �������� �������� ����������: ������� �����������, ������������� ������ ������,
    /// ����������� ���������(������� � ��������), �������� ������ �� ������������ ��������,
    /// ������ ����������� ������������ ���������, ����������������� �� ���� ���������� ���; ��������������.
    /// � ����� ������ ������������ �� ��������� ������������ �����������, ������������ � �������� ��������� ��������,
    /// �����, ��� ������������, �������������� ���, ��������, ��������� �������� � ��������, ������������� ��������� � �����.
    /// </summary>
    public abstract class PracticalityDreaminess : CharacterTraitBase, IComparable<PracticalityDreaminess>
    {
        public static bool operator <(PracticalityDreaminess c1, PracticalityDreaminess c2) =>
            Char1LessChar2<LowDreaminess, MiddleDreaminess, HighDreaminess, PracticalityDreaminess>(c1, c2);

        public static bool operator <=(PracticalityDreaminess c1, PracticalityDreaminess c2) =>
            Char1LessOrEqualChar2<LowDreaminess, MiddleDreaminess, HighDreaminess, PracticalityDreaminess>(c1, c2);

        public static bool operator >(PracticalityDreaminess c1, PracticalityDreaminess c2) =>
                    Char1MoreChar2<LowDreaminess, MiddleDreaminess, HighDreaminess, PracticalityDreaminess>(c1, c2);

        public static bool operator >=(PracticalityDreaminess c1, PracticalityDreaminess c2) =>
            Char1MoreOrEqualChar2<LowDreaminess, MiddleDreaminess, HighDreaminess, PracticalityDreaminess>(c1, c2);

        public int CompareTo(PracticalityDreaminess other)
        {
            if (this > other)
                return -1;
            if (this < other)
                return 1;
            return 0;
        }
    }
}