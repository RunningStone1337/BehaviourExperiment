using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// ��� ������� �������� ����������: ����������������, ������������ �� ��������� � ���������, ��������
    /// � ��������� � ����� ���� � ���������, ���������� � ����������� � ������������,
    /// ������������� ���������, ������ ���������������� ���������, ���������� �� ���������� �������� ������������.
    /// ��� �������� �������� ����������: �������������, �������������������,
    /// ������� ���������������� ���������, �������� ������������� ��������,
    /// ��������������� � ���������, � ����� �����, ��������� � �����������, ����� ��������� ���-���� �� ����,
    /// �������������� �� �������������, ������������� ������������.
    /// � ������������� ���� �������� �������������� ����, ��� �������� � �������� ������������
    /// �� ����� ������� ����� �������������, ������ ������� � ���������������, �������� ������� ������� � �����,
    /// ������ � ������.����� ����, ��� ������ � ��������� �������� � ����������� ��������,
    /// �� ����������� ������������� ��������, �������� � ���������.
    /// ������ ���������� �����������, ����������������, ������������ � ����������� ���������.
    /// </summary>
    public abstract class ConservatismRadicalism : CharacterTraitBase, IComparable<ConservatismRadicalism>
    {
        public static bool operator <(ConservatismRadicalism c1, ConservatismRadicalism c2) =>
            Char1LessChar2<LowRadicalism, MiddleRadicalism, HighRadicalism, ConservatismRadicalism>(c1, c2);

        public static bool operator <=(ConservatismRadicalism c1, ConservatismRadicalism c2) =>
            Char1LessOrEqualChar2<LowRadicalism, MiddleRadicalism, HighRadicalism, ConservatismRadicalism>(c1, c2);

        public static bool operator >(ConservatismRadicalism c1, ConservatismRadicalism c2) =>
                    Char1MoreChar2<LowRadicalism, MiddleRadicalism, HighRadicalism, ConservatismRadicalism>(c1, c2);

        public static bool operator >=(ConservatismRadicalism c1, ConservatismRadicalism c2) =>
            Char1MoreOrEqualChar2<LowRadicalism, MiddleRadicalism, HighRadicalism, ConservatismRadicalism>(c1, c2);

        /// <summary>
        /// ���������� ���������� ��������� ��������.
        /// ��� ����� ���������, ��� �������� � ��������.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override abstract float CalculateImportanceForFamiliar(AgentBase ab);
        protected override List<CharacterTraitBase> GetInterestedTraitsForCharacter(AgentBase agent)
        {
            var cs = agent.CharacterSystem;
            return new List<CharacterTraitBase>() {
                cs.ConservatismRadicalism,
                cs.ConformismNonconformism,
                cs.Intelligence,
                cs.NormativityOfBehaviour,
                cs.StraightforwardnessDiplomacy,
                cs.TimidityCourage
            };
        }
        public int CompareTo(ConservatismRadicalism other)
        {
            if (this > other)
                return -1;
            if (this < other)
                return 1;
            return 0;
        }
    }
}