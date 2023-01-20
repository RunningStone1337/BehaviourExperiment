namespace BehaviourModel
{
    /// <summary>
    /// Приятие, средняя эмоция
    /// </summary>
    public class AcceptanceApprovalEmotion : ApprovalEmotion
    {
        public AcceptanceApprovalEmotion(IEmotionSource source) : base(source, MIDDLE_EMOTION_POWER)
        {
        }
    }
}