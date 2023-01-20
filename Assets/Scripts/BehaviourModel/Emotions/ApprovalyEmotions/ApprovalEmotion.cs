namespace BehaviourModel
{
    /// <summary>
    /// ������� ������ ���������.
    /// </summary>
    public abstract class ApprovalEmotion : PositiveEmotionBase, ISubordinationEmotion
    {
        public ApprovalEmotion(IEmotionSource source, int emotionPower) : base(source, emotionPower)
        {
        }
    }
}