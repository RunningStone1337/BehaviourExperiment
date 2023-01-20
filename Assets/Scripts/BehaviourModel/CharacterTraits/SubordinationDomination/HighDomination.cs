namespace BehaviourModel
{
    /// <summary>
    /// Высокая доминантность
    /// </summary>
    public sealed class HighDomination : SubordinationDomination
    {
        public override void Initiate(int characterValue, AgentBase agent)
        {
            base.Initiate(characterValue, agent);
            ImportanceInfluencHandlersDict.Add(typeof(IAgressiveEmotion), 1 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(NegativeEmotionBase), 1 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(ISubordinationEmotion), -1 * CharacterValue);
        }

        /// <summary>
        /// Я очень автономен и своенравен. 
        /// Если будешь пытаться надо мной доминировать - пожалеешь.
        /// Я сам буду доминировать над слабыми, конфликтовать с сильными пока не одержу верх или 
        /// не признаю их равными или не подчинюсь большей силе.
        /// Учителя не уважаю, авторитет здесь Я.
        /// Мы знакомы? Если да, кто круче? Если я, ты не интересн в принципе.
        /// Если мы конфликтуем, будем выяснять кто главный до конца.
        /// Не знакомы? Слабак - не подворачивайся под руку, пожалеешь. 
        /// Не похож на слабака? Проверим на деле.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;
    }
}