namespace BehaviourModel
{
    /// <summary>
    /// ��������
    /// </summary>
    public class AwaitingInterestEmotion : InterestEmotionBase
    {
        public AwaitingInterestEmotion(IReactionSource source) : base(source, MIDDLE_EMOTION_POWER)
        {
        }
        public AwaitingInterestEmotion() : base()
        {

        }
    }
}