namespace BehaviourModel
{
    /// <summary>
    /// ���������, ������� ������
    /// </summary>
    public class MiserySadEmotion : SadEmotionBase
    {
        public MiserySadEmotion(IReactionSource source) : base(source, STRONG_EMOTION_POWER)
        {
        }
        public MiserySadEmotion() : base()
        {

        }
    }
}