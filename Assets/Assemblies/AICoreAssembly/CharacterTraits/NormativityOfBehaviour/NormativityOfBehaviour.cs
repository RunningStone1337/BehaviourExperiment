using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// Для низкого значения характерно: склонность к непостоянству, подверженность влиянию чувств,
    /// случая и обстоятельств. Потворствует своим желаниям, не делает усилий по выполнению групповых
    /// требований и норм. Неорганизованность, безответственность, импульсивность, отсутствие согласия
    /// с общепринятыми моральными правилами и стандартами, гибкость по отношению к социальным нормам,
    /// свобода от их влияния, иногда беспринципность и склонность к асоциальному поведению.
    /// Для высокого значения характерно: добросовестность, ответственность, стабильность, уравновешенность,
    /// настойчивость, склонность к морализированию, разумность, совестливость.
    /// Развитое чувство долга и ответственности, осознанное соблюдение общепринятых моральных правил и норм,
    /// настойчивость в достижении цели, деловая направленность.
    /// </summary>
    public abstract class NormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor> : CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>,
        IComparable<NormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor>>
         where TAgent : ICurrentStateHandler<TState> where TReaction : IReaction
         where TFeature : IFeature where TState : IState where TSensor : ISensor
    {
        public static bool operator <(NormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor> c1,
            NormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
         Char1LessChar2<LowNormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor>,
             MiddleNormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor>,
             HighNormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor>,
             NormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator <=(NormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor> c1,
            NormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1LessOrEqualChar2<LowNormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleNormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor>,
                HighNormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor>,
                NormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator >(NormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor> c1,
            NormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1MoreChar2<LowNormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleNormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor>,
                HighNormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor>,
                NormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public static bool operator >=(NormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor> c1,
            NormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor> c2) =>
            Char1MoreOrEqualChar2<LowNormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor>,
                MiddleNormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor>,
                HighNormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor>,
                NormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor>>(c1, c2);

        public int CompareTo(NormativityOfBehaviour<TAgent, TReaction, TFeature, TState, TSensor> other)
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
            ThisCharType = CharTraitType.NormativityOfBehaviour;
        }
        public override List<CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>>
            GetCorrelatedTraitsForCharacter(AgentBase<TAgent, TReaction, TFeature, TState, TSensor> agent)
        {
            var cs = agent.CharacterSystem;
            return new List<CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>>()
            {
                cs.NormativityOfBehaviour,
                cs.CalmnessAnxiety,
                cs.NormativityOfBehaviour,
                cs.PracticalityDreaminess,
                cs.RelaxationTension,
                cs.Selfcontrol
            };
        }

        public override string ToString()
        {
            return $"Нормативность поведения: значение {RawCharacterValue}, grade {CharacterGrade}";
        }
    }
}