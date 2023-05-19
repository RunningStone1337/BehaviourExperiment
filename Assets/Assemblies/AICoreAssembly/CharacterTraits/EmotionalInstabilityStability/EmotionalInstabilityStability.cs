using System;

namespace BehaviourModel
{
    /// <summary>
    /// Для низкого значения характерно: эмоциональная неустойчивость, импульсивность;
    /// человек находится под влиянием чувств, переменчив в настроениях, легко расстраивается,
    /// неустойчив в интересах. Низкая толерантность по отношению к фрустрации, раздражительность, утомляемость.
    /// Для высокого значения характерно: эмоциональная устойчивость, выдержанность;
    /// человек эмоционально зрелый, спокойный, устойчив в интересах, работоспособный, может быть ригидным, ориентирован на реальность.
    /// Этот фактор характеризует динамическое обобщение и зрелость эмоций в противоположность нерегулируемой эмоциональности.
    /// </summary>
    public abstract class EmotionalInstabilityStability :
        CharacterTraitBase,
        IComparable<EmotionalInstabilityStability>, IEmotionalTrait
    {
        public static bool operator <(EmotionalInstabilityStability c1,
            EmotionalInstabilityStability c2) =>
         Char1LessChar2<LowEmotionalStability,
             MiddleEmotionalStability,
             HighEmotionalStability,
             EmotionalInstabilityStability>(c1, c2);

        public static bool operator <=(EmotionalInstabilityStability c1,
            EmotionalInstabilityStability c2) =>
            Char1LessOrEqualChar2<LowEmotionalStability,
            MiddleEmotionalStability,
                HighEmotionalStability,
                EmotionalInstabilityStability>(c1, c2);

        public static bool operator >(EmotionalInstabilityStability c1,
            EmotionalInstabilityStability c2) =>
            Char1MoreChar2<LowEmotionalStability,
                             MiddleEmotionalStability,
                HighEmotionalStability,
                EmotionalInstabilityStability>(c1, c2);

        public static bool operator >=(EmotionalInstabilityStability c1,
            EmotionalInstabilityStability c2) =>
            Char1MoreOrEqualChar2<LowEmotionalStability,
                             MiddleEmotionalStability,
                HighEmotionalStability,
                EmotionalInstabilityStability>(c1, c2);

        public int CompareTo(EmotionalInstabilityStability other)
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
            ThisCharType = CharTraitType.EmotionalInstabilityStability;
        }
       

        public override string ToString()
        {
            return $"Эм. стабильность: значение {RawCharacterValue}, grade {CharacterGrade}";
        }
    }
}