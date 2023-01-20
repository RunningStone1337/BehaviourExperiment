namespace BehaviourModel
{
    /// <summary>
    /// Высокая эмоциональная стабильность
    /// </summary>
    public sealed class HighEmotionalStability : EmotionalInstabilityStability
    {
        public override void Initiate(int characterValue, AgentBase agent)
        {
            base.Initiate(characterValue, agent);
            ImportanceInfluencHandlersDict.Add(typeof(EmotionBase), -2 * CharacterValue);

            ImportanceInfluencHandlersDict.Add(typeof(CommunicationActivityBase), 1 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(EducationalActivityBase), 2 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(PlayActivityBase), 2 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(PracticalActivityBase), 2 * CharacterValue);
        }
        /// <summary>
        /// Я не испытываю перепадов настроений.
        /// Мы знакомы? Если да, говори по делу, я сосредоточен на важных делах.
        /// Если нет, не трать моё время.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => false;
    }
}