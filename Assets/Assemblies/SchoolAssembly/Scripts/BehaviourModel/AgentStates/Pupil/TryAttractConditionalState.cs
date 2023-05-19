using System;
using System.Collections;
using UnityEngine;

namespace BehaviourModel
{
    public class TryAttractConditionalState<TStateHandler, TAttentionTarget> : TryAttractAttentionStateBase<TStateHandler, TAttentionTarget>
        where TStateHandler : SchoolAgentBase<TStateHandler>
        where TAttentionTarget : SchoolAgentBase<TAttentionTarget>
    {
        Func<bool> contitionForCompanionToHeldAttention;
        protected override IEnumerator TryAttractAgentAttention(TAttentionTarget agentToAttention)
        {
            //если состояние прерываемо - пробуем прервать
            if (agentToAttention.CurrentState is IOptionalToCompleteState<TAttentionTarget>)
            {
                var state = agentToAttention.SetState<ConditionalAttentionToAgentState<TAttentionTarget, TStateHandler>>();
                state.Initiate(agentToAttention, thisAgent, contitionForCompanionToHeldAttention);
                continueAttempts = false;
            }
            else
                yield return new WaitForSeconds(0.99f);
        }
        public void Initiate(TStateHandler handler, TAttentionTarget companion, Func<bool> conditionToHoldAttention)
        {
            Initiate(handler, companion);
            contitionForCompanionToHeldAttention = conditionToHoldAttention;
        }
    }
}
