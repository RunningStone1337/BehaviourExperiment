using Core;

namespace BehaviourModel
{
    /// <summary>
    /// Умеренная стабильность
    /// </summary>
    public sealed class MiddleEmotionalStability : EmotionalInstabilityStability
    {
        /// <summary>
        /// Я умеренно эмоционален. Новый опыт может заинтересовать, но не часто.
        /// На стресс реагирую активно, но могу и погорячиться.
        /// Мы знакомы? Если да, то насколько ты адекватен? 
        /// Нет - не инетерсуешь.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;

        public override void Initiate(int characterValue, AgentBase agent)
        {
            base.Initiate(characterValue, agent);

            ImportanceInfluencHandlersDict.Add(typeof(LessonEvent), -1 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(BreakEvent), -1 * CharacterValue);

            ImportanceInfluencHandlersDict.Add(typeof(CommunicationActivityBase), 1 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(EducationalActivityBase), 1 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(PlayActivityBase), 1 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(PracticalActivityBase), 1 * CharacterValue);
        }
    }
}