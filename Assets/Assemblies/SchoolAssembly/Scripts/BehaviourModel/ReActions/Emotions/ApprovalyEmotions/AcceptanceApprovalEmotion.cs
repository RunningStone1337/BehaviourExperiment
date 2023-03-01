using System.Collections;

namespace BehaviourModel
{
    /// <summary>
    /// Приятие, средняя эмоция
    /// </summary>
    public class AcceptanceApprovalEmotion : ApprovalEmotion
    {
        public AcceptanceApprovalEmotion():base()
        {

        }
        public override IEnumerator TryPerformAction()
        {
            throw new System.NotImplementedException();
        }
    }
}