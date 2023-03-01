using BuildingModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class GoToBoardAction : PositivePhysicAction
    {
        public GoToBoardAction(PupilAgent thisAgent)
        {
            ActionActor = thisAgent;
        }

        public override IEnumerator TryPerformAction()
        {
            //успех - выйти к доске, выполнить ???, вернуться на место
            var board = InterierHandler.Handler.Boards.Random();
            var cast = (PupilAgent)ActionActor;
            cast.MovementTarget = board;
            cast.SetState<MoveToTargetState<PupilAgent>>();
            yield return cast.CurrentState.StartState();
        }
    }
}
