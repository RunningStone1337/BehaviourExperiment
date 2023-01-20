using Core;

namespace BehaviourModel
{
    /// <summary>
    /// Низкая стабильность
    /// </summary>
    public sealed class LowEmotionalStability : EmotionalInstabilityStability
    {
        /// <summary>
        /// У меня семь пятниц на неделе. Даже если мы не ладим, я могу что-нибудь
        /// отчебучить. Если дружим - можем легко поссориться по мелочи.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;

        public override void Initiate(int characterValue, AgentBase agent)
        {
            base.Initiate(characterValue, agent);
            ImportanceInfluencHandlersDict.Add(typeof(EmotionBase), 2 * CharacterValue);

            ImportanceInfluencHandlersDict.Add(typeof(LessonEvent), 2 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(BreakEvent), 2 * CharacterValue);

            ImportanceInfluencHandlersDict.Add(typeof(CommunicationActivityBase), 2 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(EducationalActivityBase), -2 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(PlayActivityBase), 2 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(PracticalActivityBase), -2 * CharacterValue);
        }
    }
}