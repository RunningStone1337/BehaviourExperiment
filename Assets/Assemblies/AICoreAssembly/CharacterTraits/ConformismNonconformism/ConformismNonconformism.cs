using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// Степень независимости, свободы от мнений других людей.
    /// Для низкого значения характерно: зависимость от мнения и требований группы, социабельность, следование за общественным мнением, стремление работать и принимать решения вместе с другими людьми, низкая самостоятельность, ориентация на социальное одобрение.
    /// Для высокого значения характерно: независимость, ориентация на собственные решения,
    /// самостоятельность, находчивость, стремление иметь собственное мнение.
    /// При крайних высоких оценках склонность к противопоставлению себя группе и желание в ней доминировать.
    /// Низкие оценки по этому фактору имеют личности общительные, для которых много значит одобрение общества,
    /// это светские люди.
    /// Высокие оценки имеют люди, которые часто разобщены с группой и по роду занятий являются индивидуалистами – писатели,
    /// ученые и преступники.
    /// </summary>
    public abstract class ConformismNonconformism : CharacterTraitBase, IComparable<ConformismNonconformism>, ICommunicationalTrait
    {
        public static bool operator <(ConformismNonconformism c1,
            ConformismNonconformism c2) =>
         Char1LessChar2<LowNonconformism,
             MiddleNonconformism,
             HighNonconformism,
             ConformismNonconformism>(c1, c2);

        public static bool operator <=(ConformismNonconformism c1,
            ConformismNonconformism c2) =>
            Char1LessOrEqualChar2<LowNonconformism,
                MiddleNonconformism,
                HighNonconformism,
                ConformismNonconformism>(c1, c2);

        public static bool operator >(ConformismNonconformism c1,
            ConformismNonconformism c2) =>
            Char1MoreChar2<LowNonconformism,
                MiddleNonconformism,
                HighNonconformism,
                ConformismNonconformism>(c1, c2);

        public static bool operator >=(ConformismNonconformism c1,
            ConformismNonconformism c2) =>
            Char1MoreOrEqualChar2<LowNonconformism,
                MiddleNonconformism,
                HighNonconformism,
                ConformismNonconformism>(c1, c2);

        public int CompareTo(ConformismNonconformism other)
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
            ThisCharType = CharTraitType.ConformismNonconformism;
        }
      

        public override string ToString()
        {
            return $"Конформизм-нонконмформизм: значение {RawCharacterValue}, grade {CharacterGrade}";
        }
    }
}