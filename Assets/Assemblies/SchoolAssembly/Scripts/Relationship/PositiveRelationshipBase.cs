namespace BehaviourModel
{
    public abstract class PositiveRelationshipBase<TAgent, TOtherAgent, TState/*, TReaction, TFeature, TState, TSensor*/> :
        RelationshipBase<TAgent, TOtherAgent, TState/*, TReaction, TFeature, TState, TSensor*/>
       where TAgent : ICurrentStateHandler<TState>
        where TOtherAgent : IAgent
        //where TReaction : IReaction
        //where TFeature : IFeature
        where TState : IState
        //where TSensor : ISensor
    {
        protected PositiveRelationshipBase(TAgent thisAgent, TOtherAgent secondAgent) : base(thisAgent, secondAgent)
        {
        }
    }
}