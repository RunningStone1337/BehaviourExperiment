using System;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    /// <summary>
    /// Для низкого значения характерно: несентиментальность, самоуверенность, суровость,
    /// рассудочность, гибкость в суждениях, практичность, иногда некоторая жесткость
    /// и черствость по отношению к окружающим, рациональность, логичность.
    /// Для высокого значения характерно: чувствительность, впечатлительность, богатство
    /// эмоциональных переживаний, склонность к романтизму, художественное восприятие мира,
    /// развитые эстетические интересы, артистичность, женственность, склонность к эмпатии, сочувствию,
    /// сопереживанию и пониманию других людей, утонченная эмоциональность.
    /// Этот фактор отражает различия в культурном уровне и эстетической восприимчивости личности.
    /// Интересен тот факт, что люди с низкими показателями по этому фактору меньше болеют, более агрессивны,
    /// чаще занимаются спортом, атлетичны.
    /// Характеристики этого фактора ближе к фактору второго порядка «низкая эмоциональность
    /// – высокая эмоциональность»; данный фактор является там главенствующим.
    /// Личность с высокими показателями по этому фактору характеризуется как физически и умственно утонченная,
    /// склонная к рефлексии, задумывающаяся над своими ошибками и путями избежания таковых.
    /// </summary>
    public abstract class RigiditySensetivity<TReaction, TFeature, TState> : CharacterTraitBase<TReaction, TFeature, TState>
        ,IComparable<RigiditySensetivity<TReaction, TFeature, TState>>
        where TReaction : IReaction
        where TFeature : IFeature where TState : IState
    {


        public static bool operator <(RigiditySensetivity<TReaction, TFeature, TState> c1,
                    RigiditySensetivity<TReaction, TFeature, TState> c2) =>
         Char1LessChar2<LowSensetivity<TReaction, TFeature, TState>,
             MiddleSensetivity<TReaction, TFeature, TState>,
             HighSensetivity<TReaction, TFeature, TState>,
             RigiditySensetivity<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator <=(RigiditySensetivity<TReaction, TFeature, TState> c1,
            RigiditySensetivity<TReaction, TFeature, TState> c2) =>
            Char1LessOrEqualChar2<LowSensetivity<TReaction, TFeature, TState>,
                MiddleSensetivity<TReaction, TFeature, TState>,
                HighSensetivity<TReaction, TFeature, TState>,
                RigiditySensetivity<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator >(RigiditySensetivity<TReaction, TFeature, TState> c1,
            RigiditySensetivity<TReaction, TFeature, TState> c2) =>
            Char1MoreChar2<LowSensetivity<TReaction, TFeature, TState>,
                MiddleSensetivity<TReaction, TFeature, TState>,
                HighSensetivity<TReaction, TFeature, TState>,
                RigiditySensetivity<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator >=(RigiditySensetivity<TReaction, TFeature, TState> c1,
            RigiditySensetivity<TReaction, TFeature, TState> c2) =>
            Char1MoreOrEqualChar2<LowSensetivity<TReaction, TFeature, TState>,
                MiddleSensetivity<TReaction, TFeature, TState>,
                HighSensetivity<TReaction, TFeature, TState>,
                RigiditySensetivity<TReaction, TFeature, TState>>(c1, c2);

        public int CompareTo(RigiditySensetivity<TReaction, TFeature, TState> other)
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
                cs.RigiditySensetivity,
                cs.EmotionalInstabilityStability,
                cs.PracticalityDreaminess,
                cs.RestraintExpressiveness,
                cs.RigiditySensetivity,
                cs.SubordinationDomination
            };
        }
        public override string ToString()
        {
            return $"Жесткость-чувствительность: значение {RawCharacterValue}, grade {CharacterGrade}";
        }
              
    }
}