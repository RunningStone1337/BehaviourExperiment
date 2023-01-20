namespace BehaviourModel
{
    /// <summary>
    /// Высокая экспрессивность.
    /// </summary>
    public sealed class HighExpressiveness : RestraintExpressiveness
    {
        /// <summary>
        /// Я очень вспыльчив. Могу отреагировать на тебя, если ты чем-то сильно привлечёшь моё внимание.
        /// Особенно если мы знакомы. Если нет, я буду проявлять разные знаки внимания.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;

        public override void Initiate(int characterValue, AgentBase agent)
        {
            base.Initiate(characterValue, agent);
            ImportanceInfluencHandlersDict.Add(typeof(EmotionBase), 3 * CharacterValue);
        }
    }
}