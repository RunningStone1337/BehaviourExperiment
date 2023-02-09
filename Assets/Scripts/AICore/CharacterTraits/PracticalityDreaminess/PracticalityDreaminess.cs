using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// ƒл€ низкого значени€ характерно: высока€ скорость решени€ практических задач,
    /// прозаичность, ориентаци€ на внешнюю реальность, развитое конкретное воображение, практичность, реалистичность.
    /// ƒл€ высокого значени€ характерно: богатое воображение, поглощенность своими иде€ми,
    /// внутренними иллюзи€ми(Ђвитает в облакахї), легкость отказа от практических суждений,
    /// умение оперировать абстрактными пон€ти€ми, ориентированность на свой внутренний мир; мечтательность.
    /// ¬ целом фактор ориентирован на измерение особенностей воображени€, отражающихс€ в реальном поведении личности,
    /// таких, как практичность, приземленность или, наоборот, некоторое Ђвитание в облакахї, романтическое отношение к жизни.
    /// </summary>
    public abstract class PracticalityDreaminess<TReaction, TFeature, TState> : CharacterTraitBase<TReaction, TFeature, TState>,
        IComparable<PracticalityDreaminess<TReaction, TFeature, TState>>
         where TReaction : IReaction
         where TFeature : IFeature where TState : IState
    {


        public static bool operator <(PracticalityDreaminess<TReaction, TFeature, TState> c1,
                    PracticalityDreaminess<TReaction, TFeature, TState> c2) =>
         Char1LessChar2<LowDreaminess<TReaction, TFeature, TState>,
             MiddleDreaminess<TReaction, TFeature, TState>,
             HighDreaminess<TReaction, TFeature, TState>,
             PracticalityDreaminess<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator <=(PracticalityDreaminess<TReaction, TFeature, TState> c1,
            PracticalityDreaminess<TReaction, TFeature, TState> c2) =>
            Char1LessOrEqualChar2<LowDreaminess<TReaction, TFeature, TState>,
                MiddleDreaminess<TReaction, TFeature, TState>,
                HighDreaminess<TReaction, TFeature, TState>,
                PracticalityDreaminess<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator >(PracticalityDreaminess<TReaction, TFeature, TState> c1,
            PracticalityDreaminess<TReaction, TFeature, TState> c2) =>
            Char1MoreChar2<LowDreaminess<TReaction, TFeature, TState>,
                MiddleDreaminess<TReaction, TFeature, TState>,
                HighDreaminess<TReaction, TFeature, TState>,
                PracticalityDreaminess<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator >=(PracticalityDreaminess<TReaction, TFeature, TState> c1,
            PracticalityDreaminess<TReaction, TFeature, TState> c2) =>
            Char1MoreOrEqualChar2<LowDreaminess<TReaction, TFeature, TState>,
                MiddleDreaminess<TReaction, TFeature, TState>,
                HighDreaminess<TReaction, TFeature, TState>,
                PracticalityDreaminess<TReaction, TFeature, TState>>(c1, c2);

        public int CompareTo(PracticalityDreaminess<TReaction, TFeature, TState> other)
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
            return new List<CharacterTraitBase<TReaction, TFeature, TState> >()
            { 
                cs.PracticalityDreaminess,
                cs.ConservatismRadicalism,
                cs.CredulitySuspicion,
                cs.Intelligence,
                cs.PracticalityDreaminess
            };
        }
        public override string ToString()
        {
            return $"ѕрактичность-мечтательность: значение {RawCharacterValue}, grade {CharacterGrade}";
        }
       
    }
}