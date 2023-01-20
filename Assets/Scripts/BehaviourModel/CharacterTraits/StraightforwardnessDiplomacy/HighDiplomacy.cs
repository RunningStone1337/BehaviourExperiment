namespace BehaviourModel
{
    /// <summary>
    /// Высокая дипломатичность
    /// </summary>
    public sealed class HighDiplomacy : StraightforwardnessDiplomacy
    {
        /// <summary>
        /// Я очень хитёр, пунктуален и в целом не так прост, как могу казаться.
        /// Мы знакомы? Если да, как ты держишь себя в обществе?
        /// Если нет, я могу проявить тактичность и интерес(зависит от факторов), а могуи прогинорировать.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;
    }
}