using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// Базовый класс, описывающий взаимоотношения между двумя агентами.
    /// </summary>
    [Serializable]
    public abstract class RelationshipBase
    {
        protected RelationshipBase(AgentBase thisAgent, AgentBase secondAgent)
        {
            ThisAgent = thisAgent;
            SecondAgent = secondAgent;
            KnownCharacterTraits = new List<CharacterTraitBase>();
            KnownFeatures = new List<FeatureBase>();
        }

        #region influenceChecks

        protected static float NegativeValIfLess<T>
            (CharacterTraitBase valueHandler, T traitToCompare1, T traitToCompare2)
                   where T : CharacterTraitBase, IComparable<T>
        {
            //TODO возможно не будет работать с характерами
            var compare = traitToCompare1.CompareTo(traitToCompare2);
            if (compare == 1)
                return -valueHandler.CharacterValue;
            return default;
        }

        protected static float NegativeValIfMatch<T, TBase>
            (CharacterTraitBase valueHandler, TBase traitToMatch)
            where T : TBase
            where TBase : CharacterTraitBase
        {
            //TODO возможно не будет работать с характерами
            if (traitToMatch is T)
                return -valueHandler.CharacterValue;
            return default;
        }

        protected static float NegativeValIfMore<T1>
            (CharacterTraitBase valueHandler, T1 traitToCompare1, T1 traitToCompare2)
                   where T1 : CharacterTraitBase, IComparable<T1>
        {
            //TODO возможно не будет работать с характерами
            var compare = traitToCompare1.CompareTo(traitToCompare2);
            if (compare == -1)
                return -valueHandler.CharacterValue;
            return default;
        }

        protected static float PositiveValIfLess<T1>
            (CharacterTraitBase valueHandler, T1 traitToCompare1, T1 traitToCompare2)
                   where T1 : CharacterTraitBase, IComparable<T1>
        {
            //TODO возможно не будет работать с характерами
            var compare = traitToCompare1.CompareTo(traitToCompare2);
            if (compare == 1)
                return valueHandler.CharacterValue;
            return default;
        }

        protected static float PositiveValIfLessElseNegative<T1>
                                            (CharacterTraitBase valueHandler, T1 traitToCompare1, T1 traitToCompare2)
                   where T1 : CharacterTraitBase, IComparable<T1>
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
        protected static float PositiveValIfLessNegativeIfMore<T>
            (CharacterTraitBase valueHandler, T traitToCompare1, T traitToCompare2)
                   where T : CharacterTraitBase, IComparable<T>
        {
            //TODO возможно не будет работать с характерами
            var compare = traitToCompare1.CompareTo(traitToCompare2);
            if (compare == 1)
                return valueHandler.CharacterValue;
            if (compare == -1)
                return -valueHandler.CharacterValue;
            return default;
        }

        protected static float PositiveValIfLessOrEqual<T>
                    (CharacterTraitBase valueHandler, T traitToCompare1, T traitToCompare2)
                   where T : CharacterTraitBase, IComparable<T>
        {
            //TODO возможно не будет работать с характерами
            var compare = traitToCompare1.CompareTo(traitToCompare2);
            if (compare == 1 || compare == 0)
                return valueHandler.CharacterValue;
            return default;
        }

        protected static float PositiveValIfLessOrEqualElseNegative<T1>
            (CharacterTraitBase valueHandler, T1 traitToCompare1, T1 traitToCompare2)
                   where T1 : CharacterTraitBase, IComparable<T1>
        {
            //TODO возможно не будет работать с характерами
            var compare = traitToCompare1.CompareTo(traitToCompare2);
            if (compare == 1 || compare == 0)
                return valueHandler.CharacterValue;
            else
                return -valueHandler.CharacterValue;
        }

        protected static float PositiveValIfMatch<T, TBase>
            (CharacterTraitBase valueHandler, TBase traitToMatch)
            where T : TBase
            where TBase : CharacterTraitBase
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
        protected static float PositiveValIfMatchElseNegative<T1, TBase>(CharacterTraitBase valueHandler, TBase traitToCompare)
            where T1 : TBase
            where TBase : CharacterTraitBase
        {
            if (traitToCompare is T1)
                return valueHandler.CharacterValue;
            else
                return -valueHandler.CharacterValue;
        }

        protected static float PositiveValIfMatchNegativeIfMore<TMatch, TCompare>(CharacterTraitBase valueHandler, TCompare traitToMatchOrCompare, TCompare traitToCompare)
                   where TCompare : CharacterTraitBase, IComparable<TCompare>
        {
            if (traitToMatchOrCompare is TMatch)
                return valueHandler.CharacterValue;
            var compare = traitToMatchOrCompare.CompareTo(traitToCompare);
            if (compare == -1)
                return -valueHandler.CharacterValue;
            return default;
        }

        protected static float PositiveValIfMatchT1NegativeIfMatchT2<T1, T2, TBase>
                   (CharacterTraitBase valueHandler, TBase traitToCheck)
            where T1 : TBase
            where T2 : TBase
            where TBase : CharacterTraitBase
        {
            //TODO возможно не будет работать с характерами
            if (traitToCheck is T1)
                return valueHandler.CharacterValue;
            else if (traitToCheck is T2)
                return -valueHandler.CharacterValue;
            return default;
        }

        protected static float PositiveValIfMoreOrEqual<T1>
                                                    (CharacterTraitBase valueHandler, T1 traitToCompare1, T1 traitToCompare2)
                   where T1 : CharacterTraitBase, IComparable<T1>
        {
            //TODO возможно не будет работать с характерами
            var compare = traitToCompare1.CompareTo(traitToCompare2);
            if (compare == -1 || compare == 0)
                return valueHandler.CharacterValue;
            return default;
        }

        protected static float PositiveValIfMoreOrEqualElseNegative<T>
                                           (CharacterTraitBase valueHandler, T traitToCompare1, T traitToCompare2)
                   where T : CharacterTraitBase, IComparable<T>
        {
            //TODO возможно не будет работать с характерами
            var compare = traitToCompare1.CompareTo(traitToCompare2);
            if (compare == 1 || compare == 0)
                return valueHandler.CharacterValue;
            else
                return -valueHandler.CharacterValue;
        }

        public virtual float GetImportanceValueFor(HighSuspicion highSuspicion) => default;

        #endregion influenceChecks

        /// <summary>
        /// Является ли черта <paramref name="trait"/> у SecondAgent известной для ThisAgent?
        /// </summary>
        /// <param name="trait"></param>
        /// <returns></returns>
        protected bool KnownCharacterTrait<T>() where T : CharacterTraitBase
        {
            foreach (var ct in KnownCharacterTraits)
            {
                if (ct is T)
                    return true;
            }
            return false;
        }

        protected int MatchFeaturesCount<T>() where T : FeatureBase
        {
            int counter = 0;
            foreach (var f in KnownFeatures)
            {
                if (f is T)
                    counter++;
            }
            return counter;
        }

        public List<CharacterTraitBase> KnownCharacterTraits { get; }

        public List<FeatureBase> KnownFeatures { get; }

        public AgentBase SecondAgent { get; }

        public AgentBase ThisAgent { get; }

        public virtual float GetImportanceValueFor(HighAnxiety highAnxiety) => default;

        public virtual float GetImportanceValueFor(MiddleRadicalism middleRadicalism) => default;

        public virtual float GetImportanceValueFor(LowRadicalism lowRadicalism) => default;

        /// <summary>
        /// Влияние <paramref name="highRadicalism"/> на <paramref name="SecondAgent"/> при типе отношений.
        /// </summary>
        /// <param name="highRadicalism"></param>
        /// <returns></returns>
        public virtual float GetImportanceValueFor(HighRadicalism highRadicalism) => default;

        public virtual bool HasImportanceFor(HighSuspicion highSuspicion) => default;//сделать abstract после компиляции

        public virtual bool HasImportanceFor(HighAnxiety highAnxiety) => default;//сделать abstract после компиляции

        public abstract bool HasImportanceFor(MiddleRadicalism middleRadicalism);

        /// <summary>
        /// Если при переопределении возвращает true, нужно оверрайдить GetImportanceValueFor.
        /// Имеет ли влияние <paramref name="SecondAgent"/> для <paramref name="highRadicalism"/> при this типе отношений?
        /// </summary>
        /// <param name="highRadicalism"></param>
        /// <param name="ab"></param>
        /// <returns></returns>
        public abstract bool HasImportanceFor(LowRadicalism lowRadicalism);

        /// <summary>
        /// Если при переопределении возвращает true, нужно оверрайдить GetImportanceValueFor.
        /// Имеет ли влияние <paramref name="SecondAgent"/> для <paramref name="highRadicalism"/> при this типе отношений?
        /// </summary>
        /// <param name="highRadicalism"></param>
        /// <param name="ab"></param>
        /// <returns></returns>
        public abstract bool HasImportanceFor(HighRadicalism highRadicalism);
    }
}