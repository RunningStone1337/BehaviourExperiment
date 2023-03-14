using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class ConditionalAttentionToAgentState<TStateHandler, TAttentionTarget> : ConditionalAttentionToPhenomState<TStateHandler, TAttentionTarget>
         where TStateHandler : SchoolAgentBase<TStateHandler>
        where TAttentionTarget : SchoolAgentBase<TAttentionTarget>
    {
        
    }
}
