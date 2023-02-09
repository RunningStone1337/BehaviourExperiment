using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    public enum RelationshipType
    {
        PoorlyKnown,
        Familiar,
        Fellow,
        Comrade,
        Friend,
        Foe,
        Enemy
    }

    /// <summary>
    /// Базовый класс, описывающий взаимоотношения между двумя учениками.
    /// </summary>
    [Serializable]
    public abstract class RelationshipBase<TReaction, TFeature, TState>
        where TReaction:IReaction
        where TFeature : IFeature where TState : IState
    /*: ICharacterTraitsImportanceInfluenceHandler*/


    {
        protected RelationshipType relationship;

        protected RelationshipBase(AgentBase<TReaction, TFeature, TState>thisAgent, AgentBase<TReaction, TFeature, TState>secondAgent)
        {
            ThisAgent = thisAgent;
            SecondAgent = secondAgent;
            KnownCharacterTraits = new List<CharacterTraitBase<TReaction, TFeature, TState>>();
            KnownFeatures = new List<IFeature>();
        }

        /// <summary>
        /// Является ли черта <paramref name="trait"/> у SecondAgent известной для ThisAgent?
        /// </summary>
        /// <param name="trait"></param>
        /// <returns></returns>
        public bool KnownCharacterTrait<T>() where T : CharacterTraitBase<TReaction, TFeature, TState>
        {
            foreach (var ct in KnownCharacterTraits)
            {
                if (ct is T)
                    return true;
            }
            return false;
        }

        protected int MatchFeaturesCount<T>() where T : IFeature
        {
            int counter = 0;
            foreach (var f in KnownFeatures)
            {
                if (f is T)
                    counter++;
            }
            return counter;
        }

        public List<CharacterTraitBase<TReaction, TFeature, TState>> KnownCharacterTraits { get; protected set; }

        public List<IFeature> KnownFeatures { get; protected set; }

        public RelationshipType RelationshipType => relationship;

        public AgentBase<TReaction, TFeature, TState> SecondAgent { get; }

        public AgentBase<TReaction, TFeature, TState>ThisAgent { get; }

        //public virtual float GetImportanceValueFor(LowCourage lowCourage) => default;

        //public virtual float GetImportanceValueFor(MiddleSuspicion middleSuspicion) => default;

        //public virtual float GetImportanceValueFor(MiddleDiplomacy middleDiplomacy) => default;

        //public virtual float GetImportanceValueFor(LowDiplomacy lowDiplomacy) => default;

        //public virtual float GetImportanceValueFor(HighDiplomacy highDiplomacy) => default;

        //public virtual float GetImportanceValueFor(MiddleDreaminess middleDreaminess) => default;

        //public virtual float GetImportanceValueFor(LowDomination lowDomination) => default;

        //public virtual float GetImportanceValueFor(MiddleSelfcontrol middleSelfcontrol) => default;

        //public virtual float GetImportanceValueFor(LowSelfcontrol lowSelfcontrol) => default;

        //public virtual float GetImportanceValueFor(MiddleSensetivity middleSensetivity) => default;

        //public virtual float GetImportanceValueFor(LowSensetivity lowSensetivity) => default;

        //public virtual float GetImportanceValueFor(HighSensetivity highSensetivity) => default;

        //public virtual float GetImportanceValueFor(MiddleExpressiveness middleExpressiveness) => default;

        //public virtual float GetImportanceValueFor(LowExpressiveness lowExpressiveness) => default;

        //public virtual float GetImportanceValueFor(HighExpressiveness highExpressiveness) => default;

        //public virtual float GetImportanceValueFor(HighDomination highDomination) => default;

        //public virtual float GetImportanceValueFor(MiddleNonconformism middleNonconformism) => default;

        //public virtual float GetImportanceValueFor(HighSelfcontrol highSelfcontrol) => default;

        //public virtual float GetImportanceValueFor(MiddleTension middleTension) => default;

        //public virtual float GetImportanceValueFor(MiddleCourage middleCourage) => default;

        //public virtual float GetImportanceValueFor(LowTension lowTension) => default;

        //public virtual float GetImportanceValueFor(MiddleDomination middleDomination) => default;

        //public virtual float GetImportanceValueFor(HighTension highTension) => default;

        //public virtual float GetImportanceValueFor(MiddleClosenessSociability middleClosenessSociability) => default;

        //public virtual float GetImportanceValueFor(LowNormativityOfBehaviour lowNormativityOfBehaviour) => default;

        //public virtual float GetImportanceValueFor(LowIntelligence lowIntelligence) => default;

        //public virtual float GetImportanceValueFor(HighCourage highCourage) => default;

        //public virtual float GetImportanceValueFor(HighEmotionalStability highEmotionalStability) => default;

        //public virtual float GetImportanceValueFor(LowNonconformism lowNonconformism) => default;

        //public virtual float GetImportanceValueFor(HighNonconformism highNonconformism) => default;

        //public virtual float GetImportanceValueFor(MiddleAnxiety middleAnxiety) => default;

        //public virtual float GetImportanceValueFor(HighDreaminess highDreaminess) => default;

        //public virtual float GetImportanceValueFor(HighClosenessSociability highClosenessSociability) => default;

        //public virtual float GetImportanceValueFor(LowClosenessSociability lowClosenessSociability) => default;

        //public virtual float GetImportanceValueFor(LowAnxiety lowAnxiety) => default;

        //public virtual float GetImportanceValueFor(LowDreaminess lowDreaminess) => default;

        //public virtual float GetImportanceValueFor(MiddleNormativityOfBehaviour middleNormativityOfBehaviour) => default;

        //public virtual float GetImportanceValueFor(LowSuspicion lowSuspicion) => default;

        //public virtual float GetImportanceValueFor(HighSuspicion highSuspicion) => default;

        //public virtual float GetImportanceValueFor(HighAnxiety highAnxiety) => default;

        //public virtual float GetImportanceValueFor(MiddleRadicalism middleRadicalism) => default;

        //public virtual float GetImportanceValueFor(LowRadicalism lowRadicalism) => default;

        ///// <summary>
        ///// Влияние <paramref name="highRadicalism"/> на <paramref name="SecondAgent"/> при типе отношений.
        ///// </summary>
        ///// <param name="highRadicalism"></param>
        ///// <returns></returns>
        //public virtual float GetImportanceValueFor(HighRadicalism highRadicalism) => default;

        //public virtual float GetImportanceValueFor(HighNormativityOfBehaviour highNormativityOfBehaviour) => default;

        //public virtual float GetImportanceValueFor(HighIntelligence highIntelligence) => default;

        //public virtual float GetImportanceValueFor(MiddleEmotionalStability middleEmotionalStability) => default;

        //public virtual float GetImportanceValueFor(LowEmotionalStability lowEmotionalStability) => default;

        //public virtual float GetImportanceValueFor(MiddleIntelligence middleIntelligence) => default;


        public void InitFrom(RelationshipBase<TReaction, TFeature, TState> oldRelation)
        {
            KnownCharacterTraits = oldRelation.KnownCharacterTraits;
            KnownFeatures = oldRelation.KnownFeatures;
        }

        #region influenceChecks

        public static float NegativeValIfLess<T>
            (CharacterTraitBase<TReaction, TFeature, TState> valueHandler, T traitToCompare1, T traitToCompare2)
                   where T : CharacterTraitBase<TReaction, TFeature, TState>, IComparable<T>
        {
            //TODO возможно не будет работать с характерами
            var compare = traitToCompare1.CompareTo(traitToCompare2);
            if (compare == 1)
                return -valueHandler.CharacterValue;
            return default;
        }

        public static float NegativeValIfLessElsePositive<T>
            (CharacterTraitBase<TReaction, TFeature, TState> valueHandler, T traitToCompare1, T traitToCompare2)
                   where T : CharacterTraitBase<TReaction, TFeature, TState>, IComparable<T>
        {
            //TODO возможно не будет работать с характерами
            var compare = traitToCompare1.CompareTo(traitToCompare2);
            if (compare == 1)
                return -valueHandler.CharacterValue;
            return valueHandler.CharacterValue;
        }

        public static float NegativeValIfLessOrEqual<T>
            (CharacterTraitBase<TReaction, TFeature, TState> valueHandler, T traitToCompare1, T traitToCompare2)
                   where T : CharacterTraitBase<TReaction, TFeature, TState>, IComparable<T>
        {
            //TODO возможно не будет работать с характерами
            var compare = traitToCompare1.CompareTo(traitToCompare2);
            if (compare == 1 || compare == 0)
                return -valueHandler.CharacterValue;
            return default;
        }

        public static float NegativeValIfLessOrEqualElsePositive<T>
            (CharacterTraitBase<TReaction, TFeature, TState> valueHandler, T traitToCompare1, T traitToCompare2)
                   where T : CharacterTraitBase<TReaction, TFeature, TState>, IComparable<T>
        {
            //TODO возможно не будет работать с характерами
            var compare = traitToCompare1.CompareTo(traitToCompare2);
            if (compare == 1 || compare == 0)
                return -valueHandler.CharacterValue;
            return valueHandler.CharacterValue;
        }

        public static float NegativeValIfMatch<T, TBase>
            (CharacterTraitBase<TReaction, TFeature, TState> valueHandler, TBase traitToMatch)
            where T : TBase
            where TBase : CharacterTraitBase<TReaction, TFeature, TState>
        {
            //TODO возможно не будет работать с характерами
            if (traitToMatch is T)
                return -valueHandler.CharacterValue;
            return default;
        }

        /// <summary>
        /// Если T1 больше чем T2
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="valueHandler"></param>
        /// <param name="traitToCompare1"></param>
        /// <param name="traitToCompare2"></param>
        /// <returns></returns>
        public static float NegativeValIfMore<T1>
            (CharacterTraitBase<TReaction, TFeature, TState> valueHandler, T1 traitToCompare1, T1 traitToCompare2)
                   where T1 : CharacterTraitBase<TReaction, TFeature, TState>, IComparable<T1>
        {
            //TODO возможно не будет работать с характерами
            var compare = traitToCompare1.CompareTo(traitToCompare2);
            if (compare == -1)
                return -valueHandler.CharacterValue;
            return default;
        }

        public static float NegativeValIfMoreElsePositive<T>
            (CharacterTraitBase<TReaction, TFeature, TState> valueHandler, T traitToCompare1, T traitToCompare2)
                   where T : CharacterTraitBase<TReaction, TFeature, TState>, IComparable<T>
        {
            //TODO возможно не будет работать с характерами
            var compare = traitToCompare1.CompareTo(traitToCompare2);
            if (compare == -1)
                return -valueHandler.CharacterValue;
            else
                return valueHandler.CharacterValue;
        }

        /// <summary>
        /// Если T1 больше или равен чем T2
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="valueHandler"></param>
        /// <param name="traitToCompare1"></param>
        /// <param name="traitToCompare2"></param>
        /// <returns></returns>
        public static float NegativeValIfMoreOrEqual<T1>
            (CharacterTraitBase<TReaction, TFeature, TState> valueHandler, T1 traitToCompare1, T1 traitToCompare2)
                   where T1 : CharacterTraitBase<TReaction, TFeature, TState>, IComparable<T1>
        {
            //TODO возможно не будет работать с характерами
            var compare = traitToCompare1.CompareTo(traitToCompare2);
            if (compare == -1 || compare == 0)
                return -valueHandler.CharacterValue;
            return default;
        }

        /// <summary>
        /// Если <paramref name="traitToCompare1"/> больше или равен чем <paramref name="traitToCompare2"/>
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="valueHandler"></param>
        /// <param name="traitToCompare1"></param>
        /// <param name="traitToCompare2"></param>
        /// <returns></returns>
        public static float NegativeValIfMoreOrEqualElsePositive<T1>
            (CharacterTraitBase<TReaction, TFeature, TState> valueHandler, T1 traitToCompare1, T1 traitToCompare2)
                   where T1 : CharacterTraitBase<TReaction, TFeature, TState>, IComparable<T1>
        {
            //TODO возможно не будет работать с характерами
            var compare = traitToCompare1.CompareTo(traitToCompare2);
            if (compare == -1 || compare == 0)
                return -valueHandler.CharacterValue;
            return valueHandler.CharacterValue;
        }

        /// <summary>
        /// Если T1 != T2
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="valueHandler"></param>
        /// <param name="traitToCompare1"></param>
        /// <param name="traitToCompare2"></param>
        /// <returns></returns>
        public static float NegativeValIfNonEqual<T1>
            (CharacterTraitBase<TReaction, TFeature, TState> valueHandler, T1 traitToCompare1, T1 traitToCompare2)
                   where T1 : CharacterTraitBase<TReaction, TFeature, TState>, IComparable<T1>
        {
            //TODO возможно не будет работать с характерами
            var compare = traitToCompare1.CompareTo(traitToCompare2);
            if (compare != 0)
                return -valueHandler.CharacterValue;
            return default;
        }

        public static float NegativeValIfNonEqualElsePositive<T1>
           (CharacterTraitBase<TReaction, TFeature, TState> valueHandler, T1 traitToCompare1, T1 traitToCompare2)
                  where T1 : CharacterTraitBase<TReaction, TFeature, TState>, IComparable<T1>
        {
            //TODO возможно не будет работать с характерами
            var compare = traitToCompare1.CompareTo(traitToCompare2);
            if (compare != 0)
                return -valueHandler.CharacterValue;
            return valueHandler.CharacterValue;
        }

        public static float PositiveValIfEquals<TBase>
            (CharacterTraitBase<TReaction, TFeature, TState> valueHandler, TBase traitToCompare1, TBase traitToCompare2)
                   where TBase : CharacterTraitBase<TReaction, TFeature, TState>
        {
            //TODO возможно не будет работать с характерами
            var compare = traitToCompare1.GetType().IsEquivalentTo(traitToCompare2.GetType());
            if (compare)
                return valueHandler.CharacterValue;
            return default;
        }

        public static float PositiveValIfEqualsElseNeg<TBase>
            (CharacterTraitBase<TReaction, TFeature, TState> valueHandler, TBase traitToCompare1, TBase traitToCompare2)
                   where TBase : CharacterTraitBase<TReaction, TFeature, TState>
        {
            //TODO возможно не будет работать с характерами
            var compare = traitToCompare1.GetType().IsEquivalentTo(traitToCompare2.GetType());
            if (compare)
                return valueHandler.CharacterValue;
            return -valueHandler.CharacterValue;
        }

        /// <summary>
        /// Если <paramref name="traitToCompare1"/> меньше <paramref name="traitToCompare2"/>
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="valueHandler"></param>
        /// <param name="traitToCompare1"></param>
        /// <param name="traitToCompare2"></param>
        /// <returns></returns>
        public static float PositiveValIfLess<T1>
            (CharacterTraitBase<TReaction, TFeature, TState> valueHandler, T1 traitToCompare1, T1 traitToCompare2)
                   where T1 : CharacterTraitBase<TReaction, TFeature, TState>, IComparable<T1>
        {
            //TODO возможно не будет работать с характерами
            var compare = traitToCompare1.CompareTo(traitToCompare2);
            if (compare == 1)
                return valueHandler.CharacterValue;
            return default;
        }

        public static float PositiveValIfLessElseNeg<T1>
            (CharacterTraitBase<TReaction, TFeature, TState> valueHandler, T1 traitToCompare1, T1 traitToCompare2)
                   where T1 : CharacterTraitBase<TReaction, TFeature, TState>, IComparable<T1>
        {
            //TODO возможно не будет работать с характерами
            var compare = traitToCompare1.CompareTo(traitToCompare2);
            if (compare == 1)
                return valueHandler.CharacterValue;
            else
                return -valueHandler.CharacterValue;
        }

        /// <summary>
        /// Если <paramref name="traitToCompare1"/> меньше <paramref name="traitToCompare2"/>: значение <paramref name="valueHandler"/>.
        /// Если <paramref name="traitToCompare1"/> больше <paramref name="traitToCompare2"/>: - значение <paramref name="valueHandler"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="valueHandler"></param>
        /// <param name="traitToCompare1"></param>
        /// <param name="traitToCompare2"></param>
        /// <returns></returns>
        public static float PositiveValIfLessNegativeIfMore<T>
            (CharacterTraitBase<TReaction, TFeature, TState> valueHandler, T traitToCompare1, T traitToCompare2)
                   where T : CharacterTraitBase<TReaction, TFeature, TState>, IComparable<T>
        {
            //TODO возможно не будет работать с характерами
            var compare = traitToCompare1.CompareTo(traitToCompare2);
            if (compare == 1)
                return valueHandler.CharacterValue;
            if (compare == -1)
                return -valueHandler.CharacterValue;
            return default;
        }

        public static float PositiveValIfLessOrEqual<T>
                    (CharacterTraitBase<TReaction, TFeature, TState> valueHandler, T traitToCompare1, T traitToCompare2)
                   where T : CharacterTraitBase<TReaction, TFeature, TState>, IComparable<T>
        {
            //TODO возможно не будет работать с характерами
            var compare = traitToCompare1.CompareTo(traitToCompare2);
            if (compare == 1 || compare == 0)
                return valueHandler.CharacterValue;
            return default;
        }

        public static float PositiveValIfLessOrEqualElseNeg<T1>
            (CharacterTraitBase<TReaction, TFeature, TState> valueHandler, T1 traitToCompare1, T1 traitToCompare2)
                   where T1 : CharacterTraitBase<TReaction, TFeature, TState>, IComparable<T1>
        {
            //TODO возможно не будет работать с характерами
            var compare = traitToCompare1.CompareTo(traitToCompare2);
            if (compare == 1 || compare == 0)
                return valueHandler.CharacterValue;
            else
                return -valueHandler.CharacterValue;
        }

        public static float PositiveValIfMatch<T, TBase>
            (CharacterTraitBase<TReaction, TFeature, TState> valueHandler, TBase traitToMatch)
            where T : TBase
            where TBase : CharacterTraitBase<TReaction, TFeature, TState>
        {
            //TODO возможно не будет работать с характерами
            if (traitToMatch is T)
                return valueHandler.CharacterValue;
            return default;
        }

        /// <summary>
        /// Возвращает значение <paramref name="valueHandler"/> если <paramref name="traitToCompare"/>
        /// является <typeparamref name="T1"/>, иначе возвращает отрицательное значение  <paramref name="valueHandler"/>
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="valueHandler"></param>
        /// <param name="traitToCompare"></param>
        /// <returns></returns>
        public static float PositiveValIfMatchElseNegative<T1, TBase>(CharacterTraitBase<TReaction, TFeature, TState> valueHandler, TBase traitToCompare)
            where T1 : TBase
            where TBase : CharacterTraitBase<TReaction, TFeature, TState>
        {
            if (traitToCompare is T1)
                return valueHandler.CharacterValue;
            else
                return -valueHandler.CharacterValue;
        }

        public static float PositiveValIfMatchNegativeIfMore<TMatch, TCompare>(CharacterTraitBase<TReaction, TFeature, TState> valueHandler, TCompare traitToMatchOrCompare, TCompare traitToCompare)
                   where TCompare : CharacterTraitBase<TReaction, TFeature, TState>, IComparable<TCompare>
        {
            if (traitToMatchOrCompare is TMatch)
                return valueHandler.CharacterValue;
            var compare = traitToMatchOrCompare.CompareTo(traitToCompare);
            if (compare == -1)
                return -valueHandler.CharacterValue;
            return default;
        }

        public static float PositiveValIfMatchT1NegativeIfMatchT2<T1, T2, TBase>
                   (CharacterTraitBase<TReaction, TFeature, TState> valueHandler, TBase traitToCheck)
            where T1 : TBase
            where T2 : TBase
            where TBase : CharacterTraitBase<TReaction, TFeature, TState>
        {
            //TODO возможно не будет работать с характерами
            if (traitToCheck is T1)
                return valueHandler.CharacterValue;
            else if (traitToCheck is T2)
                return -valueHandler.CharacterValue;
            return default;
        }

        public static float PositiveValIfMore<T1>
            (CharacterTraitBase<TReaction, TFeature, TState> valueHandler, T1 traitToCompare1, T1 traitToCompare2)
                   where T1 : CharacterTraitBase<TReaction, TFeature, TState>, IComparable<T1>
        {
            //TODO возможно не будет работать с характерами
            var compare = traitToCompare1.CompareTo(traitToCompare2);
            if (compare == -1)
                return valueHandler.CharacterValue;
            return default;
        }

        public static float PositiveValIfMoreElseNegative<T>
            (CharacterTraitBase<TReaction, TFeature, TState> valueHandler, T traitToCompare1, T traitToCompare2)
                   where T : CharacterTraitBase<TReaction, TFeature, TState>, IComparable<T>
        {
            //TODO возможно не будет работать с характерами
            var compare = traitToCompare1.CompareTo(traitToCompare2);
            if (compare == 1)
                return valueHandler.CharacterValue;
            else
                return -valueHandler.CharacterValue;
        }

        public static float PositiveValIfMoreOrEqual<T1>
            (CharacterTraitBase<TReaction, TFeature, TState> valueHandler, T1 traitToCompare1, T1 traitToCompare2)
                   where T1 : CharacterTraitBase<TReaction, TFeature, TState>, IComparable<T1>
        {
            //TODO возможно не будет работать с характерами
            var compare = traitToCompare1.CompareTo(traitToCompare2);
            if (compare == -1 || compare == 0)
                return valueHandler.CharacterValue;
            return default;
        }

        public static float PositiveValIfMoreOrEqualElseNeg<T>
            (CharacterTraitBase<TReaction, TFeature, TState> valueHandler, T traitToCompare1, T traitToCompare2)
                   where T : CharacterTraitBase<TReaction, TFeature, TState>, IComparable<T>
        {
            //TODO возможно не будет работать с характерами
            var compare = traitToCompare1.CompareTo(traitToCompare2);
            if (compare == 1 || compare == 0)
                return valueHandler.CharacterValue;
            else
                return -valueHandler.CharacterValue;
        }

        #endregion influenceChecks
    }
}