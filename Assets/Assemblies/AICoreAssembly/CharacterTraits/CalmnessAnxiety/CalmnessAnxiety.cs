using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// Спокойствие-тревожность. Низкие оценки характерны для людей,
    /// которые «управляют своими неудачами». Личность с высокими оценками по этому фактору
    /// чувствует свою неустойчивость, напряженность в трудных жизненных ситуациях,
    /// легко теряет присутствие духа, полна сожалений и сострадания;
    /// для нее характерна комбинация симптомов ипохондрии и неврастении с преобладанием страхов.
    /// Этот фактор шире, чем чувство вины в общепринятом смысле.
    /// </summary>
    public abstract class CalmnessAnxiety : CharacterTraitBase,
        IComparable<CalmnessAnxiety>, IEmotionalTrait

    {
        public static bool operator <(CalmnessAnxiety c1,
            CalmnessAnxiety c2) =>
                  Char1LessChar2<LowAnxiety,
                      MiddleAnxiety,
                      HighAnxiety,
                      CalmnessAnxiety>(c1, c2);

        public static bool operator <=(CalmnessAnxiety c1,
            CalmnessAnxiety c2) =>
            Char1LessOrEqualChar2<LowAnxiety,
                MiddleAnxiety,
                HighAnxiety,
                CalmnessAnxiety>(c1, c2);

        public static bool operator >(CalmnessAnxiety c1,
            CalmnessAnxiety c2) =>
            Char1MoreChar2<LowAnxiety,
                MiddleAnxiety,
                HighAnxiety,
                CalmnessAnxiety>(c1, c2);

        public static bool operator >=(CalmnessAnxiety c1,
            CalmnessAnxiety c2) =>
            Char1MoreOrEqualChar2<LowAnxiety,
                MiddleAnxiety,
                HighAnxiety,
                CalmnessAnxiety>(c1, c2);

        public int CompareTo(CalmnessAnxiety other)
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
            ThisCharType = CharTraitType.CalmnessAnxiety;
        }
        public override string ToString()
        {
            return $"Спокойствие-тревожность: значение {RawCharacterValue}, grade {CharacterGrade}";
        }
    }
}