namespace BehaviourModel
{
    /// <summary>
    /// ���������
    /// </summary>
    public class DislikeDisgustEmotion : DisgustEmotionBase
    {
        public DislikeDisgustEmotion(IReactionSource source) : base(source, MIDDLE_EMOTION_POWER)
        {
        }
        public DislikeDisgustEmotion() : base()
        {

        }
    }
}