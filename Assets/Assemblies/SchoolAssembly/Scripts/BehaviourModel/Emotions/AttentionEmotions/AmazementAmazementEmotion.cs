namespace BehaviourModel
{
    /// <summary>
    /// Изумление
    /// </summary>
    public class AmazementAmazementEmotion : SurpriseEmotionBase
    {
        public AmazementAmazementEmotion(IReactionSource source) : base(source, STRONG_EMOTION_POWER)
        {
        }
        public AmazementAmazementEmotion() : base()
        {

        }
    }
}