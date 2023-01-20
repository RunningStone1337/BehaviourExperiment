namespace BehaviourModel
{
    /// <summary>
    /// ������� ������ �����.
    /// </summary>
    public abstract class HorrorEmotionBase : NegativeEmotionBase, ISubordinationEmotion, IAlienatedEmotion
    {
        public HorrorEmotionBase(IEmotionSource source, int emotionPower) : base(source, emotionPower)
        {
        }
    }
}