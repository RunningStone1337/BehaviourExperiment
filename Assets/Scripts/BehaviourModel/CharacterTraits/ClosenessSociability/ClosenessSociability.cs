using System;

namespace BehaviourModel
{
    /// <summary>
    /// Фактор общительности человека в малых группах и способности установления контактов.
    /// Низкие значения - индивидуалист, склонность к работе в изолированности. Высокие значения - общительность,
    /// склонность к лидерству в группах.
    /// Для низкого значения характерно: скрытность, обособленность, отчужденность, недоверчивость, необщительность,
    /// замкнутость, критичность, склонность к объективности, ригидности, к излишней строгости в оценке людей.
    /// Трудности в установлении межличностных, непосредственных контактов.
    /// Для высокого значения характерно: общительность, открытость, естественность, непринужденность,
    /// готовность к сотрудничеству, приспособляемость, внимание к людям, готовность к совместной работе,
    /// активность в устранении конфликтов в группе, готовность идти на поводу.Легкость в установлении непосредственных,
    /// межличностных контактов
    /// </summary>
    public abstract class ClosenessSociability : CharacterTraitBase, IComparable<ClosenessSociability>
    {
        public static bool operator <(ClosenessSociability c1, ClosenessSociability c2) =>
        Char1LessChar2<LowClosenessSociability, MiddleClosenessSociability, HighClosenessSociability, ClosenessSociability>(c1, c2);

        public static bool operator <=(ClosenessSociability c1, ClosenessSociability c2) =>
            Char1LessOrEqualChar2<LowClosenessSociability, MiddleClosenessSociability, HighClosenessSociability, ClosenessSociability>(c1, c2);

        public static bool operator >(ClosenessSociability c1, ClosenessSociability c2) =>
            Char1MoreChar2<LowClosenessSociability, MiddleClosenessSociability, HighClosenessSociability, ClosenessSociability>(c1, c2);

        public static bool operator >=(ClosenessSociability c1, ClosenessSociability c2) =>
            Char1MoreOrEqualChar2<LowClosenessSociability, MiddleClosenessSociability, HighClosenessSociability, ClosenessSociability>(c1, c2);

        public int CompareTo(ClosenessSociability other)
        {
            if (this > other)
                return -1;
            if (this < other)
                return 1;
            return 0;
        }
    }
}