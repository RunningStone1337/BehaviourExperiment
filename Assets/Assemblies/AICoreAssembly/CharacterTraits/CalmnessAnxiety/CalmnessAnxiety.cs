using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// Спокойствие-тревожность. Низкие оценки характерны для людей,
    /// которые «управляют своими неудачами». Личность с высокими оценками по этому фактору
    /// чувствует свою неустойчивость, напряженность в трудных жизненных ситуациях,
    /// легко теряет присутствие духа, полна сожалений и сострадания;
    /// для нее характерна комбинация симптомов ипохондрии и неврастении с преобладанием страхов.
    /// Этот фактор шире, чем чувство вины в общепринятом смысле.
    /// </summary>
    public abstract class CalmnessAnxiety<TAgent, TReaction, TFeature, TState, TSensor> : CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>,
        IComparable<CalmnessAnxiety<TAgent, TReaction, TFeature, TState, TSensor>>
        where TAgent : ICurrentStateHandler<TState> where TReaction : IReaction
        where TFeature : IFeature where TState : IState where TSensor : ISensor

    {
        public static bool operator <(CalmnessAnxiety<TAgent, TReaction, TFeature, TState, TSensor> c1,
            CalmnessAnxiety<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
                  Char1LessChar2<LowAnxiety<TAgent, TReaction, TFeature, TState, TSensor>,
                      MiddleAnxiety<TAgent, TReaction, TFeature, TState, TSensor>,
                      HighAnxiety<TAgent, TReaction, TFeature, TState, TSensor>,
                      CalmnessAnxiety<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator <=(CalmnessAnxiety<TAgent, TReaction, TFeature, TState, TSensor> c1,
            CalmnessAnxiety<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1LessOrEqualChar2<LowAnxiety<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleAnxiety<TAgent, TReaction, TFeature, TState, TSensor>,
                HighAnxiety<TAgent, TReaction, TFeature, TState, TSensor>,
                CalmnessAnxiety<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator >(CalmnessAnxiety<TAgent, TReaction, TFeature, TState, TSensor> c1,
            CalmnessAnxiety<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1MoreChar2<LowAnxiety<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleAnxiety<TAgent, TReaction, TFeature, TState, TSensor>,
                HighAnxiety<TAgent, TReaction, TFeature, TState, TSensor>,
                CalmnessAnxiety<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator >=(CalmnessAnxiety<TAgent, TReaction, TFeature, TState, TSensor> c1,
            CalmnessAnxiety<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1MoreOrEqualChar2<LowAnxiety<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleAnxiety<TAgent, TReaction, TFeature, TState, TSensor>,
                HighAnxiety<TAgent, TReaction, TFeature, TState, TSensor>,
                CalmnessAnxiety<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public int CompareTo(CalmnessAnxiety<TAgent, TReaction, TFeature, TState, TSensor> other)
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
            return new List<CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>>() {
                cs.CalmnessAnxiety,
                cs.ClosenessSociability,
                cs.EmotionalInstabilityStability,
                cs.RelaxationTension,
                cs.RestraintExpressiveness,
                cs.RigiditySensetivity,
                cs.SubordinationDomination
            };
        }
        public override void Initiate(int characterValue, TAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisCharType = CharTraitType.CalmnessAnxiety;
        }
        public override string ToString()
        {
            return $"Спокойствие-тревожность: значение {RawCharacterValue}, grade {CharacterGrade}";
        }
    }
}