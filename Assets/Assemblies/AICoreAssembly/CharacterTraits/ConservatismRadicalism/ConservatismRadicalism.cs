using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// Для низкого значения характерно: консервативность, устойчивость по отношению к традициям, сомнение
    /// в отношении к новых идей и принципов, склонность к морализации и нравоучениям,
    /// сопротивление переменам, узость интеллектуальных интересов, ориентация на конкретную реальную деятельность.
    /// Для высокого значения характерно: свободомыслие, экспериментаторство,
    /// наличие интеллектуальных интересов, развитое аналитическое мышление,
    /// восприимчивость к переменам, к новым идеям, недоверие к авторитетам, отказ принимать что-либо на веру,
    /// направленность на аналитическую, теоретическую деятельность.
    /// В исследованиях было получено доказательство того, что личности с высокими показателями
    /// по этому фактору лучше информированы, меньше склонны к морализаторству, выражают больший интерес к науке,
    /// нежели к догмам.Более того, они готовы к нарушению привычек и устоявшихся традиций,
    /// им свойственна независимость суждений, взглядов и поведения.
    /// Фактор определяет радикальное, интеллектуальное, политическое и религиозное отношения.
    /// </summary>
    public abstract class ConservatismRadicalism<TAgent, TReaction, TFeature, TState, TSensor> : CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>,
        IComparable<ConservatismRadicalism<TAgent, TReaction, TFeature, TState, TSensor>>
         where TAgent : ICurrentStateHandler<TState> where TReaction : IReaction
         where TFeature : IFeature
        where TState : IState where TSensor : ISensor
    {
        public static bool operator <(ConservatismRadicalism<TAgent, TReaction, TFeature, TState, TSensor> c1,
            ConservatismRadicalism<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
         Char1LessChar2<LowRadicalism<TAgent, TReaction, TFeature, TState, TSensor>,
             MiddleRadicalism<TAgent, TReaction, TFeature, TState, TSensor>,
             HighRadicalism<TAgent, TReaction, TFeature, TState, TSensor>,
             ConservatismRadicalism<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator <=(ConservatismRadicalism<TAgent, TReaction, TFeature, TState, TSensor> c1,
            ConservatismRadicalism<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1LessOrEqualChar2<LowRadicalism<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleRadicalism<TAgent, TReaction, TFeature, TState, TSensor>,
                HighRadicalism<TAgent, TReaction, TFeature, TState, TSensor>,
                ConservatismRadicalism<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator >(ConservatismRadicalism<TAgent, TReaction, TFeature, TState, TSensor> c1,
            ConservatismRadicalism<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1MoreChar2<LowRadicalism<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleRadicalism<TAgent, TReaction, TFeature, TState, TSensor>,
                HighRadicalism<TAgent, TReaction, TFeature, TState, TSensor>,
                ConservatismRadicalism<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator >=(ConservatismRadicalism<TAgent, TReaction, TFeature, TState, TSensor> c1,
            ConservatismRadicalism<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1MoreOrEqualChar2<LowRadicalism<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleRadicalism<TAgent, TReaction, TFeature, TState, TSensor>,
                HighRadicalism<TAgent, TReaction, TFeature, TState, TSensor>,
                ConservatismRadicalism<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public int CompareTo(ConservatismRadicalism<TAgent, TReaction, TFeature, TState, TSensor> other)
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
            ThisCharType = CharTraitType.ConservatismRadicalism;
        }
        public override List<CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>>
            GetCorrelatedTraitsForCharacter(AgentBase<TAgent, TReaction, TFeature, TState, TSensor> agent)
        {
            var cs = agent.CharacterSystem;
            return new List<CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>>() {
                cs.ConservatismRadicalism,
                cs.Intelligence,
                cs.NormativityOfBehaviour,
                cs.StraightforwardnessDiplomacy,
                cs.TimidityCourage
            };
        }

        public override string ToString()
        {
            return $"Консерватизм-радикализм: значение {RawCharacterValue}, grade {CharacterGrade}";
        }
    }
}