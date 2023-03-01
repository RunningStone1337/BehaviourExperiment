using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class TryAttractAttentionState<TStateHandler, TAttentionTarget> : SchoolAgentStateBase<TStateHandler>, IOptionalToCompleteState
        where TStateHandler: SchoolAgentBase<TStateHandler>
        where TAttentionTarget: SchoolAgentBase<TAttentionTarget>
    {
        TAttentionTarget agentToAttention;
        float timeout;
        bool continueAttempts;
        public bool IsContinue { get => continueAttempts; set => continueAttempts = value; }

        public override IEnumerator StartState()
        {
            if (agentToAttention.CurrentState is
                AttentionToAgentState<TAttentionTarget, TStateHandler> att && att.AttentionSubject == thisAgent)
                yield break;
            //TODO поворот агента к цели привлечения
            while (timeout > 0f && continueAttempts)
            {
                float startTry = Time.time;
                yield return TryAttractAgentAttention(agentToAttention);
                float endTry = Time.time - startTry;
                timeout -= endTry;
            }
            thisAgent.SetDefaultState();
        }

        private IEnumerator TryAttractAgentAttention(TAttentionTarget agentToAttention)
        {
            //если состояние прерываемо - пробуем прервать
            if (agentToAttention.CurrentState is IOptionalToCompleteState otcs)
            {
                agentToAttention.SetState<AttentionToAgentState<TAttentionTarget, TStateHandler>>();
                ((AttentionToAgentState<TAttentionTarget, TStateHandler>)agentToAttention.CurrentState).Initiate(agentToAttention, thisAgent, 3f);
                continueAttempts = false;
            }
            else
                yield return new WaitForSeconds(0.99f);
        }

        public void Initiate(TStateHandler thisAgent, TAttentionTarget agentAttractToAttention)
        {
            base.Initiate(thisAgent);
            agentToAttention = agentAttractToAttention;
            timeout = 11f - thisAgent.CharacterSystem.RestraintExpressiveness.RawCharacterValue;
            continueAttempts = true;
        }
    }
}
