namespace BehaviourModel
{
    /// <summary>
    /// ��������
    /// </summary>
    public class AwaitingInterestEmotion : InterestEmotionBase
    {
        public AwaitingInterestEmotion(IEmotionSource source) : base(source, MIDDLE_EMOTION_POWER)
        {
        }
    }
}