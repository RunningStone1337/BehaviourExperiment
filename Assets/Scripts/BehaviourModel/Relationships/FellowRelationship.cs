namespace BehaviourModel
{
    /// <summary>
    /// Приятель - первая стадия симпатии. "В принципе можно сотрудничать".
    /// </summary>
    public class FellowRelationship : PositiveRelationshipBase
    {
        public FellowRelationship(AgentBase thisAgent, AgentBase secondAgent) : base(thisAgent, secondAgent)
        {
        }

        public override float GetImportanceValueFor(HighRadicalism highRadicalism)
        {
            float res = default;
            var cs = SecondAgent.CharacterSystem;
            var tcs = ThisAgent.CharacterSystem;
            //можем оценивать только известные черты характера!
            if (KnownCharacterTrait<ConservatismRadicalism>())
                res += PositiveValIfMoreOrEqual(highRadicalism, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
            if (KnownCharacterTrait<ConformismNonconformism>())
                res += PositiveValIfMoreOrEqual(highRadicalism, cs.ConformismNonconformism, tcs.ConformismNonconformism);
            if (KnownCharacterTrait<Intelligence>())
                res += PositiveValIfMoreOrEqualElseNegative(highRadicalism, cs.Intelligence, tcs.Intelligence);
            if (KnownCharacterTrait<NormativityOfBehaviour>())
                res += NegativeValIfMatch<HighNormativityOfBehaviour, NormativityOfBehaviour > (highRadicalism, cs.NormativityOfBehaviour);
            if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
                res += PositiveValIfMatchT1NegativeIfMatchT2<LowDiplomacy, HighDiplomacy, StraightforwardnessDiplomacy>(highRadicalism, cs.StraightforwardnessDiplomacy);
            if (KnownCharacterTrait<TimidityCourage>())
                res += PositiveValIfMatch<HighCourage, TimidityCourage>(highRadicalism, cs.TimidityCourage);
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
                res += PositiveValIfLess(lowRadicalism, scs.ConformismNonconformism, tcs.ConformismNonconformism);
            if (KnownCharacterTrait<Intelligence>())
                res+=PositiveValIfLessOrEqual(lowRadicalism, scs.Intelligence, tcs.Intelligence);
            if (KnownCharacterTrait<NormativityOfBehaviour>())
                res+=PositiveValIfMatchT1NegativeIfMatchT2<HighNormativityOfBehaviour, LowNormativityOfBehaviour, NormativityOfBehaviour>(lowRadicalism, scs.NormativityOfBehaviour);
            if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
                res+=PositiveValIfMatchT1NegativeIfMatchT2<HighDiplomacy, LowDiplomacy, StraightforwardnessDiplomacy>(lowRadicalism, scs.StraightforwardnessDiplomacy);
            return res;
        }

        public override float GetImportanceValueFor(MiddleRadicalism midRadicalism)
        {
            float res = default;
            var scs = SecondAgent.CharacterSystem;
            var tcs = ThisAgent.CharacterSystem;
            //можем оценивать только известные черты характера!
            if (KnownCharacterTrait<ConservatismRadicalism>())
            {
                //уровень радикализма == - ++
                if (scs.ConservatismRadicalism is MiddleRadicalism)
                    res += midRadicalism.CharacterValue;
                else
                    res -= midRadicalism.CharacterValue;
            }
            if (KnownCharacterTrait<ConformismNonconformism>())
            {
                //уровень нонконформизма ниже чем у меня - +
                if (scs.ConformismNonconformism is MiddleNonconformism)
                    res += midRadicalism.CharacterValue;
                //уровень нонконформизма выше или ниже - -
                else
                    res -= midRadicalism.CharacterValue;
            }
            if (KnownCharacterTrait<NormativityOfBehaviour>())
            {
                //совпадает нормативность - -
                if (scs.NormativityOfBehaviour is MiddleNormativityOfBehaviour)
                    res += midRadicalism.CharacterValue;
                //высокая нормативность - +
                else if (scs.NormativityOfBehaviour < tcs.NormativityOfBehaviour)
                    res -= midRadicalism.CharacterValue;
            }
            if (KnownCharacterTrait<StraightforwardnessDiplomacy>())
            {
                //низкая дипломатичность - -
                if (scs.StraightforwardnessDiplomacy < tcs.StraightforwardnessDiplomacy)
                    res -= midRadicalism.CharacterValue;
                //высокая дипломатичность - +
                else if (scs.StraightforwardnessDiplomacy >= tcs.StraightforwardnessDiplomacy)
                    res += midRadicalism.CharacterValue;
            }
            return res;
        }

        public override bool HasImportanceFor(HighRadicalism highRadicalism) => true;

        public override bool HasImportanceFor(LowRadicalism lowRadicalism) => true;

        public override bool HasImportanceFor(MiddleRadicalism middleRadicalism) => true;
    }
}