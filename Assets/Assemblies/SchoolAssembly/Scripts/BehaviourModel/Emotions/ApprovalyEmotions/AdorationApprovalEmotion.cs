namespace BehaviourModel
{
    /// <summary>
    /// Восхищение, обожание
    /// </summary>
    public class AdorationApprovalEmotion : ApprovalEmotion
    {
        public AdorationApprovalEmotion(IReactionSource source) : base(source, STRONG_EMOTION_POWER)
        {
        }
        public AdorationApprovalEmotion() : base()
        {

        }
    }
}