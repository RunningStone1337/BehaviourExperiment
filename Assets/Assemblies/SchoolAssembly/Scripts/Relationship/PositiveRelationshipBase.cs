namespace BehaviourModel
{
    public abstract class PositiveRelationshipBase<TAgent, TOtherAgent> :
        RelationshipBase<TAgent, TOtherAgent>
        where TAgent : IAgent
        where TOtherAgent : IAgent
    {
        protected PositiveRelationshipBase(TAgent thisAgent, TOtherAgent secondAgent) : base(thisAgent, secondAgent)
        {
        }
    }
}