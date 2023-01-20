namespace BehaviourModel
{
    /// <summary>
    /// Умеренная чувствительность
    /// </summary>
    public sealed class MiddleSensetivity : RigiditySensetivity
    {
        /// <summary>
        /// Я могу руководствоваться и сердцем, и головой. Зависит от ситуации.
        /// Мы знакомы? Если да, что нас связывает? 
        /// Если нет, я скорее не проявлю интерес.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;

        public override void Initiate(int characterValue, AgentBase agent)
        {
            base.Initiate(characterValue, agent);
            ImportanceInfluencHandlersDict.Add(typeof(EmotionBase), 1 * CharacterValue);
        }
    }
}