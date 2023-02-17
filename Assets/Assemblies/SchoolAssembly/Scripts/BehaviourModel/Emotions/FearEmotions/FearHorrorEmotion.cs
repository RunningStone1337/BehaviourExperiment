namespace BehaviourModel
{
    /// <summary>
    /// Страх
    /// </summary>
    public class FearHorrorEmotion : HorrorEmotionBase
    {
        public FearHorrorEmotion(IReactionSource source) : base(source, MIDDLE_EMOTION_POWER)
        {
        }
        public FearHorrorEmotion() : base()
        {

        }
    }
}