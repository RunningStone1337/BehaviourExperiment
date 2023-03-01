using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class ListenToAgentActionBase<TStateHandler, TListenTarget> : IndividualPerciptionActionBase
        where TStateHandler: SchoolAgentBase<TStateHandler> 
        where TListenTarget : SchoolAgentBase<TListenTarget> 
    {
        public override IEnumerator TryPerformAction()
        {
            var actor = (TStateHandler)ActionActor;
            var listeningAgent = ReactionSource as TListenTarget;
            if (listeningAgent != null && actor.AgentEnvironment.ChairInfo != null)
            {
                actor.SetState<AttentionToAgentState<TStateHandler, TListenTarget>>();
                ((AttentionToAgentState<TStateHandler, TListenTarget>)actor.CurrentState).Initiate(actor, listeningAgent, 3f);
                yield return actor.CurrentState.StartState();
                WasPerformed = true;
            }
        }
    }
}
