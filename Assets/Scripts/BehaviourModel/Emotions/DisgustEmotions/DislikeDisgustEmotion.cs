namespace BehaviourModel
{
    /// <summary>
    /// Неприязнь
    /// </summary>
    public class DislikeDisgustEmotion : DisgustEmotionBase
    {
        public DislikeDisgustEmotion(IEmotionSource source) : base(source, MIDDLE_EMOTION_POWER)
        {
        }
    }
}