using System;

namespace BehaviourModel
{
    /// <summary>
    /// ƒл€ низкого значени€ характерно: высока€ скорость решени€ практических задач,
    /// прозаичность, ориентаци€ на внешнюю реальность, развитое конкретное воображение, практичность, реалистичность.
    /// ƒл€ высокого значени€ характерно: богатое воображение, поглощенность своими иде€ми,
    /// внутренними иллюзи€ми(Ђвитает в облакахї), легкость отказа от практических суждений,
    /// умение оперировать абстрактными пон€ти€ми, ориентированность на свой внутренний мир; мечтательность.
    /// ¬ целом фактор ориентирован на измерение особенностей воображени€, отражающихс€ в реальном поведении личности,
    /// таких, как практичность, приземленность или, наоборот, некоторое Ђвитание в облакахї, романтическое отношение к жизни.
    /// </summary>
    public abstract class PracticalityDreaminess : CharacterTraitBase, IComparable<PracticalityDreaminess>
    {
        public static bool operator <(PracticalityDreaminess c1, PracticalityDreaminess c2) =>
            Char1LessChar2<LowDreaminess, MiddleDreaminess, HighDreaminess, PracticalityDreaminess>(c1, c2);

        public static bool operator <=(PracticalityDreaminess c1, PracticalityDreaminess c2) =>
            Char1LessOrEqualChar2<LowDreaminess, MiddleDreaminess, HighDreaminess, PracticalityDreaminess>(c1, c2);

        public static bool operator >(PracticalityDreaminess c1, PracticalityDreaminess c2) =>
                    Char1MoreChar2<LowDreaminess, MiddleDreaminess, HighDreaminess, PracticalityDreaminess>(c1, c2);

        public static bool operator >=(PracticalityDreaminess c1, PracticalityDreaminess c2) =>
            Char1MoreOrEqualChar2<LowDreaminess, MiddleDreaminess, HighDreaminess, PracticalityDreaminess>(c1, c2);

        public int CompareTo(PracticalityDreaminess other)
        {
            if (this > other)
                return -1;
            if (this < other)
                return 1;
            return 0;
        }
    }
}