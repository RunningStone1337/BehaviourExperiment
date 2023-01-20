namespace BehaviourModel
{
    /// <summary>
    /// Умеренная нормативность
    /// </summary>
    public sealed class MiddleNormativityOfBehaviour : NormativityOfBehaviour
    {
        /// <summary>
        /// Я вообще не затейник, но за компанию могу похулиганить.
        /// Поддержать коллектив. По настроению являюсь сам инициатором антисоциальных
        /// движений.
        /// Мы знакомы? Если да, можем что-нибудь шальное придумать.
        /// Если нет, ты сам можешь стать объектом моих проделок.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;
    }
}