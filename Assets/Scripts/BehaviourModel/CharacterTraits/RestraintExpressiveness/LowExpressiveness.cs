namespace BehaviourModel
{
    /// <summary>
    /// Высокая сдержанность
    /// </summary>
    public sealed class LowExpressiveness : RestraintExpressiveness
    {
        /// <summary>
        /// Я очень избирателен в партнёрах.
        /// Мы знакомы? Если нет, ты должен меня очень заинтересовать.
        /// Если да, какие у нас отношения?
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab)
        {
            throw new System.NotImplementedException();
        }

        public override void Initiate(int characterValue, AgentBase agent)
        {
            base.Initiate(characterValue, agent);
            ImportanceInfluencHandlersDict.Add(typeof(EmotionBase), -3 * CharacterValue);
        }
    }
}