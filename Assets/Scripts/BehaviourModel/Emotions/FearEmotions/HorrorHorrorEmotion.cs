namespace BehaviourModel
{
    /// <summary>
    /// Ужас, сильная эмоция
    /// </summary>
    public class HorrorHorrorEmotion : HorrorEmotionBase
    {
        public HorrorHorrorEmotion(IEmotionSource source) : base(source, STRONG_EMOTION_POWER)
        {
        }
    }
}