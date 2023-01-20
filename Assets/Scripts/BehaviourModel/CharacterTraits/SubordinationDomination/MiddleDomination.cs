namespace BehaviourModel
{
    /// <summary>
    /// Средняя доминантность
    /// </summary>
    public sealed class MiddleDomination : SubordinationDomination
    {
        /// <summary>
        /// Могу за себя постоять, но сам вряд ли буду что-то доказывать кому-то.
        /// Мы знакомы? Если да, то какие у нас отношения? Если враждуем, я буду за тобой приглядывать.
        /// Если нет - не интересен.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;
    }
}