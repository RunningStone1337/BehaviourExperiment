namespace BehaviourModel
{
    /// <summary>
    /// �������, ������� ������
    /// </summary>
    public class AcceptanceApprovalEmotion : ApprovalEmotion
    {
        public AcceptanceApprovalEmotion(IReactionSource source) : base(source, MIDDLE_EMOTION_POWER)
        {
        }
        public AcceptanceApprovalEmotion():base()
        {

        }
    }
}