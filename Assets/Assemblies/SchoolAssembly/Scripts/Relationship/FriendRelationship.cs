using UnityEngine;

namespace BehaviourModel
{
    /// <summary>
    /// Друг - наивысшая степень доверия.
    /// </summary>
    public class FriendRelationship<TAgent, TOtherAgent, TState/*, TReaction, TFeature, TState, TSensor*/> 
        : FellowRelationship<TAgent, TOtherAgent, TState/*, TReaction, TFeature, TState, TSensor*/>
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
        //    if (KnownCharacterTrait<CredulitySuspicion>())
        //        res += PositiveValIfLessOrEqual(highClosenessSociability, cs.CredulitySuspicion, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += PositiveValIfMoreOrEqual(highClosenessSociability, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);
        //    if (KnownCharacterTrait<TimidityCourage>())
        //        res += PositiveValIfMoreOrEqual(highClosenessSociability, cs.TimidityCourage, tcs.TimidityCourage);
        //    return res;
        //}
        //public override float GetImportanceValueFor(LowClosenessSociability highClosenessSociability)
        //{
        //    float res = default;
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += PositiveValIfLessOrEqual(highClosenessSociability, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += PositiveValIfMoreOrEqual(highClosenessSociability, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<ConformismNonconformism>())
        //        res += PositiveValIfMoreOrEqual(highClosenessSociability, cs.ConformismNonconformism, tcs.ConformismNonconformism);
        //    if (KnownCharacterTrait<CredulitySuspicion>())
        //        res += PositiveValIfLessOrEqual(highClosenessSociability, cs.CredulitySuspicion, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += PositiveValIfEquals(highClosenessSociability, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);
        //    if (KnownCharacterTrait<TimidityCourage>())
        //        res += PositiveValIfLessOrEqual(highClosenessSociability, cs.TimidityCourage, tcs.TimidityCourage);
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
        //        res += PositiveValIfEquals(highClosenessSociability, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<ConformismNonconformism>())
        //        res += PositiveValIfLessOrEqual(highClosenessSociability, cs.ConformismNonconformism, tcs.ConformismNonconformism);
        //    if (KnownCharacterTrait<CredulitySuspicion>())
        //        res += PositiveValIfLessOrEqual(highClosenessSociability, cs.CredulitySuspicion, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += PositiveValIfMoreOrEqual(highClosenessSociability, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);
        //    if (KnownCharacterTrait<TimidityCourage>())
        //        res += PositiveValIfMoreOrEqual(highClosenessSociability, cs.TimidityCourage, tcs.TimidityCourage);
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
        //        res += PositiveValIfLessOrEqual(highAnxiety, cs.CalmnessAnxiety, tcs.CalmnessAnxiety);
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += PositiveValIfLessOrEqual(highAnxiety, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += PositiveValIfMoreOrEqualElseNeg(highAnxiety, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += PositiveValIfLessOrEqualElseNeg(highAnxiety, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += PositiveValIfLessOrEqual(highAnxiety, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<RigiditySensetivity>())
        //        res += PositiveValIfMoreOrEqual(highAnxiety, cs.RigiditySensetivity, tcs.RigiditySensetivity);
        //    if (KnownCharacterTrait<SubordinationDomination>())
        //        res += PositiveValIfLessOrEqualElseNeg(highAnxiety, cs.SubordinationDomination, tcs.SubordinationDomination);
        //    return res;
        //}
        //public override float GetImportanceValueFor(MiddleAnxiety midAnxiety)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<CalmnessAnxiety>())
        //        res += PositiveValIfEquals(midAnxiety, cs.CalmnessAnxiety, tcs.CalmnessAnxiety);
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += PositiveValIfMoreOrEqual(midAnxiety, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += PositiveValIfMoreOrEqual(midAnxiety, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += PositiveValIfLessOrEqual(midAnxiety, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += PositiveValIfEquals(midAnxiety, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<RigiditySensetivity>())
        //        res += PositiveValIfEquals(midAnxiety, cs.RigiditySensetivity, tcs.RigiditySensetivity);
        //    if (KnownCharacterTrait<SubordinationDomination>())
        //        res += PositiveValIfEqualsElseNeg(midAnxiety, cs.SubordinationDomination, tcs.SubordinationDomination);
        //    return res;
        //}
        //public override float GetImportanceValueFor(LowAnxiety lowAnxiety)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<CalmnessAnxiety>())
        //        res += PositiveValIfEquals(lowAnxiety, cs.CalmnessAnxiety, tcs.CalmnessAnxiety);
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += PositiveValIfEquals(lowAnxiety, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += PositiveValIfEquals(lowAnxiety, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += PositiveValIfEquals(lowAnxiety, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += PositiveValIfLess(lowAnxiety, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<RigiditySensetivity>())
        //        res += PositiveValIfLess(lowAnxiety, cs.RigiditySensetivity, tcs.RigiditySensetivity);
        //    if (KnownCharacterTrait<SubordinationDomination>())
        //        res += PositiveValIfLessOrEqual(lowAnxiety, cs.SubordinationDomination, tcs.SubordinationDomination);
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
        //        res += PositiveValIfEquals(highNonconformism, cs.ConformismNonconformism, tcs.ConformismNonconformism);
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += PositiveValIfLessOrEqual(highNonconformism, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += PositiveValIfMoreOrEqual(highNonconformism, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<Intelligence>())
        //        res += PositiveValIfMoreOrEqual(highNonconformism, cs.Intelligence, tcs.Intelligence);
        //    if (KnownCharacterTrait<NormativityOfBehaviour>())
        //        res += PositiveValIfMoreOrEqual(highNonconformism, cs.NormativityOfBehaviour, tcs.NormativityOfBehaviour);
        //    if (KnownCharacterTrait<PracticalityDreaminess>())
        //        res += PositiveValIfLessOrEqual(highNonconformism, cs.PracticalityDreaminess, tcs.PracticalityDreaminess);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += PositiveValIfMoreOrEqual(highNonconformism, cs.Selfcontrol, tcs.Selfcontrol);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += PositiveValIfEquals(highNonconformism, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);
        //    if (KnownCharacterTrait<SubordinationDomination>())
        //        res += PositiveValIfLessOrEqual(highNonconformism, cs.SubordinationDomination, tcs.SubordinationDomination);
        //    if (KnownCharacterTrait<TimidityCourage>())
        //        res += PositiveValIfMoreOrEqual(highNonconformism, cs.TimidityCourage, tcs.TimidityCourage);
        //    return res;
        //}
        //public override float GetImportanceValueFor(MiddleNonconformism midNonconformism)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<ConformismNonconformism>())
        //        res += PositiveValIfEquals(midNonconformism, cs.ConformismNonconformism, tcs.ConformismNonconformism);
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += PositiveValIfEquals(midNonconformism, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += PositiveValIfEquals(midNonconformism, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<Intelligence>())
        //        res += PositiveValIfMoreOrEqual(midNonconformism, cs.Intelligence, tcs.Intelligence);
        //    if (KnownCharacterTrait<NormativityOfBehaviour>())
        //        res += PositiveValIfMoreOrEqual(midNonconformism, cs.NormativityOfBehaviour, tcs.NormativityOfBehaviour);
        //    if (KnownCharacterTrait<PracticalityDreaminess>())
        //        res += PositiveValIfEquals(midNonconformism, cs.PracticalityDreaminess, tcs.PracticalityDreaminess);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += PositiveValIfMoreOrEqual(midNonconformism, cs.Selfcontrol, tcs.Selfcontrol);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += PositiveValIfEquals(midNonconformism, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);
        //    if (KnownCharacterTrait<SubordinationDomination>())
        //        res += PositiveValIfLessOrEqual(midNonconformism, cs.SubordinationDomination, tcs.SubordinationDomination);
        //    if (KnownCharacterTrait<TimidityCourage>())
        //        res += PositiveValIfMoreOrEqual(midNonconformism, cs.TimidityCourage, tcs.TimidityCourage);
        //    return res;
        //}
        //public override float GetImportanceValueFor(LowNonconformism lowNonconformism)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<ConformismNonconformism>())
        //        res += PositiveValIfEquals(lowNonconformism, cs.ConformismNonconformism, tcs.ConformismNonconformism);
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += PositiveValIfMoreOrEqual(lowNonconformism, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += PositiveValIfEquals(lowNonconformism, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<Intelligence>())
        //        res += PositiveValIfLessOrEqual(lowNonconformism, cs.Intelligence, tcs.Intelligence);
        //    if (KnownCharacterTrait<NormativityOfBehaviour>())
        //        res += PositiveValIfMoreOrEqual(lowNonconformism, cs.NormativityOfBehaviour, tcs.NormativityOfBehaviour);
        //    if (KnownCharacterTrait<PracticalityDreaminess>())
        //        res += PositiveValIfEquals(lowNonconformism, cs.PracticalityDreaminess, tcs.PracticalityDreaminess);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += PositiveValIfMoreOrEqual(lowNonconformism, cs.Selfcontrol, tcs.Selfcontrol);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += PositiveValIfMoreOrEqual(lowNonconformism, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);
        //    if (KnownCharacterTrait<SubordinationDomination>())
        //        res += PositiveValIfLessOrEqual(lowNonconformism, cs.SubordinationDomination, tcs.SubordinationDomination);
        //    if (KnownCharacterTrait<TimidityCourage>())
        //        res += PositiveValIfLessOrEqual(lowNonconformism, cs.TimidityCourage, tcs.TimidityCourage);
        //    return res;
        //}

        //#endregion

        //#region radicalism
        //public override float GetImportanceValueFor(HighRadicalism highRadicalism)
        //{
        //    float res = default;
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    //можем оценивать только известные черты характера!
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += PositiveValIfMoreOrEqualElseNeg(highRadicalism, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<ConformismNonconformism>())
        //        res += PositiveValIfMoreOrEqual(highRadicalism, cs.ConformismNonconformism, tcs.ConformismNonconformism);
        //    if (KnownCharacterTrait<TimidityCourage>())
        //        res += PositiveValIfMatchT1NegativeIfMatchT2<HighCourage, LowCourage, TimidityCourage>(highRadicalism, cs.TimidityCourage);
        //    //наличие обучающих увлечений - +
        //    int featuresCount = MatchFeaturesCount<EducationalActivityBase>();
        //    if (featuresCount > 0)
        //        res += featuresCount * highRadicalism.CharacterValue;
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
        //    if (KnownCharacterTrait<NormativityOfBehaviour>())
        //        res += PositiveValIfMatch<HighNormativityOfBehaviour, NormativityOfBehaviour>(lowRadicalism, scs.NormativityOfBehaviour);
        //    var cont = MatchFeaturesCount<PlayActivityBase>();
        //    cont += MatchFeaturesCount<CommunicationActivityBase>();
        //    cont += MatchFeaturesCount<PracticalActivityBase>();
        //    if (cont > 0)
        //        res += cont * lowRadicalism.CharacterValue;
        //    return res;
        //}

        //public override float GetImportanceValueFor(MiddleRadicalism midRadicalism)
        //{
        //    float res = default;
        //    var scs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    //можем оценивать только известные черты характера!
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += PositiveValIfMatch<MiddleRadicalism, ConservatismRadicalism>(midRadicalism, scs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<ConformismNonconformism>())
        //        res += PositiveValIfMatch<MiddleNonconformism, ConformismNonconformism>(midRadicalism, scs.ConformismNonconformism);
        //    if (KnownCharacterTrait<NormativityOfBehaviour>())
        //        res += PositiveValIfMatch<MiddleNormativityOfBehaviour, NormativityOfBehaviour>(midRadicalism, scs.NormativityOfBehaviour);
        //    var count = MatchFeaturesCount<ActivityFeatureBase>();
        //    if (count > 0)
        //        res += count * midRadicalism.CharacterValue;
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
        //        res += PositiveValIfLessOrEqualElseNeg(highSuspicion, cs.CredulitySuspicion, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<CalmnessAnxiety>())
        //        res += PositiveValIfLessOrEqual(highSuspicion, cs.CalmnessAnxiety, tcs.CalmnessAnxiety);
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += PositiveValIfLessOrEqual(highSuspicion, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += PositiveValIfEqualsElseNeg(highSuspicion, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += PositiveValIfEqualsElseNeg(highSuspicion, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += PositiveValIfLessOrEqual(highSuspicion, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<RigiditySensetivity>())
        //        res += PositiveValIfEquals(highSuspicion, cs.RigiditySensetivity, tcs.RigiditySensetivity);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += PositiveValIfMoreOrEqual(highSuspicion, cs.Selfcontrol, tcs.Selfcontrol);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += PositiveValIfEquals(highSuspicion, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);

        //    return res;
        //}
        //public override float GetImportanceValueFor(MiddleSuspicion midSuspicion)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<CredulitySuspicion>())
        //        res += PositiveValIfLessOrEqual(midSuspicion, cs.CredulitySuspicion, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<CalmnessAnxiety>())
        //        res += PositiveValIfLessOrEqual(midSuspicion, cs.CalmnessAnxiety, tcs.CalmnessAnxiety);
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += PositiveValIfEquals(midSuspicion, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += PositiveValIfEquals(midSuspicion, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += PositiveValIfEquals(midSuspicion, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += PositiveValIfLessOrEqual(midSuspicion, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<RigiditySensetivity>())
        //        res += PositiveValIfEqualsElseNeg(midSuspicion, cs.RigiditySensetivity, tcs.RigiditySensetivity);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += PositiveValIfEqualsElseNeg(midSuspicion, cs.Selfcontrol, tcs.Selfcontrol);
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
        //        res += PositiveValIfMoreOrEqual(lowSuspicion, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += PositiveValIfMoreOrEqual(lowSuspicion, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += PositiveValIfEquals(lowSuspicion, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
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
        //        res += PositiveValIfMoreOrEqual(highStab, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += PositiveValIfLessOrEqual(highStab, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<CredulitySuspicion>())
        //        res += PositiveValIfMoreOrEqual(highStab, cs.CredulitySuspicion, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<NormativityOfBehaviour>())
        //        res += PositiveValIfMoreOrEqual(highStab, cs.NormativityOfBehaviour, tcs.NormativityOfBehaviour);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += PositiveValIfEquals(highStab, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += PositiveValIfLessOrEqual(highStab, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<RigiditySensetivity>())
        //        res += PositiveValIfEquals(highStab, cs.RigiditySensetivity, tcs.RigiditySensetivity);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += PositiveValIfMoreOrEqual(highStab, cs.Selfcontrol, tcs.Selfcontrol);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += PositiveValIfEquals(highStab, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);

        //    return res;
        //}
        //public override float GetImportanceValueFor(MiddleEmotionalStability midStab)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += PositiveValIfMoreOrEqual(midStab, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += PositiveValIfLessOrEqual(midStab, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<CredulitySuspicion>())
        //        res += PositiveValIfEquals(midStab, cs.CredulitySuspicion, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<NormativityOfBehaviour>())
        //        res += PositiveValIfMoreOrEqual(midStab, cs.NormativityOfBehaviour, tcs.NormativityOfBehaviour);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += PositiveValIfEquals(midStab, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += PositiveValIfLessOrEqual(midStab, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<RigiditySensetivity>())
        //        res += PositiveValIfEquals(midStab, cs.RigiditySensetivity, tcs.RigiditySensetivity);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += PositiveValIfMoreOrEqual(midStab, cs.Selfcontrol, tcs.Selfcontrol);
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
        //        res += PositiveValIfLessOrEqual(lowStab, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += PositiveValIfMoreOrEqual(lowStab, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<CredulitySuspicion>())
        //        res += PositiveValIfLessOrEqualElseNeg(lowStab, cs.CredulitySuspicion, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<NormativityOfBehaviour>())
        //        res += PositiveValIfLessOrEqualElseNeg(lowStab, cs.NormativityOfBehaviour, tcs.NormativityOfBehaviour);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += PositiveValIfLessOrEqualElseNeg(lowStab, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += PositiveValIfMoreOrEqualElseNeg(lowStab, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<RigiditySensetivity>())
        //        res += PositiveValIfMoreOrEqualElseNeg(lowStab, cs.RigiditySensetivity, tcs.RigiditySensetivity);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += PositiveValIfLessOrEqualElseNeg(lowStab, cs.Selfcontrol, tcs.Selfcontrol);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += PositiveValIfLessOrEqualElseNeg(lowStab, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);

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
        //        res += PositiveValIfMoreOrEqual(hIntel, cs.Intelligence, tcs.Intelligence);
        //    if (KnownCharacterTrait<ConformismNonconformism>())
        //        res += PositiveValIfMoreOrEqual(hIntel, cs.ConformismNonconformism, tcs.ConformismNonconformism);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += PositiveValIfMoreOrEqual(hIntel, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += PositiveValIfMoreOrEqual(hIntel, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += PositiveValIfLessOrEqual(hIntel, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);

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
        //        res += PositiveValIfMoreOrEqual(mIntel, cs.ConformismNonconformism, tcs.ConformismNonconformism);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += PositiveValIfMoreOrEqual(mIntel, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += PositiveValIfMoreOrEqual(mIntel, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += PositiveValIfLessOrEqual(mIntel, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);

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
        //        res += PositiveValIfLessOrEqual(lIntel, cs.ConformismNonconformism, tcs.ConformismNonconformism);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += PositiveValIfLessOrEqual(lIntel, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += PositiveValIfEquals(lIntel, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += PositiveValIfMoreOrEqualElseNeg(lIntel, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
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
        //        res += PositiveValIfEquals(hNormativity, cs.PracticalityDreaminess, tcs.PracticalityDreaminess);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += PositiveValIfMoreOrEqual(hNormativity, cs.Selfcontrol, tcs.Selfcontrol);

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
        //        res += PositiveValIfEquals(mNormativity, cs.CalmnessAnxiety, tcs.CalmnessAnxiety);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += PositiveValIfMoreOrEqual(mNormativity, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += PositiveValIfEquals(mNormativity, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<PracticalityDreaminess>())
        //        res += PositiveValIfEquals(mNormativity, cs.PracticalityDreaminess, tcs.PracticalityDreaminess);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += PositiveValIfMoreOrEqual(mNormativity, cs.Selfcontrol, tcs.Selfcontrol);
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
        //        res += PositiveValIfMoreOrEqual(lNormativity, cs.PracticalityDreaminess, tcs.PracticalityDreaminess);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += PositiveValIfLessOrEqual(lNormativity, cs.Selfcontrol, tcs.Selfcontrol);
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
        //        res += PositiveValIfEqualsElseNeg(hDreamines, cs.PracticalityDreaminess, tcs.PracticalityDreaminess);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += PositiveValIfEquals(hDreamines, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<CredulitySuspicion>())
        //        res += PositiveValIfLessOrEqual(hDreamines, cs.CredulitySuspicion, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<Intelligence>())
        //        res += PositiveValIfEquals(hDreamines, cs.Intelligence, tcs.Intelligence);
        //    if (KnownCharacterTrait<RigiditySensetivity>())
        //        res += PositiveValIfMoreOrEqual(hDreamines, cs.RigiditySensetivity, tcs.RigiditySensetivity);
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
        //        res += PositiveValIfEquals(mDream, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<CredulitySuspicion>())
        //        res += PositiveValIfEquals(mDream, cs.CredulitySuspicion, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<Intelligence>())
        //        res += PositiveValIfMoreOrEqual(mDream, cs.Intelligence, tcs.Intelligence);
        //    if (KnownCharacterTrait<RigiditySensetivity>())
        //        res += PositiveValIfEquals(mDream, cs.RigiditySensetivity, tcs.RigiditySensetivity);
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
        //        res += PositiveValIfMoreOrEqual(lDream, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<CredulitySuspicion>())
        //        res += PositiveValIfEquals(lDream, cs.CredulitySuspicion, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<Intelligence>())
        //        res += PositiveValIfMoreOrEqual(lDream, cs.Intelligence, tcs.Intelligence);
        //    if (KnownCharacterTrait<RigiditySensetivity>())
        //        res += PositiveValIfEquals(lDream, cs.RigiditySensetivity, tcs.RigiditySensetivity);
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
        //        res += PositiveValIfEquals(hTension, cs.CalmnessAnxiety, tcs.CalmnessAnxiety);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += PositiveValIfMoreOrEqual(hTension, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<CredulitySuspicion>())
        //        res += PositiveValIfMoreOrEqual(hTension, cs.CredulitySuspicion, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += PositiveValIfMoreOrEqual(hTension, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += PositiveValIfEquals(hTension, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
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
        //        res += PositiveValIfMoreOrEqual(mTension, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += PositiveValIfLessOrEqual(mTension, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<SubordinationDomination>())
        //        res += PositiveValIfLessOrEqual(mTension, cs.SubordinationDomination, tcs.SubordinationDomination);
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
        //        res += PositiveValIfEquals(lTension, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<CalmnessAnxiety>())
        //        res += PositiveValIfEquals(lTension, cs.CalmnessAnxiety, tcs.CalmnessAnxiety);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += PositiveValIfEquals(lTension, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<CredulitySuspicion>())
        //        res += PositiveValIfEquals(lTension, cs.CredulitySuspicion, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += PositiveValIfEquals(lTension, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += PositiveValIfEquals(lTension, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<SubordinationDomination>())
        //        res += PositiveValIfEquals(lTension, cs.SubordinationDomination, tcs.SubordinationDomination);
        //    if (KnownCharacterTrait<TimidityCourage>())
        //        res += PositiveValIfEquals(lTension, cs.TimidityCourage, tcs.TimidityCourage);
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
        //        res += PositiveValIfEquals(heExpr, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<CalmnessAnxiety>())
        //        res += PositiveValIfEquals(heExpr, cs.CalmnessAnxiety, tcs.CalmnessAnxiety);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += PositiveValIfEqualsElseNeg(heExpr, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<NormativityOfBehaviour>())
        //        res += PositiveValIfLessOrEqualElseNeg(heExpr, cs.NormativityOfBehaviour, tcs.NormativityOfBehaviour);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += PositiveValIfMoreOrEqual(heExpr, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += PositiveValIfLessOrEqual(heExpr, cs.Selfcontrol, tcs.Selfcontrol);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += PositiveValIfLessOrEqual(heExpr, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);
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
        //        res += PositiveValIfMoreOrEqual(mExpr, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<NormativityOfBehaviour>())
        //        res += PositiveValIfMoreOrEqual(mExpr, cs.NormativityOfBehaviour, tcs.NormativityOfBehaviour);
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
        //        res += PositiveValIfMoreOrEqual(lExpr, cs.NormativityOfBehaviour, tcs.NormativityOfBehaviour);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += PositiveValIfEquals(lExpr, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += PositiveValIfEquals(lExpr, cs.Selfcontrol, tcs.Selfcontrol);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += PositiveValIfEquals(lExpr, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);
        //    return res;
        //}

        //#endregion
        public FriendRelationship(TAgent thisAgent, TOtherAgent secondAgent) 
            : base(thisAgent, secondAgent)
        {
            Debug.Log("New friend");
            //relationship = RelationshipType.Friend;
        }
        public override string ToString() => "Friend";


        static readonly float friendToFellow = -50f;
        protected override bool NeedTransitonToNewRelationship(float currentRelationshipValue, out RelationshipBase<TAgent, TOtherAgent, TState> newRelation)
        {
            newRelation = default;
            if (currentRelationshipValue <= friendToFellow)
            {
                newRelation = new FellowRelationship<TAgent, TOtherAgent, TState>(ThisAgent, SecondAgent);
                newRelation.CurrentRelationshipProgress = currentRelationshipValue - friendToFellow;
                return true;
            }
            return false;
        }
    }
}