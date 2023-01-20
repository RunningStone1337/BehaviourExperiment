namespace BehaviourModel
{
    /// <summary>
    /// Удивление
    /// </summary>
    public class SurpriseAmazementEmotion : SurpriseEmotionBase
    {
        public SurpriseAmazementEmotion(IEmotionSource source) : base(source, MIDDLE_EMOTION_POWER)
        {
        }
    }
}