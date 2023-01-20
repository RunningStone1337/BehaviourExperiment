namespace BehaviourModel
{
    /// <summary>
    /// ������� ������ ������
    /// </summary>
    public abstract class SadEmotionBase : NegativeEmotionBase, IAlienatedEmotion
    {
        protected SadEmotionBase(IEmotionSource source, int emotionPower) : base(source, emotionPower)
        {
        }
    }
}