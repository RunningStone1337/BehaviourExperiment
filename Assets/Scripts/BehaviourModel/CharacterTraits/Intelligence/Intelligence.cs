using System;

namespace BehaviourModel
{
    /// <summary>
    /// ƒл€ низкого значени€ характерно: конкретность и некотора€ ригидность мышлени€, затруднени€
    /// в решении абстрактных задач, сниженна€ оперативность мышлени€, недостаточный уровень общей вербальной культуры.
    /// ƒл€ высокого значени€ характерно: развитое абстрактное мышление, оперативность, сообразительность,
    /// быстра€ обучаемость.ƒостаточно высокий уровень общей культуры, особенно вербальной.
    /// ‘актор ¬ не определ€ет уровень интеллекта, он ориентирован на измерение оперативности мышлени€
    /// и общего уровн€ вербальной культуры и эрудиции.—ледует отметить,
    /// что низкие оценки по этому фактору могут зависеть от других характеристик личности:
    /// тревожности, фрустрированности, низкого образовательного ценза.
    /// </summary>
    public abstract class Intelligence : CharacterTraitBase, IComparable<Intelligence>
    {
        public static bool operator <(Intelligence c1, Intelligence c2) =>
          Char1LessChar2<LowIntelligence, MiddleIntelligence, HighIntelligence, Intelligence>(c1, c2);

        public static bool operator <=(Intelligence c1, Intelligence c2) =>
            Char1LessOrEqualChar2<LowIntelligence, MiddleIntelligence, HighIntelligence, Intelligence>(c1, c2);

        public static bool operator >(Intelligence c1, Intelligence c2) =>
                    Char1MoreChar2<LowIntelligence, MiddleIntelligence, HighIntelligence, Intelligence>(c1, c2);

        public static bool operator >=(Intelligence c1, Intelligence c2) =>
            Char1MoreOrEqualChar2<LowIntelligence, MiddleIntelligence, HighIntelligence, Intelligence>(c1, c2);

        public int CompareTo(Intelligence other)
        {
            if (this > other)
                return -1;
            if (this < other)
                return 1;
            return 0;
        }
    }
}