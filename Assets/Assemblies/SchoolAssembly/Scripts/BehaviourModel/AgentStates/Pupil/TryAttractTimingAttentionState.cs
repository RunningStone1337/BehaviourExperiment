using System.Collections;
using UnityEngine;

namespace BehaviourModel
{
    public class TryAttractTimingAttentionState<TStateHandler, TAttentionTarget> : TryAttractAttentionStateBase<TStateHandler, TAttentionTarget>
          where TStateHandler : SchoolAgentBase<TStateHandler>
        where TAttentionTarget : SchoolAgentBase<TAttentionTarget>
    {
        protected override IEnumerator TryAttractAgentAttention(TAttentionTarget agentToAttention)
        {
            //если состояние прерываемо - пробуем прервать
            if (agentToAttention.CurrentState is IOptionalToCompleteState)
            {
                var state = agentToAttention.SetState<TimingAttentionToAgentState<TAttentionTarget, TStateHandler>>();
                state.Initiate(agentToAttention, thisAgent, 0.5f);
                continueAttempts = false;
            }
            else
                yield return new WaitForSeconds(0.99f);
        }
    }
}