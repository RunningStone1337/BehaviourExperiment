using System;

namespace BehaviourModel
{
    /// <summary>
    /// Base class for relationship between two agents.
    /// </summary>
    [Serializable]
    public abstract class RelationshipBase<TThisAgent, TOtherAgent>
        where TThisAgent : IAgent 
        where TOtherAgent : IAgent
    {
        protected float currentProgress;
        protected RelationshipBase(TThisAgent thisAgent, TOtherAgent secondAgent)
        {
            ThisAgent = thisAgent;
            SecondAgent = secondAgent;
            currentProgress = default;
        }

        public TOtherAgent SecondAgent { get; }

        public TThisAgent ThisAgent { get; }
        public float CurrentRelationshipProgress { get=> currentProgress; set=> currentProgress = value; }

        public virtual RelationshipBase<TThisAgent, TOtherAgent> AddInfluence(float relationsInfluence)
        {
            currentProgress += relationsInfluence;
            if (TryTransitonToNewRelationship( 
                out RelationshipBase<TThisAgent, TOtherAgent> newRelation))
                return newRelation;
            return this;
        }

        protected abstract bool TryTransitonToNewRelationship(out RelationshipBase<TThisAgent, TOtherAgent> newRelation);

    }
}