namespace BehaviourModel
{
    /// <summary>
    /// Знакомый - недостаточно информации для точной классификации друг/враг/приятель/товарищь/неприятель.
    /// Здесь происходит первичная основная оценка значимости.
    /// </summary>
    public class FamiliarRelationship<TReaction, TFeature, TState> : RelationshipBase<TReaction, TFeature, TState>
        where TReaction : IReaction
        where TFeature : IFeature where TState : IState


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
        //        res += PositiveValIfMoreElseNegative(highClosenessSociability, cs.ConformismNonconformism, tcs.ConformismNonconformism);
        //    if (KnownCharacterTrait<CredulitySuspicion>())
        //        res += PositiveValIfMoreElseNegative(highClosenessSociability, cs.CredulitySuspicion, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += PositiveValIfEquals(highClosenessSociability, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);
        //    if (KnownCharacterTrait<TimidityCourage>())
        //        res += PositiveValIfLessOrEqualElseNeg(highClosenessSociability, cs.TimidityCourage, tcs.TimidityCourage);
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
        //        res += NegativeValIfLess(highClosenessSociability, cs.ConformismNonconformism, tcs.ConformismNonconformism);
        //    if (KnownCharacterTrait<CredulitySuspicion>())
        //        res += NegativeValIfMatch<HighSuspicion,CredulitySuspicion>(highClosenessSociability, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += PositiveValIfMoreOrEqualElseNeg(highClosenessSociability, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);
        //    if (KnownCharacterTrait<TimidityCourage>())
        //        res += NegativeValIfMore(highClosenessSociability, cs.TimidityCourage, tcs.TimidityCourage);
        //    return res;
        //}
        //public override float GetImportanceValueFor(MiddleClosenessSociability highClosenessSociability)
        //{
        //    float res = default;
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += PositiveValIfEquals(highClosenessSociability, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += PositiveValIfLessOrEqualElseNeg(highClosenessSociability, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<ConformismNonconformism>())
        //        res += PositiveValIfLessOrEqualElseNeg(highClosenessSociability, cs.ConformismNonconformism, tcs.ConformismNonconformism);

        //        res += PositiveValIfMatchT1NegativeIfMatchT2<LowSuspicion,HighSuspicion,CredulitySuspicion>(highClosenessSociability, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += PositiveValIfMoreOrEqualElseNeg(highClosenessSociability, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);
        //    if (KnownCharacterTrait<TimidityCourage>())
        //        res += PositiveValIfLessOrEqualElseNeg(highClosenessSociability, cs.TimidityCourage, tcs.TimidityCourage);
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
        //        res += NegativeValIfMoreOrEqual(highAnxiety, cs.CalmnessAnxiety, tcs.CalmnessAnxiety);
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += NegativeValIfMore(highAnxiety, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += NegativeValIfLess(highAnxiety, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += NegativeValIfMore(highAnxiety, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += NegativeValIfMore(highAnxiety, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<RigiditySensetivity>())
        //        res += NegativeValIfLess(highAnxiety, cs.RigiditySensetivity, tcs.RigiditySensetivity);
        //    if (KnownCharacterTrait<SubordinationDomination>())
        //        res += NegativeValIfMoreOrEqual(highAnxiety, cs.SubordinationDomination, tcs.SubordinationDomination);
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
        //        res += PositiveValIfMoreElseNegative(midAnxiety, cs.RigiditySensetivity, tcs.RigiditySensetivity);
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
        //        res += PositiveValIfEqualsElseNeg(lowAnxiety, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += PositiveValIfEqualsElseNeg(lowAnxiety, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += PositiveValIfEqualsElseNeg(lowAnxiety, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += PositiveValIfLessElseNeg(lowAnxiety, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<RigiditySensetivity>())
        //        res += PositiveValIfLessElseNeg(lowAnxiety, cs.RigiditySensetivity, tcs.RigiditySensetivity);
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
        //        res += NegativeValIfLessElsePositive(highNonconformism, cs.ConformismNonconformism, tcs.ConformismNonconformism);
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += NegativeValIfMoreElsePositive(highNonconformism, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += NegativeValIfLessElsePositive(highNonconformism, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<Intelligence>())
        //        res += NegativeValIfLessElsePositive(highNonconformism, cs.Intelligence, tcs.Intelligence);
        //    if (KnownCharacterTrait<NormativityOfBehaviour>())
        //        res += NegativeValIfNonEqualElsePositive(highNonconformism, cs.NormativityOfBehaviour, tcs.NormativityOfBehaviour);
        //    if (KnownCharacterTrait<PracticalityDreaminess>())
        //        res += NegativeValIfNonEqualElsePositive(highNonconformism, cs.PracticalityDreaminess, tcs.PracticalityDreaminess);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += NegativeValIfLessElsePositive(highNonconformism, cs.Selfcontrol, tcs.Selfcontrol);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += NegativeValIfNonEqualElsePositive(highNonconformism, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);
        //    if (KnownCharacterTrait<SubordinationDomination>())
        //        res += NegativeValIfLess(highNonconformism, cs.SubordinationDomination, tcs.SubordinationDomination);
        //    if (KnownCharacterTrait<TimidityCourage>())
        //        res += NegativeValIfNonEqualElsePositive(highNonconformism, cs.TimidityCourage, tcs.TimidityCourage);
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
        //        res += PositiveValIfMoreOrEqualElseNeg(midNonconformism, cs.Intelligence, tcs.Intelligence);
        //    if (KnownCharacterTrait<NormativityOfBehaviour>())
        //        res += PositiveValIfMoreOrEqualElseNeg(midNonconformism, cs.NormativityOfBehaviour, tcs.NormativityOfBehaviour);
        //    if (KnownCharacterTrait<PracticalityDreaminess>())
        //        res += PositiveValIfEqualsElseNeg(midNonconformism, cs.PracticalityDreaminess, tcs.PracticalityDreaminess);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += PositiveValIfMoreOrEqualElseNeg(midNonconformism, cs.Selfcontrol, tcs.Selfcontrol);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += PositiveValIfEqualsElseNeg(midNonconformism, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);
        //    if (KnownCharacterTrait<SubordinationDomination>())
        //        res += PositiveValIfLessOrEqualElseNeg(midNonconformism, cs.SubordinationDomination, tcs.SubordinationDomination);
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
        //        res += PositiveValIfMoreOrEqualElseNeg(lowNonconformism, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += PositiveValIfLessOrEqualElseNeg(lowNonconformism, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<Intelligence>())
        //        res += PositiveValIfLessOrEqualElseNeg(lowNonconformism, cs.Intelligence, tcs.Intelligence);
        //    if (KnownCharacterTrait<NormativityOfBehaviour>())
        //        res += PositiveValIfMoreOrEqualElseNeg(lowNonconformism, cs.NormativityOfBehaviour, tcs.NormativityOfBehaviour);
        //    if (KnownCharacterTrait<PracticalityDreaminess>())
        //        res += PositiveValIfEqualsElseNeg(lowNonconformism, cs.PracticalityDreaminess, tcs.PracticalityDreaminess);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += PositiveValIfMoreOrEqualElseNeg(lowNonconformism, cs.Selfcontrol, tcs.Selfcontrol);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += PositiveValIfEqualsElseNeg(lowNonconformism, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);
        //    if (KnownCharacterTrait<SubordinationDomination>())
        //        res += PositiveValIfLessOrEqualElseNeg(lowNonconformism, cs.SubordinationDomination, tcs.SubordinationDomination);
        //    if (KnownCharacterTrait<TimidityCourage>())
        //        res += PositiveValIfEquals(lowNonconformism, cs.TimidityCourage, tcs.TimidityCourage);
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
        //        res += PositiveValIfLessOrEqualElseNeg(highRadicalism, cs.ConservatismRadicalism, highRadicalism);
        //    if (KnownCharacterTrait<ConformismNonconformism>())
        //        res += PositiveValIfMoreOrEqualElseNeg(highRadicalism, cs.ConformismNonconformism, tcs.ConformismNonconformism);
        //    if (KnownCharacterTrait<Intelligence>())
        //        res += PositiveValIfMoreOrEqualElseNeg(highRadicalism, cs.Intelligence, tcs.Intelligence);
        //    if (KnownCharacterTrait<NormativityOfBehaviour>())
        //        res += PositiveValIfMatchT1NegativeIfMatchT2<LowNormativityOfBehaviour, HighNormativityOfBehaviour, NormativityOfBehaviour>(highRadicalism, cs.NormativityOfBehaviour);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += PositiveValIfMatchT1NegativeIfMatchT2<LowDiplomacy, HighDiplomacy, StraightforwardnessDiplomacy>(highRadicalism, cs.StraightforwardnessDiplomacy);
        //    if (KnownCharacterTrait<TimidityCourage>())
        //        res += PositiveValIfMatchT1NegativeIfMatchT2<HighCourage, LowCourage, TimidityCourage>(highRadicalism, cs.TimidityCourage);
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
        //        res += PositiveValIfLessNegativeIfMore(lowRadicalism, scs.ConformismNonconformism, tcs.ConformismNonconformism);
        //    if (KnownCharacterTrait<Intelligence>())
        //        res += PositiveValIfLessOrEqualElseNeg(lowRadicalism, scs.Intelligence, tcs.Intelligence);
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
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += PositiveValIfMatchElseNegative<MiddleRadicalism, ConservatismRadicalism>(midRadicalism, scs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<ConformismNonconformism>())
        //        res += PositiveValIfMatchElseNegative<MiddleNonconformism, ConformismNonconformism>(midRadicalism, scs.ConformismNonconformism);
        //    if (KnownCharacterTrait<NormativityOfBehaviour>())
        //        res += PositiveValIfMoreOrEqualElseNeg(midRadicalism, scs.NormativityOfBehaviour, tcs.NormativityOfBehaviour);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += PositiveValIfMoreOrEqualElseNeg(midRadicalism, scs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);
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
        //        res += NegativeValIfMoreOrEqual(highSuspicion, cs.CredulitySuspicion, tcs.CredulitySuspicion);
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
        //        res += NegativeValIfMore(midSuspicion, cs.CredulitySuspicion, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<CalmnessAnxiety>())
        //        res += NegativeValIfNonEqualElsePositive(midSuspicion, cs.CalmnessAnxiety, tcs.CalmnessAnxiety);
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += NegativeValIfMoreElsePositive(midSuspicion, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += NegativeValIfNonEqualElsePositive(midSuspicion, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += NegativeValIfNonEqualElsePositive(midSuspicion, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += PositiveValIfLessOrEqualElseNeg(midSuspicion, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<RigiditySensetivity>())
        //        res += PositiveValIfLessOrEqualElseNeg(midSuspicion, cs.RigiditySensetivity, tcs.RigiditySensetivity);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += PositiveValIfMoreOrEqualElseNeg(midSuspicion, cs.Selfcontrol, tcs.Selfcontrol);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += PositiveValIfMoreOrEqualElseNeg(midSuspicion, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);

        //    return res;
        //}
        //public override float GetImportanceValueFor(LowSuspicion lowSuspicion)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<CredulitySuspicion>())
        //        res += PositiveValIfEquals(lowSuspicion, cs.CredulitySuspicion, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<CalmnessAnxiety>())
        //        res += PositiveValIfMoreOrEqualElseNeg(lowSuspicion, cs.CalmnessAnxiety, tcs.CalmnessAnxiety);
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += PositiveValIfMoreOrEqual(lowSuspicion, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += PositiveValIfEqualsElseNeg(lowSuspicion, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += PositiveValIfMoreOrEqual(lowSuspicion, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += PositiveValIfEquals(lowSuspicion, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<RigiditySensetivity>())
        //        res += PositiveValIfMoreOrEqual(lowSuspicion, cs.RigiditySensetivity, tcs.RigiditySensetivity);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += PositiveValIfMoreOrEqualElseNeg(lowSuspicion, cs.Selfcontrol, tcs.Selfcontrol);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += PositiveValIfEquals(lowSuspicion, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);

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
        //        res += PositiveValIfEqualsElseNeg(highStab, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += PositiveValIfEqualsElseNeg(highStab, cs.ClosenessSociability, tcs.ClosenessSociability);
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
        //        res += PositiveValIfMoreOrEqualElseNeg(midStab, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += PositiveValIfEqualsElseNeg(midStab, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<CredulitySuspicion>())
        //        res += PositiveValIfEqualsElseNeg(midStab, cs.CredulitySuspicion, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<NormativityOfBehaviour>())
        //        res += PositiveValIfMoreOrEqualElseNeg(midStab, cs.NormativityOfBehaviour, tcs.NormativityOfBehaviour);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += PositiveValIfEqualsElseNeg(midStab, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += PositiveValIfLessOrEqualElseNeg(midStab, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<RigiditySensetivity>())
        //        res += PositiveValIfEqualsElseNeg(midStab, cs.RigiditySensetivity, tcs.RigiditySensetivity);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += PositiveValIfMoreOrEqualElseNeg(midStab, cs.Selfcontrol, tcs.Selfcontrol);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += PositiveValIfLessOrEqualElseNeg(midStab, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);

        //    return res;
        //}
        //public override float GetImportanceValueFor(LowEmotionalStability lowStab)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += NegativeValIfMoreElsePositive(lowStab, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += NegativeValIfLessElsePositive(lowStab, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<CredulitySuspicion>())
        //        res += NegativeValIfLessOrEqualElsePositive(lowStab, cs.CredulitySuspicion, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<NormativityOfBehaviour>())
        //        res += PositiveValIfLessOrEqualElseNeg(lowStab, cs.NormativityOfBehaviour, tcs.NormativityOfBehaviour);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += PositiveValIfLessOrEqualElseNeg(lowStab, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += PositiveValIfMoreOrEqualElseNeg(lowStab, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<RigiditySensetivity>())
        //        res += PositiveValIfEqualsElseNeg(lowStab, cs.RigiditySensetivity, tcs.RigiditySensetivity);
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
        //        res += PositiveValIfMoreOrEqualElseNeg(hIntel, cs.Intelligence, tcs.Intelligence);
        //    if (KnownCharacterTrait<ConformismNonconformism>())
        //        res += PositiveValIfMoreOrEqualElseNeg(hIntel, cs.ConformismNonconformism, tcs.ConformismNonconformism);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += PositiveValIfMoreOrEqualElseNeg(hIntel, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += PositiveValIfEqualsElseNeg(hIntel, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += PositiveValIfEqualsElseNeg(hIntel, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);           

        //    return res;
        //}
        //public override float GetImportanceValueFor(MiddleIntelligence mIntel)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<Intelligence>())
        //        res += PositiveValIfLessOrEqualElseNeg(mIntel, cs.Intelligence, tcs.Intelligence);
        //    if (KnownCharacterTrait<ConformismNonconformism>())
        //        res += PositiveValIfLessOrEqualElseNeg(mIntel, cs.ConformismNonconformism, tcs.ConformismNonconformism);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += PositiveValIfEqualsElseNeg(mIntel, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += PositiveValIfEquals(mIntel, cs.RelaxationTension, tcs.RelaxationTension);
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
        //        res += PositiveValIfEqualsElseNeg(lIntel, cs.Intelligence, tcs.Intelligence);
        //    if (KnownCharacterTrait<ConformismNonconformism>())
        //        res += PositiveValIfEqualsElseNeg(lIntel, cs.ConformismNonconformism, tcs.ConformismNonconformism);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += PositiveValIfLessOrEqualElseNeg(lIntel, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += PositiveValIfLessOrEqualElseNeg(lIntel, cs.RelaxationTension, tcs.RelaxationTension);
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
        //        res += PositiveValIfLessOrEqualElseNeg(hNormativity, cs.CalmnessAnxiety, tcs.CalmnessAnxiety);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += PositiveValIfMoreOrEqualElseNeg(hNormativity, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += PositiveValIfEqualsElseNeg(hNormativity, cs.RelaxationTension, tcs.RelaxationTension);
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
        //        res += PositiveValIfEqualsElseNeg(lNormativity, cs.CalmnessAnxiety, tcs.CalmnessAnxiety);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += PositiveValIfLessOrEqualElseNeg(lNormativity, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += PositiveValIfLessOrEqualElseNeg(lNormativity, cs.RelaxationTension, tcs.RelaxationTension);
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
        //        res += PositiveValIfMoreOrEqualElseNeg(hDreamines, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<CredulitySuspicion>())
        //        res += PositiveValIfLessOrEqualElseNeg(hDreamines, cs.CredulitySuspicion, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<Intelligence>())
        //        res += PositiveValIfMoreOrEqualElseNeg(hDreamines, cs.Intelligence, tcs.Intelligence);
        //    if (KnownCharacterTrait<RigiditySensetivity>())
        //        res += PositiveValIfEqualsElseNeg(hDreamines, cs.RigiditySensetivity, tcs.RigiditySensetivity);
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
        //        res += PositiveValIfLessOrEqualElseNeg(mDream, cs.CredulitySuspicion, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<Intelligence>())
        //        res += PositiveValIfMoreOrEqualElseNeg(mDream, cs.Intelligence, tcs.Intelligence);
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
        //        res += PositiveValIfMoreOrEqualElseNeg(lDream, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
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
        //        res += PositiveValIfLessOrEqualElseNeg(hTension, cs.CalmnessAnxiety, tcs.CalmnessAnxiety);
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
        //        res += PositiveValIfLessOrEqualElseNeg(mTension, cs.CalmnessAnxiety, tcs.CalmnessAnxiety);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += PositiveValIfEqualsElseNeg(mTension, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<CredulitySuspicion>())
        //        res += PositiveValIfEqualsElseNeg(mTension, cs.CredulitySuspicion, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += PositiveValIfMoreOrEqualElseNeg(mTension, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += PositiveValIfLessOrEqualElseNeg(mTension, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<SubordinationDomination>())
        //        res += PositiveValIfLessOrEqualElseNeg(mTension, cs.SubordinationDomination, tcs.SubordinationDomination);
        //    if (KnownCharacterTrait<TimidityCourage>())
        //        res += PositiveValIfEqualsElseNeg(mTension, cs.TimidityCourage, tcs.TimidityCourage);
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
        //        res += PositiveValIfEqualsElseNeg(lTension, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<CredulitySuspicion>())
        //        res += PositiveValIfEqualsElseNeg(lTension, cs.CredulitySuspicion, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += PositiveValIfMoreOrEqualElseNeg(lTension, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += PositiveValIfLessOrEqualElseNeg(lTension, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<SubordinationDomination>())
        //        res += PositiveValIfLessElseNeg(lTension, cs.SubordinationDomination, tcs.SubordinationDomination);
        //    if (KnownCharacterTrait<TimidityCourage>())
        //        res += PositiveValIfLessOrEqualElseNeg(lTension, cs.TimidityCourage, tcs.TimidityCourage);
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
        //        res += PositiveValIfLessOrEqualElseNeg(heExpr, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<NormativityOfBehaviour>())
        //        res += PositiveValIfLessOrEqualElseNeg(heExpr, cs.NormativityOfBehaviour, tcs.NormativityOfBehaviour);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += PositiveValIfEqualsElseNeg(heExpr, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += PositiveValIfEquals(heExpr, cs.Selfcontrol, tcs.Selfcontrol);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += PositiveValIfEquals(heExpr, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);
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
        //        res += PositiveValIfLessOrEqualElseNeg(mExpr, cs.NormativityOfBehaviour, tcs.NormativityOfBehaviour);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += PositiveValIfEqualsElseNeg(mExpr, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += PositiveValIfEqualsElseNeg(mExpr, cs.Selfcontrol, tcs.Selfcontrol);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += PositiveValIfEqualsElseNeg(mExpr, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);
        //    return res;
        //}
        //public override float GetImportanceValueFor(LowExpressiveness lExpr)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += PositiveValIfEquals(lExpr, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
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

        public FamiliarRelationship(AgentBase<TReaction, TFeature, TState> thisAgent, AgentBase<TReaction, TFeature, TState> secondAgent) 
            : base(thisAgent, secondAgent)
        {
            relationship = RelationshipType.Familiar;
        }
        public override string ToString()
        {
            return "Знакомый.";
        }

    }
}