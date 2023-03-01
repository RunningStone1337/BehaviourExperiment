using System.Collections;

namespace BehaviourModel
{
    /// <summary>
    /// ќжидание
    /// </summary>
    public class AwaitingInterestEmotion : InterestEmotionBase
    {
        public AwaitingInterestEmotion() : base()
        {

        }
        public override IEnumerator TryPerformAction()
        {
            throw new System.NotImplementedException();
        }
    }
}