namespace BehaviourModel
{
    /// <summary>
    /// ��������������
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