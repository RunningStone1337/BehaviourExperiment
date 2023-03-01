using System.Collections;

namespace BehaviourModel
{
    /// <summary>
    /// Неодобрение, слабая эмоция
    /// </summary>
    public class DisapprovalDisgustEmotion : DisgustEmotionBase
    {
        public DisapprovalDisgustEmotion() : base()
        {

        }
        public override IEnumerator TryPerformAction()
        {
            throw new System.NotImplementedException();
        }
    }
}