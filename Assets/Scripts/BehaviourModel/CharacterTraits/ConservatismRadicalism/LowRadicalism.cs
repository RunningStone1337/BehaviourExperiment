namespace BehaviourModel
{
    public sealed class LowRadicalism : ConservatismRadicalism
    {
        /// <summary>
        /// Меня воспитывала бабушка. Как она сказала - так и делаю.
        /// Если ты спорщик и считаешь себя свои идеи правильными, ты мне не нравишься.
        /// Я и сам знаю, как правильно - как бабушка научила.
        /// Мы знакомы? Если да, какие у тебя интересы? Если не такие же как у меня, мы 
        /// не сойдёмся. Не знакомы - я оценю, как ты подходишь под критерии моей бабушки.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;
    }
}