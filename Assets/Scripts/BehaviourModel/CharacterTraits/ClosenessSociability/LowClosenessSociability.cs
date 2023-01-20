using Core;

namespace BehaviourModel
{
    /// <summary>
    /// Замкнутость
    /// </summary>
    public sealed class LowClosenessSociability : ClosenessSociability
    {
        /// <summary>
        /// Я не очень общительный. Ты не исключение.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => false;

        public override void Initiate(int characterValue, AgentBase agent)
        {
            base.Initiate(characterValue, agent);
            ImportanceInfluencHandlersDict.Add(typeof(IAgressiveEmotion), 1 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(NegativeEmotionBase), 1 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(ISubordinationEmotion), -1 * CharacterValue);

            ImportanceInfluencHandlersDict.Add(typeof(LessonEvent), -1 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(BreakEvent), -1 * CharacterValue);

            ImportanceInfluencHandlersDict.Add(typeof(CommunicationActivityBase), -2 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(EducationalActivityBase), 2 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(PlayActivityBase), 1 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(PracticalActivityBase), 1 * CharacterValue);
        }
    }
}