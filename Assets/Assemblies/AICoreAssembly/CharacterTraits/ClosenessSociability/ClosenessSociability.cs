using System;
using System.Collections.Generic;

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
    public abstract class ClosenessSociability : CharacterTraitBase
        , IComparable<ClosenessSociability>,ICommunicationalTrait

    {
        public static bool operator <(ClosenessSociability c1, ClosenessSociability c2) =>
        Char1LessChar2<LowClosenessSociability,
            MiddleClosenessSociability,
            HighClosenessSociability,
            ClosenessSociability>(c1, c2);

        public static bool operator <=(ClosenessSociability c1, ClosenessSociability c2) =>
            Char1LessOrEqualChar2<LowClosenessSociability,
                MiddleClosenessSociability,
                HighClosenessSociability,
                ClosenessSociability>(c1, c2);

        public static bool operator >(ClosenessSociability c1, ClosenessSociability c2) =>
            Char1MoreChar2<LowClosenessSociability,
                MiddleClosenessSociability,
                HighClosenessSociability,
                ClosenessSociability>(c1, c2);

        public static bool operator >=(ClosenessSociability c1, ClosenessSociability c2) =>
            Char1MoreOrEqualChar2<LowClosenessSociability,
                MiddleClosenessSociability,
                HighClosenessSociability,
                ClosenessSociability>(c1, c2);
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisCharType = CharTraitType.ClosenessSociability;
        }
        public int CompareTo(ClosenessSociability other)
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