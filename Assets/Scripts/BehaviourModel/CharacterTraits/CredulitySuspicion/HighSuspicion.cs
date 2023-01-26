namespace BehaviourModel
{
    /// <summary>
    /// Подозрительность
    /// </summary>
    public sealed class HighSuspicion : CredulitySuspicion
    {
        protected override float CalculateImportanceForFamiliar(AgentBase agent)
        {
            float res = default;
            var currentRelation = ThisAgent.GetCurrentRelationTo(agent);
            if (currentRelation.HasImportanceFor(this))
                res += currentRelation.GetImportanceValueFor(this);
            return res;
        }

        /// <summary>
        /// Я не сильно доверяю людям.
        /// Мы знакомы? Если да, то ты должен быть моим хорошим другом или хотя
        /// бы старым знакомым, чтобы я проявил интерес, иначе ты не нужен.
        /// Если нет, я точно не буду проявлять к тебе интерес.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;

        public override void Initiate(int characterValue, AgentBase agent)
        {
            base.Initiate(characterValue, agent);
            ImportanceInfluencHandlersDict.Add(typeof(EmotionBase), -1 * CharacterValue);

            ImportanceInfluencHandlersDict.Add(typeof(CommunicationActivityBase), -1 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(EducationalActivityBase), -1 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(PlayActivityBase), -1 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(PracticalActivityBase), -1 * CharacterValue);
        }
    }
}