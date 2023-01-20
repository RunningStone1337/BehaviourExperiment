namespace BehaviourModel
{
    /// <summary>
    /// Базовая эмоция гнева.
    /// </summary>
    public abstract class AngerEmotionBase : PositiveEmotionBase, IAgressiveEmotion
    {
        public AngerEmotionBase(IEmotionSource source, int emotionPower) : base(source, emotionPower)
        {
        }
    }
}