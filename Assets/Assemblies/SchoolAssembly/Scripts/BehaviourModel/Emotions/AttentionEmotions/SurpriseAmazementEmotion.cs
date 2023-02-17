namespace BehaviourModel
{
    /// <summary>
    /// Удивление
    /// </summary>
    public class SurpriseAmazementEmotion : SurpriseEmotionBase
    {
        public SurpriseAmazementEmotion(IReactionSource source) : base(source, MIDDLE_EMOTION_POWER)
        {
        }
        public SurpriseAmazementEmotion() : base()
        {

        }
    }
}