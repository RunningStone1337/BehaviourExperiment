namespace BehaviourModel
{
    /// <summary>
    /// Ужас, сильная эмоция
    /// </summary>
    public class HorrorHorrorEmotion : HorrorEmotionBase
    {
        public HorrorHorrorEmotion(IReactionSource source) : base(source, STRONG_EMOTION_POWER)
        {
        }
        public HorrorHorrorEmotion() : base()
        {

        }
    }
}