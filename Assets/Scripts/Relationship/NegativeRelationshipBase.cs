namespace BehaviourModel
{
    public abstract class NegativeRelationshipBase<TReaction, TFeature, TState> : RelationshipBase<TReaction, TFeature, TState>
        where TReaction : IReaction
        where TFeature : IFeature where TState : IState

        //where TFeature : IFeature where TState : IState
        //where TState : IState


    {
        protected NegativeRelationshipBase(AgentBase<TReaction, TFeature, TState>thisAgent, AgentBase<TReaction, TFeature, TState>secondAgent)
            : base(thisAgent, secondAgent)
        {
        }
    }
}