namespace BehaviourModel
{
    /// <summary>
    /// Страдание, сильная эмоция
    /// </summary>
    public class MiserySadEmotion : SadEmotionBase
    {
        public MiserySadEmotion(IReactionSource source) : base(source, STRONG_EMOTION_POWER)
        {
        }
        public MiserySadEmotion() : base()
        {

        }
    }
}