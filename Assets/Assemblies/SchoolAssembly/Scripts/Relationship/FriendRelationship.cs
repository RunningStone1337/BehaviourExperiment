using UnityEngine;

namespace BehaviourModel
{
    public class FriendRelationship<TAgent, TOtherAgent, TState> 
        : FellowRelationship<TAgent, TOtherAgent, TState>
        where TAgent : ICurrentStateHandler<TState>
        where TOtherAgent : IAgent
        where TState : IState
    {
        public FriendRelationship(TAgent thisAgent, TOtherAgent secondAgent) 
            : base(thisAgent, secondAgent)
        {
        }
        public override string ToString() => "Friend";

        static readonly float friendToFellow = -50f;
        protected override bool NeedTransitonToNewRelationship(float currentRelationshipValue, out RelationshipBase<TAgent, TOtherAgent, TState> newRelation)
        {
            newRelation = default;
            if (currentRelationshipValue <= friendToFellow)
            {
                newRelation = new FellowRelationship<TAgent, TOtherAgent, TState>(ThisAgent, SecondAgent)
                {
                    CurrentRelationshipProgress = currentRelationshipValue - friendToFellow
                };
                return true;
            }
            return false;
        }
    }
}