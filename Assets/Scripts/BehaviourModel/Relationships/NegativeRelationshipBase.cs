namespace BehaviourModel
{
    public abstract class NegativeRelationshipBase : RelationshipBase
    {
        protected NegativeRelationshipBase(AgentBase thisAgent, AgentBase secondAgent) : base(thisAgent, secondAgent)
        {
        }
    }
}