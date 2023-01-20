namespace BehaviourModel
{
    /// <summary>
    /// Страдание, сильная эмоция
    /// </summary>
    public class MiserySadEmotion : SadEmotionBase
    {
        public MiserySadEmotion(IEmotionSource source) : base(source, STRONG_EMOTION_POWER)
        {
        }
    }
}