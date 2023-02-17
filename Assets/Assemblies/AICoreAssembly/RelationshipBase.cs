using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// Base class for relationship between two agents.
    /// </summary>
    [Serializable]
    public abstract class RelationshipBase<TThisAgent, TOtherAgent, TState/*, TReaction, TFeature, TState, TSensor*/>
        where TThisAgent : ICurrentStateHandler<TState> 
        where TOtherAgent : IAgent
        where TState : IState
        //where TReaction : IReaction
        //where TFeature : IFeature
        //where TSensor : ISensor
        /*: ICharacterTraitsImportanceInfluenceHandler*/

    {
        //protected RelationshipType relationship;

        protected RelationshipBase(TThisAgent thisAgent, TOtherAgent secondAgent)
        {
            ThisAgent = thisAgent;
            SecondAgent = secondAgent;
            //KnownCharacterTraits = new List<CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor>>();
            //KnownFeatures = new List<TFeature>();
        }
        //protected int MatchFeaturesCount<T>() where T : IFeature
        //{
        //    int counter = 0;
        //    foreach (var f in KnownFeatures)
        //    {
        //        if (f is T)
        //            counter++;
        //    }
        //    return counter;
        //}

        //public List<CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor>> KnownCharacterTraits { get; protected set; }

        //public List<TFeature> KnownFeatures { get; protected set; }


        public TOtherAgent SecondAgent { get; }

        public TThisAgent ThisAgent { get; }

        //public void InitFrom(RelationshipBase<TThisAgent, TReaction, TFeature, TState, TSensor> oldRelation)
        //{
        //    KnownCharacterTraits = oldRelation.KnownCharacterTraits;
        //    KnownFeatures = oldRelation.KnownFeatures;
        //}

        /// <summary>
        /// Является ли черта <paramref name="trait"/> у SecondAgent известной для ThisAgent?
        /// </summary>
        /// <param name="trait"></param>
        /// <returns></returns>
        //public bool KnownCharacterTrait<T>() where T : CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor>
        //{
        //    foreach (var ct in KnownCharacterTraits)
        //    {
        //        if (ct is T)
        //            return true;
        //    }
        //    return false;
        //}

       


        #region influenceChecks

        //public static float NegativeValIfLess<T>
        //    (CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor> valueHandler, T traitToCompare1, T traitToCompare2)
        //           where T : CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor>, IComparable<T>
        //{
        //    //TODO возможно не будет работать с характерами
        //    var compare = traitToCompare1.CompareTo(traitToCompare2);
        //    if (compare == 1)
        //        return -valueHandler.SpecializedCharacterValue;
        //    return default;
        //}

        //public static float NegativeValIfLessElsePositive<T>
        //    (CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor> valueHandler, T traitToCompare1, T traitToCompare2)
        //           where T : CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor>, IComparable<T>
        //{
        //    //TODO возможно не будет работать с характерами
        //    var compare = traitToCompare1.CompareTo(traitToCompare2);
        //    if (compare == 1)
        //        return -valueHandler.SpecializedCharacterValue;
        //    return valueHandler.SpecializedCharacterValue;
        //}

        //public static float NegativeValIfLessOrEqual<T>
        //    (CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor> valueHandler, T traitToCompare1, T traitToCompare2)
        //           where T : CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor>, IComparable<T>
        //{
        //    //TODO возможно не будет работать с характерами
        //    var compare = traitToCompare1.CompareTo(traitToCompare2);
        //    if (compare == 1 || compare == 0)
        //        return -valueHandler.SpecializedCharacterValue;
        //    return default;
        //}

        //public static float NegativeValIfLessOrEqualElsePositive<T>
        //    (CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor> valueHandler, T traitToCompare1, T traitToCompare2)
        //           where T : CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor>, IComparable<T>
        //{
        //    //TODO возможно не будет работать с характерами
        //    var compare = traitToCompare1.CompareTo(traitToCompare2);
        //    if (compare == 1 || compare == 0)
        //        return -valueHandler.SpecializedCharacterValue;
        //    return valueHandler.SpecializedCharacterValue;
        //}

        //public static float NegativeValIfMatch<T, TBase>
        //    (CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor> valueHandler, TBase traitToMatch)
        //    where T : TBase
        //    where TBase : CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor>
        //{
        //    //TODO возможно не будет работать с характерами
        //    if (traitToMatch is T)
        //        return -valueHandler.SpecializedCharacterValue;
        //    return default;
        //}

        ///// <summary>
        ///// Если T1 больше чем T2
        ///// </summary>
        ///// <typeparam name="T1"></typeparam>
        ///// <param name="valueHandler"></param>
        ///// <param name="traitToCompare1"></param>
        ///// <param name="traitToCompare2"></param>
        ///// <returns></returns>
        //public static float NegativeValIfMore<T1>
        //    (CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor> valueHandler, T1 traitToCompare1, T1 traitToCompare2)
        //           where T1 : CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor>, IComparable<T1>
        //{
        //    //TODO возможно не будет работать с характерами
        //    var compare = traitToCompare1.CompareTo(traitToCompare2);
        //    if (compare == -1)
        //        return -valueHandler.SpecializedCharacterValue;
        //    return default;
        //}

        //public static float NegativeValIfMoreElsePositive<T>
        //    (CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor> valueHandler, T traitToCompare1, T traitToCompare2)
        //           where T : CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor>, IComparable<T>
        //{
        //    //TODO возможно не будет работать с характерами
        //    var compare = traitToCompare1.CompareTo(traitToCompare2);
        //    if (compare == -1)
        //        return -valueHandler.SpecializedCharacterValue;
        //    else
        //        return valueHandler.SpecializedCharacterValue;
        //}

        ///// <summary>
        ///// Если T1 больше или равен чем T2
        ///// </summary>
        ///// <typeparam name="T1"></typeparam>
        ///// <param name="valueHandler"></param>
        ///// <param name="traitToCompare1"></param>
        ///// <param name="traitToCompare2"></param>
        ///// <returns></returns>
        //public static float NegativeValIfMoreOrEqual<T1>
        //    (CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor> valueHandler, T1 traitToCompare1, T1 traitToCompare2)
        //           where T1 : CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor>, IComparable<T1>
        //{
        //    //TODO возможно не будет работать с характерами
        //    var compare = traitToCompare1.CompareTo(traitToCompare2);
        //    if (compare == -1 || compare == 0)
        //        return -valueHandler.SpecializedCharacterValue;
        //    return default;
        //}

        ///// <summary>
        ///// Если <paramref name="traitToCompare1"/> больше или равен чем <paramref name="traitToCompare2"/>
        ///// </summary>
        ///// <typeparam name="T1"></typeparam>
        ///// <param name="valueHandler"></param>
        ///// <param name="traitToCompare1"></param>
        ///// <param name="traitToCompare2"></param>
        ///// <returns></returns>
        //public static float NegativeValIfMoreOrEqualElsePositive<T1>
        //    (CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor> valueHandler, T1 traitToCompare1, T1 traitToCompare2)
        //           where T1 : CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor>, IComparable<T1>
        //{
        //    //TODO возможно не будет работать с характерами
        //    var compare = traitToCompare1.CompareTo(traitToCompare2);
        //    if (compare == -1 || compare == 0)
        //        return -valueHandler.SpecializedCharacterValue;
        //    return valueHandler.SpecializedCharacterValue;
        //}

        ///// <summary>
        ///// Если T1 != T2
        ///// </summary>
        ///// <typeparam name="T1"></typeparam>
        ///// <param name="valueHandler"></param>
        ///// <param name="traitToCompare1"></param>
        ///// <param name="traitToCompare2"></param>
        ///// <returns></returns>
        //public static float NegativeValIfNonEqual<T1>
        //    (CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor> valueHandler, T1 traitToCompare1, T1 traitToCompare2)
        //           where T1 : CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor>, IComparable<T1>
        //{
        //    //TODO возможно не будет работать с характерами
        //    var compare = traitToCompare1.CompareTo(traitToCompare2);
        //    if (compare != 0)
        //        return -valueHandler.SpecializedCharacterValue;
        //    return default;
        //}

        //public static float NegativeValIfNonEqualElsePositive<T1>
        //   (CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor> valueHandler, T1 traitToCompare1, T1 traitToCompare2)
        //          where T1 : CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor>, IComparable<T1>
        //{
        //    //TODO возможно не будет работать с характерами
        //    var compare = traitToCompare1.CompareTo(traitToCompare2);
        //    if (compare != 0)
        //        return -valueHandler.SpecializedCharacterValue;
        //    return valueHandler.SpecializedCharacterValue;
        //}

        //public static float PositiveValIfEquals<TBase>
        //    (CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor> valueHandler, TBase traitToCompare1, TBase traitToCompare2)
        //           where TBase : CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor>
        //{
        //    //TODO возможно не будет работать с характерами
        //    var compare = traitToCompare1.GetType().IsEquivalentTo(traitToCompare2.GetType());
        //    if (compare)
        //        return valueHandler.SpecializedCharacterValue;
        //    return default;
        //}

        //public static float PositiveValIfEqualsElseNeg<TBase>
        //    (CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor> valueHandler, TBase traitToCompare1, TBase traitToCompare2)
        //           where TBase : CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor>
        //{
        //    //TODO возможно не будет работать с характерами
        //    var compare = traitToCompare1.GetType().IsEquivalentTo(traitToCompare2.GetType());
        //    if (compare)
        //        return valueHandler.SpecializedCharacterValue;
        //    return -valueHandler.SpecializedCharacterValue;
        //}

        ///// <summary>
        ///// Если <paramref name="traitToCompare1"/> меньше <paramref name="traitToCompare2"/>
        ///// </summary>
        ///// <typeparam name="T1"></typeparam>
        ///// <param name="valueHandler"></param>
        ///// <param name="traitToCompare1"></param>
        ///// <param name="traitToCompare2"></param>
        ///// <returns></returns>
        //public static float PositiveValIfLess<T1>
        //    (CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor> valueHandler, T1 traitToCompare1, T1 traitToCompare2)
        //           where T1 : CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor>, IComparable<T1>
        //{
        //    //TODO возможно не будет работать с характерами
        //    var compare = traitToCompare1.CompareTo(traitToCompare2);
        //    if (compare == 1)
        //        return valueHandler.SpecializedCharacterValue;
        //    return default;
        //}

        //public static float PositiveValIfLessElseNeg<T1>
        //    (CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor> valueHandler, T1 traitToCompare1, T1 traitToCompare2)
        //           where T1 : CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor>, IComparable<T1>
        //{
        //    //TODO возможно не будет работать с характерами
        //    var compare = traitToCompare1.CompareTo(traitToCompare2);
        //    if (compare == 1)
        //        return valueHandler.SpecializedCharacterValue;
        //    else
        //        return -valueHandler.SpecializedCharacterValue;
        //}

        ///// <summary>
        ///// Если <paramref name="traitToCompare1"/> меньше <paramref name="traitToCompare2"/>: значение <paramref name="valueHandler"/>.
        ///// Если <paramref name="traitToCompare1"/> больше <paramref name="traitToCompare2"/>: - значение <paramref name="valueHandler"/>.
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="valueHandler"></param>
        ///// <param name="traitToCompare1"></param>
        ///// <param name="traitToCompare2"></param>
        ///// <returns></returns>
        //public static float PositiveValIfLessNegativeIfMore<T>
        //    (CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor> valueHandler, T traitToCompare1, T traitToCompare2)
        //           where T : CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor>, IComparable<T>
        //{
        //    //TODO возможно не будет работать с характерами
        //    var compare = traitToCompare1.CompareTo(traitToCompare2);
        //    if (compare == 1)
        //        return valueHandler.SpecializedCharacterValue;
        //    if (compare == -1)
        //        return -valueHandler.SpecializedCharacterValue;
        //    return default;
        //}

        //public static float PositiveValIfLessOrEqual<T>
        //            (CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor> valueHandler, T traitToCompare1, T traitToCompare2)
        //           where T : CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor>, IComparable<T>
        //{
        //    //TODO возможно не будет работать с характерами
        //    var compare = traitToCompare1.CompareTo(traitToCompare2);
        //    if (compare == 1 || compare == 0)
        //        return valueHandler.SpecializedCharacterValue;
        //    return default;
        //}

        //public static float PositiveValIfLessOrEqualElseNeg<T1>
        //    (CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor> valueHandler, T1 traitToCompare1, T1 traitToCompare2)
        //           where T1 : CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor>, IComparable<T1>
        //{
        //    //TODO возможно не будет работать с характерами
        //    var compare = traitToCompare1.CompareTo(traitToCompare2);
        //    if (compare == 1 || compare == 0)
        //        return valueHandler.SpecializedCharacterValue;
        //    else
        //        return -valueHandler.SpecializedCharacterValue;
        //}

        //public static float PositiveValIfMatch<T, TBase>
        //    (CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor> valueHandler, TBase traitToMatch)
        //    where T : TBase
        //    where TBase : CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor>
        //{
        //    //TODO возможно не будет работать с характерами
        //    if (traitToMatch is T)
        //        return valueHandler.SpecializedCharacterValue;
        //    return default;
        //}

        ///// <summary>
        ///// Возвращает значение <paramref name="valueHandler"/> если <paramref name="traitToCompare"/>
        ///// является <typeparamref name="T1"/>, иначе возвращает отрицательное значение  <paramref name="valueHandler"/>
        ///// </summary>
        ///// <typeparam name="T1"></typeparam>
        ///// <param name="valueHandler"></param>
        ///// <param name="traitToCompare"></param>
        ///// <returns></returns>
        //public static float PositiveValIfMatchElseNegative<T1, TBase>(CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor> valueHandler, TBase traitToCompare)
        //    where T1 : TBase
        //    where TBase : CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor>
        //{
        //    if (traitToCompare is T1)
        //        return valueHandler.SpecializedCharacterValue;
        //    else
        //        return -valueHandler.SpecializedCharacterValue;
        //}

        //public static float PositiveValIfMatchNegativeIfMore<TMatch, TCompare>(CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor> valueHandler, TCompare traitToMatchOrCompare, TCompare traitToCompare)
        //           where TCompare : CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor>, IComparable<TCompare>
        //{
        //    if (traitToMatchOrCompare is TMatch)
        //        return valueHandler.SpecializedCharacterValue;
        //    var compare = traitToMatchOrCompare.CompareTo(traitToCompare);
        //    if (compare == -1)
        //        return -valueHandler.SpecializedCharacterValue;
        //    return default;
        //}

        //public static float PositiveValIfMatchT1NegativeIfMatchT2<T1, T2, TBase>
        //           (CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor> valueHandler, TBase traitToCheck)
        //    where T1 : TBase
        //    where T2 : TBase
        //    where TBase : CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor>
        //{
        //    //TODO возможно не будет работать с характерами
        //    if (traitToCheck is T1)
        //        return valueHandler.SpecializedCharacterValue;
        //    else if (traitToCheck is T2)
        //        return -valueHandler.SpecializedCharacterValue;
        //    return default;
        //}

        //public static float PositiveValIfMore<T1>
        //    (CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor> valueHandler, T1 traitToCompare1, T1 traitToCompare2)
        //           where T1 : CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor>, IComparable<T1>
        //{
        //    //TODO возможно не будет работать с характерами
        //    var compare = traitToCompare1.CompareTo(traitToCompare2);
        //    if (compare == -1)
        //        return valueHandler.SpecializedCharacterValue;
        //    return default;
        //}

        //public static float PositiveValIfMoreElseNegative<T>
        //    (CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor> valueHandler, T traitToCompare1, T traitToCompare2)
        //           where T : CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor>, IComparable<T>
        //{
        //    //TODO возможно не будет работать с характерами
        //    var compare = traitToCompare1.CompareTo(traitToCompare2);
        //    if (compare == 1)
        //        return valueHandler.SpecializedCharacterValue;
        //    else
        //        return -valueHandler.SpecializedCharacterValue;
        //}

        //public static float PositiveValIfMoreOrEqual<T1>
        //    (CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor> valueHandler, T1 traitToCompare1, T1 traitToCompare2)
        //           where T1 : CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor>, IComparable<T1>
        //{
        //    //TODO возможно не будет работать с характерами
        //    var compare = traitToCompare1.CompareTo(traitToCompare2);
        //    if (compare == -1 || compare == 0)
        //        return valueHandler.SpecializedCharacterValue;
        //    return default;
        //}

        //public static float PositiveValIfMoreOrEqualElseNeg<T>
        //    (CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor> valueHandler, T traitToCompare1, T traitToCompare2)
        //           where T : CharacterTraitBase<TThisAgent, TReaction, TFeature, TState, TSensor>, IComparable<T>
        //{
        //    //TODO возможно не будет работать с характерами
        //    var compare = traitToCompare1.CompareTo(traitToCompare2);
        //    if (compare == 1 || compare == 0)
        //        return valueHandler.SpecializedCharacterValue;
        //    else
        //        return -valueHandler.SpecializedCharacterValue;
        //}

        #endregion influenceChecks
    }
}