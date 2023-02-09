
using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// Низкая тревожность=спокойный
    /// </summary>
    public class LowAnxiety<TReaction, TFeature, TState> : CalmnessAnxiety<TReaction, TFeature, TState>
         where TReaction : IReaction
        where TFeature : IFeature where TState : IState
    {
        //protected override float CalculateImportanceForFamiliar(AgentBase agent)
        //{
        //    float res = default;
        //    var currentRelation = ThisAgent.GetCurrentRelationTo(agent);
        //    if (currentRelation!= null)
        //        res += currentRelation.GetImportanceValueFor(this);
        //    return res;
        //}
        
    }
}