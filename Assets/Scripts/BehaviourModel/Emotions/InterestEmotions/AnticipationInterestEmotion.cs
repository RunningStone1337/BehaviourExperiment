namespace BehaviourModel
{
    /// <summary>
    /// ��������������
    /// </summary>
    public class AnticipationInterestEmotion : InterestEmotionBase
    {
        public AnticipationInterestEmotion(IEmotionSource source) : base(source, STRONG_EMOTION_POWER)
        {
        }
    }
}