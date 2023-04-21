namespace BehaviourModel
{
    public class EnemyRelationship<TAgent, TOtherAgent, TState>
        : FoeRelationship<TAgent, TOtherAgent, TState>
        where TAgent : ICurrentStateHandler<TState>
        where TOtherAgent : IAgent
        where TState : IState
    {
        public EnemyRelationship(TAgent thisAgent, TOtherAgent secondAgent) : base(thisAgent, secondAgent)
        {
        }
        public override string ToString() => "Enemy";

        static readonly float enemyToFoe = -30;
        protected override bool NeedTransitonToNewRelationship(float currentRelationshipValue, out RelationshipBase<TAgent, TOtherAgent, TState> newRelation)
        {
            newRelation = default;
            if (currentRelationshipValue >= enemyToFoe)
            {
                newRelation = new FoeRelationship<TAgent, TOtherAgent, TState>(ThisAgent, SecondAgent);
                newRelation.CurrentRelationshipProgress = currentRelationshipValue - enemyToFoe;
                return true;
            }
            return false;
        }
    }
}