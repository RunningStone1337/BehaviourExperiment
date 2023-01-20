using Core;

namespace BehaviourModel
{
    /// <summary>
    /// Высокая мечтательность
    /// </summary>
    public sealed class HighDreaminess : PracticalityDreaminess
    {
        /// <summary>
        /// Мы знакомы? Если да, какие у нас отношения?
        /// Если нет, скорее всего внутренний мир интереснее тебя.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;

        public override void Initiate(int characterValue, AgentBase agent)
        {
            base.Initiate(characterValue, agent);
            ImportanceInfluencHandlersDict.Add(typeof(BreakEvent), 1 * CharacterValue);

            ImportanceInfluencHandlersDict.Add(typeof(PracticalActivityBase), -3 * CharacterValue);
        }
    }
}