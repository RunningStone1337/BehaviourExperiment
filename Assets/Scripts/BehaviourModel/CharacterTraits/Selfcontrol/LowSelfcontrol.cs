using Core;

namespace BehaviourModel
{
    /// <summary>
    /// Низкий самоконтроль
    /// </summary>
    public sealed class LowSelfcontrol : Selfcontrol
    {
        /// <summary>
        /// Я зависим от желаний и сиюминутных хотелок.
        /// Мы знакомы? Если да, с тобой можно покуралесить?
        /// Если нет, ты можешь стать объектом моих выходок.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;

        public override void Initiate(int characterValue, AgentBase agent)
        {
            base.Initiate(characterValue, agent);
            recognitionChance = (7 + CharacterValue) / 10f;
            ImportanceInfluencHandlersDict.Add(typeof(LessonEvent), -5 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(BreakEvent), -5 * CharacterValue);
        }
    }
}