namespace BehaviourModel
{
    /// <summary>
    /// Опасение
    /// </summary>
    public class CautionHorrorEmotion : HorrorEmotionBase
    {
        public CautionHorrorEmotion(IReactionSource source) : base(source, WEAK_EMOTION_POWER)
        {
        }
        public CautionHorrorEmotion() : base()
        {

        }
    }
}