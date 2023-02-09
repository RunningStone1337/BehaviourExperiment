namespace BehaviourModel
{
    /// <summary>
    /// Высокий радикализм
    /// </summary>
    public class HighRadicalism<TReaction, TFeature, TState> : ConservatismRadicalism<TReaction, TFeature, TState>
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