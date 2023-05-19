using UnityEngine;

namespace BehaviourModel
{
    public class FellowRelationship<TAgent, TOtherAgent> 
        : PositiveRelationshipBase<TAgent, TOtherAgent>
        where TAgent : IAgent
        where TOtherAgent : IAgent
    {
        public FellowRelationship(TAgent thisAgent, TOtherAgent secondAgent)
            : base(thisAgent, secondAgent)
        {
        }
        public override string ToString() => "Fellow";

        static readonly float fellowToFriendBorder = 150f;
        static readonly float fellowToFoeBorder = -30f;
        protected override bool TryTransitonToNewRelationship(out RelationshipBase<TAgent, TOtherAgent> newRelation)
        {
            newRelation = default;
            if (currentProgress >= fellowToFriendBorder)
            {
                newRelation = new FriendRelationship<TAgent, TOtherAgent>(ThisAgent, SecondAgent)
                {
                    CurrentRelationshipProgress = currentProgress - fellowToFriendBorder
                };
                return true;
            }
            else if (currentProgress <= fellowToFoeBorder)
            {
                newRelation = new FoeRelationship<TAgent, TOtherAgent>(ThisAgent, SecondAgent)
                {
                    CurrentRelationshipProgress = currentProgress - fellowToFriendBorder
                };
                return true;
            }
            return false;
        }
    }
}