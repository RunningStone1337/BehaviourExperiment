namespace BehaviourModel
{
    /// <summary>
    /// Восхищение, обожание
    /// </summary>
    public class AdorationApprovalEmotion : ApprovalEmotion
    {
        public AdorationApprovalEmotion(IEmotionSource source) : base(source, STRONG_EMOTION_POWER)
        {
        }
    }
}