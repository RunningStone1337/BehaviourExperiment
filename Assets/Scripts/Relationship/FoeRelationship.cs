namespace BehaviourModel
{
    /// <summary>
    /// Неприятель - человек неприятен, вызывает негативную реакцию,
    /// но это ещё не конец - можно исправить ситуацию в лучшую или худшую сторону.
    /// </summary>
    public class FoeRelationship<TReaction, TFeature, TState> : NegativeRelationshipBase<TReaction, TFeature, TState>
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
        //        res += NegativeValIfMoreOrEqualElsePositive(highClosenessSociability, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += NegativeValIfNonEqualElsePositive(highClosenessSociability, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<ConformismNonconformism>())
        //        res += PositiveValIfMoreOrEqualElseNeg(highClosenessSociability, cs.ConformismNonconformism, tcs.ConformismNonconformism);
            
        //        res += PositiveValIfMatchT1NegativeIfMatchT2<LowSuspicion,HighSuspicion,CredulitySuspicion>(highClosenessSociability, tcs.CredulitySuspicion);
            
        //        res += PositiveValIfMatchT1NegativeIfMatchT2<HighDiplomacy,LowDiplomacy,StraightforwardnessDiplomacy>(highClosenessSociability, tcs.StraightforwardnessDiplomacy);
            
        //        res += PositiveValIfMatchT1NegativeIfMatchT2<HighCourage,LowCourage,TimidityCourage>(highClosenessSociability, tcs.TimidityCourage);
        //    return res;
        //}
        //public override float GetImportanceValueFor(LowClosenessSociability lowClosenessSociability)
        //{
        //    float res = default;
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += NegativeValIfMoreOrEqual(lowClosenessSociability, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += NegativeValIfNonEqual(lowClosenessSociability, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<ConformismNonconformism>())
        //        res += PositiveValIfEqualsElseNeg(lowClosenessSociability, cs.ConformismNonconformism, tcs.ConformismNonconformism);
            
        //        res += NegativeValIfMatch<HighSuspicion, CredulitySuspicion>(lowClosenessSociability, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += NegativeValIfNonEqual(lowClosenessSociability, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);
            
        //        res += PositiveValIfMatchT1NegativeIfMatchT2<HighCourage, LowCourage, TimidityCourage>(lowClosenessSociability, tcs.TimidityCourage);
        //    return res;
        //}
        //public override float GetImportanceValueFor(MiddleClosenessSociability midClosenessSociability)
        //{
        //    float res = default;
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += PositiveValIfMoreOrEqualElseNeg(midClosenessSociability, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += PositiveValIfEqualsElseNeg(midClosenessSociability, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<ConformismNonconformism>())
        //        res += PositiveValIfEqualsElseNeg(midClosenessSociability, cs.ConformismNonconformism, tcs.ConformismNonconformism);
            
        //        res += PositiveValIfMatchT1NegativeIfMatchT2<LowSuspicion, HighSuspicion, CredulitySuspicion>(midClosenessSociability, tcs.CredulitySuspicion);
            
        //        res += PositiveValIfMatchT1NegativeIfMatchT2<HighDiplomacy, LowDiplomacy, StraightforwardnessDiplomacy>(midClosenessSociability, tcs.StraightforwardnessDiplomacy);
            
        //        res += PositiveValIfMatchT1NegativeIfMatchT2<HighCourage, LowCourage, TimidityCourage>(midClosenessSociability, tcs.TimidityCourage);
        //    return res;
        //}
      
        //#endregion

        //#region calmness
        //public override float GetImportanceValueFor(HighAnxiety highAnxiety)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    res += -highAnxiety.CharacterValue;
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += NegativeValIfLess(highAnxiety, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += NegativeValIfLess(highAnxiety, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += NegativeValIfMoreOrEqual(highAnxiety, cs.RelaxationTension, tcs.RelaxationTension);
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
        //        res += NegativeValIfMoreOrEqual(midAnxiety, cs.CalmnessAnxiety, tcs.CalmnessAnxiety);
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += NegativeValIfMoreOrEqual(midAnxiety, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += NegativeValIfLessElsePositive(midAnxiety, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += NegativeValIfMoreElsePositive(midAnxiety, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += NegativeValIfMoreOrEqualElsePositive(midAnxiety, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<RigiditySensetivity>())
        //        res += NegativeValIfLess(midAnxiety, cs.RigiditySensetivity, tcs.RigiditySensetivity);
        //    if (KnownCharacterTrait<SubordinationDomination>())
        //        res += NegativeValIfMoreOrEqualElsePositive(midAnxiety, cs.SubordinationDomination, tcs.SubordinationDomination);
        //    return res;
        //}
        //public override float GetImportanceValueFor(LowAnxiety lowAnxiety)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<CalmnessAnxiety>())
        //        res += PositiveValIfLessElseNeg(lowAnxiety, cs.CalmnessAnxiety, tcs.CalmnessAnxiety);
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += PositiveValIfLess(lowAnxiety, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += PositiveValIfMoreOrEqualElseNeg(lowAnxiety, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += PositiveValIfEqualsElseNeg(lowAnxiety, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += PositiveValIfLessElseNeg(lowAnxiety, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<RigiditySensetivity>())
        //        res += PositiveValIfEqualsElseNeg(lowAnxiety, cs.RigiditySensetivity, tcs.RigiditySensetivity);
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
        //        res += NegativeValIfLessOrEqual(highNonconformism, cs.ConformismNonconformism, tcs.ConformismNonconformism);
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += NegativeValIfMore(highNonconformism, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += NegativeValIfLess(highNonconformism, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<Intelligence>())
        //        res += NegativeValIfLess(highNonconformism, cs.Intelligence, tcs.Intelligence);
        //    if (KnownCharacterTrait<NormativityOfBehaviour>())
        //        res += NegativeValIfLess(highNonconformism, cs.NormativityOfBehaviour, tcs.NormativityOfBehaviour);
        //    if (KnownCharacterTrait<PracticalityDreaminess>())
        //        res += NegativeValIfNonEqual(highNonconformism, cs.PracticalityDreaminess, tcs.PracticalityDreaminess);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += NegativeValIfLess(highNonconformism, cs.Selfcontrol, tcs.Selfcontrol);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += NegativeValIfNonEqual(highNonconformism, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);
        //    if (KnownCharacterTrait<SubordinationDomination>())
        //        res += NegativeValIfMore(highNonconformism, cs.SubordinationDomination, tcs.SubordinationDomination);
        //    if (KnownCharacterTrait<TimidityCourage>())
        //        res += NegativeValIfLess(highNonconformism, cs.TimidityCourage, tcs.TimidityCourage);
        //    return res;
        //}
        //public override float GetImportanceValueFor(MiddleNonconformism midNonconformism)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<ConformismNonconformism>())
        //        res += NegativeValIfNonEqual(midNonconformism, cs.ConformismNonconformism, tcs.ConformismNonconformism);
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += NegativeValIfMore(midNonconformism, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += NegativeValIfNonEqual(midNonconformism, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<Intelligence>())
        //        res += NegativeValIfLess(midNonconformism, cs.Intelligence, tcs.Intelligence);
        //    if (KnownCharacterTrait<NormativityOfBehaviour>())
        //        res += NegativeValIfLess(midNonconformism, cs.NormativityOfBehaviour, tcs.NormativityOfBehaviour);
        //    if (KnownCharacterTrait<PracticalityDreaminess>())
        //        res += NegativeValIfNonEqual(midNonconformism, cs.PracticalityDreaminess, tcs.PracticalityDreaminess);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += NegativeValIfLess(midNonconformism, cs.Selfcontrol, tcs.Selfcontrol);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += NegativeValIfNonEqual(midNonconformism, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);
        //    if (KnownCharacterTrait<SubordinationDomination>())
        //        res += NegativeValIfMoreOrEqual(midNonconformism, cs.SubordinationDomination, tcs.SubordinationDomination);
        //    if (KnownCharacterTrait<TimidityCourage>())
        //        res += NegativeValIfNonEqual(midNonconformism, cs.TimidityCourage, tcs.TimidityCourage);
        //    return res;
        //}
        //public override float GetImportanceValueFor(LowNonconformism lowNonconformism)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<ConformismNonconformism>())
        //        res += PositiveValIfMoreOrEqual(lowNonconformism, cs.ConformismNonconformism, tcs.ConformismNonconformism);
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += PositiveValIfMoreOrEqualElseNeg(lowNonconformism, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += NegativeValIfNonEqual(lowNonconformism, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<Intelligence>())
        //        res += PositiveValIfLessElseNeg(lowNonconformism, cs.Intelligence, tcs.Intelligence);
        //    if (KnownCharacterTrait<NormativityOfBehaviour>())
        //        res += PositiveValIfEqualsElseNeg(lowNonconformism, cs.NormativityOfBehaviour, tcs.NormativityOfBehaviour);
        //    if (KnownCharacterTrait<PracticalityDreaminess>())
        //        res += PositiveValIfEqualsElseNeg(lowNonconformism, cs.PracticalityDreaminess, tcs.PracticalityDreaminess);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += NegativeValIfNonEqual(lowNonconformism, cs.Selfcontrol, tcs.Selfcontrol);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += NegativeValIfNonEqual(lowNonconformism, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);
        //    if (KnownCharacterTrait<SubordinationDomination>())
        //        res += NegativeValIfMoreElsePositive(lowNonconformism, cs.SubordinationDomination, tcs.SubordinationDomination);
        //    if (KnownCharacterTrait<TimidityCourage>())
        //        res += PositiveValIfLessOrEqualElseNeg(lowNonconformism, cs.TimidityCourage, tcs.TimidityCourage);
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
        //        res += PositiveValIfLess(highRadicalism, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<ConformismNonconformism>())
        //        res += NegativeValIfLess(highRadicalism, cs.ConformismNonconformism, tcs.ConformismNonconformism);
        //    if (KnownCharacterTrait<Intelligence>())
        //        res += NegativeValIfLess(highRadicalism, cs.Intelligence, tcs.Intelligence);
        //    if (KnownCharacterTrait<NormativityOfBehaviour>())
        //        res += PositiveValIfMatchT1NegativeIfMatchT2<LowNormativityOfBehaviour, HighNormativityOfBehaviour, NormativityOfBehaviour>(highRadicalism, cs.NormativityOfBehaviour);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += NegativeValIfMatch<HighDiplomacy, StraightforwardnessDiplomacy>(highRadicalism, cs.StraightforwardnessDiplomacy);
        //    if (KnownCharacterTrait<TimidityCourage>())
        //        res += PositiveValIfMatchT1NegativeIfMatchT2<HighCourage, LowCourage, TimidityCourage>(highRadicalism, cs.TimidityCourage);
        //    return res;
        //}

        //public override float GetImportanceValueFor(LowRadicalism lowRadicalism)
        //{
        //    float res = default;
        //    var scs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += PositiveValIfMatchNegativeIfMore<LowRadicalism, ConservatismRadicalism>(lowRadicalism, scs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<ConformismNonconformism>())
        //        res += NegativeValIfMore(lowRadicalism, scs.ConformismNonconformism, tcs.ConformismNonconformism);
        //    if (KnownCharacterTrait<Intelligence>())
        //        res += NegativeValIfMore(lowRadicalism, scs.Intelligence, tcs.Intelligence);
        //    if (KnownCharacterTrait<NormativityOfBehaviour>())
        //        res += NegativeValIfMatch<LowNormativityOfBehaviour, NormativityOfBehaviour>(lowRadicalism, scs.NormativityOfBehaviour);
        //    return res;
        //}

        //public override float GetImportanceValueFor(MiddleRadicalism midRadicalism)
        //{
        //    float res = default;
        //    var scs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    //можем оценивать только известные черты характера!
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += PositiveValIfMatchElseNegative<MiddleRadicalism, ConservatismRadicalism>(midRadicalism, scs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<NormativityOfBehaviour>())
        //        res += NegativeValIfLess(midRadicalism, scs.NormativityOfBehaviour, tcs.NormativityOfBehaviour);
        //    return res;
        //}

       
        //#endregion

        //#region suspicion
        //public override float GetImportanceValueFor(HighSuspicion highSuspicion)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;

        //    res += -highSuspicion.CharacterValue;
        //    if (KnownCharacterTrait<CalmnessAnxiety>())
        //        res += NegativeValIfNonEqual(highSuspicion, cs.CalmnessAnxiety, tcs.CalmnessAnxiety);
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += NegativeValIfMoreOrEqual(highSuspicion, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += NegativeValIfMoreOrEqual(highSuspicion, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += NegativeValIfLessOrEqual(highSuspicion, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += NegativeValIfMoreOrEqual(highSuspicion, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<RigiditySensetivity>())
        //        res += NegativeValIfNonEqual(highSuspicion, cs.RigiditySensetivity, tcs.RigiditySensetivity);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += NegativeValIfNonEqual(highSuspicion, cs.Selfcontrol, tcs.Selfcontrol);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += NegativeValIfNonEqual(highSuspicion, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);

        //    return res;
        //}
        //public override float GetImportanceValueFor(MiddleSuspicion midSuspicion)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<CredulitySuspicion>())
        //        res += NegativeValIfMoreOrEqual(midSuspicion, cs.CredulitySuspicion, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<CalmnessAnxiety>())
        //        res += NegativeValIfMore(midSuspicion, cs.CalmnessAnxiety, tcs.CalmnessAnxiety);
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += NegativeValIfMore(midSuspicion, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += NegativeValIfMore(midSuspicion, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += NegativeValIfLessOrEqual(midSuspicion, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += NegativeValIfMore(midSuspicion, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<RigiditySensetivity>())
        //        res += NegativeValIfLessOrEqual(midSuspicion, cs.RigiditySensetivity, tcs.RigiditySensetivity);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += NegativeValIfLess(midSuspicion, cs.Selfcontrol, tcs.Selfcontrol);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += NegativeValIfLess(midSuspicion, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);

        //    return res;
        //}
        //public override float GetImportanceValueFor(LowSuspicion lowSuspicion)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<CredulitySuspicion>())
        //        res += PositiveValIfLessOrEqualElseNeg(lowSuspicion, cs.CredulitySuspicion, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<CalmnessAnxiety>())
        //        res += PositiveValIfLessOrEqualElseNeg(lowSuspicion, cs.CalmnessAnxiety, tcs.CalmnessAnxiety);
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += PositiveValIfMoreOrEqualElseNeg(lowSuspicion, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += PositiveValIfEqualsElseNeg(lowSuspicion, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += PositiveValIfEqualsElseNeg(lowSuspicion, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += PositiveValIfEqualsElseNeg(lowSuspicion, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<RigiditySensetivity>())
        //        res += PositiveValIfEqualsElseNeg(lowSuspicion, cs.RigiditySensetivity, tcs.RigiditySensetivity);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += PositiveValIfMoreOrEqualElseNeg(lowSuspicion, cs.Selfcontrol, tcs.Selfcontrol);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += PositiveValIfMoreOrEqualElseNeg(lowSuspicion, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);

        //    return res;
        //}
      

        //#endregion

        //#region emotional stability

        //public override float GetImportanceValueFor(HighEmotionalStability highStab)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    res += -highStab.CharacterValue;
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += NegativeValIfNonEqual(highStab, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<CredulitySuspicion>())
        //        res += NegativeValIfNonEqual(highStab, cs.CredulitySuspicion, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<NormativityOfBehaviour>())
        //        res += NegativeValIfLess(highStab, cs.NormativityOfBehaviour, tcs.NormativityOfBehaviour);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += NegativeValIfNonEqual(highStab, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += NegativeValIfMore(highStab, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<RigiditySensetivity>())
        //        res += NegativeValIfNonEqual(highStab, cs.RigiditySensetivity, tcs.RigiditySensetivity);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += NegativeValIfLess(highStab, cs.Selfcontrol, tcs.Selfcontrol);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += NegativeValIfNonEqual(highStab, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);

        //    return res;
        //}
        //public override float GetImportanceValueFor(MiddleEmotionalStability midStab)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += NegativeValIfLessElsePositive(midStab, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += NegativeValIfNonEqualElsePositive(midStab, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<CredulitySuspicion>())
        //        res += NegativeValIfMoreElsePositive(midStab, cs.CredulitySuspicion, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<NormativityOfBehaviour>())
        //        res += NegativeValIfNonEqualElsePositive(midStab, cs.NormativityOfBehaviour, tcs.NormativityOfBehaviour);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += NegativeValIfNonEqualElsePositive(midStab, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += NegativeValIfMoreElsePositive(midStab, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<RigiditySensetivity>())
        //        res += NegativeValIfNonEqualElsePositive(midStab, cs.RigiditySensetivity, tcs.RigiditySensetivity);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += NegativeValIfLessElsePositive(midStab, cs.Selfcontrol, tcs.Selfcontrol);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += NegativeValIfNonEqualElsePositive(midStab, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);

        //    return res;
        //}
        //public override float GetImportanceValueFor(LowEmotionalStability lowStab)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    res += -lowStab.CharacterValue;
        //    if (KnownCharacterTrait<ClosenessSociability>())
        //        res += NegativeValIfNonEqualElsePositive(lowStab, cs.ClosenessSociability, tcs.ClosenessSociability);
        //    if (KnownCharacterTrait<CredulitySuspicion>())
        //        res += NegativeValIfNonEqualElsePositive(lowStab, cs.CredulitySuspicion, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<NormativityOfBehaviour>())
        //        res += NegativeValIfMoreOrEqualElsePositive(lowStab, cs.NormativityOfBehaviour, tcs.NormativityOfBehaviour);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += NegativeValIfNonEqualElsePositive(lowStab, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += NegativeValIfLessElsePositive(lowStab, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<RigiditySensetivity>())
        //        res += NegativeValIfNonEqualElsePositive(lowStab, cs.RigiditySensetivity, tcs.RigiditySensetivity);
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
        //        res += NegativeValIfLess(hIntel, cs.Intelligence, tcs.Intelligence);
        //    if (KnownCharacterTrait<ConformismNonconformism>())
        //        res += NegativeValIfLess(hIntel, cs.ConformismNonconformism, tcs.ConformismNonconformism);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += NegativeValIfLess(hIntel, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += NegativeValIfNonEqual(hIntel, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += NegativeValIfNonEqual(hIntel, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);

        //    return res;
        //}
        //public override float GetImportanceValueFor(MiddleIntelligence mIntel)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<Intelligence>())
        //        res += NegativeValIfLess(mIntel, cs.Intelligence, tcs.Intelligence);
        //    if (KnownCharacterTrait<ConformismNonconformism>())
        //        res += NegativeValIfNonEqual(mIntel, cs.ConformismNonconformism, tcs.ConformismNonconformism);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += NegativeValIfNonEqual(mIntel, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += NegativeValIfNonEqual(mIntel, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += NegativeValIfMore(mIntel, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);

        //    return res;
        //}
        //public override float GetImportanceValueFor(LowIntelligence lIntel)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<Intelligence>())
        //        res += NegativeValIfMore(lIntel, cs.Intelligence, tcs.Intelligence);
        //    if (KnownCharacterTrait<ConformismNonconformism>())
        //        res += NegativeValIfMore(lIntel, cs.ConformismNonconformism, tcs.ConformismNonconformism);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += NegativeValIfMore(lIntel, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += NegativeValIfNonEqual(lIntel, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += NegativeValIfLess(lIntel, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
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
        //        res += NegativeValIfLess(hNormativity, cs.NormativityOfBehaviour, tcs.NormativityOfBehaviour);
        //    if (KnownCharacterTrait<CalmnessAnxiety>())
        //        res += NegativeValIfNonEqual(hNormativity, cs.CalmnessAnxiety, tcs.CalmnessAnxiety);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += NegativeValIfLess(hNormativity, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += NegativeValIfNonEqual(hNormativity, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<PracticalityDreaminess>())
        //        res += NegativeValIfNonEqual(hNormativity, cs.PracticalityDreaminess, tcs.PracticalityDreaminess);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += NegativeValIfLess(hNormativity, cs.Selfcontrol, tcs.Selfcontrol);

        //    return res;
        //}
        //public override float GetImportanceValueFor(MiddleNormativityOfBehaviour mNormativity)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<NormativityOfBehaviour>())
        //        res += NegativeValIfLessElsePositive(mNormativity, cs.NormativityOfBehaviour, tcs.NormativityOfBehaviour);
        //    if (KnownCharacterTrait<CalmnessAnxiety>())
        //        res += NegativeValIfMoreElsePositive(mNormativity, cs.CalmnessAnxiety, tcs.CalmnessAnxiety);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += NegativeValIfLessElsePositive(mNormativity, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += NegativeValIfNonEqual(mNormativity, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<PracticalityDreaminess>())
        //        res += NegativeValIfNonEqual(mNormativity, cs.PracticalityDreaminess, tcs.PracticalityDreaminess);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += NegativeValIfLessElsePositive(mNormativity, cs.Selfcontrol, tcs.Selfcontrol);
        //    return res;
        //}
        //public override float GetImportanceValueFor(LowNormativityOfBehaviour lNormativity)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<NormativityOfBehaviour>())
        //        res += NegativeValIfMoreElsePositive(lNormativity, cs.NormativityOfBehaviour, tcs.NormativityOfBehaviour);
        //    if (KnownCharacterTrait<CalmnessAnxiety>())
        //        res += NegativeValIfLess(lNormativity, cs.CalmnessAnxiety, tcs.CalmnessAnxiety);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += NegativeValIfMore(lNormativity, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += NegativeValIfNonEqual(lNormativity, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<PracticalityDreaminess>())
        //        res += NegativeValIfNonEqual(lNormativity, cs.PracticalityDreaminess, tcs.PracticalityDreaminess);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += NegativeValIfMoreElsePositive(lNormativity, cs.Selfcontrol, tcs.Selfcontrol);
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
        //        res += NegativeValIfLess(hDreamines, cs.PracticalityDreaminess, tcs.PracticalityDreaminess);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += NegativeValIfNonEqualElsePositive(hDreamines, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<CredulitySuspicion>())
        //        res += NegativeValIfNonEqual(hDreamines, cs.CredulitySuspicion, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<Intelligence>())
        //        res += NegativeValIfNonEqualElsePositive(hDreamines, cs.Intelligence, tcs.Intelligence);
        //    if (KnownCharacterTrait<RigiditySensetivity>())
        //        res += NegativeValIfLessElsePositive(hDreamines, cs.RigiditySensetivity, tcs.RigiditySensetivity);
        //    return res;
        //}
        //public override float GetImportanceValueFor(MiddleDreaminess mDream)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<PracticalityDreaminess>())
        //        res += NegativeValIfNonEqual(mDream, cs.PracticalityDreaminess, tcs.PracticalityDreaminess);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += NegativeValIfNonEqual(mDream, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<CredulitySuspicion>())
        //        res += NegativeValIfNonEqual(mDream, cs.CredulitySuspicion, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<Intelligence>())
        //        res += NegativeValIfLessElsePositive(mDream, cs.Intelligence, tcs.Intelligence);
        //    if (KnownCharacterTrait<RigiditySensetivity>())
        //        res += NegativeValIfNonEqualElsePositive(mDream, cs.RigiditySensetivity, tcs.RigiditySensetivity);
        //    return res;
        //}
        //public override float GetImportanceValueFor(LowDreaminess lDream)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<PracticalityDreaminess>())
        //        res += NegativeValIfNonEqual(lDream, cs.PracticalityDreaminess, tcs.PracticalityDreaminess);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += NegativeValIfMore(lDream, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<CredulitySuspicion>())
        //        res += NegativeValIfMore(lDream, cs.CredulitySuspicion, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<Intelligence>())
        //        res += NegativeValIfLess(lDream, cs.Intelligence, tcs.Intelligence);
        //    if (KnownCharacterTrait<RigiditySensetivity>())
        //        res += NegativeValIfMore(lDream, cs.RigiditySensetivity, tcs.RigiditySensetivity);
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
        //        res += NegativeValIfNonEqual(hTension, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<CalmnessAnxiety>())
        //        res += NegativeValIfMoreOrEqual(hTension, cs.CalmnessAnxiety, tcs.CalmnessAnxiety);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += NegativeValIfNonEqual(hTension, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<CredulitySuspicion>())
        //        res += NegativeValIfNonEqual(hTension, cs.CredulitySuspicion, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += NegativeValIfLess(hTension, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += NegativeValIfNonEqual(hTension, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<SubordinationDomination>())
        //        res += NegativeValIfMoreOrEqual(hTension, cs.SubordinationDomination, tcs.SubordinationDomination);
        //    if (KnownCharacterTrait<TimidityCourage>())
        //        res += NegativeValIfMoreOrEqual(hTension, cs.TimidityCourage, tcs.TimidityCourage);
        //    return res;
        //}
        //public override float GetImportanceValueFor(MiddleTension mTension)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += NegativeValIfMoreOrEqual(mTension, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<CalmnessAnxiety>())
        //        res += NegativeValIfMoreOrEqual(mTension, cs.CalmnessAnxiety, tcs.CalmnessAnxiety);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += NegativeValIfNonEqual(mTension, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<CredulitySuspicion>())
        //        res += NegativeValIfNonEqual(mTension, cs.CredulitySuspicion, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += NegativeValIfLess(mTension, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += NegativeValIfNonEqual(mTension, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<SubordinationDomination>())
        //        res += NegativeValIfMoreOrEqual(mTension, cs.SubordinationDomination, tcs.SubordinationDomination);
        //    if (KnownCharacterTrait<TimidityCourage>())
        //        res += NegativeValIfNonEqual(mTension, cs.TimidityCourage, tcs.TimidityCourage);
        //    return res;
        //}
        //public override float GetImportanceValueFor(LowTension lTension)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += NegativeValIfMore(lTension, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<CalmnessAnxiety>())
        //        res += NegativeValIfMore(lTension, cs.CalmnessAnxiety, tcs.CalmnessAnxiety);
        //    if (KnownCharacterTrait<ConservatismRadicalism>())
        //        res += NegativeValIfNonEqual(lTension, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
        //    if (KnownCharacterTrait<CredulitySuspicion>())
        //        res += NegativeValIfMoreOrEqual(lTension, cs.CredulitySuspicion, tcs.CredulitySuspicion);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += NegativeValIfLess(lTension, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += NegativeValIfMore(lTension, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<SubordinationDomination>())
        //        res += NegativeValIfMore(lTension, cs.SubordinationDomination, tcs.SubordinationDomination);
        //    if (KnownCharacterTrait<TimidityCourage>())
        //        res += NegativeValIfMore(lTension, cs.TimidityCourage, tcs.TimidityCourage);
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
        //        res += NegativeValIfLessOrEqual(heExpr, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<CalmnessAnxiety>())
        //        res += NegativeValIfNonEqual(heExpr, cs.CalmnessAnxiety, tcs.CalmnessAnxiety);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += NegativeValIfMore(heExpr, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<NormativityOfBehaviour>())
        //        res += NegativeValIfMore(heExpr, cs.NormativityOfBehaviour, tcs.NormativityOfBehaviour);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += NegativeValIfMore(heExpr, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += NegativeValIfNonEqual(heExpr, cs.Selfcontrol, tcs.Selfcontrol);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += NegativeValIfNonEqual(heExpr, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);
        //    return res;
        //}
        //public override float GetImportanceValueFor(MiddleExpressiveness mExpr)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += NegativeValIfMore(mExpr, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<CalmnessAnxiety>())
        //        res += NegativeValIfMore(mExpr, cs.CalmnessAnxiety, tcs.CalmnessAnxiety);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += NegativeValIfLess(mExpr, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<NormativityOfBehaviour>())
        //        res += NegativeValIfLess(mExpr, cs.NormativityOfBehaviour, tcs.NormativityOfBehaviour);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += NegativeValIfNonEqual(mExpr, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += NegativeValIfLess(mExpr, cs.Selfcontrol, tcs.Selfcontrol);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += NegativeValIfLessElsePositive(mExpr, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);
        //    return res;
        //}
        //public override float GetImportanceValueFor(LowExpressiveness lExpr)
        //{
        //    var cs = SecondAgent.CharacterSystem;
        //    var tcs = ThisAgent.CharacterSystem;
        //    float res = default;
        //    if (KnownCharacterTrait<RestraintExpressiveness>())
        //        res += PositiveValIfEqualsElseNeg(lExpr, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
        //    if (KnownCharacterTrait<CalmnessAnxiety>())
        //        res += NegativeValIfMore(lExpr, cs.CalmnessAnxiety, tcs.CalmnessAnxiety);
        //    if (KnownCharacterTrait<EmotionalInstabilityStability>())
        //        res += NegativeValIfMoreOrEqualElsePositive(lExpr, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
        //    if (KnownCharacterTrait<NormativityOfBehaviour>())
        //        res += NegativeValIfLess(lExpr, cs.NormativityOfBehaviour, tcs.NormativityOfBehaviour);
        //    if (KnownCharacterTrait<RelaxationTension>())
        //        res += NegativeValIfNonEqualElsePositive(lExpr, cs.RelaxationTension, tcs.RelaxationTension);
        //    if (KnownCharacterTrait<Selfcontrol>())
        //        res += NegativeValIfLess(lExpr, cs.Selfcontrol, tcs.Selfcontrol);
        //    if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
        //        res += NegativeValIfLessElsePositive(lExpr, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);
        //    return res;
        //}
       
        //#endregion
        public FoeRelationship(AgentBase<TReaction, TFeature, TState> thisAgent,AgentBase<TReaction, TFeature, TState> secondAgent) : base(thisAgent, secondAgent)
        {
            relationship = RelationshipType.Foe;
        }
        public override string ToString()
        {
            return "Неприятельские отношения.";
        }
       
    }
}