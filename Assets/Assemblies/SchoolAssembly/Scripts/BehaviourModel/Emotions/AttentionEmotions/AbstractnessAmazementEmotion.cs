namespace BehaviourModel
{
    /// <summary>
    /// �������������, ������ ������
    /// </summary>
    public class AbstractnessAmazementEmotion : SurpriseEmotionBase
    {
        public AbstractnessAmazementEmotion(IReactionSource source) : base(source, WEAK_EMOTION_POWER)
        {
        }
        public AbstractnessAmazementEmotion() : base()
        {

        }
    }
}