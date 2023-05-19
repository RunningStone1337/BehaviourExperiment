using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// ��� ������� �������� ����������: ���������� � �������������, �������������� ������� ������,
    /// ������ � �������������. ������������ ����� ��������, �� ������ ������ �� ���������� ���������
    /// ���������� � ����. ������������������, ������������������, ��������������, ���������� ��������
    /// � ������������� ���������� ��������� � �����������, �������� �� ��������� � ���������� ������,
    /// ������� �� �� �������, ������ ��������������� � ���������� � ������������ ���������.
    /// ��� �������� �������� ����������: ����������������, ���������������, ������������, ����������������,
    /// �������������, ���������� � ���������������, ����������, �������������.
    /// �������� ������� ����� � ���������������, ���������� ���������� ������������ ��������� ������ � ����,
    /// ������������� � ���������� ����, ������� ��������������.
    /// </summary>
    public abstract class NormativityOfBehaviour : CharacterTraitBase,
        IComparable<NormativityOfBehaviour>, IRegulationalTrait
    {
        public static bool operator <(NormativityOfBehaviour c1,
            NormativityOfBehaviour c2) =>
         Char1LessChar2<LowNormativityOfBehaviour,
             MiddleNormativityOfBehaviour,
             HighNormativityOfBehaviour,
             NormativityOfBehaviour>(c1, c2);

        public static bool operator <=(NormativityOfBehaviour c1,
            NormativityOfBehaviour c2) =>
            Char1LessOrEqualChar2<LowNormativityOfBehaviour,
                MiddleNormativityOfBehaviour,
                HighNormativityOfBehaviour,
                NormativityOfBehaviour>(c1, c2);

        public static bool operator >(NormativityOfBehaviour c1,
            NormativityOfBehaviour c2) =>
            Char1MoreChar2<LowNormativityOfBehaviour,
                MiddleNormativityOfBehaviour,
                HighNormativityOfBehaviour,
                NormativityOfBehaviour>(c1, c2);

        public static bool operator >=(NormativityOfBehaviour c1,
            NormativityOfBehaviour c2) =>
            Char1MoreOrEqualChar2<LowNormativityOfBehaviour,
                MiddleNormativityOfBehaviour,
                HighNormativityOfBehaviour,
                NormativityOfBehaviour>(c1, c2);

        public int CompareTo(NormativityOfBehaviour other)
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
            ThisCharType = CharTraitType.NormativityOfBehaviour;
        }
       

        public override string ToString()
        {
            return $"������������� ���������: �������� {RawCharacterValue}, grade {CharacterGrade}";
        }
    }
}