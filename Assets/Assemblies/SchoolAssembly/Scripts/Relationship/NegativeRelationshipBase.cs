namespace BehaviourModel
{
    public abstract class NegativeRelationshipBase<TAgent, TOtherAgent, TState> 
        : RelationshipBase<TAgent, TOtherAgent, TState>
        where TAgent : ICurrentStateHandler<TState>
        where TOtherAgent : IAgent
        where TState : IState
    {
        protected NegativeRelationshipBase(TAgent thisAgent, TOtherAgent secondAgent)
            : base(thisAgent, secondAgent)
        {
        }
    }
}