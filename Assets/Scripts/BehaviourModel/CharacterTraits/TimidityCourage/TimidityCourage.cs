using System;

namespace BehaviourModel
{
    /// <summary>
    /// Для низкого значения характерно: робость, застенчивость, эмоциональная сдержанность,
    /// осторожность, социальная пассивность, деликатность, внимательность к другим, повышенная чувствительность к угрозе,
    /// предпочтение индивидуального стиля деятельности и общения в малой группе (2–3 человека).
    /// Для высокого значения характерно: смелость, предприимчивость, активность;
    /// человек имеет эмоциональные интересы, готовность к риску и сотрудничеству с незнакомыми людьми
    /// в незнакомых обстоятельствах, способность принимать самостоятельные, неординарные решения,
    /// склонность к авантюризму и проявлению лидерских качеств.
    /// Фактор H – четко определенный фактор, который характеризует степень активности в социальных контактах.
    /// При этом надо учитывать, что этот фактор имеет генетическое происхождение и отражает активность
    /// организма и особенности темперамента.Люди с высокими оценками этого фактора имеют склонность к профессиям риска
    /// (летчики-испытатели), упорны, социабельны, умеют выдерживать эмоциональные нагрузки, что часто делает их лидерами.
    /// Низкие оценки этого фактора характеризуют людей застенчивых, робких, не социабельных,
    /// трудно принимающих самостоятельные решения.
    /// </summary>
    public abstract class TimidityCourage : CharacterTraitBase, IComparable<TimidityCourage>
    {
        public static bool operator <(TimidityCourage c1, TimidityCourage c2) =>
            Char1LessChar2<LowCourage, MiddleCourage, HighCourage, TimidityCourage>(c1, c2);

        public static bool operator <=(TimidityCourage c1, TimidityCourage c2) =>
            Char1LessOrEqualChar2<LowCourage, MiddleCourage, HighCourage, TimidityCourage>(c1, c2);

        public static bool operator >(TimidityCourage c1, TimidityCourage c2) =>
            Char1MoreChar2<LowCourage, MiddleCourage, HighCourage, TimidityCourage>(c1, c2);

        public static bool operator >=(TimidityCourage c1, TimidityCourage c2) =>
            Char1MoreOrEqualChar2<LowCourage, MiddleCourage, HighCourage, TimidityCourage>(c1, c2);
        public int CompareTo(TimidityCourage other)
        {
            if (this > other)
                return -1;
            if (this < other)
                return 1;
            return 0;
        }
    }
}