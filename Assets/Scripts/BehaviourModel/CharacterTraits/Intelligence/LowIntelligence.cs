using Core;

namespace BehaviourModel
{
    /// <summary>
    /// Низкий интеллект
    /// </summary>
    public sealed class LowIntelligence : Intelligence
    {
        /// <summary>
        /// Я плохо обучаем и мало интересуюсь сложными вещами. Если что-то
        /// не получается, меня это раздражает.
        /// Мы знакомы? Какие у нас отношения?
        /// Если нет, можем подружиться.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;

        public override void Initiate(int characterValue, AgentBase agent)
        {
            base.Initiate(characterValue, agent);

            ImportanceInfluencHandlersDict.Add(typeof(LessonEvent), -2 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(BreakEvent), 2 * CharacterValue);

            ImportanceInfluencHandlersDict.Add(typeof(EducationalActivityBase), -3 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(PlayActivityBase), 3 * CharacterValue);
        }
    }
}