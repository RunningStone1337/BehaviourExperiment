using Core;

namespace BehaviourModel
{
    /// <summary>
    /// Умеренная смелость
    /// </summary>
    public sealed class MiddleCourage : TimidityCourage
    {
        /// <summary>
        /// Под влиянием факторов я могу отважиться на поступок
        /// и взять на себя инициативу.
        /// Мы знакомы? Если нет, всё зависит от условий.
        /// Если да, скорее всего я проявлю интерес.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;

        public override void Initiate(int characterValue, AgentBase agent)
        {
            base.Initiate(characterValue, agent);

            ImportanceInfluencHandlersDict.Add(typeof(LessonEvent), 1 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(BreakEvent), 1 * CharacterValue);
        }
    }
}