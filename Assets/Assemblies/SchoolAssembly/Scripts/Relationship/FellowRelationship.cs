using UnityEngine;

namespace BehaviourModel
{
    public class FellowRelationship<TAgent, TOtherAgent, TState> 
        : PositiveRelationshipBase<TAgent, TOtherAgent, TState>
        where TAgent : ICurrentStateHandler<TState>
        where TOtherAgent : IAgent
        where TState : IState
    {
        public FellowRelationship(TAgent thisAgent, TOtherAgent secondAgent)
            : base(thisAgent, secondAgent)
        {
        }
        public override string ToString() => "Fellow";

        static readonly float fellowToFriendBorder = 150f;
        static readonly float fellowToFoeBorder = -30f;
        protected override bool NeedTransitonToNewRelationship(float currentRelationshipValue, out RelationshipBase<TAgent, TOtherAgent, TState> newRelation)
        {
            newRelation = default;
            if (currentRelationshipValue >= fellowToFriendBorder)
            {
                newRelation = new FriendRelationship<TAgent, TOtherAgent, TState>(ThisAgent, SecondAgent)
                {
                    CurrentRelationshipProgress = currentRelationshipValue - fellowToFriendBorder
                };
                return true;
            }
            else if (currentRelationshipValue <= fellowToFoeBorder)
            {
                newRelation = new FoeRelationship<TAgent, TOtherAgent, TState>(ThisAgent, SecondAgent)
                {
                    CurrentRelationshipProgress = currentRelationshipValue - fellowToFriendBorder
                };
                return true;
            }
            return false;
        }
    }
}