using UnityEngine;

namespace BehaviourModel
{
    /// <summary>
    /// Приятель - первая стадия симпатии. "В принципе можно сотрудничать".
    /// </summary>
    public class FellowRelationship<TAgent, TOtherAgent, TState/*, TReaction, TFeature, TState, TSensor*/> 
        : PositiveRelationshipBase<TAgent, TOtherAgent, TState/*, TReaction, TFeature, TState, TSensor*/>
         where TAgent : ICurrentStateHandler<TState>
        where TOtherAgent : IAgent
        //where TReaction : IReaction
        //where TFeature : IFeature
        where TState : IState
        //where TSensor : ISensor
    {
        //#region social

        //public override float GetImportanceValueFor(HighClosenessSociability highClosenessSociability)
        //{
        //    float res = default;
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += PositiveValIfMoreOrEqual(highClosenessSociability, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += PositiveValIfMoreOrEqual(highClosenessSociability, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<ConformismNonconformism>())
        //        res += PositiveValIfLessOrEqual(highClosenessSociability, cs.ConformismNonconformism, tcs.ConformismNonconformism);

        //        res += PositiveValIfMatchT1NegativeIfMatchT2<LowSuspicion,HighSuspicion,CredulitySuspicion>(highClosenessSociability, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += PositiveValIfMoreOrEqual(highClosenessSociability, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);
        //    if (KnownCharacterTrait<TimidityCourage>())
        //        res += PositiveValIfMoreOrEqualElseNeg(highClosenessSociability, cs.TimidityCourage, tcs.TimidityCourage);
        //    return res;
        //}
        //public override float GetImportanceValueFor(LowClosenessSociability highClosenessSociability)
        //{
        //    float res = default;
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += NegativeValIfMore(highClosenessSociability, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += NegativeValIfMore(highClosenessSociability, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<ConformismNonconformism>())
        //        res += NegativeValIfNonEqual(highClosenessSociability, cs.ConformismNonconformism, tcs.ConformismNonconformism);

        //        res += NegativeValIfMatch<HighSuspicion,CredulitySuspicion>(highClosenessSociability, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += PositiveValIfMoreOrEqualElseNeg(highClosenessSociability, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);
        //    if (KnownCharacterTrait<TimidityCourage>())
        //        res += NegativeValIfMoreElsePositive(highClosenessSociability, cs.TimidityCourage, tcs.TimidityCourage);
        //    return res;
        //}
        //public override float GetImportanceValueFor(MiddleClosenessSociability highClosenessSociability)
        //{
        //    float res = default;
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += PositiveValIfMoreOrEqual(highClosenessSociability, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += PositiveValIfEqualsElseNeg(highClosenessSociability, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<ConformismNonconformism>())
        //        res += PositiveValIfLessOrEqualElseNeg(highClosenessSociability, cs.ConformismNonconformism, tcs.ConformismNonconformism);

        //        res += PositiveValIfMatchT1NegativeIfMatchT2<LowSuspicion,HighSuspicion,CredulitySuspicion>(highClosenessSociability,  tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += PositiveValIfMoreOrEqualElseNeg(highClosenessSociability, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);
        //    if (KnownCharacterTrait<TimidityCourage>())
        //        res += PositiveValIfEqualsElseNeg(highClosenessSociability, cs.TimidityCourage, tcs.TimidityCourage);
        //    return res;
        //}

        //#endregion

        //#region calmness
        //public override float GetImportanceValueFor(HighAnxiety highAnxiety)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<CalmnessAnxiety>())
        //        res += NegativeValIfMoreOrEqualElsePositive(highAnxiety, cs.CalmnessAnxiety, tcs.CalmnessAnxiety);
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += NegativeValIfMoreElsePositive(highAnxiety, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += NegativeValIfLess(highAnxiety, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += NegativeValIfNonEqual(highAnxiety, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += NegativeValIfMore(highAnxiety, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<RigiditySensetivity>())
        //        res += NegativeValIfNonEqualElsePositive(highAnxiety, cs.RigiditySensetivity, tcs.RigiditySensetivity);
        //    if (KnownCharacterTrait<SubordinationDomination>())
        //        res += NegativeValIfMore(highAnxiety, cs.SubordinationDomination, tcs.SubordinationDomination);
        //    return res;
        //}
        //public override float GetImportanceValueFor(MiddleAnxiety midAnxiety)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<CalmnessAnxiety>())
        //        res += NegativeValIfMoreElsePositive(midAnxiety, cs.CalmnessAnxiety, tcs.CalmnessAnxiety);
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += NegativeValIfMoreElsePositive(midAnxiety, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += PositiveValIfMoreElseNegative(midAnxiety, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += NegativeValIfMoreElsePositive(midAnxiety, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += NegativeValIfMoreElsePositive(midAnxiety, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<RigiditySensetivity>())
        //        res += PositiveValIfMore(midAnxiety, cs.RigiditySensetivity, tcs.RigiditySensetivity);
        //    if (KnownCharacterTrait<SubordinationDomination>())
        //        res += NegativeValIfMoreElsePositive(midAnxiety, cs.SubordinationDomination, tcs.SubordinationDomination);
        //    return res;
        //}
        //public override float GetImportanceValueFor(LowAnxiety lowAnxiety)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<CalmnessAnxiety>())
        //        res += PositiveValIfLessOrEqual(lowAnxiety, cs.CalmnessAnxiety, tcs.CalmnessAnxiety);
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += PositiveValIfEquals(lowAnxiety, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += PositiveValIfEqualsElseNeg(lowAnxiety, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += PositiveValIfEquals(lowAnxiety, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += PositiveValIfLessElseNeg(lowAnxiety, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<RigiditySensetivity>())
        //        res += PositiveValIfLess(lowAnxiety, cs.RigiditySensetivity, tcs.RigiditySensetivity);
        //    if (KnownCharacterTrait<SubordinationDomination>())
        //        res += PositiveValIfLessOrEqualElseNeg(lowAnxiety, cs.SubordinationDomination, tcs.SubordinationDomination);
        //    return res;
        //}

        //#endregion

        //#region nonconformism
        //public override float GetImportanceValueFor(HighNonconformism highNonconformism)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<ConformismNonconformism>())
        //        res += PositiveValIfEqualsElseNeg(highNonconformism, cs.ConformismNonconformism, tcs.ConformismNonconformism);
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += PositiveValIfLessOrEqualElseNeg(highNonconformism, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += PositiveValIfMoreOrEqualElseNeg(highNonconformism, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<Intelligence>())
        //        res += PositiveValIfMoreOrEqualElseNeg(highNonconformism, cs.Intelligence, tcs.Intelligence);
        //    if (KnownCharacterTrait<NormativityOfBehaviour>())
        //        res += PositiveValIfMoreOrEqualElseNeg(highNonconformism, cs.NormativityOfBehaviour, tcs.NormativityOfBehaviour);
        //    if (KnownCharacterTrait<PracticalityDreaminess>())
        //        res += PositiveValIfLessOrEqualElseNeg(highNonconformism, cs.PracticalityDreaminess, tcs.PracticalityDreaminess);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += PositiveValIfMoreOrEqualElseNeg(highNonconformism, cs.Selfcontrol, tcs.Selfcontrol);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += PositiveValIfEqualsElseNeg(highNonconformism, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);
        //    if (KnownCharacterTrait<SubordinationDomination>())
        //        res += PositiveValIfLessOrEqualElseNeg(highNonconformism, cs.SubordinationDomination, tcs.SubordinationDomination);
        //    if (KnownCharacterTrait<TimidityCourage>())
        //        res += PositiveValIfMoreOrEqualElseNeg(highNonconformism, cs.TimidityCourage, tcs.TimidityCourage);
        //    return res;
        //}
        //public override float GetImportanceValueFor(MiddleNonconformism midNonconformism)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<ConformismNonconformism>())
        //        res += PositiveValIfEqualsElseNeg(midNonconformism, cs.ConformismNonconformism, tcs.ConformismNonconformism);
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += PositiveValIfEqualsElseNeg(midNonconformism, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += PositiveValIfEqualsElseNeg(midNonconformism, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<Intelligence>())
        //        res += PositiveValIfMoreOrEqual(midNonconformism, cs.Intelligence, tcs.Intelligence);
        //    if (KnownCharacterTrait<NormativityOfBehaviour>())
        //        res += PositiveValIfMoreOrEqual(midNonconformism, cs.NormativityOfBehaviour, tcs.NormativityOfBehaviour);
        //    if (KnownCharacterTrait<PracticalityDreaminess>())
        //        res += PositiveValIfEquals(midNonconformism, cs.PracticalityDreaminess, tcs.PracticalityDreaminess);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += PositiveValIfMoreOrEqual(midNonconformism, cs.Selfcontrol, tcs.Selfcontrol);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += PositiveValIfEqualsElseNeg(midNonconformism, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);
        //    if (KnownCharacterTrait<SubordinationDomination>())
        //        res += PositiveValIfLessOrEqual(midNonconformism, cs.SubordinationDomination, tcs.SubordinationDomination);
        //    if (KnownCharacterTrait<TimidityCourage>())
        //        res += PositiveValIfMoreOrEqualElseNeg(midNonconformism, cs.TimidityCourage, tcs.TimidityCourage);
        //    return res;
        //}
        //public override float GetImportanceValueFor(LowNonconformism lowNonconformism)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<ConformismNonconformism>())
        //        res += PositiveValIfEqualsElseNeg(lowNonconformism, cs.ConformismNonconformism, tcs.ConformismNonconformism);
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += PositiveValIfMoreOrEqual(lowNonconformism, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += NegativeValIfLessElsePositive(lowNonconformism, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<Intelligence>())
        //        res += PositiveValIfLessOrEqualElseNeg(lowNonconformism, cs.Intelligence, tcs.Intelligence);
        //    if (KnownCharacterTrait<NormativityOfBehaviour>())
        //        res += PositiveValIfMoreOrEqualElseNeg(lowNonconformism, cs.NormativityOfBehaviour, tcs.NormativityOfBehaviour);
        //    if (KnownCharacterTrait<PracticalityDreaminess>())
        //        res += PositiveValIfEquals(lowNonconformism, cs.PracticalityDreaminess, tcs.PracticalityDreaminess);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += PositiveValIfMoreOrEqual(lowNonconformism, cs.Selfcontrol, tcs.Selfcontrol);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += PositiveValIfMoreOrEqualElseNeg(lowNonconformism, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);
        //    if (KnownCharacterTrait<SubordinationDomination>())
        //        res += PositiveValIfLessOrEqualElseNeg(lowNonconformism, cs.SubordinationDomination, tcs.SubordinationDomination);
        //    if (KnownCharacterTrait<TimidityCourage>())
        //        res += PositiveValIfLessOrEqualElseNeg(lowNonconformism, cs.TimidityCourage, tcs.TimidityCourage);
        //    return res;
        //}

        //#endregion

        //#region conservatism
        //public override float GetImportanceValueFor(HighRadicalism highRadicalism)
        //{
        //    float res = default;
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    //можем оценивать только известные черты характера!
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += PositiveValIfMoreOrEqual(highRadicalism, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<ConformismNonconformism>())
        //        res += PositiveValIfMoreOrEqual(highRadicalism, cs.ConformismNonconformism, tcs.ConformismNonconformism);
        //    if (KnownCharacterTrait<Intelligence>())
        //        res += PositiveValIfMoreOrEqualElseNeg(highRadicalism, cs.Intelligence, tcs.Intelligence);
        //    if (KnownCharacterTrait<NormativityOfBehaviour>())
        //        res += NegativeValIfMatch<HighNormativityOfBehaviour, NormativityOfBehaviour>(highRadicalism, cs.NormativityOfBehaviour);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += PositiveValIfMatchT1NegativeIfMatchT2<LowDiplomacy, HighDiplomacy, StraightforwardnessDiplomacy>(highRadicalism, cs.StraightforwardnessDiplomacy);
        //    if (KnownCharacterTrait<TimidityCourage>())
        //        res += PositiveValIfMatch<HighCourage, TimidityCourage>(highRadicalism, cs.TimidityCourage);
        //    return res;
        //}

        //public override float GetImportanceValueFor(LowRadicalism lowRadicalism)
        //{
        //    float res = default;
        //    var scs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    //можем оценивать только известные черты характера!
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += PositiveValIfMatchNegativeIfMore<LowRadicalism, ConservatismRadicalism>(lowRadicalism, scs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<ConformismNonconformism>())
        //        res += PositiveValIfLess(lowRadicalism, scs.ConformismNonconformism, tcs.ConformismNonconformism);
        //    if (KnownCharacterTrait<Intelligence>())
        //        res += PositiveValIfLessOrEqual(lowRadicalism, scs.Intelligence, tcs.Intelligence);
        //    if (KnownCharacterTrait<NormativityOfBehaviour>())
        //        res += PositiveValIfMatchT1NegativeIfMatchT2<HighNormativityOfBehaviour, LowNormativityOfBehaviour, NormativityOfBehaviour>(lowRadicalism, scs.NormativityOfBehaviour);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += PositiveValIfMatchT1NegativeIfMatchT2<HighDiplomacy, LowDiplomacy, StraightforwardnessDiplomacy>(lowRadicalism, scs.StraightforwardnessDiplomacy);
        //    return res;
        //}

        //public override float GetImportanceValueFor(MiddleRadicalism midRadicalism)
        //{
        //    float res = default;
        //    var scs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    //можем оценивать только известные черты характера!
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //    {
        //        //уровень радикализма == - ++
        //        if (scs.ConservatismRadicalism is MiddleRadicalism)
        //            res += midRadicalism.CharacterValue;
        //        else
        //            res -= midRadicalism.CharacterValue;
        //    }
        //    if (KnownCharacterTrait<ConformismNonconformism>())
        //    {
        //        //уровень нонконформизма ниже чем у меня - +
        //        if (scs.ConformismNonconformism is MiddleNonconformism)
        //            res += midRadicalism.CharacterValue;
        //        //уровень нонконформизма выше или ниже - -
        //        else
        //            res -= midRadicalism.CharacterValue;
        //    }
        //    if (KnownCharacterTrait<NormativityOfBehaviour>())
        //    {
        //        //совпадает нормативность - -
        //        if (scs.NormativityOfBehaviour is MiddleNormativityOfBehaviour)
        //            res += midRadicalism.CharacterValue;
        //        //высокая нормативность - +
        //        else if (scs.NormativityOfBehaviour < tcs.NormativityOfBehaviour)
        //            res -= midRadicalism.CharacterValue;
        //    }
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //    {
        //        //низкая дипломатичность - -
        //        if (scs.StraightforwardnessDiplomacy < tcs.StraightforwardnessDiplomacy)
        //            res -= midRadicalism.CharacterValue;
        //        //высокая дипломатичность - +
        //        else if (scs.StraightforwardnessDiplomacy >= tcs.StraightforwardnessDiplomacy)
        //            res += midRadicalism.CharacterValue;
        //    }
        //    return res;
        //}


        //#endregion

        //#region suspicion
        //public override float GetImportanceValueFor(HighSuspicion highSuspicion)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<CredulitySuspicion>())
        //        res += NegativeValIfMoreOrEqualElsePositive(highSuspicion, cs.CredulitySuspicion, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<CalmnessAnxiety>())
        //        res += NegativeValIfMoreElsePositive(highSuspicion, cs.CalmnessAnxiety, tcs.CalmnessAnxiety);
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += NegativeValIfMoreElsePositive(highSuspicion, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += NegativeValIfNonEqualElsePositive(highSuspicion, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += PositiveValIfMoreOrEqualElseNeg(highSuspicion, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += PositiveValIfLessOrEqualElseNeg(highSuspicion, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<RigiditySensetivity>())
        //        res += PositiveValIfEqualsElseNeg(highSuspicion, cs.RigiditySensetivity, tcs.RigiditySensetivity);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += PositiveValIfMoreOrEqualElseNeg(highSuspicion, cs.Selfcontrol, tcs.Selfcontrol);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += PositiveValIfEqualsElseNeg(highSuspicion, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);

        //    return res;
        //}
        //public override float GetImportanceValueFor(MiddleSuspicion midSuspicion)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<CredulitySuspicion>())
        //        res += NegativeValIfMoreElsePositive(midSuspicion, cs.CredulitySuspicion, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<CalmnessAnxiety>())
        //        res += NegativeValIfMoreElsePositive(midSuspicion, cs.CalmnessAnxiety, tcs.CalmnessAnxiety);
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += NegativeValIfMoreElsePositive(midSuspicion, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += NegativeValIfNonEqualElsePositive(midSuspicion, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += NegativeValIfNonEqualElsePositive(midSuspicion, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += PositiveValIfLessOrEqualElseNeg(midSuspicion, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<RigiditySensetivity>())
        //        res += PositiveValIfLessOrEqual(midSuspicion, cs.RigiditySensetivity, tcs.RigiditySensetivity);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += PositiveValIfMoreOrEqual(midSuspicion, cs.Selfcontrol, tcs.Selfcontrol);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += PositiveValIfMoreOrEqual(midSuspicion, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);

        //    return res;
        //}
        //public override float GetImportanceValueFor(LowSuspicion lowSuspicion)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<CredulitySuspicion>())
        //        res += PositiveValIfLessOrEqual(lowSuspicion, cs.CredulitySuspicion, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<CalmnessAnxiety>())
        //        res += PositiveValIfMoreOrEqual(lowSuspicion, cs.CalmnessAnxiety, tcs.CalmnessAnxiety);
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += PositiveValIfMoreOrEqual(lowSuspicion, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += PositiveValIfEquals(lowSuspicion, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += PositiveValIfMoreOrEqual(lowSuspicion, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += PositiveValIfLessOrEqual(lowSuspicion, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<RigiditySensetivity>())
        //        res += PositiveValIfMoreOrEqual(lowSuspicion, cs.RigiditySensetivity, tcs.RigiditySensetivity);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += PositiveValIfMoreOrEqual(lowSuspicion, cs.Selfcontrol, tcs.Selfcontrol);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += PositiveValIfMoreOrEqual(lowSuspicion, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);

        //    return res;
        //}


        //#endregion

        //#region emotional stability

        //public override float GetImportanceValueFor(HighEmotionalStability highStab)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += PositiveValIfMoreOrEqualElseNeg(highStab, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += PositiveValIfLessOrEqualElseNeg(highStab, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<CredulitySuspicion>())
        //        res += PositiveValIfMoreOrEqualElseNeg(highStab, cs.CredulitySuspicion, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<NormativityOfBehaviour>())
        //        res += PositiveValIfMoreOrEqualElseNeg(highStab, cs.NormativityOfBehaviour, tcs.NormativityOfBehaviour);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += PositiveValIfMoreOrEqualElseNeg(highStab, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += PositiveValIfLessOrEqualElseNeg(highStab, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<RigiditySensetivity>())
        //        res += PositiveValIfLessOrEqualElseNeg(highStab, cs.RigiditySensetivity, tcs.RigiditySensetivity);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += PositiveValIfMoreOrEqualElseNeg(highStab, cs.Selfcontrol, tcs.Selfcontrol);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += PositiveValIfEqualsElseNeg(highStab, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);

        //    return res;
        //}
        //public override float GetImportanceValueFor(MiddleEmotionalStability midStab)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += PositiveValIfEqualsElseNeg(midStab, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += PositiveValIfEquals(midStab, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<CredulitySuspicion>())
        //        res += PositiveValIfEquals(midStab, cs.CredulitySuspicion, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<NormativityOfBehaviour>())
        //        res += PositiveValIfEqualsElseNeg(midStab, cs.NormativityOfBehaviour, tcs.NormativityOfBehaviour);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += PositiveValIfEquals(midStab, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += PositiveValIfEqualsElseNeg(midStab, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<RigiditySensetivity>())
        //        res += PositiveValIfLessOrEqual(midStab, cs.RigiditySensetivity, tcs.RigiditySensetivity);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += PositiveValIfMoreOrEqualElseNeg(midStab, cs.Selfcontrol, tcs.Selfcontrol);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += PositiveValIfEquals(midStab, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);

        //    return res;
        //}
        //public override float GetImportanceValueFor(LowEmotionalStability lowStab)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += NegativeValIfNonEqual(lowStab, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += NegativeValIfNonEqualElsePositive(lowStab, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<CredulitySuspicion>())
        //        res += NegativeValIfMoreElsePositive(lowStab, cs.CredulitySuspicion, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<NormativityOfBehaviour>())
        //        res += NegativeValIfMoreElsePositive(lowStab, cs.NormativityOfBehaviour, tcs.NormativityOfBehaviour);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += NegativeValIfNonEqualElsePositive(lowStab, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += NegativeValIfLessElsePositive(lowStab, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<RigiditySensetivity>())
        //        res += NegativeValIfLessElsePositive(lowStab, cs.RigiditySensetivity, tcs.RigiditySensetivity);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += NegativeValIfMoreElsePositive(lowStab, cs.Selfcontrol, tcs.Selfcontrol);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += NegativeValIfNonEqualElsePositive(lowStab, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);

        //    return res;
        //}

        //#endregion

        //#region intelligence

        //public override float GetImportanceValueFor(HighIntelligence hIntel)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<Intelligence>())
        //        res += PositiveValIfMoreOrEqualElseNeg(hIntel, cs.Intelligence, tcs.Intelligence);
        //    if (KnownCharacterTrait<ConformismNonconformism>())
        //        res += PositiveValIfMoreOrEqualElseNeg(hIntel, cs.ConformismNonconformism, tcs.ConformismNonconformism);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += PositiveValIfMoreOrEqualElseNeg(hIntel, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += PositiveValIfMoreOrEqualElseNeg(hIntel, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += PositiveValIfLessOrEqualElseNeg(hIntel, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);

        //    return res;
        //}
        //public override float GetImportanceValueFor(MiddleIntelligence mIntel)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<Intelligence>())
        //        res += PositiveValIfMoreOrEqualElseNeg(mIntel, cs.Intelligence, tcs.Intelligence);
        //    if (KnownCharacterTrait<ConformismNonconformism>())
        //        res += PositiveValIfMoreOrEqualElseNeg(mIntel, cs.ConformismNonconformism, tcs.ConformismNonconformism);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += PositiveValIfMoreOrEqualElseNeg(mIntel, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += PositiveValIfMoreOrEqualElseNeg(mIntel, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += PositiveValIfLessOrEqualElseNeg(mIntel, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);

        //    return res;
        //}
        //public override float GetImportanceValueFor(LowIntelligence lIntel)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<Intelligence>())
        //        res += PositiveValIfLessOrEqual(lIntel, cs.Intelligence, tcs.Intelligence);
        //    if (KnownCharacterTrait<ConformismNonconformism>())
        //        res += PositiveValIfLessOrEqualElseNeg(lIntel, cs.ConformismNonconformism, tcs.ConformismNonconformism);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += PositiveValIfLessOrEqualElseNeg(lIntel, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += PositiveValIfLessOrEqualElseNeg(lIntel, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += PositiveValIfLessOrEqualElseNeg(lIntel, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    return res;
        //}

        //#endregion

        //#region normativity of behaviour

        //public override float GetImportanceValueFor(HighNormativityOfBehaviour hNormativity)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<NormativityOfBehaviour>())
        //        res += PositiveValIfMoreOrEqualElseNeg(hNormativity, cs.NormativityOfBehaviour, tcs.NormativityOfBehaviour);
        //    if (KnownCharacterTrait<CalmnessAnxiety>())
        //        res += PositiveValIfLessOrEqual(hNormativity, cs.CalmnessAnxiety, tcs.CalmnessAnxiety);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += PositiveValIfMoreOrEqualElseNeg(hNormativity, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += PositiveValIfEquals(hNormativity, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<PracticalityDreaminess>())
        //        res += PositiveValIfEqualsElseNeg(hNormativity, cs.PracticalityDreaminess, tcs.PracticalityDreaminess);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += PositiveValIfMoreOrEqualElseNeg(hNormativity, cs.Selfcontrol, tcs.Selfcontrol);

        //    return res;
        //}
        //public override float GetImportanceValueFor(MiddleNormativityOfBehaviour mNormativity)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<NormativityOfBehaviour>())
        //        res += PositiveValIfEqualsElseNeg(mNormativity, cs.NormativityOfBehaviour, tcs.NormativityOfBehaviour);
        //    if (KnownCharacterTrait<CalmnessAnxiety>())
        //        res += PositiveValIfEqualsElseNeg(mNormativity, cs.CalmnessAnxiety, tcs.CalmnessAnxiety);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += PositiveValIfMoreOrEqualElseNeg(mNormativity, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += PositiveValIfEqualsElseNeg(mNormativity, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<PracticalityDreaminess>())
        //        res += PositiveValIfEqualsElseNeg(mNormativity, cs.PracticalityDreaminess, tcs.PracticalityDreaminess);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += PositiveValIfMoreOrEqualElseNeg(mNormativity, cs.Selfcontrol, tcs.Selfcontrol);
        //    return res;
        //}
        //public override float GetImportanceValueFor(LowNormativityOfBehaviour lNormativity)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<NormativityOfBehaviour>())
        //        res += PositiveValIfLessOrEqualElseNeg(lNormativity, cs.NormativityOfBehaviour, tcs.NormativityOfBehaviour);
        //    if (KnownCharacterTrait<CalmnessAnxiety>())
        //        res += PositiveValIfEquals(lNormativity, cs.CalmnessAnxiety, tcs.CalmnessAnxiety);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += PositiveValIfLessOrEqual(lNormativity, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += PositiveValIfLessOrEqual(lNormativity, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<PracticalityDreaminess>())
        //        res += PositiveValIfMoreOrEqualElseNeg(lNormativity, cs.PracticalityDreaminess, tcs.PracticalityDreaminess);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += PositiveValIfLessOrEqualElseNeg(lNormativity, cs.Selfcontrol, tcs.Selfcontrol);
        //    return res;
        //}

        //#endregion

        //#region dreaminess
        //public override float GetImportanceValueFor(HighDreaminess hDreamines)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<PracticalityDreaminess>())
        //        res += PositiveValIfMoreOrEqualElseNeg(hDreamines, cs.PracticalityDreaminess, tcs.PracticalityDreaminess);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += PositiveValIfEquals(hDreamines, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<CredulitySuspicion>())
        //        res += PositiveValIfLessOrEqualElseNeg(hDreamines, cs.CredulitySuspicion, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<Intelligence>())
        //        res += PositiveValIfEqualsElseNeg(hDreamines, cs.Intelligence, tcs.Intelligence);
        //    if (KnownCharacterTrait<RigiditySensetivity>())
        //        res += PositiveValIfMoreOrEqualElseNeg(hDreamines, cs.RigiditySensetivity, tcs.RigiditySensetivity);
        //    return res;
        //}
        //public override float GetImportanceValueFor(MiddleDreaminess mDream)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<PracticalityDreaminess>())
        //        res += PositiveValIfEqualsElseNeg(mDream, cs.PracticalityDreaminess, tcs.PracticalityDreaminess);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += PositiveValIfEqualsElseNeg(mDream, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<CredulitySuspicion>())
        //        res += PositiveValIfEquals(mDream, cs.CredulitySuspicion, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<Intelligence>())
        //        res += PositiveValIfMoreOrEqual(mDream, cs.Intelligence, tcs.Intelligence);
        //    if (KnownCharacterTrait<RigiditySensetivity>())
        //        res += PositiveValIfEqualsElseNeg(mDream, cs.RigiditySensetivity, tcs.RigiditySensetivity);
        //    return res;
        //}
        //public override float GetImportanceValueFor(LowDreaminess lDream)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<PracticalityDreaminess>())
        //        res += PositiveValIfEqualsElseNeg(lDream, cs.PracticalityDreaminess, tcs.PracticalityDreaminess);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += PositiveValIfEqualsElseNeg(lDream, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<CredulitySuspicion>())
        //        res += PositiveValIfEqualsElseNeg(lDream, cs.CredulitySuspicion, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<Intelligence>())
        //        res += PositiveValIfMoreOrEqualElseNeg(lDream, cs.Intelligence, tcs.Intelligence);
        //    if (KnownCharacterTrait<RigiditySensetivity>())
        //        res += PositiveValIfEqualsElseNeg(lDream, cs.RigiditySensetivity, tcs.RigiditySensetivity);
        //    return res;
        //}

        //#endregion

        //#region relaxation
        //public override float GetImportanceValueFor(HighTension hTension)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += PositiveValIfEqualsElseNeg(hTension, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<CalmnessAnxiety>())
        //        res += PositiveValIfEqualsElseNeg(hTension, cs.CalmnessAnxiety, tcs.CalmnessAnxiety);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += PositiveValIfMoreOrEqualElseNeg(hTension, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<CredulitySuspicion>())
        //        res += PositiveValIfMoreOrEqualElseNeg(hTension, cs.CredulitySuspicion, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += PositiveValIfMoreOrEqualElseNeg(hTension, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += PositiveValIfEqualsElseNeg(hTension, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<SubordinationDomination>())
        //        res += PositiveValIfLessOrEqualElseNeg(hTension, cs.SubordinationDomination, tcs.SubordinationDomination);
        //    if (KnownCharacterTrait<TimidityCourage>())
        //        res += PositiveValIfMoreOrEqualElseNeg(hTension, cs.TimidityCourage, tcs.TimidityCourage);
        //    return res;
        //}
        //public override float GetImportanceValueFor(MiddleTension mTension)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += PositiveValIfEqualsElseNeg(mTension, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<CalmnessAnxiety>())
        //        res += PositiveValIfLessOrEqual(mTension, cs.CalmnessAnxiety, tcs.CalmnessAnxiety);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += PositiveValIfEqualsElseNeg(mTension, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<CredulitySuspicion>())
        //        res += PositiveValIfEqualsElseNeg(mTension, cs.CredulitySuspicion, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += PositiveValIfMoreOrEqualElseNeg(mTension, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += PositiveValIfLessOrEqual(mTension, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<SubordinationDomination>())
        //        res += PositiveValIfLessOrEqualElseNeg(mTension, cs.SubordinationDomination, tcs.SubordinationDomination);
        //    if (KnownCharacterTrait<TimidityCourage>())
        //        res += PositiveValIfEquals(mTension, cs.TimidityCourage, tcs.TimidityCourage);
        //    return res;
        //}
        //public override float GetImportanceValueFor(LowTension lTension)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += PositiveValIfEqualsElseNeg(lTension, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<CalmnessAnxiety>())
        //        res += PositiveValIfLessOrEqualElseNeg(lTension, cs.CalmnessAnxiety, tcs.CalmnessAnxiety);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += PositiveValIfEquals(lTension, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<CredulitySuspicion>())
        //        res += PositiveValIfEquals(lTension, cs.CredulitySuspicion, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += PositiveValIfMoreOrEqual(lTension, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += PositiveValIfLessOrEqual(lTension, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<SubordinationDomination>())
        //        res += PositiveValIfLessElseNeg(lTension, cs.SubordinationDomination, tcs.SubordinationDomination);
        //    if (KnownCharacterTrait<TimidityCourage>())
        //        res += PositiveValIfLessOrEqual(lTension, cs.TimidityCourage, tcs.TimidityCourage);
        //    return res;
        //}

        //#endregion

        //#region expressivenes
        //public override float GetImportanceValueFor(HighExpressiveness heExpr)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += PositiveValIfEqualsElseNeg(heExpr, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<CalmnessAnxiety>())
        //        res += PositiveValIfEqualsElseNeg(heExpr, cs.CalmnessAnxiety, tcs.CalmnessAnxiety);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += PositiveValIfEqualsElseNeg(heExpr, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<NormativityOfBehaviour>())
        //        res += PositiveValIfLessOrEqualElseNeg(heExpr, cs.NormativityOfBehaviour, tcs.NormativityOfBehaviour);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += PositiveValIfMoreOrEqualElseNeg(heExpr, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += PositiveValIfLessOrEqualElseNeg(heExpr, cs.Selfcontrol, tcs.Selfcontrol);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += PositiveValIfLessOrEqualElseNeg(heExpr, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);
        //    return res;
        //}
        //public override float GetImportanceValueFor(MiddleExpressiveness mExpr)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += PositiveValIfLessOrEqualElseNeg(mExpr, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<CalmnessAnxiety>())
        //        res += PositiveValIfLessOrEqualElseNeg(mExpr, cs.CalmnessAnxiety, tcs.CalmnessAnxiety);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += PositiveValIfMoreOrEqualElseNeg(mExpr, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<NormativityOfBehaviour>())
        //        res += PositiveValIfMoreOrEqualElseNeg(mExpr, cs.NormativityOfBehaviour, tcs.NormativityOfBehaviour);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += PositiveValIfEquals(mExpr, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += PositiveValIfEquals(mExpr, cs.Selfcontrol, tcs.Selfcontrol);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += PositiveValIfEquals(mExpr, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);
        //    return res;
        //}
        //public override float GetImportanceValueFor(LowExpressiveness lExpr)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += PositiveValIfLessElseNeg(lExpr, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<CalmnessAnxiety>())
        //        res += PositiveValIfLessOrEqualElseNeg(lExpr, cs.CalmnessAnxiety, tcs.CalmnessAnxiety);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += PositiveValIfMoreOrEqualElseNeg(lExpr, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<NormativityOfBehaviour>())
        //        res += PositiveValIfMoreOrEqualElseNeg(lExpr, cs.NormativityOfBehaviour, tcs.NormativityOfBehaviour);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += PositiveValIfEquals(lExpr, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += PositiveValIfEqualsElseNeg(lExpr, cs.Selfcontrol, tcs.Selfcontrol);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += PositiveValIfEquals(lExpr, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);
        //    return res;
        //}

        //#endregion

        public FellowRelationship(TAgent thisAgent, TOtherAgent secondAgent)
            : base(thisAgent, secondAgent)
        {
            Debug.Log("New fellow");
            //relationship = RelationshipType.Fellow;
        }
        public override string ToString() => "Fellow";

        static readonly float fellowToFriendBorder = 150f;
        static readonly float fellowToFoeBorder = -30f;
        protected override bool NeedTransitonToNewRelationship(float currentRelationshipValue, out RelationshipBase<TAgent, TOtherAgent, TState> newRelation)
        {
            newRelation = default;
            if (currentRelationshipValue >= fellowToFriendBorder)
            {
                newRelation = new FriendRelationship<TAgent, TOtherAgent, TState>(ThisAgent, SecondAgent);
                newRelation.CurrentRelationshipProgress = currentRelationshipValue - fellowToFriendBorder;
                return true;
            }
            else if (currentRelationshipValue <= fellowToFoeBorder)
            {
                newRelation = new FoeRelationship<TAgent, TOtherAgent, TState>(ThisAgent, SecondAgent);
                newRelation.CurrentRelationshipProgress = currentRelationshipValue - fellowToFriendBorder;
                return true;
            }
            return false;
        }
    }
}