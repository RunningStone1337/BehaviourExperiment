namespace BehaviourModel
{
    /// <summary>
    /// ����������
    /// </summary>
    public class DisgustDisgustEmotion : DisgustEmotionBase
    {
        public DisgustDisgustEmotion(IEmotionSource source) : base(source, STRONG_EMOTION_POWER)
        {
        }
    }
}