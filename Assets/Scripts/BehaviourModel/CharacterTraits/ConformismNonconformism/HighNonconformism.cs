using Core;

namespace BehaviourModel
{
    /// <summary>
    /// Нонконформист
    /// </summary>
    public sealed class HighNonconformism : ConformismNonconformism
    {
        /// <summary>
        /// У меня на всё своё особенное мнение и если твоё не совпадает с ним -
        /// ты не интересен.
        /// Мы знакомы? Если нет, так и должно быть. Если да - ты со мной или против меня?
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;

        public override void Initiate(int characterValue, AgentBase agent)
        {
            base.Initiate(characterValue, agent);
            ImportanceInfluencHandlersDict.Add(typeof(LessonEvent), 1 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(BreakEvent), 1 * CharacterValue);
        }
    }
}