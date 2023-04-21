using UnityEngine;

namespace BehaviourModel
{
    public class FamiliarRelationship<TAgent, TOtherAgent, TState> 
        : RelationshipBase<TAgent, TOtherAgent, TState>
        where TAgent : ICurrentStateHandler<TState>
        where TOtherAgent : IAgent
        where TState : IState
    {
        static readonly float toFellowBorder = 100f;
        static readonly float toFoeBorder = -50f;
        public FamiliarRelationship(TAgent thisAgent, TOtherAgent secondAgent) 
            : base(thisAgent, secondAgent)
        {
        }
        public override string ToString() => "Familiar";

        protected override bool NeedTransitonToNewRelationship(float currentRelationshipValue, out RelationshipBase<TAgent, TOtherAgent, TState> newRelation)
        {
            newRelation = default;
            if (currentRelationshipValue >= toFellowBorder)
            {
                newRelation = new FellowRelationship<TAgent, TOtherAgent,TState>(ThisAgent, SecondAgent);
                newRelation.CurrentRelationshipProgress = currentRelationshipValue - toFellowBorder;
                return true;
            }
            else if (currentRelationshipValue <= toFoeBorder)
            {
                newRelation = new FoeRelationship<TAgent, TOtherAgent,TState>(ThisAgent, SecondAgent);
                newRelation.CurrentRelationshipProgress = currentRelationshipValue - toFoeBorder;
                return true;
            }
            return false;
        }
    }
}