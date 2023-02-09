namespace BehaviourModel
{
    /// <summary>
    /// ≈два знакомое отношение. Ќе контактировал лично,
    /// только субъективные впечатлени€.
    /// </summary>
    //public class PoorKnownRelation : RelationshipBase
    //{
    //    public PoorKnownRelation(AgentBase thisAgent, AgentBase secondAgent) : base(thisAgent, secondAgent)
    //    {
    //        relationship = RelationshipType.PoorlyKnown;
    //    }
    //    public override string ToString()
    //    {
    //        return "Ќезнакомец.";
    //    }
    //    public override float GetImportanceValueFor(HighSuspicion highSuspicion)
    //    {
    //        float res = default;
    //        var cs = SecondAgent.CharacterSystem;
    //        var tcs = ThisAgent.CharacterSystem;
    //        if (KnownCharacterTrait<CredulitySuspicion>())
    //            //ниже - не интересен
    //            //больше равен - интересен
    //            res += PositiveValIfLessOrEqualElseNegative(highSuspicion, cs.CredulitySuspicion, tcs.CredulitySuspicion);
    //        if (KnownCharacterTrait<ClosenessSociability>())
    //            //если закрыт - подозрительно
    //            //открыт - нейтрально
    //            res += PositiveValIfMatch<LowClosenessSociability, ClosenessSociability>(highSuspicion, cs.ClosenessSociability);
    //        if (KnownCharacterTrait<ConformismNonconformism>())
    //            res += PositiveValIfMatchT1NegativeIfMatchT2<HighNonconformism, LowNonconformism, ConformismNonconformism>(highSuspicion, cs.ConformismNonconformism);
    //        if (KnownCharacterTrait<ConservatismRadicalism>())
    //            res += PositiveValIfMatchT1NegativeIfMatchT2<HighRadicalism, LowRadicalism, ConservatismRadicalism>(highSuspicion, cs.ConservatismRadicalism);
    //        if (KnownCharacterTrait<EmotionalInstabilityStability>())
    //            res += PositiveValIfMatchT1NegativeIfMatchT2<LowEmotionalStability, HighEmotionalStability, EmotionalInstabilityStability>(highSuspicion, cs.EmotionalInstabilityStability);
    //        if (KnownCharacterTrait<PracticalityDreaminess>())
    //            res += PositiveValIfMatchT1NegativeIfMatchT2<LowDreaminess, HighDreaminess, PracticalityDreaminess>(highSuspicion, cs.PracticalityDreaminess);
    //        if (KnownCharacterTrait<RestraintExpressiveness>())
    //            res += PositiveValIfMatchT1NegativeIfMatchT2<HighExpressiveness, LowExpressiveness, RestraintExpressiveness>(highSuspicion, cs.RestraintExpressiveness);
    //        if (KnownCharacterTrait<RigiditySensetivity>())
    //            res += PositiveValIfLess(highSuspicion, cs.RigiditySensetivity, tcs.RigiditySensetivity);
    //        if (KnownCharacterTrait<Selfcontrol>())
    //            res += PositiveValIfMatchElseNegative<LowSelfcontrol, Selfcontrol>(highSuspicion, cs.Selfcontrol);
    //        if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
    //            res += PositiveValIfLessNegativeIfMore(highSuspicion, cs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);
    //        return res;
    //    }

    //    public override float GetImportanceValueFor(LowRadicalism lowRadicalism)
    //    {
    //        //cs.ConservatismRadicalism,
    //        //    cs.ConformismNonconformism,
    //        //    cs.Intelligence,
    //        //    cs.NormativityOfBehaviour,
    //        //    cs.StraightforwardnessDiplomacy,
    //        //    cs.TimidityCourage
    //        //закончил здесь
    //        float res = default;
    //        var cs = SecondAgent.CharacterSystem;
    //        var tcs = ThisAgent.CharacterSystem;
    //        ///это копипаст
    //        //if (KnownCharacterTrait<ConservatismRadicalism>())
    //        //    res += PositiveValIfMoreOrEqualElseNegative(highRadicalism, cs.ConservatismRadicalism, highRadicalism);
    //        //if (KnownCharacterTrait<ConformismNonconformism>())
    //        //    res += PositiveValIfMoreOrEqualElseNegative(highRadicalism, cs.ConformismNonconformism, tcs.ConformismNonconformism);
    //        //if (KnownCharacterTrait<Intelligence>())
    //        //    res += PositiveValIfLessElseNegative(highRadicalism, cs.Intelligence, tcs.Intelligence);
    //        //if (KnownCharacterTrait<NormativityOfBehaviour>())
    //        //    res += PositiveValIfLessOrEqualElseNegative(highRadicalism, cs.NormativityOfBehaviour, tcs.NormativityOfBehaviour);
    //        //if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
    //        //    res += PositiveValIfMatchT1NegativeIfMatchT2<LowDiplomacy, HighDiplomacy, StraightforwardnessDiplomacy>(highRadicalism, cs.StraightforwardnessDiplomacy);
    //        //if (KnownCharacterTrait<TimidityCourage>())
    //        //    res += PositiveValIfMatchT1NegativeIfMatchT2<HighCourage, LowCourage, TimidityCourage>(highRadicalism, cs.TimidityCourage);
    //        return res;
    //    }

    //    public override float GetImportanceValueFor(HighAnxiety highAnxiety)
    //    {
    //        float res = default;
    //        var cs = SecondAgent.CharacterSystem;
    //        var tcs = ThisAgent.CharacterSystem;
    //        if (KnownCharacterTrait<CalmnessAnxiety>())
    //            res += PositiveValIfLessElseNegative(highAnxiety, cs.CalmnessAnxiety, tcs.CalmnessAnxiety);
    //        if (KnownCharacterTrait<ClosenessSociability>())
    //            res += PositiveValIfLessOrEqualElseNegative(highAnxiety, cs.ClosenessSociability, tcs.ClosenessSociability);
    //        if (KnownCharacterTrait<EmotionalInstabilityStability>())
    //            res += PositiveValIfLessOrEqualElseNegative(highAnxiety, cs.EmotionalInstabilityStability, tcs.EmotionalInstabilityStability);
    //        if (KnownCharacterTrait<RelaxationTension>())
    //            res += PositiveValIfLessOrEqualElseNegative(highAnxiety, cs.RelaxationTension, tcs.RelaxationTension);
    //        if (KnownCharacterTrait<RestraintExpressiveness>())
    //            res += PositiveValIfLessOrEqualElseNegative(highAnxiety, cs.RestraintExpressiveness, tcs.RestraintExpressiveness);
    //        if (KnownCharacterTrait<RigiditySensetivity>())
    //            res += PositiveValIfLessOrEqualElseNegative(highAnxiety, cs.RigiditySensetivity, tcs.RigiditySensetivity);
    //        if (KnownCharacterTrait<SubordinationDomination>())
    //            res += PositiveValIfLessOrEqualElseNegative(highAnxiety, cs.SubordinationDomination, tcs.SubordinationDomination);
    //        return res;
    //    }

    //    public override float GetImportanceValueFor(HighRadicalism highRadicalism)
    //    {
    //        float res = default;
    //        var cs = SecondAgent.CharacterSystem;
    //        var tcs = ThisAgent.CharacterSystem;
    //        //можем оценивать только известные черты характера!
    //        if (KnownCharacterTrait<ConservatismRadicalism>())
    //            res += PositiveValIfMoreOrEqualElseNegative(highRadicalism, cs.ConservatismRadicalism, highRadicalism);
    //        if (KnownCharacterTrait<ConformismNonconformism>())
    //            res += PositiveValIfMoreOrEqualElseNegative(highRadicalism, cs.ConformismNonconformism, tcs.ConformismNonconformism);
    //        if (KnownCharacterTrait<Intelligence>())
    //            res += PositiveValIfLessElseNegative(highRadicalism, cs.Intelligence, tcs.Intelligence);
    //        if (KnownCharacterTrait<NormativityOfBehaviour>())
    //            res += PositiveValIfLessOrEqualElseNegative(highRadicalism, cs.NormativityOfBehaviour, tcs.NormativityOfBehaviour);
    //        if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
    //            res += PositiveValIfMatchT1NegativeIfMatchT2<LowDiplomacy, HighDiplomacy, StraightforwardnessDiplomacy>(highRadicalism, cs.StraightforwardnessDiplomacy);
    //        if (KnownCharacterTrait<TimidityCourage>())
    //            res += PositiveValIfMatchT1NegativeIfMatchT2<HighCourage, LowCourage, TimidityCourage>(highRadicalism, cs.TimidityCourage);
    //        return res;
    //    }

    //    public override float GetImportanceValueFor(MiddleRadicalism midRadicalism)
    //    {
    //        float res = default;
    //        var scs = SecondAgent.CharacterSystem;
    //        var tcs = ThisAgent.CharacterSystem;
    //        if (KnownCharacterTrait<ConservatismRadicalism>())
    //            res += PositiveValIfMatchElseNegative<MiddleRadicalism, ConservatismRadicalism>(midRadicalism, scs.ConservatismRadicalism);
    //        if (KnownCharacterTrait<ConformismNonconformism>())
    //            //???
    //            res += PositiveValIfMatchElseNegative<MiddleNonconformism, ConformismNonconformism>(midRadicalism, scs.ConformismNonconformism);
    //        if (KnownCharacterTrait<NormativityOfBehaviour>())
    //            res += PositiveValIfLessOrEqualElseNegative(midRadicalism, scs.NormativityOfBehaviour, tcs.NormativityOfBehaviour);
    //        if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
    //            res += PositiveValIfLessOrEqualElseNegative(midRadicalism, scs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);
    //        return res;
    //    }

    //    public override bool HasImportanceFor(HighAnxiety highAnxiety) => true;

    //    public override bool HasImportanceFor(MiddleRadicalism middleRadicalism) => true;

    //    public override bool HasImportanceFor(LowRadicalism lowRadicalism) => true;

    //    public override bool HasImportanceFor(HighRadicalism highRadicalism) => true;

    //    public override bool HasImportanceFor(HighSuspicion highSuspicion) => true;
    //    public override bool HasImportanceFor(LowSuspicion highSuspicion) => true;

    //    public override float GetImportanceValueFor(LowSuspicion lowSuspicion)
    //    {
    //        throw new System.NotImplementedException();
    //    }
    //}
}