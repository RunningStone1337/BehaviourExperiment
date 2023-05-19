using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// ƒл€ низкого значени€ характерно: м€гкость, уступчивость, тактичность,
    /// кроткость, любезность, зависимость, безропотность, услужливость, почтительность, застенчивость,
    /// готовность брать вину на себ€, скромность, экспрессивность, склонность легко выходить из равновеси€.
    /// ƒл€ высокого значени€ характерно: самосто€тельность, независимость, настойчивость, упр€мство, напористость,
    /// своенравие, иногда конфликтность, агрессивность, отказ от признани€ внешней власти, склонность к авторитарному поведению,
    /// жажда восхищени€, бунтарь.
    /// ‘актор ≈ не очень существенно коррелирует с достижени€ми лидерства,
    /// однако св€зан с социальным статусом и выше у лидеров, чем у последователей.
    /// —уществует предположение, что оценки по этому фактору с возрастом мен€ютс€ и завис€т от пола испытуемого.
    /// ¬ своем поведении люди с высокими оценками (по этому фактору) испытывают потребность в автономии.
    /// </summary>
    public abstract class SubordinationDomination : CharacterTraitBase, IComparable<SubordinationDomination>, ICommunicationalTrait
    {
        public static bool operator <(SubordinationDomination c1,
            SubordinationDomination c2) =>
         Char1LessChar2<LowDomination,
             MiddleDomination,
             HighDomination,
             SubordinationDomination>(c1, c2);

        public static bool operator <=(SubordinationDomination c1,
            SubordinationDomination c2) =>
            Char1LessOrEqualChar2<LowDomination,
                MiddleDomination,
                HighDomination,
                SubordinationDomination>(c1, c2);

        public static bool operator >(SubordinationDomination c1,
            SubordinationDomination c2) =>
            Char1MoreChar2<LowDomination,
                MiddleDomination,
                HighDomination,
                SubordinationDomination>(c1, c2);

        public static bool operator >=(SubordinationDomination c1,
            SubordinationDomination c2) =>
            Char1MoreOrEqualChar2<LowDomination,
                MiddleDomination,
                HighDomination,
                SubordinationDomination>(c1, c2);

        public int CompareTo(SubordinationDomination other)
        {
            if (this > other)
                return -1;
            if (this < other)
                return 1;
            return 0;
        }

      

        public override string ToString()
        {
            return $"ѕодчинение-доминантность: значение {RawCharacterValue}, grade {CharacterGrade}";
        }
    }
}