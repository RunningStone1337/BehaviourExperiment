namespace BehaviourModel
{
    /// <summary>
    /// ����, ������� ������
    /// </summary>
    public class HorrorHorrorEmotion : HorrorEmotionBase
    {
        public HorrorHorrorEmotion(IReactionSource source) : base(source, STRONG_EMOTION_POWER)
        {
        }
        public HorrorHorrorEmotion() : base()
        {

        }
    }
}