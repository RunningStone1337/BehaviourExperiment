namespace BehaviourModel
{
    public abstract class NegativeRelationshipBase<TAgent, TOtherAgent, TState/*, TReaction, TFeature, TState, TSensor*/> 
        : RelationshipBase<TAgent, TOtherAgent, TState/*, TReaction, TFeature, TState, TSensor*/>
      where TAgent : ICurrentStateHandler<TState>
        where TOtherAgent : IAgent
        where TState : IState
        //where TReaction : IReaction
        //where TFeature : IFeature
        //where TSensor : ISensor


    {
        protected NegativeRelationshipBase(TAgent thisAgent, TOtherAgent secondAgent)
            : base(thisAgent, secondAgent)
        {
        }
    }
}