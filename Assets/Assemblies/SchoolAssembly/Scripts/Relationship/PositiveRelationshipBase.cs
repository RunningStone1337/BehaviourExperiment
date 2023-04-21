namespace BehaviourModel
{
    public abstract class PositiveRelationshipBase<TAgent, TOtherAgent, TState> :
        RelationshipBase<TAgent, TOtherAgent, TState>
        where TAgent : ICurrentStateHandler<TState>
        where TOtherAgent : IAgent
        where TState : IState
    {
        protected PositiveRelationshipBase(TAgent thisAgent, TOtherAgent secondAgent) : base(thisAgent, secondAgent)
        {
        }
    }
}