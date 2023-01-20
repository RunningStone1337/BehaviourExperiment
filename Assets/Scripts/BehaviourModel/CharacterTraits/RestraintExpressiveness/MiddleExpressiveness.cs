namespace BehaviourModel
{
    /// <summary>
    /// Умеренная экспрессивность
    /// </summary>
    public sealed class MiddleExpressiveness : RestraintExpressiveness
    {
        /// <summary>
        /// У меня умеренная избирательность партнеров по общению, по настроению.
        /// Мы знакомы? Скорее всего я проявлю интерес. Или нет. Зависит от левой пятки.
        /// Если нет, скорее всего не проявлю.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;

        public override void Initiate(int characterValue, AgentBase agent)
        {
            base.Initiate(characterValue, agent);
            ImportanceInfluencHandlersDict.Add(typeof(EmotionBase), 1 * CharacterValue);
        }
    }
}