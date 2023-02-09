namespace BehaviourModel
{
    /// <summary>
    /// Базовый класс для впечатлений/эмоций.
    /// </summary>
    public abstract class EmotionBase : IPhenomenon, IReaction
    {
        public static readonly int WEAK_EMOTION_POWER = 1;
        public static readonly int MIDDLE_EMOTION_POWER = 2;
        public static readonly int STRONG_EMOTION_POWER = 3;
        public IEmotionSource EmotionSource { get; private set; }
        public int PhenomenonPower { get; set; }

        public EmotionBase(IEmotionSource source, int emotionPower)
        {
            EmotionSource = source;
            PhenomenonPower = emotionPower;
        }
    }
}