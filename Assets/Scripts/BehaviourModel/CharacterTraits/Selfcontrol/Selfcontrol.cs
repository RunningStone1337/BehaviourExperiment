using System;
using UnityEngine;

namespace BehaviourModel
{
    /// <summary>
    /// ��� ������� �������� ����������: ������ ��������������������, ������� ����� ��������,
    /// ����������� �� ����������, �������� �������������� ���� ������ � ���������.
    /// ��� �������� �������� ����������: ������������������, ������� ����, ������ �������������� ���� ������ � ���������.
    /// ������ ������ �� ����� ������� ��������� �� ������ ���� � ������ ������������.
    /// ������������ ����� ����� ������������� � �����������.�������� � �������� �������� �� ����� �������
    /// ����� ��������� ���������� ��������������: ������������, �������������, ��������������, ����������
    /// � ���������� �������. ��� ����, ����� ��������������� ����� ����������, �� �������� ��������� ����������
    /// ������������ ������, ������� ������ ���������, ��������� � ���� ������������� ������.
    /// ���� ������ �������� ������� ����������� �������� ���������, ����������������� ��������.
    /// </summary>
    public abstract class Selfcontrol : CharacterTraitBase, IComparable<Selfcontrol>
    {
        [SerializeField] [Range(0f, 1f)] protected float recognitionChance;

        /// <summary>
        /// ���� ������ ���-����. �������� ������� �� �������� ������������.
        /// </summary>
        public float RecognitionChance { get; }

        public static bool operator <(Selfcontrol c1, Selfcontrol c2) =>
                          Char1LessChar2<LowSelfcontrol, MiddleSelfcontrol, HighSelfcontrol, Selfcontrol>(c1, c2);

        public static bool operator <=(Selfcontrol c1, Selfcontrol c2) =>
            Char1LessOrEqualChar2<LowSelfcontrol, MiddleSelfcontrol, HighSelfcontrol, Selfcontrol>(c1, c2);

        public static bool operator >(Selfcontrol c1, Selfcontrol c2) =>
            Char1MoreChar2<LowSelfcontrol, MiddleSelfcontrol, HighSelfcontrol, Selfcontrol>(c1, c2);

        public static bool operator >=(Selfcontrol c1, Selfcontrol c2) =>
            Char1MoreOrEqualChar2<LowSelfcontrol, MiddleSelfcontrol, HighSelfcontrol, Selfcontrol>(c1, c2);

        public int CompareTo(Selfcontrol other)
        {
            if (this > other)
                return -1;
            if (this < other)
                return 1;
            return 0;
        }
    }
}