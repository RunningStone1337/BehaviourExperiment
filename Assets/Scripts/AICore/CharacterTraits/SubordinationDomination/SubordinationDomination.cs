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
    public abstract class SubordinationDomination<TReaction, TFeature, TState> : CharacterTraitBase<TReaction, TFeature, TState>,
        IComparable<SubordinationDomination<TReaction, TFeature, TState>>
         where TReaction : IReaction
         where TFeature : IFeature where TState : IState
    {
        public static bool operator <(SubordinationDomination<TReaction, TFeature, TState> c1,
            SubordinationDomination<TReaction, TFeature, TState> c2) =>
         Char1LessChar2<LowDomination<TReaction, TFeature, TState>,
             MiddleDomination<TReaction, TFeature, TState>,
             HighDomination<TReaction, TFeature, TState>,
             SubordinationDomination<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator <=(SubordinationDomination<TReaction, TFeature, TState> c1,
            SubordinationDomination<TReaction, TFeature, TState> c2) =>
            Char1LessOrEqualChar2<LowDomination<TReaction, TFeature, TState>,
                MiddleDomination<TReaction, TFeature, TState>,
                HighDomination<TReaction, TFeature, TState>,
                SubordinationDomination<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator >(SubordinationDomination<TReaction, TFeature, TState> c1,
            SubordinationDomination<TReaction, TFeature, TState> c2) =>
            Char1MoreChar2<LowDomination<TReaction, TFeature, TState>,
                MiddleDomination<TReaction, TFeature, TState>,
                HighDomination<TReaction, TFeature, TState>,
                SubordinationDomination<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator >=(SubordinationDomination<TReaction, TFeature, TState> c1,
            SubordinationDomination<TReaction, TFeature, TState> c2) =>
            Char1MoreOrEqualChar2<LowDomination<TReaction, TFeature, TState>,
                MiddleDomination<TReaction, TFeature, TState>,
                HighDomination<TReaction, TFeature, TState>,
                SubordinationDomination<TReaction, TFeature, TState>>(c1, c2);
        public int CompareTo(SubordinationDomination<TReaction, TFeature, TState> other)
        {
            if (this > other)
                return -1;
            if (this < other)
                return 1;
            return 0;
        }

        public override List<CharacterTraitBase<TReaction, TFeature, TState> >
            GetInterestedTraitsForCharacter(AgentBase<TReaction, TFeature, TState>agent)
        {
            var cs = agent.CharacterSystem;
            return new List<CharacterTraitBase<TReaction, TFeature, TState> >()
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