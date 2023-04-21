using UnityEngine;

namespace BehaviourModel
{
    public class FoeRelationship<TAgent, TOtherAgent, TState> : 
        NegativeRelationshipBase<TAgent, TOtherAgent, TState>
        where TAgent : ICurrentStateHandler<TState>
        where TOtherAgent : IAgent
        where TState : IState
    {
        public FoeRelationship(TAgent thisAgent, TOtherAgent secondAgent) : base(thisAgent, secondAgent)
        {
        }
        public override string ToString() => "Foe";
        static readonly float foeToEnemy = -30;
        static readonly float foeToFellow = 100;
        protected override bool NeedTransitonToNewRelationship(float currentRelationshipValue, out RelationshipBase<TAgent, TOtherAgent, TState> newRelation)
        {
            newRelation = default;
            if (currentRelationshipValue <= foeToEnemy)
            {
                newRelation = new EnemyRelationship<TAgent, TOtherAgent, TState>(ThisAgent, SecondAgent)
                {
                    CurrentRelationshipProgress = currentRelationshipValue - foeToEnemy
                };
                return true;
            }
            else if (currentRelationshipValue >= foeToFellow)
            {
                newRelation = new FellowRelationship<TAgent, TOtherAgent, TState>(ThisAgent, SecondAgent)
                {
                    CurrentRelationshipProgress = currentRelationshipValue - foeToFellow
                };
                return true;
            }
            return false;
        }
    }
}