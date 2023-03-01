using System.Collections;

namespace BehaviourModel
{
    /// <summary>
    /// Отвлеченность, слабая эмоция
    /// </summary>
    public class AbstractnessAmazementEmotion : SurpriseEmotionBase
    {
        public AbstractnessAmazementEmotion() : base()
        {

        }
        public override IEnumerator TryPerformAction()
        {
            throw new System.NotImplementedException();
        }
    }
}