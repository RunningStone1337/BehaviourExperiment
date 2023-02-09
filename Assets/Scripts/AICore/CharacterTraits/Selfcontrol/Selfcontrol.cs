using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// Для низкого значения характерно: низкая дисциплинированность, следует своим желаниям,
    /// зависимость от настроений, неумение контролировать свои эмоции и поведение.
    /// Для высокого значения характерно: целенаправленность, сильная воля, умение контролировать свои эмоции и поведение.
    /// Низкие оценки по этому фактору указывают на слабую волю и плохой самоконтроль.
    /// Деятельность таких людей неупорядочена и импульсивна.Личность с высокими оценками по этому фактору
    /// имеет социально одобряемые характеристики: самоконтроль, настойчивость, сознательность, склонность
    /// к соблюдению этикета. Для того, чтобы соответствовать таким стандартам, от личности требуется приложение
    /// определенных усилий, наличие четких принципов, убеждений и учет общественного мнения.
    /// Этот фактор измеряет уровень внутреннего контроля поведения, интегрированность личности.
    /// </summary>
    public abstract class Selfcontrol<TReaction, TFeature, TState> : CharacterTraitBase<TReaction, TFeature, TState>,
        IComparable<Selfcontrol<TReaction, TFeature, TState>>
         where TReaction : IReaction
         where TFeature : IFeature where TState : IState
    {
        

        public static bool operator <(Selfcontrol<TReaction, TFeature, TState> c1,
                    Selfcontrol<TReaction, TFeature, TState> c2) =>
         Char1LessChar2<LowSelfcontrol<TReaction, TFeature, TState>,
             MiddleSelfcontrol<TReaction, TFeature, TState>,
             HighSelfcontrol<TReaction, TFeature, TState>,
             Selfcontrol<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator <=(Selfcontrol<TReaction, TFeature, TState> c1,
            Selfcontrol<TReaction, TFeature, TState> c2) =>
            Char1LessOrEqualChar2<LowSelfcontrol<TReaction, TFeature, TState>,
                MiddleSelfcontrol<TReaction, TFeature, TState>,
                HighSelfcontrol<TReaction, TFeature, TState>,
                Selfcontrol<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator >(Selfcontrol<TReaction, TFeature, TState> c1,
            Selfcontrol<TReaction, TFeature, TState> c2) =>
            Char1MoreChar2<LowSelfcontrol<TReaction, TFeature, TState>,
                MiddleSelfcontrol<TReaction, TFeature, TState>,
                HighSelfcontrol<TReaction, TFeature, TState>,
                Selfcontrol<TReaction, TFeature, TState>>(c1, c2);

        public static bool operator >=(Selfcontrol<TReaction, TFeature, TState> c1,
            Selfcontrol<TReaction, TFeature, TState> c2) =>
            Char1MoreOrEqualChar2<LowSelfcontrol<TReaction, TFeature, TState>,
                MiddleSelfcontrol<TReaction, TFeature, TState>,
                HighSelfcontrol<TReaction, TFeature, TState>,
                Selfcontrol<TReaction, TFeature, TState>>(c1, c2);

        public int CompareTo(Selfcontrol<TReaction, TFeature, TState> other)
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
                cs.Selfcontrol,
                cs.EmotionalInstabilityStability,
                cs.Selfcontrol,
                cs.RestraintExpressiveness,
                cs.RigiditySensetivity,
                cs.SubordinationDomination
            };
        }
        public override string ToString()
        {
            return $"Самоконтроль: значение {RawCharacterValue}, grade {CharacterGrade}";
        }
    }
}