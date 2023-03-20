using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// Для низкого значения характерно: благоразумие, осторожность, рассудительность в выборе партнера по общению.
    /// Склонность к озабоченности, беспокойству о будущем, пессимистичность в восприятии действительности,
    /// сдержанность в проявлении эмоций.
    /// Для высокого значения характерно: жизнерадостность, импульсивность, восторженность, беспечность,
    /// безрассудность в выборе партнеров по общению, эмоциональная значимость социальных контактов,
    /// экспрессивность, экспансивность, эмоциональная яркость в отношениях между людьми, динамичность общения,
    /// которая предполагает эмоциональное лидерство в группах
    /// Данный фактор представляет собой компонент факторов второго порядка различных свойств личности.
    /// Интересен тот факт, что с годами проявление импульсивности и беспечности постепенно снижается,
    /// что можно рассматривать как свидетельство определенной эмоциональной зрелости.
    /// В целом фактор F ориентирован на измерение эмоциональной окрашенности и динамичности в процессах общения.
    /// Пример: актеры, эффективные лидеры имеют более высокие оценки, художники, последователи – более низкие.
    /// </summary>
    public abstract class RestraintExpressiveness : CharacterTraitBase,
        IComparable<RestraintExpressiveness>
    {
        public static bool operator <(RestraintExpressiveness c1,
            RestraintExpressiveness c2) =>
         Char1LessChar2<LowExpressiveness,
             MiddleExpressiveness,
             HighExpressiveness,
             RestraintExpressiveness>(c1, c2);

        public static bool operator <=(RestraintExpressiveness c1,
            RestraintExpressiveness c2) =>
            Char1LessOrEqualChar2<LowExpressiveness,
                MiddleExpressiveness,
                HighExpressiveness,
                RestraintExpressiveness>(c1, c2);

        public static bool operator >(RestraintExpressiveness c1,
            RestraintExpressiveness c2) =>
            Char1MoreChar2<LowExpressiveness,
                MiddleExpressiveness,
                HighExpressiveness,
                RestraintExpressiveness>(c1, c2);

        public static bool operator >=(RestraintExpressiveness c1,
            RestraintExpressiveness c2) =>
            Char1MoreOrEqualChar2<LowExpressiveness,
                MiddleExpressiveness,
                HighExpressiveness,
                RestraintExpressiveness>(c1, c2);

        public int CompareTo(RestraintExpressiveness other)
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
            ThisCharType = CharTraitType.RestraintExpressiveness;
        }
       

        public override string ToString()
        {
            return $"Экспрессивность: значение {RawCharacterValue}, grade {CharacterGrade}";
        }
    }
}