namespace BehaviourModel
{
    /// <summary>
    /// Изумление
    /// </summary>
    public class AmazementAmazementEmotion : SurpriseEmotionBase
    {
        public AmazementAmazementEmotion(IEmotionSource source) : base(source, STRONG_EMOTION_POWER)
        {
        }
    }
}