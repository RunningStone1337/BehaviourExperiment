namespace BehaviourModel
{
    /// <summary>
    /// Высокая тревожность.
    /// </summary>
    public   class HighAnxiety<TReaction, TFeature, TState> : CalmnessAnxiety<TReaction, TFeature, TState>
        where TReaction : IReaction
        where TFeature : IFeature
        where TState : IState
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