using Core;

namespace BehaviourModel
{
    /// <summary>
    /// Высокая напряженность
    /// </summary>
    public sealed class HighTension : RelaxationTension
    {
        /// <summary>
        /// Я мотивированный, легок на подъём, заинтересованный.
        /// Мы знакомы? Если да, насколько ты активен? Если не похожи, мы не поладим.
        /// Если нет, скорее всего я проявлю инициативу.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab)
        {
            throw new System.NotImplementedException();
        }

        public override void Initiate(int characterValue, AgentBase agent)
        {
            base.Initiate(characterValue, agent);

            ImportanceInfluencHandlersDict.Add(typeof(LessonEvent), 3 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(BreakEvent), 3 * CharacterValue);

            ImportanceInfluencHandlersDict.Add(typeof(CommunicationActivityBase), 3 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(EducationalActivityBase), 3 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(PlayActivityBase), 3 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(PracticalActivityBase), 3 * CharacterValue);
        }
    }
}