using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class ReactionToRejectionAction : NonDirectedAction
    {
        public ReactionToRejectionAction(PupilAgent thisAgent):base()
        {
            ActionActor = thisAgent;
        }

        public override IEnumerator TryPerformAction()
        {
            throw new System.NotImplementedException();
        }
    }
}
