namespace BehaviourModel
{
    /// <summary>
    /// Печаль
    /// </summary>
    public class SadnessSadEmotion : SadEmotionBase
    {
        public SadnessSadEmotion(IEmotionSource source) : base(source, MIDDLE_EMOTION_POWER)
        {
        }
    }
}