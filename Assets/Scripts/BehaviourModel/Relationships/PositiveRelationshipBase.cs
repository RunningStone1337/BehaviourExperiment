namespace BehaviourModel
{
    public abstract class PositiveRelationshipBase : RelationshipBase
    {
        protected PositiveRelationshipBase(AgentBase thisAgent, AgentBase secondAgent) : base(thisAgent, secondAgent)
        {
        }
    }
}