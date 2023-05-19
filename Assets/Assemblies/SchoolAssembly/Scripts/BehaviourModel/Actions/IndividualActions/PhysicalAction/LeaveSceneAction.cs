using System.Collections;

namespace BehaviourModel
{
    public abstract class LeaveSceneAction<TAgent> : PhysicalAction, ICompletedAction
        where TAgent : SchoolAgentBase<TAgent>
    {
        public override IEnumerator TryPerformAction()
        {
            var cast = ActionActor as TAgent;
            if (cast != null)
            {
                var action = new GoToExitAction<TAgent>();
                action.Initiate(ReactionSource, cast);
                yield return action.TryPerformAction();
                if (action.WasPerformed)
                {
                    cast.StopActing();
                    WasPerformed = true;
                    cast.StartDisappearing();
                }
            }
        }
    }
}