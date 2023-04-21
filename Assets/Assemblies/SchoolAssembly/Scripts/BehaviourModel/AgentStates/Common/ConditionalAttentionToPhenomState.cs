using System;
using System.Collections;

namespace BehaviourModel
{
    public class ConditionalAttentionToPhenomState<TStateHandler, TAttentionTarget> : AttentionToPhenomStateBase<TStateHandler, TAttentionTarget>
         where TStateHandler : SchoolAgentBase<TStateHandler>
        where TAttentionTarget : IPhenomenon
    {
        private Func<bool> continueStateCondition;

        public void Initiate(TStateHandler _thisAgent, TAttentionTarget attentionSource, Func<bool> condition)
        {
            continueStateCondition = condition;
            Initiate(_thisAgent, attentionSource);
        }

        public override IEnumerator StartState()
        {
            while (continueStateCondition.Invoke())
            {
                yield return RotateToFaceStep();
            }
            thisAgent.AutoMakeActions = true;
            thisAgent.SetDefaultState();
        }
    }
}