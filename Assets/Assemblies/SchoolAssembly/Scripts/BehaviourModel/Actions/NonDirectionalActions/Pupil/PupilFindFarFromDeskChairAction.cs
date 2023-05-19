using System;
using System.Collections;

namespace BehaviourModel
{
    [Serializable]
    public class PupilFindFarFromDeskChairAction : NonDirectedAction, ICompletedAction
    {
        public PupilFindFarFromDeskChairAction() : base()
        {
        }

        public override IEnumerator TryPerformAction()
        {
            var cast = ActionActor as PupilAgent;
            if (cast != null && cast.AgentEnvironment.ChairInfo == null)
            {
                cast.SetState<FindFarFromDeskChairPupilState>();
                yield return cast.CurrentState.StartState();
                if (cast.AgentEnvironment.ChairInfo != null)
                    WasPerformed = true;
            }
        }
    }
}