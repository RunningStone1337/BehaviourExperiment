using Events;
using System.Collections;

namespace BehaviourModel
{
    public class PupilListenToTeacherAtLessonAction : NonDirectedAction, ICompletedAction
    {
        public PupilListenToTeacherAtLessonAction():base()
        {
            actionType = ActionType.PayAttention;
        }
        public override IEnumerator TryPerformAction()
        {
            var cast = ActionActor as PupilAgent;
            var reason = ReactionSource as TeacherAgent;
            if (cast != null && reason != null && cast.AgentEnvironment.ChairInfo != null && cast.CurrentEvent is LessonEvent)
            {
                if (reason.CurrentState is LessonExplainingState<TeacherAgent>)
                {
                    cast.StartActionVisual(this);
                    var state = cast.SetState<TimingAttentionToAgentState<PupilAgent, TeacherAgent>>();
                    state.Initiate(cast, reason, actionMakingTime);
                    yield return state.StartState();
                    WasPerformed = true;
                }
                cast.SetDefaultState();
            }
        }
        public override void Initiate(IReactionSource reactSource, IAgent reactionActor)
        {
            base.Initiate(reactSource, reactionActor);
            var cast = (PupilAgent)ActionActor;
            actionMakingTime = cast.CharacterSystem.Intelligence.RawCharacterValue * 2.5f;
        }
    }
}