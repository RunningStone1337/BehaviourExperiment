using UnityEngine;

namespace BehaviourModel
{
    public class FoeRelationship<TAgent, TOtherAgent> : 
        NegativeRelationshipBase<TAgent, TOtherAgent>
        where TAgent : IAgent
        where TOtherAgent : IAgent
    {
        public FoeRelationship(TAgent thisAgent, TOtherAgent secondAgent) : base(thisAgent, secondAgent)
        {
        }
        public override string ToString() => "Foe";
        static readonly float foeToEnemy = -30;
        static readonly float foeToFellow = 100;
        protected override bool TryTransitonToNewRelationship(out RelationshipBase<TAgent, TOtherAgent> newRelation)
        {
            newRelation = default;
            if (currentProgress <= foeToEnemy)
            {
                newRelation = new EnemyRelationship<TAgent, TOtherAgent>(ThisAgent, SecondAgent)
                {
                    CurrentRelationshipProgress = currentProgress - foeToEnemy
                };
                return true;
            }
            else if (currentProgress >= foeToFellow)
            {
                newRelation = new FellowRelationship<TAgent, TOtherAgent>(ThisAgent, SecondAgent)
                {
                    CurrentRelationshipProgress = currentProgress - foeToFellow
                };
                return true;
            }
            return false;
        }
    }
}