using System;

namespace BehaviourModel
{
    /// <summary>
    /// Для низкого значения характерно: расслабленность, вялость, апатичность, спокойствие,
    /// низкая мотивация, излишняя удовлетворенность, невозмутимость.
    /// Для высокого значения характерно: собранность, энергичность, напряженность, фрустрированность,
    /// повышенная мотивация, беспокойство, взвинченность, раздражительность.
    /// Высокая оценка интерпретируется как энергетическая возбужденность, которая требует
    /// определенной разрядки; иногда это состояние может превратиться в психосоматическое нарушение:
    /// снижается эмоциональная устойчивость, нарушается равновесие, может проявляться агрессивность.
    /// Такие люди редко становятся лидерами.
    /// Исследования показали, что низкая оценка (0–5 баллов) характерна для людей с невысоким уровнем
    /// мотивации достижения, довольствующихся имеющимся. Лица со значениями этого фактора от 5 до 8 баллов
    /// характеризуются оптимальным эмоциональным тонусом и стрессоустойчивостью.
    /// </summary>
    public abstract class RelaxationTension : CharacterTraitBase, IComparable<RelaxationTension>
    {
        public static bool operator <(RelaxationTension c1, RelaxationTension c2) =>
            Char1LessChar2<LowTension, MiddleTension, HighTension, RelaxationTension>(c1, c2);

        public static bool operator <=(RelaxationTension c1, RelaxationTension c2) =>
            Char1LessOrEqualChar2<LowTension, MiddleTension, HighTension, RelaxationTension>(c1, c2);

        public static bool operator >(RelaxationTension c1, RelaxationTension c2) =>
            Char1MoreChar2<LowTension, MiddleTension, HighTension, RelaxationTension>(c1, c2);

        public static bool operator >=(RelaxationTension c1, RelaxationTension c2) =>
            Char1MoreOrEqualChar2<LowTension, MiddleTension, HighTension, RelaxationTension>(c1, c2);
        public int CompareTo(RelaxationTension other)
        {
            if (this > other)
                return -1;
            if (this < other)
                return 1;
            return 0;
        }
    }
}