using Events;

namespace BehaviourModel
{
    public class PupilAgent : SchoolAgentBase<PupilAgent>
    {

        public override GlobalEvent CurrentEvent => ((SchoolObservationsSystem<PupilAgent>)ObservationsSystem).EventsSensor.CurrentEvent;

        public override void SetDefaultState()
        {
            SetState<IdleState<PupilAgent>>();
        }
    }
}