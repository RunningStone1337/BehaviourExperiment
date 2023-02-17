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
    public abstract class CredulitySuspicion<TAgent, TReaction, TFeature, TState, TSensor> : CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>,
        IComparable<CredulitySuspicion<TAgent, TReaction, TFeature, TState, TSensor>>
         where TAgent : ICurrentStateHandler<TState> where TReaction : IReaction
         where TFeature : IFeature
        where TState : IState where TSensor : ISensor
    {
        public static bool operator <(CredulitySuspicion<TAgent, TReaction, TFeature, TState, TSensor> c1,
            CredulitySuspicion<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
         Char1LessChar2<LowSuspicion<TAgent, TReaction, TFeature, TState, TSensor>,
             MiddleSuspicion<TAgent, TReaction, TFeature, TState, TSensor>,
             HighSuspicion<TAgent, TReaction, TFeature, TState, TSensor>,
             CredulitySuspicion<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator <=(CredulitySuspicion<TAgent, TReaction, TFeature, TState, TSensor> c1,
            CredulitySuspicion<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1LessOrEqualChar2<LowSuspicion<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleSuspicion<TAgent, TReaction, TFeature, TState, TSensor>,
                HighSuspicion<TAgent, TReaction, TFeature, TState, TSensor>,
                CredulitySuspicion<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator >(CredulitySuspicion<TAgent, TReaction, TFeature, TState, TSensor> c1,
            CredulitySuspicion<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1MoreChar2<LowSuspicion<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleSuspicion<TAgent, TReaction, TFeature, TState, TSensor>,
                HighSuspicion<TAgent, TReaction, TFeature, TState, TSensor>,
                CredulitySuspicion<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator >=(CredulitySuspicion<TAgent, TReaction, TFeature, TState, TSensor> c1,
            CredulitySuspicion<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1MoreOrEqualChar2<LowSuspicion<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleSuspicion<TAgent, TReaction, TFeature, TState, TSensor>,
                HighSuspicion<TAgent, TReaction, TFeature, TState, TSensor>,
                CredulitySuspicion<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public int CompareTo(CredulitySuspicion<TAgent, TReaction, TFeature, TState, TSensor> other)
        {
            if (this > other)
                return -1;
            if (this < other)
                return 1;
            return 0;
        }
        public override void Initiate(int characterValue, TAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisCharType = CharTraitType.CredulitySuspicion;
        }
        public override List<CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>>
            GetCorrelatedTraitsForCharacter(AgentBase<TAgent, TReaction, TFeature, TState, TSensor> agent)
        {
            var cs = agent.CharacterSystem;
            return new List<CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>>() {
                cs.CredulitySuspicion,
                cs.CalmnessAnxiety,
                cs.ClosenessSociability,
                cs.ConservatismRadicalism,
                cs.EmotionalInstabilityStability,
                cs.RestraintExpressiveness,
                cs.RigiditySensetivity,
                cs.Selfcontrol,
                cs.StraightforwardnessDiplomacy
            };
        }

        public override string ToString()
        {
            return $"Доверчивость-подозрительность: значение {RawCharacterValue}, grade {CharacterGrade}";
        }
    }
}