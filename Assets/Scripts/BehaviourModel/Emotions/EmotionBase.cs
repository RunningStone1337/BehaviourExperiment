namespace BehaviourModel
{
    /// <summary>
    /// Базовый класс для впечатлений/эмоций.
    /// </summary>
    public abstract class EmotionBase : IPhenomenon
    {
        protected const int WEAK_EMOTION_POWER = 1;
        protected const int MIDDLE_EMOTION_POWER = 2;
        protected const int STRONG_EMOTION_POWER = 3;
        public IEmotionSource EmotionSource { get; private set; }
        public int PhenomenonPower { get; set; }

        public EmotionBase(IEmotionSource source, int emotionPower)
        {
            EmotionSource = source;
            PhenomenonPower = emotionPower;
        }
    }
}