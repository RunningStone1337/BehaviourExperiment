namespace BehaviourModel
{
    /// <summary>
    /// Базовая эмоция отвращения
    /// </summary>
    public abstract class DisgustEmotionBase : NegativeEmotionBase, IAlienatedEmotion, IAgressiveEmotion
    {
        public DisgustEmotionBase() : base()
        {

        }
    }
}