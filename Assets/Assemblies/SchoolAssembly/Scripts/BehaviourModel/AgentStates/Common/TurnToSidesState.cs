using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class TurnToSidesState<TAgent> : SchoolAgentStateBase<TAgent>, IOptionalToCompleteState
        where TAgent : SchoolAgentBase<TAgent>
    {
        public bool IsContinue { get; set; } = true;

        public override IEnumerator StartState()
        {
            float startRotation = thisAgent.AgentRigidbody.rotation;
            float targetRotation = startRotation + Random.Range(45f, 60f);
            var rotator = new RotationHandler();
            yield return rotator.RotateToAngle(thisAgent.AgentRigidbody, targetRotation, 3f);
            if (!IsContinue)
                yield break;
            yield return new WaitForSeconds(Random.Range(1f, 1.5f));
            if (!IsContinue)
                yield break;
            targetRotation = startRotation - Random.Range(45f, 60f);
            yield return rotator.RotateToAngle(thisAgent.AgentRigidbody, targetRotation, 3f);
            if (!IsContinue)
                yield break;
            yield return new WaitForSeconds(Random.Range(1f, 1.5f));
            if (!IsContinue)
                yield break;
            yield return rotator.RotateToAngle(thisAgent.AgentRigidbody, startRotation, 3f);
            if (!IsContinue)
                yield break;
            thisAgent.SetDefaultState();
        }
    }
}
