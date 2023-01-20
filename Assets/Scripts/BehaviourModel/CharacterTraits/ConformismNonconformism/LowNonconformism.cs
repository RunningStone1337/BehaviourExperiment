using Core;

namespace BehaviourModel
{
    /// <summary>
    /// Конформизм, низкая независимость
    /// </summary>
    public sealed class LowNonconformism : ConformismNonconformism
    {
        /// <summary>
        /// Я социально зависим. Мне важно, чтобы ты думал обо мне хорошо.
        /// Мы знакомы? Если нет, я постараюсь произвести хорошее впечатление.
        /// Буду вести себя как от меня ожидается.
        /// Если знакомы, какие у нас отношения?
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