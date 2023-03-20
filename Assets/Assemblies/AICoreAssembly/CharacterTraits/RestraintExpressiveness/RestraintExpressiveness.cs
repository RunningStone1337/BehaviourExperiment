using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// ��� ������� �������� ����������: ������������, ������������, ���������������� � ������ �������� �� �������.
    /// ���������� � �������������, ������������ � �������, ���������������� � ���������� ����������������,
    /// ������������ � ���������� ������.
    /// ��� �������� �������� ����������: ����������������, ��������������, ��������������, �����������,
    /// �������������� � ������ ��������� �� �������, ������������� ���������� ���������� ���������,
    /// ���������������, ��������������, ������������� ������� � ���������� ����� ������, ������������ �������,
    /// ������� ������������ ������������� ��������� � �������
    /// ������ ������ ������������ ����� ��������� �������� ������� ������� ��������� ������� ��������.
    /// ��������� ��� ����, ��� � ������ ���������� �������������� � ����������� ���������� ���������,
    /// ��� ����� ������������� ��� ������������� ������������ ������������� ��������.
    /// � ����� ������ F ������������ �� ��������� ������������� ������������ � ������������ � ��������� �������.
    /// ������: ������, ����������� ������ ����� ����� ������� ������, ���������, ������������� � ����� ������.
    /// </summary>
    public abstract class RestraintExpressiveness : CharacterTraitBase,
        IComparable<RestraintExpressiveness>
    {
        public static bool operator <(RestraintExpressiveness c1,
            RestraintExpressiveness c2) =>
         Char1LessChar2<LowExpressiveness,
             MiddleExpressiveness,
             HighExpressiveness,
             RestraintExpressiveness>(c1, c2);

        public static bool operator <=(RestraintExpressiveness c1,
            RestraintExpressiveness c2) =>
            Char1LessOrEqualChar2<LowExpressiveness,
                MiddleExpressiveness,
                HighExpressiveness,
                RestraintExpressiveness>(c1, c2);

        public static bool operator >(RestraintExpressiveness c1,
            RestraintExpressiveness c2) =>
            Char1MoreChar2<LowExpressiveness,
                MiddleExpressiveness,
                HighExpressiveness,
                RestraintExpressiveness>(c1, c2);

        public static bool operator >=(RestraintExpressiveness c1,
            RestraintExpressiveness c2) =>
            Char1MoreOrEqualChar2<LowExpressiveness,
                MiddleExpressiveness,
                HighExpressiveness,
                RestraintExpressiveness>(c1, c2);

        public int CompareTo(RestraintExpressiveness other)
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
            ThisCharType = CharTraitType.RestraintExpressiveness;
        }
       

        public override string ToString()
        {
            return $"���������������: �������� {RawCharacterValue}, grade {CharacterGrade}";
        }
    }
}