using System;
using System.Collections;

namespace BehaviourModel
{
    [Serializable]
    public class PupilFindClosestToDeskAction : NonDirectedAction, ICompletedAction
    {
        public PupilFindClosestToDeskAction() : base()
        {
        }

        public override IEnumerator TryPerformAction()
        {
            var cast = ActionActor as PupilAgent;
            if (cast != null && cast.AgentEnvironment.ChairInfo == null)
            {
                cast.SetState<FindClosestToDeskChairPupilState>();
                yield return cast.CurrentState.StartState();
                if (cast.AgentEnvironment.ChairInfo != null)
                    WasPerformed = true;
            }
        }
    }
}