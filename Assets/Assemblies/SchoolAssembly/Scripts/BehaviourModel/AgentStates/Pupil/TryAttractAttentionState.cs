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
        float tryingTimeout;
        bool continueAttempts;
        public bool IsContinue { get => continueAttempts; set => continueAttempts = value; }

        public override IEnumerator StartState()
        {
            if (agentToAttention.CurrentState is
                TimingAttentionToAgentState<TAttentionTarget, TStateHandler> att && att.AttentionSubject == thisAgent)
                yield break;

            //var rotator = new RotationHandler();
            //yield return rotator.RotateToFaceDirection(agentToAttention.transform.position - thisAgent.transform.position, thisAgent.AgentRigidbody, 2f);

            while (tryingTimeout > 0f && continueAttempts)
            {
                float startTry = Time.time;
                yield return TryAttractAgentAttention(agentToAttention);
                float endTry = Time.time - startTry;
                tryingTimeout -= endTry;
            }
            //thisAgent.SetDefaultState();
        }

        private IEnumerator TryAttractAgentAttention(TAttentionTarget agentToAttention)
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

        public void Initiate(TStateHandler thisAgent, TAttentionTarget agentAttractToAttention)
        {
            base.Initiate(thisAgent);
            agentToAttention = agentAttractToAttention;
            tryingTimeout = 11f - thisAgent.CharacterSystem.RestraintExpressiveness.RawCharacterValue;
            continueAttempts = true;
        }
    }
}
