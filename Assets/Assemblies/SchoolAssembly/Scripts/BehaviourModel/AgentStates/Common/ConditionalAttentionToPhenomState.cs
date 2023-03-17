using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class ConditionalAttentionToPhenomState<TStateHandler, TAttentionTarget> : AttentionToPhenomStateBase<TStateHandler, TAttentionTarget>
         where TStateHandler : SchoolAgentBase<TStateHandler>
        where TAttentionTarget : IPhenomenon
    {
        Func<bool> continueStateCondition;
        public void Initiate(TStateHandler _thisAgent, TAttentionTarget attentionSource, Func<bool> condition)
        {
            continueStateCondition = condition;
            Initiate(_thisAgent, attentionSource);
        }
        public override IEnumerator StartState()
        {
            Debug.Log($"Condition Attention state start, cached auto ");
            //yield return RotateToFaceSubject();

            while (continueStateCondition.Invoke())
            {
                yield return RotateToFaceStep();
                //yield return new WaitForFixedUpdate();
            }
            thisAgent.AutoMakeActions = true;
            thisAgent.SetDefaultState();
            Debug.Log($"Conditional attention state end, cached auto ");
        }
    }
}
