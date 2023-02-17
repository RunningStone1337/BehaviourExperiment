namespace BehaviourModel
{
    /// <summary>
    /// ������� ������ �������
    /// </summary>
    public abstract class HappinessEmotionBase : PositiveEmotionBase, ISubordinationEmotion
    {
        protected HappinessEmotionBase(IReactionSource source, int emotionPower) : base(source, emotionPower)
        {
        }
        public HappinessEmotionBase() : base()
        {

        }
    }
}