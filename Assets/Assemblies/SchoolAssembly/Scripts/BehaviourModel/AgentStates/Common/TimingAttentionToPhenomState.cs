using System.Collections;
using UnityEngine;

namespace BehaviourModel
{
    public class TimingAttentionToPhenomState<TStateHandler, TAttentionTarget> : AttentionToPhenomStateBase<TStateHandler, TAttentionTarget>
         where TStateHandler : SchoolAgentBase<TStateHandler>
        where TAttentionTarget : IPhenomenon
    {
        public void Initiate(TStateHandler thisStateHandler, TAttentionTarget attentionSource, float stateTimeout)
        {
            Initiate(thisStateHandler, attentionSource);
            attentionTimeout = stateTimeout;
        }

        public override IEnumerator StartState()
        {
            var oldRot = thisAgent.transform.up;
            yield return RotateToFaceSubject();

            while (attentionTimeout > 0f && IsContinue)
            {
                yield return new WaitForFixedUpdate();
                attentionTimeout -= Time.fixedDeltaTime*Time.timeScale;
            }
            var rotator = new RotationHandler();
            yield return rotator.RotateToFaceDirection(oldRot, thisAgent.transform, RotationHandler.QuickRotation);
            thisAgent.SetDefaultState();
            thisAgent.AutoMakeActions = true;
        }
    }
}