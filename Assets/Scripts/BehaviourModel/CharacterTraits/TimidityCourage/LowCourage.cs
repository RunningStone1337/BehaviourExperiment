using Core;

namespace BehaviourModel
{
    /// <summary>
    /// Робость
    /// </summary>
    public sealed class LowCourage : TimidityCourage
    {
        /// <summary>
        /// Я очень стеснительный.
        /// Мы знакомы? Если да, мне должно быть комфортно в твоей компании.
        /// Если нет, я не проявлю инициативу, особенно если вокруг много людей.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;

        public override void Initiate(int characterValue, AgentBase agent)
        {
            base.Initiate(characterValue, agent);
            ImportanceInfluencHandlersDict.Add(typeof(IAgressiveEmotion), -1 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(NegativeEmotionBase), 1 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(ISubordinationEmotion), 1 * CharacterValue);

            ImportanceInfluencHandlersDict.Add(typeof(LessonEvent), -1 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(BreakEvent), -2 * CharacterValue);
        }
    }
}