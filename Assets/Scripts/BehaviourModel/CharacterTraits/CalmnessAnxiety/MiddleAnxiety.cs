using Core;

namespace BehaviourModel
{
    /// <summary>
    /// Средняя тревожность
    /// </summary>
    public sealed class MiddleAnxiety : CalmnessAnxiety
    {
        public override void Initiate(int characterValue, AgentBase agent)
        {
            base.Initiate(characterValue, agent);
          
            ImportanceInfluencHandlersDict.Add(typeof(LessonEvent), 1 * CharacterValue);
        }

        /// <summary>
        /// Иногда люди меня беспокоят, но только если я их недостаточно знаю.
        /// В целом, я адекватно реагирую на раздражителей.
        /// Кто это, кстати? Мы знакомы?
        /// Если нет, меня это не беспокоит, если да - тем более.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => false;
    }
}