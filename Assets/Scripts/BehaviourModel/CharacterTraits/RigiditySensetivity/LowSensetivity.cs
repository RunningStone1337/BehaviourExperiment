namespace BehaviourModel
{
    /// <summary>
    /// Низкая чувствительность - жесткость
    /// </summary>
    public sealed class LowSensetivity : RigiditySensetivity
    {
        /// <summary>
        /// Я не очень воспринимаю эмоции и чувства других людей.
        /// Всегда слушаю голос разума, а не сердца.
        /// Мы знакомы? Если да, какая мне толк рищаться с тобой?
        /// Если нет, могу выяснить, есть ли от тебя польза. А могу и не вяснять.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;

        public override void Initiate(int characterValue, AgentBase agent)
        {
            base.Initiate(characterValue, agent);
            ImportanceInfluencHandlersDict.Add(typeof(EmotionBase), -3 * CharacterValue);
        }
    }
}