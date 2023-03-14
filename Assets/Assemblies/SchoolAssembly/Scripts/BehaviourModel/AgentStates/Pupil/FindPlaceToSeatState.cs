using BuildingModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class FindPlaceToSeatState<T> : SchoolAgentStateBase<T>
        where T: SchoolAgentBase<T>
    {
        public override IEnumerator StartState()
        {
            if (thisAgent.AgentEnvironment.ChairInfo == null)
            {
                var chair = FindPlaceToSeat();
                if (chair != null)
                {
                    thisAgent.MovementTarget = chair.transform;
                    thisAgent.SetState<MoveToTargetState<T>>();
                    yield return thisAgent.CurrentState.StartState();
                }
                else
                {
                    thisAgent.SetState<FindFreeChairState<T>>();
                    yield return thisAgent.CurrentState.StartState();
                }
            }
            thisAgent.SetDefaultState();
        }
        protected abstract ChairInterier FindPlaceToSeat();
    }
}
