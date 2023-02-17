namespace BehaviourModel
{
    /// <summary>
    /// Безмятежность
    /// </summary>
    public class SerenityHappinessEmotion : HappinessEmotionBase
    {
        public SerenityHappinessEmotion(IReactionSource source) : base(source, WEAK_EMOTION_POWER)
        {
        }
        public SerenityHappinessEmotion() : base()
        {

        }
    }
}