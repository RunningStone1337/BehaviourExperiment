using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class AttentionToAgentState<TStateHandler, TAttentionTarget> : AttentionToPhenomStateBase<TStateHandler, TAttentionTarget>
        where TStateHandler : SchoolAgentBase<TStateHandler>
        where TAttentionTarget : SchoolAgentBase<TAttentionTarget>
    {
        
       
    }
}
