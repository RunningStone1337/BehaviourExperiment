namespace BehaviourModel
{
    /// <summary>
    /// ��������
    /// </summary>
    public class CautionFearEmotion : HorrorEmotionBase
    {
        public CautionFearEmotion(IEmotionSource source) : base(source, WEAK_EMOTION_POWER)
        {
        }
    }
}