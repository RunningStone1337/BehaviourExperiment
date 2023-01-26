namespace BehaviourModel
{
    /// <summary>
    /// Неприятель - человек неприятен, вызывает негативную реакцию,
    /// но это ещё не конец - можно исправить ситуацию в лучшую или худшую сторону.
    /// </summary>
    public class FoeRelationship : NegativeRelationshipBase
    {
        public FoeRelationship(AgentBase thisAgent, AgentBase secondAgent) : base(thisAgent, secondAgent)
        {
        }

        public override float GetImportanceValueFor(HighRadicalism highRadicalism)
        {
            float res = default;
            var cs = SecondAgent.CharacterSystem;
            var tcs = ThisAgent.CharacterSystem;
            //можем оценивать только известные черты характера!
            if (KnownCharacterTrait<ConservatismRadicalism>())
                res += PositiveValIfLess(highRadicalism, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
            if (KnownCharacterTrait<ConformismNonconformism>())
                res += NegativeValIfLess(highRadicalism, cs.ConformismNonconformism, tcs.ConformismNonconformism);
            if (KnownCharacterTrait<Intelligence>())
                res += NegativeValIfLess(highRadicalism, cs.Intelligence, tcs.Intelligence);
            if (KnownCharacterTrait<NormativityOfBehaviour>())
                res += PositiveValIfMatchT1NegativeIfMatchT2<LowNormativityOfBehaviour, HighNormativityOfBehaviour, NormativityOfBehaviour>(highRadicalism, cs.NormativityOfBehaviour);
            if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
                res += NegativeValIfMatch<HighDiplomacy, StraightforwardnessDiplomacy>(highRadicalism, cs.StraightforwardnessDiplomacy);
            if (KnownCharacterTrait<TimidityCourage>())
                res += PositiveValIfMatchT1NegativeIfMatchT2<HighCourage, LowCourage, TimidityCourage>(highRadicalism, cs.TimidityCourage);
            return res;
        }

        public override float GetImportanceValueFor(LowRadicalism lowRadicalism)
        {
            float res = default;
            var scs = SecondAgent.CharacterSystem;
            var tcs = ThisAgent.CharacterSystem;
            if (KnownCharacterTrait<ConservatismRadicalism>())
                res += PositiveValIfMatchNegativeIfMore<LowRadicalism, ConservatismRadicalism>(lowRadicalism, scs.ConservatismRadicalism, tcs.ConservatismRadicalism);
            if (KnownCharacterTrait<ConformismNonconformism>())
                res += NegativeValIfMore(lowRadicalism, scs.ConformismNonconformism, tcs.ConformismNonconformism);
            if (KnownCharacterTrait<Intelligence>())
                res += NegativeValIfMore(lowRadicalism, scs.Intelligence, tcs.Intelligence);
            if (KnownCharacterTrait<NormativityOfBehaviour>())
                res += NegativeValIfMatch<LowNormativityOfBehaviour, NormativityOfBehaviour>(lowRadicalism, scs.NormativityOfBehaviour);
            return res;
        }

        public override float GetImportanceValueFor(MiddleRadicalism midRadicalism)
        {
            float res = default;
            var scs = SecondAgent.CharacterSystem;
            var tcs = ThisAgent.CharacterSystem;
            //можем оценивать только известные черты характера!
            if (KnownCharacterTrait<ConservatismRadicalism>())
                res += PositiveValIfMatchElseNegative<MiddleRadicalism, ConservatismRadicalism>(midRadicalism, scs.ConservatismRadicalism);
            if (KnownCharacterTrait<NormativityOfBehaviour>())
                res += NegativeValIfLess(midRadicalism, scs.NormativityOfBehaviour, tcs.NormativityOfBehaviour);
            return res;
        }

        public override bool HasImportanceFor(MiddleRadicalism middleRadicalism) => true;

        public override bool HasImportanceFor(HighRadicalism highRadicalism) => true;

        public override bool HasImportanceFor(LowRadicalism lowRadicalism) => true;
    }
}