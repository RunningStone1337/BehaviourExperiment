namespace BehaviourModel
{
    /// <summary>
    /// Умеренная подозрительность
    /// </summary>
    public sealed class MiddleSuspicion : CredulitySuspicion
    {
        /// <summary>
        /// В основном мне нравятся люди и я не жду от них подвоха.
        /// Даже если такое случается, я не обобщаю это на остальных.
        /// Так что если мы знакомы и ты меня не обманывал и не проявлял
        /// враждебности, мы поладим. Если не знакомы - можно познакомиться. 
        /// При случае.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;
    }
}