using BuildingModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class FindFreeChairState : SchoolAgentStateBase
    {
        public override bool StateBreaked { get => stateBreaked; set => stateBreaked = value; }

        public override IEnumerator StartState()
        {
            StateBreaked = false;
            var chair = thisAgent.FindFreeChairToSeat(InterierHandler.Handler.Chairs);
            if (chair != null)
                thisAgent.MovementTarget = chair;
            else throw new System.Exception("Seat place not found");

            thisAgent.SetState<MoveToTargetState>();
            var cs = (SchoolAgentStateBase)thisAgent.CurrentState;
            yield return cs.StartState();
            StateBreaked = cs.StateBreaked;
            thisAgent.SetState<IdleAgentState>();
        }
    }
}