namespace BehaviourModel
{
    /// <summary>
    /// ���������
    /// </summary>
    public class DislikeDisgustEmotion : DisgustEmotionBase
    {
        public DislikeDisgustEmotion(IEmotionSource source) : base(source, MIDDLE_EMOTION_POWER)
        {
        }
    }
}