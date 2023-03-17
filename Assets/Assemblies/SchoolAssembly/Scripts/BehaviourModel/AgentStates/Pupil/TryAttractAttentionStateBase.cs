using System.Collections;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class TryAttractAttentionStateBase<TStateHandler, TAttentionTarget> : SchoolAgentStateBase<TStateHandler>, IOptionalToCompleteState
        where TStateHandler: SchoolAgentBase<TStateHandler>
        where TAttentionTarget: SchoolAgentBase<TAttentionTarget>
    {
        TAttentionTarget agentToAttention;
        protected float tryingTimeout;
        protected bool continueAttempts;
        public bool IsContinue { get => continueAttempts; set => continueAttempts = value; }

        public override IEnumerator StartState()
        {
            if (agentToAttention.CurrentState is
                AttentionToPhenomStateBase<TAttentionTarget, TStateHandler> att && att.AttentionSubject == thisAgent)
                yield break;


            while (tryingTimeout > 0f && continueAttempts)
            {
                float startTry = Time.time;
                yield return TryAttractAgentAttention(agentToAttention);
                float endTry = Time.time - startTry;
                tryingTimeout -= endTry;
            }
            //thisAgent.SetDefaultState();
        }

        protected abstract IEnumerator TryAttractAgentAttention(TAttentionTarget agentToAttention);

        public void Initiate(TStateHandler thisAgent, TAttentionTarget agentAttractToAttention)
        {
            base.Initiate(thisAgent);
            agentToAttention = agentAttractToAttention;
            tryingTimeout = 11f - thisAgent.CharacterSystem.RestraintExpressiveness.RawCharacterValue;
            continueAttempts = true;
        }
    }
}
