namespace BehaviourModel
{
    /// <summary>
    /// Базовая отрицательная эмоция
    /// </summary>
    public abstract class NegativeEmotionBase : EmotionBase
    {
        protected NegativeEmotionBase(IEmotionSource source, int emotionPower) : base(source, emotionPower)
        {
        }
    }
}