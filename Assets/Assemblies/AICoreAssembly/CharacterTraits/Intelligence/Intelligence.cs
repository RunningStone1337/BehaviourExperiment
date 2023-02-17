using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// ƒл€ низкого значени€ характерно: конкретность и некотора€ ригидность мышлени€, затруднени€
    /// в решении абстрактных задач, сниженна€ оперативность мышлени€, недостаточный уровень общей вербальной культуры.
    /// ƒл€ высокого значени€ характерно: развитое абстрактное мышление, оперативность, сообразительность,
    /// быстра€ обучаемость.ƒостаточно высокий уровень общей культуры, особенно вербальной.
    /// ‘актор ¬ не определ€ет уровень интеллекта, он ориентирован на измерение оперативности мышлени€
    /// и общего уровн€ вербальной культуры и эрудиции.—ледует отметить,
    /// что низкие оценки по этому фактору могут зависеть от других характеристик личности:
    /// тревожности, фрустрированности, низкого образовательного ценза.
    /// </summary>
    public abstract class Intelligence<TAgent, TReaction, TFeature, TState, TSensor> : CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>,
        IComparable<Intelligence<TAgent, TReaction, TFeature, TState, TSensor>>
         where TAgent : ICurrentStateHandler<TState> where TReaction : IReaction
         where TFeature : IFeature where TState : IState where TSensor : ISensor
    {
        public static bool operator <(Intelligence<TAgent, TReaction, TFeature, TState, TSensor> c1,
            Intelligence<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
         Char1LessChar2<LowIntelligence<TAgent, TReaction, TFeature, TState, TSensor>,
             MiddleIntelligence<TAgent, TReaction, TFeature, TState, TSensor>,
             HighIntelligence<TAgent, TReaction, TFeature, TState, TSensor>,
             Intelligence<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator <=(Intelligence<TAgent, TReaction, TFeature, TState, TSensor> c1,
            Intelligence<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1LessOrEqualChar2<LowIntelligence<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleIntelligence<TAgent, TReaction, TFeature, TState, TSensor>,
                HighIntelligence<TAgent, TReaction, TFeature, TState, TSensor>,
                Intelligence<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator >(Intelligence<TAgent, TReaction, TFeature, TState, TSensor> c1,
            Intelligence<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1MoreChar2<LowIntelligence<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleIntelligence<TAgent, TReaction, TFeature, TState, TSensor>,
                HighIntelligence<TAgent, TReaction, TFeature, TState, TSensor>,
                Intelligence<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator >=(Intelligence<TAgent, TReaction, TFeature, TState, TSensor> c1,
            Intelligence<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1MoreOrEqualChar2<LowIntelligence<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleIntelligence<TAgent, TReaction, TFeature, TState, TSensor>,
                HighIntelligence<TAgent, TReaction, TFeature, TState, TSensor>,
                Intelligence<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public int CompareTo(Intelligence<TAgent, TReaction, TFeature, TState, TSensor> other)
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
            ThisCharType = CharTraitType.Intelligence;
        }
        public override List<CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>>
            GetCorrelatedTraitsForCharacter(AgentBase<TAgent, TReaction, TFeature, TState, TSensor> agent)
        {
            var cs = agent.CharacterSystem;
            return new List<CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>>() {
                cs.Intelligence,
                cs.ConformismNonconformism,
                cs.Intelligence,
                cs.RelaxationTension,
                cs.RestraintExpressiveness
            };
        }

        public override string ToString()
        {
            return $"»нтеллект: значение {RawCharacterValue}, grade {CharacterGrade}";
        }
    }
}