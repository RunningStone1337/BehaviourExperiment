using UnityEngine;

namespace BehaviourModel
{
    public class FriendRelationship<TAgent, TOtherAgent> 
        : FellowRelationship<TAgent, TOtherAgent>
        where TAgent : IAgent
        where TOtherAgent : IAgent
    {
        public FriendRelationship(TAgent thisAgent, TOtherAgent secondAgent) 
            : base(thisAgent, secondAgent)
        {
        }
        public override string ToString() => "Friend";

        static readonly float friendToFellow = -50f;
        protected override bool TryTransitonToNewRelationship(out RelationshipBase<TAgent, TOtherAgent> newRelation)
        {
            newRelation = default;
            if (currentProgress <= friendToFellow)
            {
                newRelation = new FellowRelationship<TAgent, TOtherAgent>(ThisAgent, SecondAgent)
                {
                    CurrentRelationshipProgress = currentProgress - friendToFellow
                };
                return true;
            }
            return false;
        }
    }
}