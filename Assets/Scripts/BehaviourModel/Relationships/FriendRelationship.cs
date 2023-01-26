namespace BehaviourModel
{
    /// <summary>
    /// Друг - наивысшая степень доверия.
    /// </summary>
    public class FriendRelationship : ComradeRelationship
    {
        public FriendRelationship(AgentBase thisAgent, AgentBase secondAgent) : base(thisAgent, secondAgent)
        {
        }

        public override float GetImportanceValueFor(HighRadicalism highRadicalism)
        {
            float res = default;
            var cs = SecondAgent.CharacterSystem;
            var tcs = ThisAgent.CharacterSystem;
            //можем оценивать только известные черты характера!
            if (KnownCharacterTrait<ConservatismRadicalism>())
                res += PositiveValIfMoreOrEqualElseNegative(highRadicalism, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
            if (KnownCharacterTrait<ConformismNonconformism>())
                res += PositiveValIfMoreOrEqual(highRadicalism, cs.ConformismNonconformism, tcs.ConformismNonconformism);
            if (KnownCharacterTrait<TimidityCourage>())
                res += PositiveValIfMatchT1NegativeIfMatchT2<HighCourage , LowCourage, TimidityCourage>(highRadicalism, cs.TimidityCourage);
            //наличие обучающих увлечений - +
            int featuresCount = MatchFeaturesCount<EducationalActivityBase>();
            if (featuresCount > 0)
                res += featuresCount * highRadicalism.CharacterValue;
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
            if (KnownCharacterTrait<NormativityOfBehaviour>())
                res += PositiveValIfMatch<HighNormativityOfBehaviour, NormativityOfBehaviour>(lowRadicalism, scs.NormativityOfBehaviour);
            var cont = MatchFeaturesCount<PlayActivityBase>();
            cont += MatchFeaturesCount<CommunicationActivityBase>();
            cont += MatchFeaturesCount<PracticalActivityBase>();
            if (cont > 0)
                res += cont * lowRadicalism.CharacterValue;
            return res;
        }

        public override float GetImportanceValueFor(MiddleRadicalism midRadicalism)
        {
            float res = default;
            var scs = SecondAgent.CharacterSystem;
            var tcs = ThisAgent.CharacterSystem;
            //можем оценивать только известные черты характера!
            if (KnownCharacterTrait<ConservatismRadicalism>())
                res += PositiveValIfMatch<MiddleRadicalism, ConservatismRadicalism>(midRadicalism, scs.ConservatismRadicalism);
            if (KnownCharacterTrait<ConformismNonconformism>())
                res += PositiveValIfMatch<MiddleNonconformism, ConformismNonconformism>(midRadicalism, scs.ConformismNonconformism);
            if (KnownCharacterTrait<NormativityOfBehaviour>())
                res += PositiveValIfMatch<MiddleNormativityOfBehaviour, NormativityOfBehaviour>(midRadicalism, scs.NormativityOfBehaviour);
            var count = MatchFeaturesCount<ActivityFeatureBase>();
            if (count > 0)
                res += count * midRadicalism.CharacterValue;
            return res;
        }

        public override bool HasImportanceFor(LowRadicalism lowRadicalism) => true;

        public override bool HasImportanceFor(HighRadicalism highRadicalism) => true;

        public override bool HasImportanceFor(MiddleRadicalism middleRadicalism) => true;
    }
}