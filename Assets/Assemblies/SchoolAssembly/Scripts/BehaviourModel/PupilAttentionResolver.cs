using BuildingModule;
using Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class PupilAttentionResolver : 
        IImportanceInfluenceHandler<PupilAgent>, IImportanceInfluenceHandler<TeacherAgent>, IImportanceInfluenceHandler<PlacedInterier>
    {
        //[SerializeField] float attentionToNonFamiliarCoef;
        //[SerializeField] private List<ConditionActionPair<CharTraitType, AddIfKnown, CharTraitTypeExtended>> attentionToFamiliarConditions;
        //[SerializeField] private List<ConditionActionPair<CharTraitType, AddIfKnown, CharTraitTypeExtended>> attentionToFellowConditions;
        //[SerializeField] private List<ConditionActionPair<CharTraitType, AddIfKnown, CharTraitTypeExtended>> attentionToFriendConditions;
        //[SerializeField] private List<ConditionActionPair<CharTraitType, AddIfKnown, CharTraitTypeExtended>> attentionToFoeConditions;
        //[SerializeField] private List<ConditionActionPair<CharTraitType, AddIfKnown, CharTraitTypeExtended>> attentionToEnemyConditions;
      

        /// <summary>
        /// Возвращает важность для этой черты характера, которую
        /// вызывает <paramref name="ab"/> в данный момент с учётом обстоятельств.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        //protected float GetImportanceForAgent(PupilAgent ab)
        //{
        //    float res = default;
        //    //анализ уровня знакомства
        //    if (ThisTraitAgent.RelationsSystem.GetCurrentRelationTo<PupilAgent, FeatureBase>(ab) != null)
        //        res += CalculateImportanceForFamiliar(ab);
        //    else
        //        res += CalculateImportanceForStranger(ab);
        //    return res;
        //}
        //public abstract float GetApproximateAttentionFor(GlobalEvent currenEvent, CharacterToPhenomFloatRelationsTable charToEvents);

        //public abstract float GetApproximateAttentionFor(RelationshipBase relations, CharacterToPhenomFloatRelationsTable charToRelationship);
        protected float GetApproximateAttentionFor(GlobalEvent currenEvent, float[] vector)
        {
            ///источником теперь является табличка
            if (currenEvent is LessonEvent l)
                return vector[0];
            else if (currenEvent is BreakEvent b)
                return vector[1];
            else
                return vector[2];
        }
        //protected static float GetApproximateAttentionFor(RelationshipBase relations, float[] vectr)
        //{
        //    ///источником теперь является табличка
        //    /* if (relations is PoorKnownRelation p)
        //         return vectr[0];
        //     else*/
        //    if (relations is FamiliarRelationship f)
        //        return vectr[1];
        //    else if (relations is FellowRelationship fe)
        //        return vectr[2];
        //    else if (relations is ComradeRelationship co)
        //        return vectr[3];
        //    else if (relations is FriendRelationship fr)
        //        return vectr[4];
        //    else if (relations is FoeRelationship fo)
        //        return vectr[5];
        //    else if (relations is EnemyRelationship en)
        //        return vectr[6];
        //    else throw new Exception($"Unexpected relatons type {relations}");
        //}
        /// <summary>
        /// Значение важности <paramref name="agent"/> для черты характера
        /// в зависимости от уровня знакомства с <paramref name="agent"/>.
        /// </summary>
        /// <param name="agent"></param>
        /// <returns></returns>
        //protected virtual float CalculateImportanceForFamiliar(PupilAgent agent)
        //{
        //    float res = default;
        //    var currentRelation = ThisTraitAgent.GetCurrentRelationTo<PupilAgent, FeatureBase>(agent);
        //    if (currentRelation != null)
        //    {
        //        var conditions = GetConditionForRelation(currentRelation);
        //        res += GetImportanceValueFor(conditions, currentRelation);
        //    }
        //    return res;
        //}
       
        //private float GetImportanceValueFor(List<ConditionActionPair<CharTraitType, AddIfKnown, CharTraitTypeExtended>> conditions, RelationshipBase currentRelation)
        //{
        //    float result = default;
        //    //var thisTrait = GetCharTrait(thisAgent, conditions.c)
        //    foreach (var c in conditions)
        //    {
        //        if (KnownCharTrait(currentRelation, c))
        //        {
        //            result += AddCondition(currentRelation, c);
        //        }

        //    }
        //    return result;
        //}

        //private float AddCondition(RelationshipBase currentRelation, ConditionActionPair<CharTraitType, AddIfKnown, CharTraitTypeExtended> condition)
        //{
        //    var tcs = currentRelation.ThisAgent.CharacterSystem;
        //    var cs = currentRelation.SecondAgent.CharacterSystem;
        //    switch (condition.Action)
        //    {
        //        case AddIfKnown.NegativeIfLess:
        //            //return RelationshipBase.NegativeValIfLess(this, cs, this);
        //            break;
        //        case AddIfKnown.NegativeIfLessElsePositive:
        //            break;
        //        case AddIfKnown.NegativeIfLessOrEqual:
        //            break;
        //        case AddIfKnown.NegativeIfLessOrEqualElsePositive:
        //            break;
        //        case AddIfKnown.NegativeIfMatch:
        //            break;
        //        case AddIfKnown.NegativeIfMore:
        //            break;
        //        case AddIfKnown.NegativeIfMoreElsePositive:
        //            break;
        //        case AddIfKnown.NegativeIfMoreOrEqual:
        //            break;
        //        case AddIfKnown.NegativeIfMoreOrEqualElsePositive:
        //            break;
        //        case AddIfKnown.NegativeIfNonEqual:
        //            break;
        //        case AddIfKnown.NegativeIfNonEqualElsePositive:
        //            break;
        //        case AddIfKnown.PositiveIfEquals:
        //            break;
        //        case AddIfKnown.PositiveIfEqualsElseNeg:
        //            break;
        //        case AddIfKnown.PositiveIfLess:
        //            break;
        //        case AddIfKnown.PositiveIfLessElseNeg:
        //            break;
        //        case AddIfKnown.PositiveIfLessNegativeIfMore:
        //            break;
        //        case AddIfKnown.PositiveIfLessOrEqual:
        //            break;
        //        case AddIfKnown.PositiveIfLessOrEqualElseNeg:
        //            break;
        //        case AddIfKnown.PositiveIfMatch:
        //            break;
        //        case AddIfKnown.PositiveIfMatchElseNegative:
        //            break;
        //        case AddIfKnown.PositiveIfMatchNegativeIfMore:
        //            break;
        //        case AddIfKnown.PositiveIfMatchT1NegativeIfMatchT2:
        //            break;
        //        case AddIfKnown.PositiveIfMore:
        //            break;
        //        case AddIfKnown.PositiveIfMoreElseNegative:
        //            break;
        //        case AddIfKnown.PositiveIfMoreOrEqual:
        //            break;
        //        case AddIfKnown.PositiveIfMoreOrEqualElseNeg:
        //            break;
        //        default:
        //            break;
        //    }
        //    return default;
        //}
        //private static bool KnownCharTrait(RelationshipBase currentRelation, ConditionActionPair<CharTraitType, AddIfKnown, CharTraitTypeExtended> c)
        //{
        //    bool knownCheck = default;
        //    //switch (c.Condition)
        //    //{
        //    //    case CharTraitType.CalmnessAnxiety:
        //    //        knownCheck = currentRelation.KnownCharacterTrait<CalmnessAnxiety>();
        //    //        break;
        //    //    case CharTraitType.ClosenessSociability:
        //    //        knownCheck = currentRelation.KnownCharacterTrait<ClosenessSociability>();
        //    //        break;
        //    //    case CharTraitType.ConformismNonconformism:
        //    //        knownCheck = currentRelation.KnownCharacterTrait<ConformismNonconformism>();
        //    //        break;
        //    //    case CharTraitType.ConservatismRadicalism:
        //    //        knownCheck = currentRelation.KnownCharacterTrait<ConservatismRadicalism>();
        //    //        break;
        //    //    case CharTraitType.CredulitySuspicion:
        //    //        knownCheck = currentRelation.KnownCharacterTrait<CredulitySuspicion>();
        //    //        break;
        //    //    case CharTraitType.EmotionalInstabilityStability:
        //    //        knownCheck = currentRelation.KnownCharacterTrait<EmotionalInstabilityStability>();
        //    //        break;
        //    //    case CharTraitType.Intelligence:
        //    //        knownCheck = currentRelation.KnownCharacterTrait<Intelligence>();
        //    //        break;
        //    //    case CharTraitType.NormativityOfBehaviour:
        //    //        knownCheck = currentRelation.KnownCharacterTrait<NormativityOfBehaviour>();
        //    //        break;
        //    //    case CharTraitType.PracticalityDreaminess:
        //    //        knownCheck = currentRelation.KnownCharacterTrait<PracticalityDreaminess>();
        //    //        break;
        //    //    case CharTraitType.RelaxationTension:
        //    //        knownCheck = currentRelation.KnownCharacterTrait<RelaxationTension>();
        //    //        break;
        //    //    case CharTraitType.RestraintExpressiveness:
        //    //        knownCheck = currentRelation.KnownCharacterTrait<RestraintExpressiveness>();
        //    //        break;
        //    //    case CharTraitType.RigiditySensetivity:
        //    //        knownCheck = currentRelation.KnownCharacterTrait<RigiditySensetivity>();
        //    //        break;
        //    //    case CharTraitType.Selfcontrol:
        //    //        knownCheck = currentRelation.KnownCharacterTrait<Selfcontrol>();
        //    //        break;
        //    //    case CharTraitType.StraightforwardnessDiplomacy:
        //    //        knownCheck = currentRelation.KnownCharacterTrait<StraightforwardnessDiplomacy>();
        //    //        break;
        //    //    case CharTraitType.SubordinationDomination:
        //    //        knownCheck = currentRelation.KnownCharacterTrait<SubordinationDomination>();
        //    //        break;
        //    //    case CharTraitType.TimidityCourage:
        //    //        knownCheck = currentRelation.KnownCharacterTrait<TimidityCourage>();
        //    //        break;
        //    //    default:
        //    //        break;
        //    //}
        //    return knownCheck;
        //}
        //private List<ConditionActionPair<CharTraitType, AddIfKnown, CharTraitTypeExtended>> GetConditionForRelation(RelationshipBase currentRelation)
        //{
        //    List<ConditionActionPair<CharTraitType, AddIfKnown, CharTraitTypeExtended>> condition;
        //    switch (currentRelation.RelationshipType)
        //    {
        //        case RelationshipType.Familiar:
        //            condition = attentionToFamiliarConditions;
        //            break;
        //        case RelationshipType.Fellow:
        //            condition = attentionToFellowConditions;
        //            break;
        //        case RelationshipType.Friend:
        //            condition = attentionToFriendConditions;
        //            break;
        //        case RelationshipType.Foe:
        //            condition = attentionToFoeConditions;
        //            break;
        //        case RelationshipType.Enemy:
        //            condition = attentionToEnemyConditions;
        //            break;
        //        default:
        //            condition = default;
        //            break;
        //    }
        //    return condition;
        //}
        //public override void Initiate(CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor> thisTrait)
        //{
        //    base.Initiate(thisTrait);
        //    //attentionToNonFamiliarCoef = GetVectorFromTable(ThisTraitAgent.CharacterToNonFamiliarAttentionTable);

        //    //attentionToFamiliarConditions = GetListFromTable(ThisTraitAgent.CharacterToFamiliarConditionsTable);
        //    //attentionToFellowConditions = GetListFromTable(ThisTraitAgent.CharacterToFellowConditionsTable);
        //    ////attentionToComradeConditions = GetListFromTable(p.CharacterToNonFamiliarAttentionTable);
        //    //attentionToFriendConditions = GetListFromTable(ThisTraitAgent.CharacterToFriendConditionsTable);
        //    //attentionToFoeConditions = GetListFromTable(ThisTraitAgent.CharacterToFoeConditionsTable);
        //    //attentionToEnemyConditions = GetListFromTable(ThisTraitAgent.CharacterToEnemyConditionsTable);
        //}
       
        protected float GetVectorFromTable(CharacterToPhenomFloatRelationsLists table)
        {
            return default;
        }

        /// <summary>
        /// Значение важности явления <paramref name="phenomenon"/> для данной черты характера.
        /// </summary>
        /// <param name="phenomenon"></param>
        /// <returns></returns>
        public float GetImportanceValueFor(PupilAgent phenomenon)
        {
            float res = default;
            ////анализ уровня знакомства
            //if (ThisTraitAgent.RelationsSystem.GetCurrentRelationTo<PupilAgent, FeatureBase>(phenomenon) != null)
            //    res += CalculateImportanceForFamiliar(phenomenon);
            //else
            //    res += CalculateImportanceForStranger(phenomenon);
            return res;
        }

        public float GetImportanceValueFor(TeacherAgent phenomenon) => default;//abstract после компиляции
        public float GetImportanceValueFor(IPhenomenon phenomenon)
        {
            if (phenomenon is PupilAgent p)
                return GetImportanceValueFor(p);
            if (phenomenon is TeacherAgent t)
                return GetImportanceValueFor(t);
            if (phenomenon is PlacedInterier i)
                return GetImportanceValueFor(i);
            return default;
        }
        public float GetImportanceValueFor(PlacedInterier phenomenon)
        {
            //var type = phenomenon.GetType();
            //if (ImportanceInfluencHandlersDict.ContainsKey(type))
            //    return ImportanceInfluencHandlersDict[type];
            return phenomenon.PhenomenonPower;
        }
    }
}
