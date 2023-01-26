using System;
using UnityEngine;

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
    public abstract class RigiditySensetivity : CharacterTraitBase, IComparable<RigiditySensetivity>
    {
        
        [SerializeField] [Range(0f, 1f)] protected float recognitionChance;
        /// <summary>
        /// ����������� ������������� ����-����. �������� ������� �� ����� ����������������.
        /// </summary>
        public float RecognitionChance { get=> recognitionChance; }
        public static bool operator <(RigiditySensetivity c1, RigiditySensetivity c2) =>
            Char1LessChar2<LowSensetivity, MiddleSensetivity, HighSensetivity, RigiditySensetivity>(c1, c2);

        public static bool operator <=(RigiditySensetivity c1, RigiditySensetivity c2) =>
            Char1LessOrEqualChar2<LowSensetivity, MiddleSensetivity, HighSensetivity, RigiditySensetivity>(c1, c2);

        public static bool operator >(RigiditySensetivity c1, RigiditySensetivity c2) =>
            Char1MoreChar2<LowSensetivity, MiddleSensetivity, HighSensetivity, RigiditySensetivity>(c1, c2);

        public static bool operator >=(RigiditySensetivity c1, RigiditySensetivity c2) =>
            Char1MoreOrEqualChar2<LowSensetivity, MiddleSensetivity, HighSensetivity, RigiditySensetivity>(c1, c2);
        public int CompareTo(RigiditySensetivity other)
        {
            if (this > other)
                return -1;
            if (this < other)
                return 1;
            return 0;
        }
    }
}