namespace BehaviourModel
{
    /// <summary>
    /// ����������
    /// </summary>
    public class DisgustDisgustEmotion : DisgustEmotionBase
    {
        public DisgustDisgustEmotion(IReactionSource source) : base(source, STRONG_EMOTION_POWER)
        {
        }
        public DisgustDisgustEmotion() : base()
        {

        }
    }
}