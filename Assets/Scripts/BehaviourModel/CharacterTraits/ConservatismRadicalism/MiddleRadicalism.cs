namespace BehaviourModel
{
    public sealed class MiddleRadicalism : ConservatismRadicalism
    {
        /// <summary>
        /// Мне, в целом, всё равно каких ты убеждений, взглядов и веры.
        /// Высокие стремления, споры и выяснение кто прав меня не интересует.
        /// Если будешь мне что-то доказывать, я не буду слушать - может, ты и прав, но 
        /// мне всё равно. 
        /// Мы знакомы? Если да, то какие у нас отношения? Если хорошие - может и пообщаемся,
        /// только не умничай.
        /// Нет - не интересен.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;
    }
}