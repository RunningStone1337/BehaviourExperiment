using Core;

namespace BehaviourModel
{
    /// <summary>
    /// Умеренный самоконтроль
    /// </summary>
    public sealed class MiddleSelfcontrol : Selfcontrol
    {
        /// <summary>
        /// Обычно я держу себя в руках, но если сильно устану или возбужусь -
        /// могу начать вести себя странно.
        /// Мы знакомы? Если да, всё зависит от моего состояния.
        /// Если нет, ты не интересен.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;

        public override void Initiate(int characterValue, AgentBase agent)
        {
            base.Initiate(characterValue, agent);
            recognitionChance = GetRecognitionChanceForMiddle();
            ImportanceInfluencHandlersDict.Add(typeof(LessonEvent), 3 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(BreakEvent), -3 * CharacterValue);
        }
    }
}