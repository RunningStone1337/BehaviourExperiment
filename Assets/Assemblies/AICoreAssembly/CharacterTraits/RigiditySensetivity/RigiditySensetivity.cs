using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// ��� ������� �������� ����������: �������������������, ���������������, ���������,
    /// �������������, �������� � ���������, ������������, ������ ��������� ���������
    /// � ���������� �� ��������� � ����������, ��������������, ����������.
    /// ��� �������� �������� ����������: ����������������, �����������������, ���������
    /// ������������� �����������, ���������� � ����������, �������������� ���������� ����,
    /// �������� ������������ ��������, �������������, �������������, ���������� � �������, ����������,
    /// ������������� � ��������� ������ �����, ���������� ���������������.
    /// ���� ������ �������� �������� � ���������� ������ � ������������ ��������������� ��������.
    /// ��������� ��� ����, ��� ���� � ������� ������������ �� ����� ������� ������ ������, ����� ����������,
    /// ���� ���������� �������, ���������.
    /// �������������� ����� ������� ����� � ������� ������� ������� ������� ���������������
    /// � ������� ����������������; ������ ������ �������� ��� ��������������.
    /// �������� � �������� ������������ �� ����� ������� ��������������� ��� ��������� � ��������� ����������,
    /// �������� � ���������, �������������� ��� ������ �������� � ������ ��������� �������.
    /// </summary>
    public abstract class RigiditySensetivity : CharacterTraitBase
        , IComparable<RigiditySensetivity>, IEmotionalTrait
    {
        public static bool operator <(RigiditySensetivity c1,
                    RigiditySensetivity c2) =>
         Char1LessChar2<LowSensetivity,
             MiddleSensetivity,
             HighSensetivity,
             RigiditySensetivity>(c1, c2);

        public static bool operator <=(RigiditySensetivity c1,
            RigiditySensetivity c2) =>
            Char1LessOrEqualChar2<LowSensetivity,
                MiddleSensetivity,
                HighSensetivity,
                RigiditySensetivity>(c1, c2);

        public static bool operator >(RigiditySensetivity c1,
            RigiditySensetivity c2) =>
            Char1MoreChar2<LowSensetivity,
                MiddleSensetivity,
                HighSensetivity,
                RigiditySensetivity>(c1, c2);

        public static bool operator >=(RigiditySensetivity c1,
            RigiditySensetivity c2) =>
            Char1MoreOrEqualChar2<LowSensetivity,
                MiddleSensetivity,
                HighSensetivity,
                RigiditySensetivity>(c1, c2);
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisCharType = CharTraitType.RigiditySensetivity;
        }
        public int CompareTo(RigiditySensetivity other)
        {
            if (this > other)
                return -1;
            if (this < other)
                return 1;
            return 0;
        }

        

        public override string ToString()
        {
            return $"���������-����������������: �������� {RawCharacterValue}, grade {CharacterGrade}";
        }
    }
}