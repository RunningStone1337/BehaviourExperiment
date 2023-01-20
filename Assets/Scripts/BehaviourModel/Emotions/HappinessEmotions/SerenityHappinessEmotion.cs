namespace BehaviourModel
{
    /// <summary>
    /// Безмятежность
    /// </summary>
    public class SerenityHappinessEmotion : HappinessEmotionBase
    {
        public SerenityHappinessEmotion(IEmotionSource source) : base(source, WEAK_EMOTION_POWER)
        {
        }
    }
}