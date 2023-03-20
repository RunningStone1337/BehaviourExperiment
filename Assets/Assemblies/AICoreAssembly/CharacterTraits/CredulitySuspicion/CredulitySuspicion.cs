using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// ������������-����������������.
    /// ��� ������� �������� ����������: ����������, �����������, ����������, �������������;
    /// ������� �� �������, ������������. ����� ���� ������� ����������� ����������������.
    /// ��� �������� �������� ����������: ������������, ���������������, ��������������� �� ��������� � �����;
    /// ���������� � ��������, ���������� ��������� ��������������� �� ������ �� ����������,
    /// �����������������.������ ������������, ����������������� � ������������� � ���������� ���������.
    /// � ����� ������ �������� ������������� ��������� � �����.
    /// ����� ������� ������ �� ����� ������� ������� �� �������� ������ � ������������� �������������,
    /// ����������������� ��������. ������ ����� ������������� �������� �����������, �� �������� � �����������.
    /// </summary>
    public abstract class CredulitySuspicion : CharacterTraitBase,
        IComparable<CredulitySuspicion>
    {
        public static bool operator <(CredulitySuspicion c1,
            CredulitySuspicion c2) =>
         Char1LessChar2<LowSuspicion,
             MiddleSuspicion,
             HighSuspicion,
             CredulitySuspicion>(c1, c2);

        public static bool operator <=(CredulitySuspicion c1,
            CredulitySuspicion c2) =>
            Char1LessOrEqualChar2<LowSuspicion,
                MiddleSuspicion,
                HighSuspicion,
                CredulitySuspicion>(c1, c2);

        public static bool operator >(CredulitySuspicion c1,
            CredulitySuspicion c2) =>
            Char1MoreChar2<LowSuspicion,
                MiddleSuspicion,
                HighSuspicion,
                CredulitySuspicion>(c1, c2);

        public static bool operator >=(CredulitySuspicion c1,
            CredulitySuspicion c2) =>
            Char1MoreOrEqualChar2<LowSuspicion,
                MiddleSuspicion,
                HighSuspicion,
                CredulitySuspicion>(c1, c2);

        public int CompareTo(CredulitySuspicion other)
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
            ThisCharType = CharTraitType.CredulitySuspicion;
        }
       

        public override string ToString()
        {
            return $"������������-����������������: �������� {RawCharacterValue}, grade {CharacterGrade}";
        }
    }
}