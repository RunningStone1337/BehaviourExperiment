namespace BehaviourModel
{
    /// <summary>
    /// ярость
    /// </summary>
    public class RageAngerEmotion : AngerEmotionBase
    {
        public RageAngerEmotion(IEmotionSource source) : base(source, STRONG_EMOTION_POWER)
        {
        }
    }
}