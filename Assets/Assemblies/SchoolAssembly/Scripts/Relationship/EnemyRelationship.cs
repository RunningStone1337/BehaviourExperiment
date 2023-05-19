namespace BehaviourModel
{
    public class EnemyRelationship<TAgent, TOtherAgent>
        : FoeRelationship<TAgent, TOtherAgent>
        where TAgent : IAgent
        where TOtherAgent : IAgent
    {
        public EnemyRelationship(TAgent thisAgent, TOtherAgent secondAgent) : base(thisAgent, secondAgent)
        {
        }
        public override string ToString() => "Enemy";

        static readonly float enemyToFoe = -30;
        protected override bool TryTransitonToNewRelationship(out RelationshipBase<TAgent, TOtherAgent> newRelation)
        {
            newRelation = default;
            if (currentProgress >= enemyToFoe)
            {
                newRelation = new FoeRelationship<TAgent, TOtherAgent>(ThisAgent, SecondAgent);
                newRelation.CurrentRelationshipProgress = currentProgress - enemyToFoe;
                return true;
            }
            return false;
        }
    }
}