namespace BehaviourModel
{
    /// <summary>
    /// ������, ������ ������
    /// </summary>
    public class DespondencySadEmotion : SadEmotionBase
    {
        public DespondencySadEmotion(IReactionSource source) : base(source, WEAK_EMOTION_POWER)
        {
        }
        public DespondencySadEmotion() : base()
        {

        }
    }
}