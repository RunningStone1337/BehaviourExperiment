namespace BehaviourModel
{
    /// <summary>
    /// ������� ������ ���������
    /// </summary>
    public abstract class SurpriseEmotionBase : NegativeEmotionBase, IAlienatedEmotion
    {
        public SurpriseEmotionBase(IReactionSource source, int emotionPower) : base(source, emotionPower)
        {
        }
        public SurpriseEmotionBase() : base()
        {

        }
    }
}