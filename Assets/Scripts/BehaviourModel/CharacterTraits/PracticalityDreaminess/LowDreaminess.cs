using Core;

namespace BehaviourModel
{
    /// <summary>
    /// Низкая мечтательность = практичность
    /// </summary>
    public sealed class LowDreaminess : PracticalityDreaminess
    {
        /// <summary>
        ///Мы знакомы? Если да, какие у нас общие интересы и взгляды на жизнь?
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;

        public override void Initiate(int characterValue, AgentBase agent)
        {
            base.Initiate(characterValue, agent);

            ImportanceInfluencHandlersDict.Add(typeof(LessonEvent), 1 * CharacterValue);

            ImportanceInfluencHandlersDict.Add(typeof(PracticalActivityBase), 3 * CharacterValue);
        }
    }
}