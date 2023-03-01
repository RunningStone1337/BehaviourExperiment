using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class FindFreeChairAction : NonDirectedAction, ICompletedAction
    {
        public FindFreeChairAction(): base()
        {

        }
        public override IEnumerator TryPerformAction()
        {
            var cast = (PupilAgent)ActionActor;
            cast.SetState<FindFreeChairPupilState>();
            yield return cast.CurrentState.StartState();
            if (cast.AgentEnvironment.ChairInfo != null)
                WasPerformed = true;
        }
    }
}
