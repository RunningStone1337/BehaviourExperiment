using BuildingModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class GoToBoardToStudyAction : PositivePhysicAction
    {
        public BoardInterier BoardToGo { get; private set; }
        public GoToBoardToStudyAction(PupilAgent thisAgent)
        {
            ActionActor = thisAgent;
            BoardToGo = InterierHandler.Handler.Boards.GetRandom();
        }

        public override IEnumerator TryPerformAction()
        {
            var cast = (PupilAgent)ActionActor;
            cast.MovementTarget = BoardToGo.transform;
            cast.SetState<MoveToTargetState<PupilAgent>>();
            yield return cast.CurrentState.StartState();
        }
    }
}
