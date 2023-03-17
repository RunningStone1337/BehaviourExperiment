using BuildingModule;
using System;
using System.Collections;
using UnityEngine;

namespace BehaviourModel
{
    public class TeacherTryMoveToBoardAction : PhysicalAction, ICompletedAction
    {
        TeacherAgent thisAgent;
        public override IEnumerator TryPerformAction()
        {
            thisAgent = (TeacherAgent)ActionActor;
            bool noBoards = IsNoBoardsArround();
            if (noBoards)
            {
                var board = InterierHandler.Handler.Boards.GetRandom();
                thisAgent.MovementTarget = board.transform;
                var state = thisAgent.SetState<MoveToTargetState<TeacherAgent>>();
                yield return state.StartState();
                WasPerformed = true;
            }
        }

        private bool IsNoBoardsArround()
        {
            //var boards = InterierHandler.Handler.Boards;
            Collider2D[] colliders = new Collider2D[32];
            thisAgent.AgentRigidbody.GetContacts(colliders);
            foreach (var c in colliders)
            {
                if (c != null && c.TryGetComponent(out MovePoint place))
                    return false;
            }
            return true;
        }
    }
}