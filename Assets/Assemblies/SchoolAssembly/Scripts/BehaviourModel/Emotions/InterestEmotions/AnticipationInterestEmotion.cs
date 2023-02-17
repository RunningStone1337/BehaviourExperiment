namespace BehaviourModel
{
    /// <summary>
    /// Предвосхищение
    /// </summary>
    public class AnticipationInterestEmotion : InterestEmotionBase
    {
        public AnticipationInterestEmotion(IReactionSource source) : base(source, STRONG_EMOTION_POWER)
        {
        }
        public AnticipationInterestEmotion() : base()
        {

        }
    }
}