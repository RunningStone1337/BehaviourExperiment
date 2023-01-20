using Core;

namespace BehaviourModel
{
    /// <summary>
    /// Высокая нормативность
    /// </summary>
    public sealed class HighNormativityOfBehaviour : NormativityOfBehaviour
    {
        /// <summary>
        /// Если у тебя репутация хулигана, нам не о чем разговаривать.
        /// Иначе можно и попробовать. Всё зависит от тебя.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;

        public override void Initiate(int characterValue, AgentBase agent)
        {
            base.Initiate(characterValue, agent);
            ImportanceInfluencHandlersDict.Add(typeof(EmotionBase), -2 * CharacterValue);

            ImportanceInfluencHandlersDict.Add(typeof(LessonEvent), 3 * CharacterValue);

            ImportanceInfluencHandlersDict.Add(typeof(EducationalActivityBase), 3 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(PlayActivityBase), -3 * CharacterValue);
        }
    }
}