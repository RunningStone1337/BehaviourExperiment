namespace BehaviourModel
{
    /// <summary>
    /// Знакомый - недостаточно информации для точной классификации друг/враг/приятель/товарищь/неприятель.
    /// Здесь происходит первичная основная оценка значимости.
    /// </summary>
    public class FamiliarRelationship : RelationshipBase
    {
        public FamiliarRelationship(AgentBase thisAgent, AgentBase secondAgent) : base(thisAgent, secondAgent)
        {
        }

        public override float GetImportanceValueFor(HighRadicalism highRadicalism)
        {
            float res = default;
            var cs = SecondAgent.CharacterSystem;
            var tcs = ThisAgent.CharacterSystem;
            //можем оценивать только известные черты характера!
            if (KnownCharacterTrait<ConservatismRadicalism>())
                res += PositiveValIfLessOrEqualElseNegative(highRadicalism, cs.ConservatismRadicalism, highRadicalism);
            if (KnownCharacterTrait<ConformismNonconformism>())
                res += PositiveValIfMoreOrEqualElseNegative(highRadicalism, cs.ConformismNonconformism, tcs.ConformismNonconformism);
            if (KnownCharacterTrait<Intelligence>())
                res += PositiveValIfMoreOrEqualElseNegative(highRadicalism, cs.Intelligence, tcs.Intelligence);
            if (KnownCharacterTrait<NormativityOfBehaviour>())
                res += PositiveValIfMatchT1NegativeIfMatchT2< LowNormativityOfBehaviour, HighNormativityOfBehaviour, NormativityOfBehaviour>(highRadicalism, cs.NormativityOfBehaviour);
            if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
                res += PositiveValIfMatchT1NegativeIfMatchT2<LowDiplomacy, HighDiplomacy, StraightforwardnessDiplomacy>(highRadicalism, cs.StraightforwardnessDiplomacy);
            if (KnownCharacterTrait<TimidityCourage>())
                res += PositiveValIfMatchT1NegativeIfMatchT2<HighCourage, LowCourage, TimidityCourage>(highRadicalism, cs.TimidityCourage);
            return res;
        }

        public override float GetImportanceValueFor(LowRadicalism lowRadicalism)
        {
            float res = default;
            var scs = SecondAgent.CharacterSystem;
            var tcs = ThisAgent.CharacterSystem;
            //можем оценивать только известные черты характера!
            if (KnownCharacterTrait<ConservatismRadicalism>())
                res += PositiveValIfMatchNegativeIfMore<LowRadicalism, ConservatismRadicalism>(lowRadicalism, scs.ConservatismRadicalism, tcs.ConservatismRadicalism);
            if (KnownCharacterTrait<ConformismNonconformism>())
                res += PositiveValIfLessNegativeIfMore(lowRadicalism, scs.ConformismNonconformism, tcs.ConformismNonconformism);
            if (KnownCharacterTrait<Intelligence>())
                res += PositiveValIfLessOrEqualElseNegative(lowRadicalism, scs.Intelligence, tcs.Intelligence);
            if (KnownCharacterTrait<NormativityOfBehaviour>())
                res += PositiveValIfMatchT1NegativeIfMatchT2<HighNormativityOfBehaviour, LowNormativityOfBehaviour, NormativityOfBehaviour>(lowRadicalism, scs.NormativityOfBehaviour);
            if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
                res += PositiveValIfMatchT1NegativeIfMatchT2<HighDiplomacy, LowDiplomacy, StraightforwardnessDiplomacy>(lowRadicalism, scs.StraightforwardnessDiplomacy);
            return res;
        }

        public override float GetImportanceValueFor(MiddleRadicalism midRadicalism)
        {
            float res = default;
            var scs = SecondAgent.CharacterSystem;
            var tcs = ThisAgent.CharacterSystem;
            if (KnownCharacterTrait<ConservatismRadicalism>())
                res += PositiveValIfMatchElseNegative<MiddleRadicalism, ConservatismRadicalism>(midRadicalism, scs.ConservatismRadicalism);
            if (KnownCharacterTrait<ConformismNonconformism>())
                res += PositiveValIfMatchElseNegative<MiddleNonconformism, ConformismNonconformism>(midRadicalism, scs.ConformismNonconformism);
            if (KnownCharacterTrait<NormativityOfBehaviour>())
                res += PositiveValIfMoreOrEqualElseNegative(midRadicalism, scs.NormativityOfBehaviour, tcs.NormativityOfBehaviour);
            if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
                res += PositiveValIfMoreOrEqualElseNegative(midRadicalism, scs.StraightforwardnessDiplomacy, tcs.StraightforwardnessDiplomacy);
            return res;
        }

        //public override float GetImportanceValueFor(HighAnxiety highAnxiety)
        //{
        //    throw new System.Exception();
        //}

        public override bool HasImportanceFor(HighRadicalism highRadicalism) => true;

        public override bool HasImportanceFor(LowRadicalism lowRadicalism) => true;

        public override bool HasImportanceFor(MiddleRadicalism middleRadicalism) => true;

        //public override bool HasImportanceFor(HighAnxiety highAnxiety) => true;
    }
}