using Events;
using System.Collections;

namespace BehaviourModel
{
    public class TeacherExplainLessonAction : NonDirectedAction, ICompletedAction
    {
        public override void Initiate(IReactionSource reactSource, IAgent reactionActor)
        {
            base.Initiate(reactSource, reactionActor);
            actionMakingTime = float.MaxValue;
        }

        public override IEnumerator TryPerformAction()
        {
            var cast = (TeacherAgent)ActionActor;
            var evCast = ReactionSource as LessonEvent;
            if (evCast != null && cast.CurrentEvent is LessonEvent)
            {
                var move = new TeacherTryMoveToBoardAction();
                move.Initiate(evCast, cast);
                yield return move.TryPerformAction();

                cast.StartActionVisual(this);
                var state = cast.SetState<LessonExplainingState<TeacherAgent>>();
                state.Initiate(cast);
                yield return state.StartState();
                cast.EndActionVisualForce();
                WasPerformed = true;
            }
        }
    }
}