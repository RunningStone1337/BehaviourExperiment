namespace BehaviourModel
{
    /// <summary>
    /// Подчинённость
    /// </summary>
    public sealed class LowDomination : SubordinationDomination
    {
        /// <summary>
        /// Я маленький человек. С радостью сделаю всё что скажете,
        /// отпор обидчику дать не могу в принципе.
        /// Мы знакомы? Если да, сделаю всё, только не обижай меня.
        /// Если нет, будем дружить.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;

        public override void Initiate(int characterValue, AgentBase agent)
        {
            base.Initiate(characterValue, agent);
            ImportanceInfluencHandlersDict.Add(typeof(IAgressiveEmotion), 1 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(NegativeEmotionBase), 1 * CharacterValue);
        }
    }
}