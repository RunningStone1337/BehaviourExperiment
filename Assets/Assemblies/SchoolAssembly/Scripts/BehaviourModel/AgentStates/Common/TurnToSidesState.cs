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
            var startDirection = thisAgent.transform.up;
            var delta = Random.Range(45f, 60f);
            var rotator = new RotationHandler();
            var rotSpeed = Random.Range(RotationHandler.SlowRotation, RotationHandler.QuickRotation);
            yield return rotator.RotateToAngle(thisAgent.transform, delta, rotSpeed);
            if (!IsContinue)
                yield break;
            yield return new WaitForSeconds(Random.Range(2f, 3f));
            if (!IsContinue)
                yield break;
            yield return rotator.RotateToAngle(thisAgent.transform, -delta * 2, rotSpeed);
            if (!IsContinue)
                yield break;
            yield return new WaitForSeconds(Random.Range(2f, 3f));
            if (!IsContinue)
                yield break;
            yield return rotator.RotateToFaceDirection(startDirection, thisAgent.transform, rotSpeed);
            if (!IsContinue)
                yield break;
            thisAgent.SetDefaultState();
        }
    }
}
