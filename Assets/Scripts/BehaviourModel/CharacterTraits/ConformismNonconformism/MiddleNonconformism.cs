namespace BehaviourModel
{
    /// <summary>
    /// Средний нонкомформизс
    /// </summary>
    public sealed class MiddleNonconformism : ConformismNonconformism
    {
        /// <summary>
        /// Я центрист.
        /// Мы знакомы? Если да, я буду относиться к тебе без предрассудков если ты относишься ко мне так же.
        /// Если нет, ты не интересен.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab)
        {
            throw new System.NotImplementedException();
        }
    }
}