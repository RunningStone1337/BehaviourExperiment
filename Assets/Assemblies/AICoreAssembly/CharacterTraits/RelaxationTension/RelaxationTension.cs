using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// ƒл€ низкого значени€ характерно: расслабленность, в€лость, апатичность, спокойствие,
    /// низка€ мотиваци€, излишн€€ удовлетворенность, невозмутимость.
    /// ƒл€ высокого значени€ характерно: собранность, энергичность, напр€женность, фрустрированность,
    /// повышенна€ мотиваци€, беспокойство, взвинченность, раздражительность.
    /// ¬ысока€ оценка интерпретируетс€ как энергетическа€ возбужденность, котора€ требует
    /// определенной разр€дки; иногда это состо€ние может превратитьс€ в психосоматическое нарушение:
    /// снижаетс€ эмоциональна€ устойчивость, нарушаетс€ равновесие, может про€вл€тьс€ агрессивность.
    /// “акие люди редко станов€тс€ лидерами.
    /// »сследовани€ показали, что низка€ оценка (0Ц5 баллов) характерна дл€ людей с невысоким уровнем
    /// мотивации достижени€, довольствующихс€ имеющимс€. Ћица со значени€ми этого фактора от 5 до 8 баллов
    /// характеризуютс€ оптимальным эмоциональным тонусом и стрессоустойчивостью.
    /// </summary>
    public abstract class RelaxationTension<TAgent, TReaction, TFeature, TState, TSensor> : CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>,
        IComparable<RelaxationTension<TAgent, TReaction, TFeature, TState, TSensor>>
         where TAgent : ICurrentStateHandler<TState> where TReaction : IReaction
         where TFeature : IFeature where TState : IState where TSensor : ISensor
    {
        public static bool operator <(RelaxationTension<TAgent, TReaction, TFeature, TState, TSensor> c1,
            RelaxationTension<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
         Char1LessChar2<LowTension<TAgent, TReaction, TFeature, TState, TSensor>,
             MiddleTension<TAgent, TReaction, TFeature, TState, TSensor>,
             HighTension<TAgent, TReaction, TFeature, TState, TSensor>,
             RelaxationTension<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator <=(RelaxationTension<TAgent, TReaction, TFeature, TState, TSensor> c1,
            RelaxationTension<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1LessOrEqualChar2<LowTension<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleTension<TAgent, TReaction, TFeature, TState, TSensor>,
                HighTension<TAgent, TReaction, TFeature, TState, TSensor>,
                RelaxationTension<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator >(RelaxationTension<TAgent, TReaction, TFeature, TState, TSensor> c1,
            RelaxationTension<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1MoreChar2<LowTension<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleTension<TAgent, TReaction, TFeature, TState, TSensor>,
                HighTension<TAgent, TReaction, TFeature, TState, TSensor>,
                RelaxationTension<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator >=(RelaxationTension<TAgent, TReaction, TFeature, TState, TSensor> c1,
            RelaxationTension<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1MoreOrEqualChar2<LowTension<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleTension<TAgent, TReaction, TFeature, TState, TSensor>,
                HighTension<TAgent, TReaction, TFeature, TState, TSensor>,
                RelaxationTension<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public int CompareTo(RelaxationTension<TAgent, TReaction, TFeature, TState, TSensor> other)
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
            ThisCharType = CharTraitType.RelaxationTension;
        }
        public override List<CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>>
            GetCorrelatedTraitsForCharacter(AgentBase<TAgent, TReaction, TFeature, TState, TSensor> agent)
        {
            var cs = agent.CharacterSystem;
            return new List<CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>>() {
                cs.RelaxationTension,
                cs.CalmnessAnxiety,
                cs.ConservatismRadicalism,
                cs.CredulitySuspicion,
                cs.EmotionalInstabilityStability,
                cs.RestraintExpressiveness,
                cs.SubordinationDomination,
                cs.TimidityCourage
            };
        }

        public override string ToString()
        {
            return $"–асслабленность-напр€женность: значение {RawCharacterValue}, grade {CharacterGrade}";
        }
    }
}