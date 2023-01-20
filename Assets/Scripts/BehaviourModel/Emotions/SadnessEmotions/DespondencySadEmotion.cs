namespace BehaviourModel
{
    /// <summary>
    /// Уныние, слабая эмоция
    /// </summary>
    public class DespondencySadEmotion : SadEmotionBase
    {
        public DespondencySadEmotion(IEmotionSource source) : base(source, WEAK_EMOTION_POWER)
        {
        }
    }
}