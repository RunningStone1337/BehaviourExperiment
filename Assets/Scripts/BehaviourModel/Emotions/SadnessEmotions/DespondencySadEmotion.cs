namespace BehaviourModel
{
    /// <summary>
    /// ������, ������ ������
    /// </summary>
    public class DespondencySadEmotion : SadEmotionBase
    {
        public DespondencySadEmotion(IEmotionSource source) : base(source, WEAK_EMOTION_POWER)
        {
        }
    }
}