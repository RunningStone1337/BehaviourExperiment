namespace BehaviourModel
{
    /// <summary>
    /// ������
    /// </summary>
    public class SadnessSadEmotion : SadEmotionBase
    {
        public SadnessSadEmotion(IReactionSource source) : base(source, MIDDLE_EMOTION_POWER)
        {
        }
        public SadnessSadEmotion() : base()
        {

        }
    }
}