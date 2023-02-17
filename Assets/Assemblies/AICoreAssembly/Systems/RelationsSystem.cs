using System;
using System.Collections.Generic;

namespace BehaviourModel
{
    public abstract class RelationsSystem<TAgent, TReaction, TFeature, TState, TSensor> :
        SystemBase<TAgent, TReaction, TFeature, TState, TSensor>
        where TAgent : ICurrentStateHandler<TState>
        where TReaction : IReaction
        where TFeature : IFeature
        where TState : IState
        where TSensor : ISensor
    {
        /// <summary>
        /// Key - other agent, value - current relationship
        /// </summary>
        protected Dictionary<IAgent, RelationshipBase<TAgent, IAgent, TState>> relationsDicts;
       
        private void Awake()
        {
            relationsDicts = new Dictionary<IAgent, RelationshipBase<TAgent, IAgent, TState>>();
        }

        public RelationshipBase<TAgent, IAgent, TState>
            GetCurrentRelationTo<TOther>(TOther otherAgent)
            where TOther : IAgent
        {
            if (relationsDicts.ContainsKey(otherAgent))
            {
                return relationsDicts[otherAgent];
            }
            return default;
        }

        public void RemoveRelations()
        {
            relationsDicts.Clear();
        }

        //public void CreateNewRelationship(RelationshipBase<AgentBase<IFeature>> newRelation)
        //{
        //    var existRelation = GetCurrentRelationTo(newRelation.SecondAgent);
        //    if (existRelation == null)
        //    {
        //        CreateNew(newRelation);
        //    }
        //    else
        //    {
        //        ReplaceOldRelationship(newRelation);
        //    }
        //}
        //private bool IsPoorKnown(AgentBase ab) => poorKnownAgents.ContainsKey(ab);

       

        /// <summary>
        /// Добавляет информацию о известной черте характера для <paramref name="agent"/>
        /// если она ещё не известна.
        /// </summary>
        /// <param name="agent"></param>
        /// <param name="tr"></param>
        //public void AddInfoAbouAgentBase<IFeature>IfNew(AgentBase<TFeatureBase, TStateBase> agent, CharacterTraitBase<TAgent, TReaction, TFeature, TState, TSensor> tr)
        //{
        //    var relation = GetCurrentRelationTo(agent);
        //    if (relation != null)//знакомы хоть как-то
        //        relation.KnownCharacterTraits.AddIfNotContains(tr);
        //    else
        //    {
        //        //if (!poorKnownAgents.ContainsKey(agent))
        //        //    poorKnownAgents.Add(agent, new PoorKnownRelation(thisAgent, agent));
        //        //poorKnownAgents[agent].KnownCharacterTraits.AddIfNotContains(tr);
        //    }
        //}
    }
}