namespace BehaviourModel
{
    /// <summary>
    /// Средняя напряжённость
    /// </summary>
    public sealed class MiddleTension : RelaxationTension
    {
        public override void Initiate(int characterValue,AgentBase agent)
        {
            base.Initiate(characterValue, agent);

            ImportanceInfluencHandlersDict.Add(typeof(CommunicationActivityBase), 1 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(EducationalActivityBase), 1 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(PlayActivityBase), 1 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(PracticalActivityBase), 1 * CharacterValue);
        }

        /// <summary>
        /// Моя нервная система сбалансирована.
        /// Если ты не выделяешься, ты не интересен.
        /// Если привлекаешь внимание в рамках приличия, я могу проявить интерес.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;
    }
}