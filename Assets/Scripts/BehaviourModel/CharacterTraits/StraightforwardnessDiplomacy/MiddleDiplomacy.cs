namespace BehaviourModel
{
    /// <summary>
    /// Умеренная дипломтичность
    /// </summary>
    public sealed class MiddleDiplomacy : StraightforwardnessDiplomacy
    {
        /// <summary>
        /// В зависимости от ситуации могу быть и прямым и учтивмым.
        /// Мы знакомы? Если нет, я скорее проигнорирую тебя.
        /// Если да, зависит от настроения.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab)
        {
            throw new System.NotImplementedException();
        }
    }
}