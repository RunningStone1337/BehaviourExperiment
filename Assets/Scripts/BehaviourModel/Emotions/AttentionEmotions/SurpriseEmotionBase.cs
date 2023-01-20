namespace BehaviourModel
{
    /// <summary>
    /// Базовая эмоция удвиления
    /// </summary>
    public abstract class SurpriseEmotionBase : NegativeEmotionBase, IAlienatedEmotion
    {
        public SurpriseEmotionBase(IEmotionSource source, int emotionPower) : base(source, emotionPower)
        {
        }
    }
}