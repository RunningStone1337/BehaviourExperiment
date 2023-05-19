namespace BehaviourModel
{
    public interface IRelationsInfluenceHandler<TAgent>
        where TAgent : IAgent
    {
        float GetRelationshipInfluence(TAgent agentToCalculate);
    }
}
