namespace BehaviourModel
{
    /// <summary>
    /// Слабый интерес
    /// </summary>
    public class InterestInterestEmotion : InterestEmotionBase
    {
        public InterestInterestEmotion(IEmotionSource source) : base(source, WEAK_EMOTION_POWER)
        {
        }
    }
}