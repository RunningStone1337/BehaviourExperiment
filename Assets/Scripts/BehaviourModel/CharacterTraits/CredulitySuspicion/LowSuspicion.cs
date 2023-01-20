namespace BehaviourModel
{
    /// <summary>
    /// Доверчивость
    /// </summary>
    public sealed class LowSuspicion : CredulitySuspicion
    {
        /// <summary>
        /// Я очень доверчив. Все люди - братья.
        /// Хочу дружить со всеми.
        /// Мы знакомы? Если да, наверняка ты мой друг.
        /// Если нет - скоро им станешь.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;

        public override void Initiate(int characterValue, AgentBase agent)
        {
            base.Initiate(characterValue, agent);
            ImportanceInfluencHandlersDict.Add(typeof(EmotionBase), 1 * CharacterValue);

            ImportanceInfluencHandlersDict.Add(typeof(CommunicationActivityBase), 1 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(EducationalActivityBase), 1 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(PlayActivityBase), 1 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(PracticalActivityBase), 1 * CharacterValue);
        }
    }
}