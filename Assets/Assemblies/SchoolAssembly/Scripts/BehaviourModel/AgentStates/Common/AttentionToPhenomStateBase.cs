using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class AttentionToPhenomStateBase<TStateHandler, TAttentionTarget> : SchoolAgentStateBase<TStateHandler>, IOptionalToCompleteState
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
            thisAgent.Brain.ManualAction = StartState();
        }
       
        protected IEnumerator RotateToFaceSubject()
        {
             var rotator = new RotationHandler();
            if (AttentionSubject is MonoBehaviour cast)
            {
                yield return rotator.RotateToFaceDirection(cast.transform.position - thisAgent.transform.position,
                    thisAgent.AgentRigidbody, 3f);
            }
        }
    }
}
