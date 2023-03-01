using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    [Serializable]
    public class FindClosestToDeskAction : NonDirectedAction, ICompletedAction
    {
        public FindClosestToDeskAction():base() { }
        public override IEnumerator TryPerformAction()
        {
            var cast = (PupilAgent)ActionActor;
            if (cast.AgentEnvironment.ChairInfo == null)
            {
                cast.SetState<FindClosestToDeskChairPupilState>();
                yield return cast.CurrentState.StartState();
                if (cast.AgentEnvironment.ChairInfo != null)
                    WasPerformed = true;
            }
        }
    }
}
