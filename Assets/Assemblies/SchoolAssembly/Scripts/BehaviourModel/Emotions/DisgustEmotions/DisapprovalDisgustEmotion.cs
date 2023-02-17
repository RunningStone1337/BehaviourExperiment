namespace BehaviourModel
{
    /// <summary>
    /// Неодобрение, слабая эмоция
    /// </summary>
    public class DisapprovalDisgustEmotion : DisgustEmotionBase
    {
        public DisapprovalDisgustEmotion(IReactionSource source) : base(source, WEAK_EMOTION_POWER)
        {
        }
        public DisapprovalDisgustEmotion() : base()
        {

        }
    }
}