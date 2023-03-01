using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class AttentionToPhenomStateBase<TStateHandler, TAttentionTarget> : SchoolAgentStateBase<TStateHandler>, IOptionalToCompleteState
        where TStateHandler : SchoolAgentBase<TStateHandler>
        where TAttentionTarget : IPhenomenon
    {
        protected float attentionTimeout;
        public TAttentionTarget AttentionSubject { get; protected set; }
        public bool IsContinue { get ; set; }

        public void Initiate(TStateHandler thisStateHandler, TAttentionTarget attentionSource, float _attentionTimeout)
        {
            base.Initiate(thisStateHandler);
            IsContinue = true;
            AttentionSubject = attentionSource;
            attentionTimeout = _attentionTimeout;
        }
        public override IEnumerator StartState()
        {
            while (attentionTimeout > 0f && IsContinue)
            {
                yield return new WaitForFixedUpdate();
                attentionTimeout -= Time.fixedDeltaTime;
            }
            if (IsContinue)
                thisAgent.SetDefaultState();
        }
    }
}
