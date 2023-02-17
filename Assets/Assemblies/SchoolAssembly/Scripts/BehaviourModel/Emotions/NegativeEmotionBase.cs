namespace BehaviourModel
{
    /// <summary>
    /// Базовая отрицательная эмоция
    /// </summary>
    public abstract class NegativeEmotionBase : EmotionBase
    {
        protected NegativeEmotionBase(IReactionSource source, int emotionPower) : base(source, emotionPower)
        {
        }
        public NegativeEmotionBase():base()
        {

        }
    }
}