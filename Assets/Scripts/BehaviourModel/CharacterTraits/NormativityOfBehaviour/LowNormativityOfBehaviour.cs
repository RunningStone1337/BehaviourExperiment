using Core;

namespace BehaviourModel
{
    /// <summary>
    /// Низкая нормативность
    /// </summary>
    public sealed class LowNormativityOfBehaviour : NormativityOfBehaviour
    {
        public override void Initiate(int characterValue, AgentBase agent)
        {
            base.Initiate(characterValue, agent);
            ImportanceInfluencHandlersDict.Add(typeof(EmotionBase), 2 * CharacterValue);

            ImportanceInfluencHandlersDict.Add(typeof(LessonEvent), -3 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(BreakEvent), 3 * CharacterValue);

            ImportanceInfluencHandlersDict.Add(typeof(EducationalActivityBase), -3 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(PlayActivityBase), 3 * CharacterValue);
        }

        /// <summary>
        /// Я оторва. Если ты скучный и любишь правила, ты не интересен.
        /// Мы знакомы? Если нет, я тебя скорее всего достану. Если да, какие ун ас отошения?
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;
    }
}