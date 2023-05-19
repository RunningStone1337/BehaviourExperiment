
namespace BehaviourModel
{
    public class FamiliarRelationship<TAgent, TOtherAgent> 
        : RelationshipBase<TAgent, TOtherAgent>
        where TAgent : IAgent
        where TOtherAgent : IAgent
    {
        static readonly float toFellowBorder = 100f;
        static readonly float toFoeBorder = -50f;
        public FamiliarRelationship(TAgent thisAgent, TOtherAgent secondAgent) 
            : base(thisAgent, secondAgent)
        {
        }
        public override string ToString() => "Familiar";

        protected override bool TryTransitonToNewRelationship(out RelationshipBase<TAgent, TOtherAgent> newRelation)
        {
            newRelation = default;
            if (currentProgress >= toFellowBorder)
            {
                newRelation = new FellowRelationship<TAgent, TOtherAgent>(ThisAgent, SecondAgent);
                newRelation.CurrentRelationshipProgress = currentProgress - toFellowBorder;
                return true;
            }
            else if (currentProgress <= toFoeBorder)
            {
                newRelation = new FoeRelationship<TAgent, TOtherAgent>(ThisAgent, SecondAgent);
                newRelation.CurrentRelationshipProgress = currentProgress - toFoeBorder;
                return true;
            }
            return false;
        }
    }
}