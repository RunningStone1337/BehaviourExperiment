namespace BehaviourModel
{
    /// <summary>
    /// Высокий радикализм
    /// </summary>
    public class HighRadicalism<TAgent, TReaction, TFeature, TState, TSensor> : ConservatismRadicalism<TAgent, TReaction, TFeature, TState, TSensor>
         where TAgent : ICurrentStateHandler<TState> where TReaction : IReaction
         where TFeature : IFeature where TState : IState where TSensor : ISensor
    {
        public override void Initiate(int characterValue, TAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisConcreteCharType = CharTraitTypeExtended.HighConservatismRadicalism;
        }

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