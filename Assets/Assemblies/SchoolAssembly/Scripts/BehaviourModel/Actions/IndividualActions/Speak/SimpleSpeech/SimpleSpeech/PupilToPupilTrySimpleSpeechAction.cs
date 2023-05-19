using System.Collections;
using UnityEngine;

namespace BehaviourModel
{
    public class PupilToPupilTrySimpleSpeechAction : TryPrimitiveSpeechAction<PupilAgent, PupilAgent>, ICompletedAction, IRequest
    {
        public override IEnumerator TryPerformAction()
        {
            actor = ActionActor as PupilAgent;
            paricipiant = ReactionSource as PupilAgent;
            if (actor != null && paricipiant != null)
            {
                //нужно ли подходить ?
                yield return TryMoveToParticipiant();
                yield return base.TryPerformAction();
            }
        }

        private IEnumerator TryMoveToParticipiant()
        {
            var dist = Vector3.Distance(actor.transform.position, paricipiant.transform.position);
            //подойти к собеседнику
            if (dist > 0.5f && paricipiant.AgentEnvironment.ChairInfo == null)
            {
                actor.MovementTarget = paricipiant.transform;
                var state = actor.SetState<MoveToTargetState<PupilAgent>>();
                yield return state.StartState();
            }
        }
    }
}