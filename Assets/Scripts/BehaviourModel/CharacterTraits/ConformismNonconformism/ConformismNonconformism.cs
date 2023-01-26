using System;

namespace BehaviourModel
{
    /// <summary>
    /// —тепень независимости, свободы от мнений других людей.
    /// ƒл€ низкого значени€ характерно: зависимость от мнени€ и требований группы, социабельность, следование за общественным мнением, стремление работать и принимать решени€ вместе с другими людьми, низка€ самосто€тельность, ориентаци€ на социальное одобрение.
    /// ƒл€ высокого значени€ характерно: независимость, ориентаци€ на собственные решени€,
    /// самосто€тельность, находчивость, стремление иметь собственное мнение.
    /// ѕри крайних высоких оценках склонность к противопоставлению себ€ группе и желание в ней доминировать.
    /// Ќизкие оценки по этому фактору имеют личности общительные, дл€ которых много значит одобрение общества,
    /// это светские люди.
    /// ¬ысокие оценки имеют люди, которые часто разобщены с группой и по роду зан€тий €вл€ютс€ индивидуалистами Ц писатели,
    /// ученые и преступники.
    /// </summary>
    public abstract class ConformismNonconformism : CharacterTraitBase, IComparable<ConformismNonconformism>
    {
        public static bool operator <(ConformismNonconformism c1, ConformismNonconformism c2) =>
           Char1LessChar2<LowNonconformism, MiddleNonconformism, HighNonconformism, ConformismNonconformism>(c1, c2);

        public static bool operator <=(ConformismNonconformism c1, ConformismNonconformism c2) =>
            Char1LessOrEqualChar2<LowNonconformism, MiddleNonconformism, HighNonconformism, ConformismNonconformism>(c1, c2);

        public static bool operator >(ConformismNonconformism c1, ConformismNonconformism c2) =>
                    Char1MoreChar2<LowNonconformism, MiddleNonconformism, HighNonconformism, ConformismNonconformism>(c1, c2);

        public static bool operator >=(ConformismNonconformism c1, ConformismNonconformism c2) =>
            Char1MoreOrEqualChar2<LowNonconformism, MiddleNonconformism, HighNonconformism, ConformismNonconformism>(c1, c2);

        public int CompareTo(ConformismNonconformism other)
        {
            if (this > other)
                return -1;
            if (this < other)
                return 1;
            return 0;
        }
    }
}