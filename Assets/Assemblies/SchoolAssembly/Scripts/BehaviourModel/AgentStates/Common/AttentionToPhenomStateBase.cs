using Common;
using System.Collections;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class AttentionToPhenomStateBase<TStateHandler, TAttentionTarget> : SchoolAgentStateBase<TStateHandler>
        where TStateHandler : SchoolAgentBase<TStateHandler>
        where TAttentionTarget : IPhenomenon
    {
        protected float attentionTimeout;
        public TAttentionTarget AttentionSubject { get; protected set; }
        public bool IsContinue { get ; set; }

        public void Initiate(TStateHandler thisStateHandler, TAttentionTarget attentionSource)
        {
            base.Initiate(thisStateHandler);
            IsContinue = true;
            AttentionSubject = attentionSource;
            thisAgent.AutoMakeActions = false;
            thisAgent.Executor.ManualAction = StartState();
            thisAgent.BreakCurrentActing();
        }
        protected IEnumerator RotateToFaceStep()
        {
            var rotator = new RotationHandler();
            if (AttentionSubject is MonoBehaviour cast)
            {
                yield return rotator.RotateToFaceDirectionStep(cast.transform,
                    thisAgent.transform, RotationHandler.QuickRotation);
            }
        }
        protected IEnumerator RotateToFaceSubject()
        {
             var rotator = new RotationHandler();
            if (AttentionSubject is MonoBehaviour cast)
            {
                yield return rotator.RotateToFaceDirection(cast.transform,
                    thisAgent.transform, RotationHandler.QuickRotation);
            }
        }
    }
}
