using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    public class RelationsSystem<TAgent, TReaction, TFeature, TSensor> :
        SystemBase<TAgent, TReaction, TFeature, TSensor>
        where TAgent :  IAgent
        where TReaction : IAction
        where TFeature : IFeature
        where TSensor : ISensor
    {
        /// <summary>
        /// Key - other agent, value - current relationship
        /// </summary>
        protected Dictionary<IAgent, RelationshipBase<TAgent, IAgent>> relationsDicts;
       
        protected override void Awake()
        {
            base.Awake();
            relationsDicts = new Dictionary<IAgent, RelationshipBase<TAgent, IAgent>>();
        }

        public RelationshipBase<TAgent, IAgent>
            GetCurrentRelationTo<TOther>(TOther otherAgent)
            where TOther : IAgent
        {
            if (relationsDicts.ContainsKey(otherAgent))
                return relationsDicts[otherAgent];
            return default;
        }

        public virtual void AddInfluenceForRelations(RelationshipBase<TAgent, IAgent> relations, float relationsInfluence)
        {
            var newRelations = relations.AddInfluence(relationsInfluence);
            if (relations != newRelations)
                relationsDicts[relations.SecondAgent] = newRelations;
        }

        public void AddIfNotContains<TRelations>(TRelations newRelations)
            where TRelations : RelationshipBase<TAgent, IAgent>
        {
            if (!relationsDicts.ContainsKey(newRelations.SecondAgent))
                relationsDicts.Add(newRelations.SecondAgent, newRelations);
            else throw new Exception("Attempt to create new relationship when system contains existing one, this is not allowed." +
                "To override existed relationship first remove old relationship manually.");
        }
        public void RemoveIfCintainsRelationship<TRelations>(TRelations rel)
            where TRelations : RelationshipBase<TAgent, IAgent>
        {
            if (relationsDicts.ContainsKey(rel.SecondAgent))
                relationsDicts.Remove(rel.SecondAgent);
        }

        public void ClearRelations()
        {
            relationsDicts.Clear();
        }    
    }
}