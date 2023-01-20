using Core;

namespace BehaviourModel
{
    /// <summary>
    /// –асслабленность
    /// </summary>
    public sealed class LowTension : RelaxationTension
    {
        public override void Initiate(int characterValue, AgentBase agent)
        {
            base.Initiate(characterValue, agent);

            ImportanceInfluencHandlersDict.Add(typeof(LessonEvent), -3 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(BreakEvent), -3 * CharacterValue);

            ImportanceInfluencHandlersDict.Add(typeof(CommunicationActivityBase), -3 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(EducationalActivityBase), -3 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(PlayActivityBase), -3 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(PracticalActivityBase), -3 * CharacterValue);
        }

        /// <summary>
        /// я расслаблен, низко мотивирован, не возбудим. 
        /// ¬р€д ли € про€влю инициативу когда-либо.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => false;
    }
}