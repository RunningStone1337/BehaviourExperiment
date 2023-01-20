using Core;

namespace BehaviourModel
{
    /// <summary>
    /// Средний интеллект
    /// </summary>
    public sealed class MiddleIntelligence : Intelligence
    {
        /// <summary>
        /// Я середняк хорошист, по настроению отличник.
        /// Мы знакомы? Если нет, это не важно.
        /// Если да, какие у нас отношения?
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;

        public override void Initiate(int characterValue, AgentBase agent)
        {
            base.Initiate(characterValue, agent);

            ImportanceInfluencHandlersDict.Add(typeof(LessonEvent), 1 * CharacterValue);

            ImportanceInfluencHandlersDict.Add(typeof(EducationalActivityBase), 1 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(PlayActivityBase), 1 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(PracticalActivityBase), 1 * CharacterValue);
        }
    }
}