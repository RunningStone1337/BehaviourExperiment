namespace BehaviourModel
{
    /// <summary>
    /// ������� ������ �������
    /// </summary>
    public abstract class HappinessEmotionBase : PositiveEmotionBase, ISubordinationEmotion
    {
        protected HappinessEmotionBase(IEmotionSource source, int emotionPower) : base(source, emotionPower)
        {
        }
    }
}