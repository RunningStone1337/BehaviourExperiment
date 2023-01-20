namespace BehaviourModel
{
    /// <summary>
    /// Отвлеченность, слабая эмоция
    /// </summary>
    public class AbstractnessAmazementEmotion : SurpriseEmotionBase
    {
        public AbstractnessAmazementEmotion(IEmotionSource source) : base(source, WEAK_EMOTION_POWER)
        {
        }
    }
}