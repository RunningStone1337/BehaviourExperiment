namespace BehaviourModel
{
    /// <summary>
    /// �����
    /// </summary>
    public class FearHorrorEmotion : HorrorEmotionBase
    {
        public FearHorrorEmotion(IEmotionSource source) : base(source, MIDDLE_EMOTION_POWER)
        {
        }
    }
}