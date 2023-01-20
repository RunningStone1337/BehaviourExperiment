namespace BehaviourModel
{
    /// <summary>
    /// ������� ������ �����.
    /// </summary>
    public abstract class AngerEmotionBase : PositiveEmotionBase, IAgressiveEmotion
    {
        public AngerEmotionBase(IEmotionSource source, int emotionPower) : base(source, emotionPower)
        {
        }
    }
}