namespace BehaviourModel
{
    /// <summary>
    /// Нонконформист
    /// </summary>
    public class HighNonconformism<TAgent, TReaction, TFeature, TState, TSensor> : ConformismNonconformism<TAgent, TReaction, TFeature, TState, TSensor>
             where TAgent : ICurrentStateHandler<TState> where TReaction : IReaction
         where TFeature : IFeature where TState : IState where TSensor : ISensor
    {
        public override void Initiate(int characterValue, TAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisConcreteCharType = CharTraitTypeExtended.HighConformismNonconformism;
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