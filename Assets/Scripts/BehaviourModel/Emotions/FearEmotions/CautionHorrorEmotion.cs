namespace BehaviourModel
{
    /// <summary>
    /// ��������
    /// </summary>
    public class CautionHorrorEmotion : HorrorEmotionBase
    {
        public CautionHorrorEmotion(IEmotionSource source) : base(source, WEAK_EMOTION_POWER)
        {
        }
    }
}