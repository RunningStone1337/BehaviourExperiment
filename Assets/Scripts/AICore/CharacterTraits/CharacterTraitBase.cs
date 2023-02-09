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
    public abstract class CharacterTraitBase<TReaction, TFeature, TState> :
        MonoBehaviour
        where TReaction : IReaction
        where TFeature : IFeature
        where TState : IState
    {
        [SerializeField] private AttentionResolverBase attentionResolver;
        [SerializeField] private int characterCalculatedValue;
        [SerializeField] private CharacterGrade characterGrade;
        [SerializeField] [Range(1, 10)] private int rawCharacterValue;
        [SerializeField] private ReactionResolverBase reactionResolver;
        [SerializeField] private AgentBase<TReaction, TFeature, TState> thisAgent;
        [SerializeField] [HideInInspector] private CharTraitTypeExtended chisCharType;
        /// <summary>
        /// Ожидаемые, т.е. приемлемые для данной черты действия, необязательно социально приемлемые
        /// </summary>
        /// <returns></returns>
        //public virtual List<ActionBase> GetExpectedActionsAtLesson()=>default;

        /// <summary>
        /// Возможные значения характера:
        /// Слабый трейт: 1:3
        /// Средний трейт: -1:1
        /// Сильный трейт: 1:3
        /// </summary>
        /// <param name="characterValue"></param>
        /// <returns></returns>
        private int CalculateThisTraitValue(int characterValue)
        {
            if (characterValue < 4)
                return Mathf.Abs(characterValue - 4);
            else if (characterValue > 3 && characterValue < 8)
            {
                if (characterValue == 4)
                    return -1;
                if (characterValue == 5 || characterValue == 6)
                    return 0;
                else
                    return 1;
            }
            else if (characterValue > 7)
                return characterValue - 7;
            else throw new ArgumentOutOfRangeException($"{nameof(characterValue)} was out of range [1;10] with value {characterValue}");
        }

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
        /// Список "интересующих" данную черту черт личности <paramref name="agent"/>.
        /// Это черты, коррелирующие с данной и включающие оценивающую.
        /// </summary>
        /// <param name="agent"></param>
        /// <returns></returns>
        public abstract List<CharacterTraitBase<TReaction, TFeature, TState>>
            GetInterestedTraitsForCharacter(AgentBase<TReaction, TFeature, TState> agent);

        protected float GetRecognitionChanceForMiddle()
        {
            if (CharacterValue == 1)
                return 0.4f;
            if (CharacterValue == -1)
                return 0.7f;
            if (CharacterValue == 0)
                return Random.Range(0f, 1f) >= 0.5f ? 0.5f : 0.6f;
            throw new Exception($"Неожиданное значение {nameof(CharacterValue)} для {ToString()}: {CharacterValue}");
        }

        public CharacterGrade CharacterGrade { get => characterGrade; set => characterGrade = value; }
        /// <summary>
        /// Попробовать распознать "интересующие" черты <paramref name="agent"/> для данной черты характера.
        /// </summary>
        /// <param name="agent"></param>
        //protected void TryDiscoverAgentTraits(AgentBase agent)
        //{
        //    var potentialTraits = GetInterestedTraitsForCharacter(agent);
        //    var cs = agent.CharacterSystem;
        //    var selfControl = cs.Selfcontrol.RecognitionChance;
        //    var recognitionAbility = ThisAgent.CharacterSystem.RigiditySensetivity.RecognitionChance;
        //    if (selfControl - recognitionAbility > 0f)//восприятие выше скрытности - вероятность выше 0
        //    {
        //        var prob = recognitionAbility - selfControl;
        //        foreach (var tr in potentialTraits)
        //        {
        //            var random = Random.Range(0f, 1f);
        //            if (random <= prob)
        //            {
        //                //распознали - получаем новую информацию о человеке.
        //                //он ещё не знаком, но впечатление составлено.
        //                ThisAgent.RelationsSystem.AddInfoAbouAgentBase<IFeature>IfNew(agent, tr);
        //            }
        //        }
        //    }
        //}
        /// <summary>
        /// Специализированное значение
        /// </summary>
        public int CharacterValue { get => characterCalculatedValue; protected set => characterCalculatedValue = value; }

        public int RawCharacterValue { get => rawCharacterValue; private set => rawCharacterValue = Mathf.Clamp(value, 1, 10); }
        //protected Dictionary<Type, float> ImportanceInfluencHandlersDict { get; set; }
        public AgentBase<TReaction, TFeature, TState> ThisAgent => thisAgent;

        //public int PhenomenonPower { get => ((IPhenomenon)ThisAgent).PhenomenonPower; set => ((IPhenomenon)ThisAgent).PhenomenonPower = value; }

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
             where TBASE : CharacterTraitBase<TReaction, TFeature, TState>
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
                    where TBASE : CharacterTraitBase<TReaction, TFeature, TState>
        {
            return Char1LessChar2<TL, TM, TH, TBASE>(c1, c2) || c1.GetType().IsEquivalentTo(c2.GetType());
        }

        protected static bool Char1MoreChar2<TL, TM, TH, TBASE>(TBASE c1, TBASE c2)
                      where TL : TBASE
                     where TM : TBASE
                     where TH : TBASE
                     where TBASE : CharacterTraitBase<TReaction, TFeature, TState>
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
                    where TBASE : CharacterTraitBase<TReaction, TFeature, TState>
        {
            return Char1MoreChar2<TL, TM, TH, TBASE>(c1, c2) || c1.GetType().IsEquivalentTo(c2.GetType());
        }

        #endregion operators overloading

        public virtual void Initiate(int characterValue, AgentBase<TReaction, TFeature, TState> agent)

        {
            thisAgent = agent;
            RawCharacterValue = characterValue;
            CharacterGrade = GetCharacterGrade(RawCharacterValue);
            CharacterValue = CalculateThisTraitValue(characterValue);
            //if (attentionResolver == null)
            //    attentionResolver = gameObject.AddComponent<AttentionResolverBase>();
            //attentionResolver.Initiate(this);
            //if (reactionResolver == null)
            //    reactionResolver = gameObject.AddComponent<ReactionResolverBase>();
            //reactionResolver.Initiate(this);
        }

        //internal bool HasReactionOn<T>(T phenom, out List<IReaction> reaction) where T : IPhenomenon
        //{
        //    reaction = new List<IReaction>();
        //    return reactionResolver.HasReactionOn(phenom, out  reaction);
        //}
    }
}