using System;
using System.Collections;

namespace BehaviourModel
{
    [Serializable]
    public class PupilLookAroundIfOnChairAction : PupilLookAroudAction
    {
        public override IEnumerator TryPerformAction()
        {
            var cast = ActionActor as PupilAgent;
            if (cast != null && cast.AgentEnvironment.ChairInfo != null)
            {
                yield return base.TryPerformAction();
            }
        }
    }
}