namespace BehaviourModel
{
    /// <summary>
    /// Товарищ - близкий по роду деятельности, занятий, по условиям жизни
    /// и т. п. и связанный общностью взглядов.
    /// </summary>
    public class ComradeRelationship : FellowRelationship
    {
        public ComradeRelationship(AgentBase thisAgent, AgentBase secondAgent) : base(thisAgent, secondAgent)
        {
        }

        public override float GetImportanceValueFor(HighRadicalism highRadicalism)
        {
            float res = default;
            var cs = SecondAgent.CharacterSystem;
            var tcs = ThisAgent.CharacterSystem;
            if (KnownCharacterTrait<ConservatismRadicalism>())
                res += PositiveValIfMoreOrEqual(highRadicalism, cs.ConservatismRadicalism, tcs.ConservatismRadicalism);
            if (KnownCharacterTrait<ConformismNonconformism>())
                res += PositiveValIfMoreOrEqual(highRadicalism, cs.ConformismNonconformism, tcs.ConformismNonconformism);
            if (KnownCharacterTrait<Intelligence>())
                res += PositiveValIfMoreOrEqual(highRadicalism, cs.Intelligence, tcs.Intelligence);
            if (KnownCharacterTrait<NormativityOfBehaviour>())
                res += NegativeValIfMatch<HighNormativityOfBehaviour, NormativityOfBehaviour>(highRadicalism, cs.NormativityOfBehaviour);
            if (KnownCharacterTrait<TimidityCourage>())
                res += PositiveValIfMatchT1NegativeIfMatchT2<HighCourage, LowCourage, TimidityCourage>(highRadicalism, cs.TimidityCourage);
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
                res += PositiveValIfMatch<LowRadicalism, ConservatismRadicalism>(lowRadicalism, scs.ConservatismRadicalism);
            if (KnownCharacterTrait<ConformismNonconformism>())
                res += PositiveValIfLess(lowRadicalism, scs.ConformismNonconformism, tcs.ConformismNonconformism);
            if (KnownCharacterTrait<Intelligence>())
                res += PositiveValIfLessOrEqualElseNegative(lowRadicalism, scs.Intelligence, tcs.Intelligence);
            if (KnownCharacterTrait<NormativityOfBehaviour>())
                res += PositiveValIfMatch<HighNormativityOfBehaviour, NormativityOfBehaviour>(lowRadicalism, scs.NormativityOfBehaviour);
            var cont = MatchFeaturesCount<PlayActivityBase>();
            cont += MatchFeaturesCount<CommunicationActivityBase>();
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
                res += PositiveValIfMatchElseNegative<MiddleRadicalism, ConservatismRadicalism>(midRadicalism, scs.ConservatismRadicalism);
            if (KnownCharacterTrait<ConformismNonconformism>())
                res += PositiveValIfMatch<MiddleNonconformism, ConformismNonconformism>(midRadicalism, scs.ConformismNonconformism);
            if (KnownCharacterTrait<NormativityOfBehaviour>())
                res += PositiveValIfMatch<MiddleNormativityOfBehaviour, NormativityOfBehaviour>(midRadicalism, scs.NormativityOfBehaviour);
            var count = MatchFeaturesCount<ActivityFeatureBase>();
            if (count>0)
                res += count * midRadicalism.CharacterValue;
            return res;
        }

        public override bool HasImportanceFor(MiddleRadicalism middleRadicalism) => true;

        public override bool HasImportanceFor(LowRadicalism lowRadicalism) => true;

        public override bool HasImportanceFor(HighRadicalism highRadicalism) => true;
    }
}