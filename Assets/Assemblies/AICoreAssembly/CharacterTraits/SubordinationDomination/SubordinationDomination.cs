using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// ƒл€ низкого значени€ характерно: м€гкость, уступчивость, тактичность,
    /// кроткость, любезность, зависимость, безропотность, услужливость, почтительность, застенчивость,
    /// готовность брать вину на себ€, скромность, экспрессивность, склонность легко выходить из равновеси€.
    /// ƒл€ высокого значени€ характерно: самосто€тельность, независимость, настойчивость, упр€мство, напористость,
    /// своенравие, иногда конфликтность, агрессивность, отказ от признани€ внешней власти, склонность к авторитарному поведению,
    /// жажда восхищени€, бунтарь.
    /// ‘актор ≈ не очень существенно коррелирует с достижени€ми лидерства,
    /// однако св€зан с социальным статусом и выше у лидеров, чем у последователей.
    /// —уществует предположение, что оценки по этому фактору с возрастом мен€ютс€ и завис€т от пола испытуемого.
    /// ¬ своем поведении люди с высокими оценками (по этому фактору) испытывают потребность в автономии.
    /// </summary>
    public abstract class SubordinationDomination<TAgent, TReaction, TFeature, TState, TSensor> : CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>,
        IComparable<SubordinationDomination<TAgent, TReaction, TFeature, TState, TSensor>>
         where TAgent : ICurrentStateHandler<TState> where TReaction : IReaction
         where TFeature : IFeature where TState : IState where TSensor : ISensor
    {
        public static bool operator <(SubordinationDomination<TAgent, TReaction, TFeature, TState, TSensor> c1,
            SubordinationDomination<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
         Char1LessChar2<LowDomination<TAgent, TReaction, TFeature, TState, TSensor>,
             MiddleDomination<TAgent, TReaction, TFeature, TState, TSensor>,
             HighDomination<TAgent, TReaction, TFeature, TState, TSensor>,
             SubordinationDomination<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator <=(SubordinationDomination<TAgent, TReaction, TFeature, TState, TSensor> c1,
            SubordinationDomination<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1LessOrEqualChar2<LowDomination<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleDomination<TAgent, TReaction, TFeature, TState, TSensor>,
                HighDomination<TAgent, TReaction, TFeature, TState, TSensor>,
                SubordinationDomination<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator >(SubordinationDomination<TAgent, TReaction, TFeature, TState, TSensor> c1,
            SubordinationDomination<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1MoreChar2<LowDomination<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleDomination<TAgent, TReaction, TFeature, TState, TSensor>,
                HighDomination<TAgent, TReaction, TFeature, TState, TSensor>,
                SubordinationDomination<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator >=(SubordinationDomination<TAgent, TReaction, TFeature, TState, TSensor> c1,
            SubordinationDomination<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1MoreOrEqualChar2<LowDomination<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleDomination<TAgent, TReaction, TFeature, TState, TSensor>,
                HighDomination<TAgent, TReaction, TFeature, TState, TSensor>,
                SubordinationDomination<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public int CompareTo(SubordinationDomination<TAgent, TReaction, TFeature, TState, TSensor> other)
        {
            if (this > other)
                return -1;
            if (this < other)
                return 1;
            return 0;
        }

        public override List<CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>>
            GetCorrelatedTraitsForCharacter(AgentBase<TAgent, TReaction, TFeature, TState, TSensor> agent)
        {
            var cs = agent.CharacterSystem;
            return new List<CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>>()
            {
      cs.SubordinationDomination,
                cs.ConformismNonconformism,
                cs.CredulitySuspicion,
                cs.EmotionalInstabilityStability,
                cs.RelaxationTension,
                cs.RigiditySensetivity,
                cs.TimidityCourage,
            };
        }

        public override string ToString()
        {
            return $"ѕодчинение-доминантность: значение {RawCharacterValue}, grade {CharacterGrade}";
        }
    }
}