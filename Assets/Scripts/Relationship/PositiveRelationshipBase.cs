namespace BehaviourModel
{
    public abstract class PositiveRelationshipBase<TReaction, TFeature, TState> : RelationshipBase<TReaction, TFeature, TState>
        where TReaction : IReaction
        where TFeature : IFeature where TState : IState
    {
        protected PositiveRelationshipBase(AgentBase<TReaction, TFeature, TState> thisAgent, AgentBase<TReaction, TFeature, TState> secondAgent) : base(thisAgent, secondAgent)
        {
        }
    }
}