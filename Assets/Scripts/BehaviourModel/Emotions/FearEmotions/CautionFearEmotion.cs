namespace BehaviourModel
{
    /// <summary>
    /// Опасение
    /// </summary>
    public class CautionFearEmotion : HorrorEmotionBase
    {
        public CautionFearEmotion(IEmotionSource source) : base(source, WEAK_EMOTION_POWER)
        {
        }
    }
}