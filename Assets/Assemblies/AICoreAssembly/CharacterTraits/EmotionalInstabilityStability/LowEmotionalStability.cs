namespace BehaviourModel
{
    /// <summary>
    /// Низкая стабильность
    /// </summary>
    public class LowEmotionalStability<TAgent, TReaction, TFeature, TState, TSensor> : EmotionalInstabilityStability<TAgent, TReaction, TFeature, TState, TSensor>
        where TAgent : ICurrentStateHandler<TState> where TReaction : IReaction
        where TFeature : IFeature where TState : IState where TSensor : ISensor
    {
        public override void Initiate(int characterValue, TAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisConcreteCharType = CharTraitTypeExtended.LowEmotionalInstabilityStability;
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