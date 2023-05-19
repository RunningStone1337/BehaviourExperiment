namespace BehaviourModel
{
    public abstract class NegativeRelationshipBase<TAgent, TOtherAgent> 
        : RelationshipBase<TAgent, TOtherAgent>
        where TAgent : IAgent
        where TOtherAgent : IAgent
    {
        protected NegativeRelationshipBase(TAgent thisAgent, TOtherAgent secondAgent)
            : base(thisAgent, secondAgent)
        {
        }
    }
}