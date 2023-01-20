namespace BehaviourModel
{
    /// <summary>
    /// Высокая чувствительность
    /// </summary>
    public sealed class HighSensetivity : RigiditySensetivity
    {
        /// <summary>
        /// Я очень ранимая и утончённая личность.
        /// Мы знакомы? Если нет, то я проявлю интерес если ты в беде или такой же как и я.
        /// Если да, какие у нас отношения?
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;

        public override void Initiate(int characterValue, AgentBase agent)
        {
            base.Initiate(characterValue, agent);
            ImportanceInfluencHandlersDict.Add(typeof(EmotionBase), 3 * CharacterValue);
        }
    }
}