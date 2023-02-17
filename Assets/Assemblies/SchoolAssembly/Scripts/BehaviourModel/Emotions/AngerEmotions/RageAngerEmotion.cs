namespace BehaviourModel
{
    /// <summary>
    /// ������
    /// </summary>
    public class RageAngerEmotion : AngerEmotionBase
    {
        public RageAngerEmotion(IReactionSource source) : base(source, STRONG_EMOTION_POWER)
        {
        }
        public RageAngerEmotion():base()
        {

        }
    }
}