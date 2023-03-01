using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    [Serializable]
    public class FindFarFromDeskChairAction : NonDirectedAction, ICompletedAction
    {
        public FindFarFromDeskChairAction():base(){}
        public override IEnumerator TryPerformAction()
        {
            var cast = (PupilAgent)ActionActor;
            if (cast.AgentEnvironment.ChairInfo == null)
            {
                cast.SetState<FindFarFromDeskChairPupilState>();
                yield return cast.CurrentState.StartState();
                if (cast.AgentEnvironment.ChairInfo != null)
                    WasPerformed = true;
            }
        }
    }
}
