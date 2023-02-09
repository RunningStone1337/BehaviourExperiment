using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// Степень независимости, свободы от мнений других людей.
    /// Для низкого значения характерно: зависимость от мнения и требований группы, социабельность, следование за общественным мнением, стремление работать и принимать решения вместе с другими людьми, низкая самостоятельность, ориентация на социальное одобрение.
    /// Для высокого значения характерно: независимость, ориентация на собственные решения,
    /// самостоятельность, находчивость, стремление иметь собственное мнение.
    /// При крайних высоких оценках склонность к противопоставлению себя группе и желание в ней доминировать.
    /// Низкие оценки по этому фактору имеют личности общительные, для которых много значит одобрение общества,
    /// это светские люди.
    /// Высокие оценки имеют люди, которые часто разобщены с группой и по роду занятий являются индивидуалистами – писатели,
    /// ученые и преступники.
    /// </summary>
    public abstract class ConformismNonconformism<TReaction, TFeature, TState> : CharacterTraitBase<TReaction, TFeature, TState>,
        IComparable<ConformismNonconformism<TReaction, TFeature, TState>>
         where TReaction : IReaction
         where TFeature : IFeature
        where TState : IState
    {
        public static bool operator <(ConformismNonconformism<TReaction, TFeature, TState> c1,
            ConformismNonconformism<TReaction, TFeature, TState> c2) =>
         Char1LessChar2<LowNonconformism<TReaction, TFeature, TState>,
             MiddleNonconformism<TReaction, TFeature, TState>,
             HighNonconformism<TReaction, TFeature, TState>,
             ConformismNonconformism<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator <=(ConformismNonconformism<TReaction, TFeature, TState> c1,
            ConformismNonconformism<TReaction, TFeature, TState> c2) =>
            Char1LessOrEqualChar2<LowNonconformism<TReaction, TFeature, TState>,
                MiddleNonconformism<TReaction, TFeature, TState>,
                HighNonconformism<TReaction, TFeature, TState>,
                ConformismNonconformism<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator >(ConformismNonconformism<TReaction, TFeature, TState> c1,
            ConformismNonconformism<TReaction, TFeature, TState> c2) =>
            Char1MoreChar2<LowNonconformism<TReaction, TFeature, TState>,
                MiddleNonconformism<TReaction, TFeature, TState>,
                HighNonconformism<TReaction, TFeature, TState>,
                ConformismNonconformism<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator >=(ConformismNonconformism<TReaction, TFeature, TState> c1,
            ConformismNonconformism<TReaction, TFeature, TState> c2) =>
            Char1MoreOrEqualChar2<LowNonconformism<TReaction, TFeature, TState>,
                MiddleNonconformism<TReaction, TFeature, TState>,
                HighNonconformism<TReaction, TFeature, TState>,
                ConformismNonconformism<TReaction, TFeature, TState>>(c1, c2);
        public int CompareTo(ConformismNonconformism<TReaction, TFeature, TState> other)
        {
            if (this > other)
                return -1;
            if (this < other)
                return 1;
            return 0;
        }
        public override string ToString()
        {
            return $"Конформизм-нонконмформизм: значение {RawCharacterValue}, grade {CharacterGrade}";
        }
        public override List<CharacterTraitBase<TReaction, TFeature, TState> > 
            GetInterestedTraitsForCharacter(AgentBase<TReaction, TFeature, TState> agent)
        {
            var cs = agent.CharacterSystem;
            return new List<CharacterTraitBase<TReaction, TFeature, TState> >() { 
                cs.ConformismNonconformism,
                cs.ClosenessSociability,
                cs.ConservatismRadicalism,
                cs.Intelligence,
                cs.NormativityOfBehaviour,
                cs.PracticalityDreaminess,
                cs.Selfcontrol,
                cs.StraightforwardnessDiplomacy,
                cs.SubordinationDomination,
                cs.TimidityCourage,
            };
        }
    }
}