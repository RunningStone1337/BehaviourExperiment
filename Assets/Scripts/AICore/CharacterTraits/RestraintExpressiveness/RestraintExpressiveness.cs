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
    public abstract class RestraintExpressiveness<TReaction, TFeature, TState> : CharacterTraitBase<TReaction, TFeature, TState>,
        IComparable<RestraintExpressiveness<TReaction, TFeature, TState>>
         where TReaction : IReaction
         where TFeature : IFeature where TState : IState
    {
        public static bool operator <(RestraintExpressiveness<TReaction, TFeature, TState> c1,
            RestraintExpressiveness<TReaction, TFeature, TState> c2) =>
         Char1LessChar2<LowExpressiveness<TReaction, TFeature, TState>,
             MiddleExpressiveness<TReaction, TFeature, TState>,
             HighExpressiveness<TReaction, TFeature, TState>,
             RestraintExpressiveness<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator <=(RestraintExpressiveness<TReaction, TFeature, TState> c1,
            RestraintExpressiveness<TReaction, TFeature, TState> c2) =>
            Char1LessOrEqualChar2<LowExpressiveness<TReaction, TFeature, TState>,
                MiddleExpressiveness<TReaction, TFeature, TState>,
                HighExpressiveness<TReaction, TFeature, TState>,
                RestraintExpressiveness<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator >(RestraintExpressiveness<TReaction, TFeature, TState> c1,
            RestraintExpressiveness<TReaction, TFeature, TState> c2) =>
            Char1MoreChar2<LowExpressiveness<TReaction, TFeature, TState>,
                MiddleExpressiveness<TReaction, TFeature, TState>,
                HighExpressiveness<TReaction, TFeature, TState>,
                RestraintExpressiveness<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator >=(RestraintExpressiveness<TReaction, TFeature, TState> c1,
            RestraintExpressiveness<TReaction, TFeature, TState> c2) =>
            Char1MoreOrEqualChar2<LowExpressiveness<TReaction, TFeature, TState>,
                MiddleExpressiveness<TReaction, TFeature, TState>,
                HighExpressiveness<TReaction, TFeature, TState>,
                RestraintExpressiveness<TReaction, TFeature, TState>>(c1, c2);
        public int CompareTo(RestraintExpressiveness<TReaction, TFeature, TState> other)
        {
            if (this > other)
                return -1;
            if (this < other)
                return 1;
            return 0;
        }
        public override List<CharacterTraitBase<TReaction, TFeature, TState> >
            GetInterestedTraitsForCharacter(AgentBase<TReaction, TFeature, TState> agent)
        {
            var cs = agent.CharacterSystem;
            return new List<CharacterTraitBase<TReaction, TFeature, TState> >()
            {
                cs.RestraintExpressiveness,
                cs.CalmnessAnxiety,
                cs.EmotionalInstabilityStability,
                cs.NormativityOfBehaviour,
                cs.RelaxationTension,
                cs.Selfcontrol,
                cs.StraightforwardnessDiplomacy
            };
        }
        public override string ToString()
        {
            return $"Экспрессивность: значение {RawCharacterValue}, grade {CharacterGrade}";
        }
    }
}