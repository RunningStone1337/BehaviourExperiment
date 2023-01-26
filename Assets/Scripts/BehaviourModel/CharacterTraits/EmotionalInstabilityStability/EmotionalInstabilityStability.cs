using System;

namespace BehaviourModel
{
    /// <summary>
    /// ��� ������� �������� ����������: ������������� ��������������, ��������������;
    /// ������� ��������� ��� �������� ������, ���������� � �����������, ����� ��������������,
    /// ���������� � ���������. ������ ������������� �� ��������� � ����������, �����������������, ������������.
    /// ��� �������� �������� ����������: ������������� ������������, �������������;
    /// ������� ������������ ������, ���������, �������� � ���������, ���������������, ����� ���� ��������, ������������ �� ����������.
    /// ���� ������ ������������� ������������ ��������� � �������� ������ � ����������������� �������������� ���������������.
    /// </summary>
    public abstract class EmotionalInstabilityStability : CharacterTraitBase, IComparable<EmotionalInstabilityStability>
    {
        public static bool operator <(EmotionalInstabilityStability c1, EmotionalInstabilityStability c2) =>
       Char1LessChar2<LowEmotionalStability, MiddleEmotionalStability, HighEmotionalStability, EmotionalInstabilityStability>(c1, c2);

        public static bool operator <=(EmotionalInstabilityStability c1, EmotionalInstabilityStability c2) =>
            Char1LessOrEqualChar2<LowEmotionalStability, MiddleEmotionalStability, HighEmotionalStability, EmotionalInstabilityStability>(c1, c2);

        public static bool operator >(EmotionalInstabilityStability c1, EmotionalInstabilityStability c2) =>
            Char1MoreChar2<LowEmotionalStability, MiddleEmotionalStability, HighEmotionalStability, EmotionalInstabilityStability>(c1, c2);

        public static bool operator >=(EmotionalInstabilityStability c1, EmotionalInstabilityStability c2) =>
            Char1MoreOrEqualChar2<LowEmotionalStability, MiddleEmotionalStability, HighEmotionalStability, EmotionalInstabilityStability>(c1, c2);
        public int CompareTo(EmotionalInstabilityStability other)
        {
            if (this > other)
                return -1;
            if (this < other)
                return 1;
            return 0;
        }
    }
}