namespace BehaviourModel
{
    /// <summary>
    /// �������, ������� ������
    /// </summary>
    public class AcceptanceApprovalEmotion : ApprovalEmotion
    {
        public AcceptanceApprovalEmotion(IEmotionSource source) : base(source, MIDDLE_EMOTION_POWER)
        {
        }
    }
}