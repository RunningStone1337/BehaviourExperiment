using BuildingModule;
using System.Collections;

namespace BehaviourModel
{
    public abstract class FindPlaceToSeatState<T> : SchoolAgentStateBase<T>
        where T : SchoolAgentBase<T>
    {
        protected abstract ChairInterier FindPlaceToSeat();

        public override IEnumerator StartState()
        {
            if (thisAgent.AgentEnvironment.ChairInfo == null)
            {
                ChairInterier chair;
                if (thisAgent.AgentEnvironment.BindedChair == null)
                    chair = FindPlaceToSeat();
                else
                    chair = thisAgent.AgentEnvironment.BindedChair;

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
    }
}