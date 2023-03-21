using Events;

namespace BehaviourModel
{
    public sealed class TeacherAgent : SchoolAgentBase<TeacherAgent>
    {
        public override GlobalEvent CurrentEvent => ((SchoolObservationsSystem<TeacherAgent>)ObservationsSystem).EventsSensor.CurrentEvent;

        public override void SetDefaultState()
        {
            SetState<IdleTeacherState>();
        }
    }
}