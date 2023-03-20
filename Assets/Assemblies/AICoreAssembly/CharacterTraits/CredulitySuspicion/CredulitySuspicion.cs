using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// Доверчивость-подозрительность.
    /// Для низкого значения характерно: открытость, уживчивость, терпимость, покладистость;
    /// свобода от зависти, уступчивость. Может быть чувство собственной незначительности.
    /// Для высокого значения характерно: осторожность, эгоцентричность, настороженность по отношению к людям;
    /// склонность к ревности, стремление возложить ответственность за ошибки на окружающих,
    /// раздражительность.Иногда автономность, самостоятельность и независимость в социальном поведении.
    /// В целом фактор отражает эмоциональное отношение к людям.
    /// Очень высокие оценки по этому фактору говорят об излишней защите и эмоциональной напряженности,
    /// фрустрированности личности. Низкий полюс характеризует личность добродушную, но склонную к конформизму.
    /// </summary>
    public abstract class CredulitySuspicion : CharacterTraitBase,
        IComparable<CredulitySuspicion>
    {
        public static bool operator <(CredulitySuspicion c1,
            CredulitySuspicion c2) =>
         Char1LessChar2<LowSuspicion,
             MiddleSuspicion,
             HighSuspicion,
             CredulitySuspicion>(c1, c2);

        public static bool operator <=(CredulitySuspicion c1,
            CredulitySuspicion c2) =>
            Char1LessOrEqualChar2<LowSuspicion,
                MiddleSuspicion,
                HighSuspicion,
                CredulitySuspicion>(c1, c2);

        public static bool operator >(CredulitySuspicion c1,
            CredulitySuspicion c2) =>
            Char1MoreChar2<LowSuspicion,
                MiddleSuspicion,
                HighSuspicion,
                CredulitySuspicion>(c1, c2);

        public static bool operator >=(CredulitySuspicion c1,
            CredulitySuspicion c2) =>
            Char1MoreOrEqualChar2<LowSuspicion,
                MiddleSuspicion,
                HighSuspicion,
                CredulitySuspicion>(c1, c2);

        public int CompareTo(CredulitySuspicion other)
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
            ThisCharType = CharTraitType.CredulitySuspicion;
        }
       

        public override string ToString()
        {
            return $"Доверчивость-подозрительность: значение {RawCharacterValue}, grade {CharacterGrade}";
        }
    }
}