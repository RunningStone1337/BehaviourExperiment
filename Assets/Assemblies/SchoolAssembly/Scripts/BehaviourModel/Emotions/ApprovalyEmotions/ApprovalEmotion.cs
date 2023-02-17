namespace BehaviourModel
{
    /// <summary>
    /// ������� ������ ���������.
    /// </summary>
    public abstract class ApprovalEmotion : PositiveEmotionBase, ISubordinationEmotion
    {
        public ApprovalEmotion(IReactionSource source, int emotionPower) : base(source, emotionPower)
        {
        }
        public ApprovalEmotion() : base()
        {

        }
    }
}