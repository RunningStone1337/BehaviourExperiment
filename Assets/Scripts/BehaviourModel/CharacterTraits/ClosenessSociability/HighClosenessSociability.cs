using Core;

namespace BehaviourModel
{
    /// <summary>
    /// ¬ысока€ общительность
    /// </summary>
    public sealed class HighClosenessSociability : ClosenessSociability
    {
        /// <summary>
        /// я очень общительный.  онечно мне интересно с общатьс€, только если мы не враги.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;

        public override void Initiate(int characterValue, AgentBase agent)
        {
            base.Initiate(characterValue, agent);
            ImportanceInfluencHandlersDict.Add(typeof(PositiveEmotionBase), 1 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(NegativeEmotionBase), -1 * CharacterValue);

            ImportanceInfluencHandlersDict.Add(typeof(LessonEvent), 3 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(BreakEvent), 3 * CharacterValue);

            ImportanceInfluencHandlersDict.Add(typeof(CommunicationActivityBase), 2 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(EducationalActivityBase), -1 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(PlayActivityBase), 2 * CharacterValue);
        }
    }
}