namespace BehaviourModel
{
    /// <summary>
    /// Базовая эмоция грусти
    /// </summary>
    public abstract class SadEmotionBase : NegativeEmotionBase, IAlienatedEmotion
    {
        protected SadEmotionBase(IReactionSource source, int emotionPower) : base(source, emotionPower)
        {
        }

        public SadEmotionBase() : base()
        {

        }
    }
}