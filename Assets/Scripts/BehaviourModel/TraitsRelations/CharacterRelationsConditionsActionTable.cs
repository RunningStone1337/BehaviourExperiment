using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public enum CharTraitType {
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
   
    public enum AddIfKnown {
        NegativeIfLess,
        NegativeIfLessElsePositive,
        NegativeIfLessOrEqual,
        NegativeIfLessOrEqualElsePositive,
        NegativeIfMatch,
        NegativeIfMore,
        NegativeIfMoreElsePositive,
        NegativeIfMoreOrEqual,
        NegativeIfMoreOrEqualElsePositive,
        NegativeIfNonEqual,
        NegativeIfNonEqualElsePositive,
        PositiveIfEquals,
        PositiveIfEqualsElseNeg,
        PositiveIfLess,
        PositiveIfLessElseNeg,
        PositiveIfLessNegativeIfMore,
        PositiveIfLessOrEqual,
        PositiveIfLessOrEqualElseNeg,
        PositiveIfMatch,
        PositiveIfMatchElseNegative,
        PositiveIfMatchNegativeIfMore,
        PositiveIfMatchT1NegativeIfMatchT2,
        PositiveIfMore,
        PositiveIfMoreElseNegative,
        PositiveIfMoreOrEqual,
        PositiveIfMoreOrEqualElseNeg
    }

    [CreateAssetMenu(menuName = "RelationshipTables/CharacterConditionsTable", fileName = "NewMatrix")]
    public class CharacterRelationsConditionsActionTable : CharacterConditionsActorTable<CharTraitType, AddIfKnown, CharTraitTypeExtended>
    {
        
    }
}