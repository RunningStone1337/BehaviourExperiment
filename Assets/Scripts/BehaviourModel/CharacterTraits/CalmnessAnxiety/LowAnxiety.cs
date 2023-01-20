using Core;

namespace BehaviourModel
{
    /// <summary>
    /// Низкая тревожность=спокойный
    /// </summary>
    public sealed class LowAnxiety : CalmnessAnxiety
    {
        /// <summary>
        /// Я спокоен как камень. По-настоящему, а не только показываю это.
        /// Какой он может вызывать интерес? Мы вообще знакомы?
        /// Если знакомы, то как давно и какие у нас отношения? В любом случае, он меня не сильно
        /// беспокоит.
        /// Если не знакомы, я не буду навязываться и проявлять инициативу.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => false;

        public override void Initiate(int characterValue, AgentBase agent)
        {
            base.Initiate(characterValue, agent);
            ImportanceInfluencHandlersDict.Add(typeof(PositiveEmotionBase), 1 * CharacterValue);

            ImportanceInfluencHandlersDict.Add(typeof(LessonEvent), 2 * CharacterValue);
        }
    }
}