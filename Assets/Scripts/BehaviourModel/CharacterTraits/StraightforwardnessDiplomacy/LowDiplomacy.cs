namespace BehaviourModel
{
    /// <summary>
    /// Ќизка€ дипломатичность
    /// </summary>
    public sealed class LowDiplomacy : StraightforwardnessDiplomacy
    {
        /// <summary>
        /// я очень пр€молинеен и даже бестактен.
        /// ћы знакомы? ≈сли да, могу про€вить интерес невзира€ на возможные противоречи€.
        /// ≈сли нет, мен€ мало что остановит.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;
    }
}