using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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

    //[Serializable]
    public abstract class CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor> : MonoBehaviour
        where TAgent : ICurrentStateHandler<TState>
        where TReaction : IReaction
        where TFeature : IFeature
        where TState : IState 
        where TSensor : ISensor
    {
        [SerializeField] private int characterCalculatedValue;
        [SerializeField] [HideInInspector] private CharacterGrade characterGrade;
        [SerializeField] [Range(1, 10)] private int rawCharacterValue;
        [SerializeField] protected TAgent thisAgent;
        [SerializeField] [HideInInspector] private CharTraitTypeExtended thisConcreteCharType;
        [SerializeField] [HideInInspector] private CharTraitType thisCharType;
       
        public CharTraitType ThisCharType { get => thisCharType; protected set => thisCharType = value; }
        private CharacterGrade GetCharacterGrade(int rawCharacterValue)
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
            //if (characterValue < 4)
            //    return characterValue - 6;
            //else if (characterValue > 3 && characterValue < 8)
            //{
            //    if (characterValue == 4)
            //        return -1;
            //    if (characterValue == 5 || characterValue == 6)
            //        return 0;
            //    else
            //        return 1;
            //}
            //else if (characterValue > 7)
            //    return characterValue - 7;
            else throw new ArgumentOutOfRangeException($"{nameof(characterValue)} was out of range [1;10] with value {characterValue}");
        }

        /// <summary>
        /// ќжидаемые, т.е. приемлемые дл€ данной черты действи€, необ€зательно социально приемлемые
        /// </summary>
        /// <returns></returns>
        //public virtual List<ActionBase> GetExpectedActionsAtLesson()=>default;
        protected float GetRecognitionChanceForMiddle()
        {
            if (SpecializedCharacterValue == 1)
                return 0.4f;
            if (SpecializedCharacterValue == -1)
                return 0.7f;
            if (SpecializedCharacterValue == 0)
                return Random.Range(0f, 1f) >= 0.5f ? 0.5f : 0.6f;
            throw new Exception($"Ќеожиданное значение {nameof(SpecializedCharacterValue)} дл€ {ToString()}: {SpecializedCharacterValue}");
        }

        public CharacterGrade CharacterGrade { get => characterGrade; set => characterGrade = value; }
        public int RawCharacterValue { get => rawCharacterValue; private set => rawCharacterValue = Mathf.Clamp(value, 1, 10); }
        /// <summary>
        /// This trait calculated value. Be default can be in range [-5;5] (see)
        /// </summary>
        public int SpecializedCharacterValue { get => characterCalculatedValue; protected set => characterCalculatedValue = value; }

        public TAgent ThisAgent => thisAgent;

        public CharTraitTypeExtended ThisConcreteCharType { get => thisConcreteCharType; protected set => thisConcreteCharType = value; }

        /// <summary>
        /// A list of traits correlating with this trait, including this one.
        /// Redefine the method in the inheritors to define your own dependencies and use them for your own purposes.
        /// </summary>
        /// <param name="agent"></param>
        /// <returns></returns>
        public abstract List<CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>>
            GetCorrelatedTraitsForCharacter(AgentBase<TAgent, TReaction, TFeature, TState, TSensor> agent);


        #region operators overloading

        /// <summary>
        /// ”ниверсальна€ проверка сравнени€ двух черт характера
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
             where TBASE : CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>
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
                    where TBASE : CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>
        {
            return Char1LessChar2<TL, TM, TH, TBASE>(c1, c2) || c1.GetType().IsEquivalentTo(c2.GetType());
        }

        protected static bool Char1MoreChar2<TL, TM, TH, TBASE>(TBASE c1, TBASE c2)
                      where TL : TBASE
                     where TM : TBASE
                     where TH : TBASE
                     where TBASE : CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>
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
                    where TBASE : CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor>
        {
            return Char1MoreChar2<TL, TM, TH, TBASE>(c1, c2) || c1.GetType().IsEquivalentTo(c2.GetType());
        }

        #endregion operators overloading

        public virtual void Initiate(int characterValue, TAgent agent)
        {
            thisAgent = agent;
            RawCharacterValue = characterValue;
            CharacterGrade = GetCharacterGrade(RawCharacterValue);
            SpecializedCharacterValue = CalculateSpecializedValue(characterValue);
        }
    }
}