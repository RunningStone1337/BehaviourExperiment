namespace BehaviourModel
{
    /// <summary>
    /// ����, ������� ������
    /// </summary>
    public class HorrorHorrorEmotion : HorrorEmotionBase
    {
        public HorrorHorrorEmotion(IEmotionSource source) : base(source, STRONG_EMOTION_POWER)
        {
        }
    }
}