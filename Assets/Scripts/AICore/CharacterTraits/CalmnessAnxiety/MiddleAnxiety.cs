namespace BehaviourModel
{
    /// <summary>
    /// —редн€€ тревожность
    /// </summary>
    public   class MiddleAnxiety<TReaction, TFeature, TState> : CalmnessAnxiety<TReaction, TFeature, TState>
        where TReaction : IReaction
        where TFeature : IFeature where TState : IState

    {
        //protected override float CalculateImportanceForFamiliar(AgentBase agent)
        //{
        //    float res = default;
        //    var currentRelation = ThisAgent.GetCurrentRelationTo(agent);
        //    if (currentRelation != null)
        //        res += currentRelation.GetImportanceValueFor(this);
        //    return res;
        //}
    }
}