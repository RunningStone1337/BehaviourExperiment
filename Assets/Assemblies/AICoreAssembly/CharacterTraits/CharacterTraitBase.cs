using System;
using UnityEngine;

namespace BehaviourModel
{
    public enum CharacterGrade
    {
        Low,
        Middle,
        High
    }
    public enum CharTraitType
    {
        CalmnessAnxiety,
        ClosenessSociability,
        ConformismNonconformism,
        ConservatismRadicalism,
        CredulitySuspicion,
        EmotionalInstabilityStability,
        Intelligence,
        NormativityOfBehaviour,
        PracticalityDreaminess,
        RelaxationTension,
        RestraintExpressiveness,
        RigiditySensetivity,
        Selfcontrol,
        StraightforwardnessDiplomacy,
        SubordinationDomination,
        TimidityCourage
    }
    public enum CharTraitTypeExtended
    {
        LowCalmnessAnxiety,
        MidCalmnessAnxiety,
        HighCalmnessAnxiety,
        LowClosenessSociability,
        MidClosenessSociability,
        HighClosenessSociability,
        LowConformismNonconformism,
        MidConformismNonconformism,
        HighConformismNonconformism,
        LowConservatismRadicalism,
        MidConservatismRadicalism,
        HighConservatismRadicalism,
        LowCredulitySuspicion,
        MidCredulitySuspicion,
        HighCredulitySuspicion,
        LowEmotionalInstabilityStability,
        MidEmotionalInstabilityStability,
        HighEmotionalInstabilityStability,
        LowIntelligence,
        MidIntelligence,
        HighIntelligence,
        LowNormativityOfBehaviour,
        MidNormativityOfBehaviour,
        HighNormativityOfBehaviour,
        LowPracticalityDreaminess,
        MidPracticalityDreaminess,
        HighPracticalityDreaminess,
        LowRelaxationTension,
        MidRelaxationTension,
        HighRelaxationTension,
        LowRestraintExpressiveness,
        MidRestraintExpressiveness,
        HighRestraintExpressiveness,
        LowRigiditySensetivity,
        MidRigiditySensetivity,
        HighRigiditySensetivity,
        LowSelfcontrol,
        MidSelfcontrol,
        HighSelfcontrol,
        LowStraightforwardnessDiplomacy,
        MidStraightforwardnessDiplomacy,
        HighStraightforwardnessDiplomacy,
        LowSubordinationDomination,
        MidSubordinationDomination,
        HighSubordinationDomination,
        LowTimidityCourage,
        MidTimidityCourage,
        HighTimidityCourage
    }

    public abstract class CharacterTraitBase : MonoBehaviour, IUtilityCalculationSource
       
    {
        [SerializeField] private int characterCalculatedValue;
        [SerializeField] [HideInInspector] private CharacterGrade characterGrade;
        [SerializeField] [Range(1, 10)] private int rawCharacterValue;
        [SerializeField] protected IAgent thisAgent;
        [SerializeField] [HideInInspector] private CharTraitTypeExtended thisConcreteCharType;
        [SerializeField] [HideInInspector] private CharTraitType thisCharType;
       
        public CharTraitType ThisCharType { get => thisCharType; protected set => thisCharType = value; }
        private static CharacterGrade GetCharacterGrade(int rawCharacterValue)
        {
            if (rawCharacterValue > 0 && rawCharacterValue < 4)
                return CharacterGrade.Low;
            if (rawCharacterValue > 3 && rawCharacterValue < 8)
                return CharacterGrade.Middle;
            if (rawCharacterValue > 7 && rawCharacterValue < 11)
                return CharacterGrade.High;
            throw new Exception($"Unexpected value {rawCharacterValue}, approved value [1;10]");
        }

        /// <summary>
        /// Probably values:
        /// Low trait: -5:-3
        /// Middle trait: -2:2
        /// Strong trait: 3:5
        /// Override this method to set your own logic for defining a specialized value.
        /// You can use it in your implementation of balancing weights in a decision-making model
        /// (if they depend on the values of character traits).
        /// </summary>
        /// <param name="characterValue"></param>
        /// <returns></returns>
        protected virtual int CalculateSpecializedValue(int characterValue)
        {
            if (characterValue < 6)
                return characterValue - 6;
            if (characterValue > 5)
                return characterValue - 5;
            else throw new ArgumentOutOfRangeException($"{nameof(characterValue)} was out of range [1;10] with value {characterValue}");
        }

        public CharacterGrade CharacterGrade { get => characterGrade; set => characterGrade = value; }
        public int RawCharacterValue { get => rawCharacterValue; private set => rawCharacterValue = Mathf.Clamp(value, 1, 10); }
        
        /// <summary>
        /// This trait calculated value. Be default can be in range [-5;5]
        /// </summary>
        public int SpecializedCharacterValue { get => characterCalculatedValue; protected set => characterCalculatedValue = value; }

        public IAgent ThisAgent => thisAgent;

        public CharTraitTypeExtended ThisConcreteCharType { get => thisConcreteCharType; protected set => thisConcreteCharType = value; }

        #region operators overloading

        /// <summary>
        /// Универсальная проверка сравнения двух черт характера
        /// </summary>
        /// <typeparam name="TL"></typeparam>
        /// <typeparam name="TM"></typeparam>
        /// <typeparam name="TH"></typeparam>
        /// <typeparam name="TBASE"></typeparam>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        protected static bool Char1LessChar2<TL, TM, TH, TBASE>(TBASE c1, TBASE c2)
             where TL : TBASE
             where TM : TBASE
             where TH : TBASE
             where TBASE : CharacterTraitBase
        {
            var left = c1 is TL;
            var left2 = c2 is TL;
            if (left && !left2)
                return true;
            var mid = c1 is TM;
            if (mid && c2 is TH)
                return true;
            return false;
        }

        protected static bool Char1LessOrEqualChar2<TL, TM, TH, TBASE>(TBASE c1, TBASE c2)
                    where TL : TBASE
                    where TM : TBASE
                    where TH : TBASE
                    where TBASE : CharacterTraitBase
        {
            return Char1LessChar2<TL, TM, TH, TBASE>(c1, c2) || c1.GetType().IsEquivalentTo(c2.GetType());
        }

        protected static bool Char1MoreChar2<TL, TM, TH, TBASE>(TBASE c1, TBASE c2)
                      where TL : TBASE
                     where TM : TBASE
                     where TH : TBASE
                     where TBASE : CharacterTraitBase
        {
            var right = c1 is TH;
            var right2 = c2 is TH;
            if (right && !right2)
                return true;
            var mid = c1 is TM;
            if (mid && c2 is TL)
                return true;
            return false;
        }

        protected static bool Char1MoreOrEqualChar2<TL, TM, TH, TBASE>(TBASE c1, TBASE c2)
                    where TL : TBASE
                    where TM : TBASE
                    where TH : TBASE
                    where TBASE : CharacterTraitBase
        {
            return Char1MoreChar2<TL, TM, TH, TBASE>(c1, c2) || c1.GetType().IsEquivalentTo(c2.GetType());
        }

        #endregion operators overloading

        public virtual void Initiate(int rawCharacterValue, IAgent agent)
        {
            thisAgent = agent;
            RawCharacterValue = rawCharacterValue;
            CharacterGrade = GetCharacterGrade(RawCharacterValue);
            SpecializedCharacterValue = CalculateSpecializedValue(rawCharacterValue);
        }
    }
}