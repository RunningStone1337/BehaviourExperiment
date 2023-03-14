using System.Collections;

namespace BehaviourModel
{
    public class PupilFindFreeChairAction : NonDirectedAction, ICompletedAction
    {
        public PupilFindFreeChairAction() : base()
        {
        }

        public override IEnumerator TryPerformAction()
        {
            var cast = ActionActor as PupilAgent;
            if (cast != null && cast.AgentEnvironment.ChairInfo == null)
            {
                var state = cast.SetState<FindFreeChairPupilState>();
                yield return state.StartState();
                if (cast.AgentEnvironment.ChairInfo != null)
                    WasPerformed = true;
            }
        }
    }
}