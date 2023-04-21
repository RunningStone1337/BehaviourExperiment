using Events;

namespace BehaviourModel
{
    public class PupilAgent : SchoolAgentBase<PupilAgent>

    {
        void Awake()
        {
            if (currentState == null)
                SetState<PupilChooseActionState>();
        }

        public override GlobalEvent CurrentEvent => ((SchoolObservationsSystem<PupilAgent>)ObservationsSystem).EventsSensor.CurrentEvent;

        public override void SetDefaultState()
        {
            SetState<IdleState<PupilAgent>>();
        }
    }
}