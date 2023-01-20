namespace BehaviourModel
{
    /// <summary>
    /// ������� ������ ����������
    /// </summary>
    public abstract class DisgustEmotionBase : NegativeEmotionBase, IAlienatedEmotion, IAgressiveEmotion
    {
        protected DisgustEmotionBase(IEmotionSource source, int emotionPower) : base(source, emotionPower)
        {
        }
    }
}