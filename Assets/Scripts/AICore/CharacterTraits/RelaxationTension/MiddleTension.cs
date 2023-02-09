namespace BehaviourModel
{
    /// <summary>
    /// —редн€€ напр€жЄнность
    /// </summary>
    public   class MiddleTension<TReaction, TFeature, TState> : RelaxationTension<TReaction, TFeature, TState>
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