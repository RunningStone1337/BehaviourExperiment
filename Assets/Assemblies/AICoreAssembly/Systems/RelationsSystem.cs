using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    public abstract class RelationsSystem<TAgent, TReaction, TFeature, TState, TSensor> :
        SystemBase<TAgent, TReaction, TFeature, TState, TSensor>
        where TAgent : ICurrentStateHandler<TState>, IAgent
        where TReaction : IReaction
        where TFeature : IFeature
        where TState : IState
        where TSensor : ISensor
    {
        /// <summary>
        /// Key - other agent, value - current relationship
        /// </summary>
        protected Dictionary<IAgent, RelationshipBase<TAgent, IAgent, TState>> relationsDicts;
       
        protected override void Awake()
        {
            base.Awake();
            relationsDicts = new Dictionary<IAgent, RelationshipBase<TAgent, IAgent, TState>>();
        }

        public RelationshipBase<TAgent, IAgent, TState>
            GetCurrentRelationTo<TOther>(TOther otherAgent)
            where TOther : IAgent
        {
            if (relationsDicts.ContainsKey(otherAgent))
                return relationsDicts[otherAgent];
            return default;
        }

        public void AddInfluenceForRelations(RelationshipBase<TAgent, IAgent, TState> relations, float relationsInfluence)
        {
            var newRelations = relations.AddInfluence(relationsInfluence);
            if (relations != newRelations)
                relationsDicts[relations.SecondAgent] = newRelations;
        }

        public TRelations CreateNew<TRelations>(TRelations newRelations)
            where TRelations : RelationshipBase<TAgent, IAgent, TState>
        {
            if (!relationsDicts.ContainsKey(newRelations.SecondAgent))
                relationsDicts.Add(newRelations.SecondAgent, newRelations);
            else throw new Exception("Attempt to create new relationship when system contains existing one, this is not allowed." +
                "To override existed relationship first demove old relationship force.");
            return newRelations;
        }

        public void ClearRelations()
        {
            relationsDicts.Clear();
        }    
    }
}