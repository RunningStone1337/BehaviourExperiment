namespace BehaviourModel
{
    /// <summary>
    /// Базовая эмоция гнева.
    /// </summary>
    public abstract class AngerEmotionBase : PositiveEmotionBase, IAgressiveEmotion
    {
        public AngerEmotionBase(IReactionSource source, int emotionPower) : base(source, emotionPower)
        {
        }
        public AngerEmotionBase():base()
        {

        }
    }
}