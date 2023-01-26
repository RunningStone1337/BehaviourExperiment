namespace BehaviourModel
{
    /// <summary>
    /// Враг - отношения у нас не сложились и вряд ли это изменится.
    /// </summary>
    public class EnemyRelationship : FoeRelationship
    {
        public EnemyRelationship(AgentBase thisAgent, AgentBase secondAgent) : base(thisAgent, secondAgent)
        {
        }

        public override float GetImportanceValueFor(HighRadicalism highRadicalism)
        {
            float res = default;
            var cs = SecondAgent.CharacterSystem;
            var tcs = ThisAgent.CharacterSystem;
            //можем оценивать только известные черты характера!
            if (KnownCharacterTrait<ConservatismRadicalism>())
                res -= highRadicalism.CharacterValue;
            if (KnownCharacterTrait<ConformismNonconformism>())
                res += NegativeValIfLess(highRadicalism, cs.ConformismNonconformism, tcs.ConformismNonconformism);
            if (KnownCharacterTrait<Intelligence>())
                res += NegativeValIfLess(highRadicalism, cs.Intelligence, tcs.Intelligence);
            if (KnownCharacterTrait<NormativityOfBehaviour>())
                res += PositiveValIfMatchT1NegativeIfMatchT2<LowNormativityOfBehaviour, HighNormativityOfBehaviour, NormativityOfBehaviour>(highRadicalism, cs.NormativityOfBehaviour);
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
                res += NegativeValIfMore(lowRadicalism, scs.ConservatismRadicalism, tcs.ConservatismRadicalism);
            if (KnownCharacterTrait<ConformismNonconformism>())
                res += NegativeValIfMore(lowRadicalism, scs.ConformismNonconformism, tcs.ConformismNonconformism);
            if (KnownCharacterTrait<Intelligence>())
                res += NegativeValIfMore(lowRadicalism, scs.Intelligence, tcs.Intelligence);
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
            return res;
        }
        public override bool HasImportanceFor(MiddleRadicalism middleRadicalism) => true;
        
        public override bool HasImportanceFor(LowRadicalism lowRadicalism) => true;

        public override bool HasImportanceFor(HighRadicalism highRadicalism) => true;
    }
}