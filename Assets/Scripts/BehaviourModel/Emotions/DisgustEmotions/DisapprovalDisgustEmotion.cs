namespace BehaviourModel
{
    /// <summary>
    /// �����������, ������ ������
    /// </summary>
    public class DisapprovalDisgustEmotion : DisgustEmotionBase
    {
        public DisapprovalDisgustEmotion(IEmotionSource source) : base(source, WEAK_EMOTION_POWER)
        {
        }
    }
}