using System;
using System.Collections.Generic;

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
    public abstract class TimidityCourage<TAgent, TReaction, TFeature, TState, TSensor> :
        CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>, IComparable<TimidityCourage<TAgent, TReaction, TFeature, TState, TSensor>>
        where TAgent : ICurrentStateHandler<TState> where TReaction : IReaction
        where TFeature : IFeature where TState : IState where TSensor : ISensor

    {
        public static bool operator <(TimidityCourage<TAgent, TReaction, TFeature, TState, TSensor> c1,
            TimidityCourage<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
         Char1LessChar2<LowCourage<TAgent, TReaction, TFeature, TState, TSensor>,
             MiddleCourage<TAgent, TReaction, TFeature, TState, TSensor>,
             HighCourage<TAgent, TReaction, TFeature, TState, TSensor>,
             TimidityCourage<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator <=(TimidityCourage<TAgent, TReaction, TFeature, TState, TSensor> c1,
            TimidityCourage<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1LessOrEqualChar2<LowCourage<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleCourage<TAgent, TReaction, TFeature, TState, TSensor>,
                HighCourage<TAgent, TReaction, TFeature, TState, TSensor>,
                TimidityCourage<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator >(TimidityCourage<TAgent, TReaction, TFeature, TState, TSensor> c1,
            TimidityCourage<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1MoreChar2<LowCourage<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleCourage<TAgent, TReaction, TFeature, TState, TSensor>,
                HighCourage<TAgent, TReaction, TFeature, TState, TSensor>,
                TimidityCourage<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator >=(TimidityCourage<TAgent, TReaction, TFeature, TState, TSensor> c1,
            TimidityCourage<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1MoreOrEqualChar2<LowCourage<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleCourage<TAgent, TReaction, TFeature, TState, TSensor>,
                HighCourage<TAgent, TReaction, TFeature, TState, TSensor>,
                TimidityCourage<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public int CompareTo(TimidityCourage<TAgent, TReaction, TFeature, TState, TSensor> other)
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
            ThisCharType = CharTraitType.TimidityCourage;
        }
        public override List<CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>>
            GetCorrelatedTraitsForCharacter(AgentBase<TAgent, TReaction, TFeature, TState, TSensor> agent)
        {
            var cs = agent.CharacterSystem;
            return new List<CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>>()
            {
                cs.TimidityCourage,
                cs.ClosenessSociability,
                cs.PracticalityDreaminess,
                cs.RelaxationTension,
                cs.StraightforwardnessDiplomacy
            };
        }

        public override string ToString()
        {
            return $"Робость-смелость: значение {RawCharacterValue}, grade {CharacterGrade}";
        }
    }
}