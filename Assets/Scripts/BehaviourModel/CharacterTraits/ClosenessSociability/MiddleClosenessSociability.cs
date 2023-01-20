using Core;

namespace BehaviourModel
{
    /// <summary>
    /// —редн€€ общительность
    /// </summary>
    public sealed class MiddleClosenessSociability : ClosenessSociability
    {
        /// <summary>
        /// я не лидер и не изгой, общаюсь со всеми понемногу.
        /// ћы знакомы? ≈сли нет, € скорее всего про€влю интерес.
        /// ≈сли да, какие у нас отношени€ и общие интересы?
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;

        public override void Initiate(int characterValue, AgentBase agent)
        {
            base.Initiate(characterValue, agent);

            ImportanceInfluencHandlersDict.Add(typeof(LessonEvent), 1 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(BreakEvent), 1 * CharacterValue);

            ImportanceInfluencHandlersDict.Add(typeof(EducationalActivityBase), 1 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(PlayActivityBase), 1 * CharacterValue);
        }
    }
}