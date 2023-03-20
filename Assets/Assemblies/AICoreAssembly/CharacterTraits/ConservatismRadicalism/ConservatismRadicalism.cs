using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// Для низкого значения характерно: консервативность, устойчивость по отношению к традициям, сомнение
    /// в отношении к новых идей и принципов, склонность к морализации и нравоучениям,
    /// сопротивление переменам, узость интеллектуальных интересов, ориентация на конкретную реальную деятельность.
    /// Для высокого значения характерно: свободомыслие, экспериментаторство,
    /// наличие интеллектуальных интересов, развитое аналитическое мышление,
    /// восприимчивость к переменам, к новым идеям, недоверие к авторитетам, отказ принимать что-либо на веру,
    /// направленность на аналитическую, теоретическую деятельность.
    /// В исследованиях было получено доказательство того, что личности с высокими показателями
    /// по этому фактору лучше информированы, меньше склонны к морализаторству, выражают больший интерес к науке,
    /// нежели к догмам.Более того, они готовы к нарушению привычек и устоявшихся традиций,
    /// им свойственна независимость суждений, взглядов и поведения.
    /// Фактор определяет радикальное, интеллектуальное, политическое и религиозное отношения.
    /// </summary>
    public abstract class ConservatismRadicalism : CharacterTraitBase,
        IComparable<ConservatismRadicalism>
    {
        public static bool operator <(ConservatismRadicalism c1,
            ConservatismRadicalism c2) =>
         Char1LessChar2<LowRadicalism,
             MiddleRadicalism,
             HighRadicalism,
             ConservatismRadicalism>(c1, c2);

        public static bool operator <=(ConservatismRadicalism c1,
            ConservatismRadicalism c2) =>
            Char1LessOrEqualChar2<LowRadicalism,
                MiddleRadicalism,
                HighRadicalism,
                ConservatismRadicalism>(c1, c2);

        public static bool operator >(ConservatismRadicalism c1,
            ConservatismRadicalism c2) =>
            Char1MoreChar2<LowRadicalism,
                MiddleRadicalism,
                HighRadicalism,
                ConservatismRadicalism>(c1, c2);

        public static bool operator >=(ConservatismRadicalism c1,
            ConservatismRadicalism c2) =>
            Char1MoreOrEqualChar2<LowRadicalism,
                MiddleRadicalism,
                HighRadicalism,
                ConservatismRadicalism>(c1, c2);

        public int CompareTo(ConservatismRadicalism other)
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
            ThisCharType = CharTraitType.ConservatismRadicalism;
        }
       

        public override string ToString()
        {
            return $"Консерватизм-радикализм: значение {RawCharacterValue}, grade {CharacterGrade}";
        }
    }
}