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
    public abstract class Intelligence<TReaction, TFeature, TState> : CharacterTraitBase<TReaction, TFeature, TState>,
        IComparable<Intelligence<TReaction, TFeature, TState>>
         where TReaction : IReaction
         where TFeature : IFeature where TState : IState
    {
        public static bool operator <(Intelligence<TReaction, TFeature, TState> c1,
            Intelligence<TReaction, TFeature, TState> c2) =>
         Char1LessChar2<LowIntelligence<TReaction, TFeature, TState>,
             MiddleIntelligence<TReaction, TFeature, TState>,
             HighIntelligence<TReaction, TFeature, TState>,
             Intelligence<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator <=(Intelligence<TReaction, TFeature, TState> c1,
            Intelligence<TReaction, TFeature, TState> c2) =>
            Char1LessOrEqualChar2<LowIntelligence<TReaction, TFeature, TState>,
                MiddleIntelligence<TReaction, TFeature, TState>,
                HighIntelligence<TReaction, TFeature, TState>,
                Intelligence<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator >(Intelligence<TReaction, TFeature, TState> c1,
            Intelligence<TReaction, TFeature, TState> c2) =>
            Char1MoreChar2<LowIntelligence<TReaction, TFeature, TState>,
                MiddleIntelligence<TReaction, TFeature, TState>,
                HighIntelligence<TReaction, TFeature, TState>,
                Intelligence<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator >=(Intelligence<TReaction, TFeature, TState> c1,
            Intelligence<TReaction, TFeature, TState> c2) =>
            Char1MoreOrEqualChar2<LowIntelligence<TReaction, TFeature, TState>,
                MiddleIntelligence<TReaction, TFeature, TState>,
                HighIntelligence<TReaction, TFeature, TState>,
                Intelligence<TReaction, TFeature, TState>>(c1, c2);
        public int CompareTo(Intelligence<TReaction, TFeature, TState> other)
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
            return new List<CharacterTraitBase<TReaction, TFeature, TState> >() {
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