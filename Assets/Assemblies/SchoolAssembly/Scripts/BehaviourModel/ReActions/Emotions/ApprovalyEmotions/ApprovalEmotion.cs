namespace BehaviourModel
{
    /// <summary>
    /// Базовая эмоция одобрения.
    /// </summary>
    public abstract class ApprovalEmotion : PositiveEmotionBase, ISubordinationEmotion
    {
        public ApprovalEmotion() : base()
        {

        }
    }
}