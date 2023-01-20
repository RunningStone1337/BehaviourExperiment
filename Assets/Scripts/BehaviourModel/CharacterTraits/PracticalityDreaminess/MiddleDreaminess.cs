namespace BehaviourModel
{
    /// <summary>
    /// Умеренная мечтательность
    /// </summary>
    public sealed class MiddleDreaminess : PracticalityDreaminess
    {
        /// <summary>
        /// Мы знакомы? Если нет, не интересен.
        /// Если да, какие отношения?
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;
    }
}