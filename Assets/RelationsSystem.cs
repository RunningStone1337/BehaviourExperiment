using Extensions;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class RelationsSystem : MonoBehaviour
    {
        [SerializeField] private Dictionary<AgentBase, ComradeRelationship> comradesAgents;
        [SerializeField] private Dictionary<AgentBase, FamiliarRelationship> familiarAgents;
        [SerializeField] private Dictionary<AgentBase, FellowRelationship> fellowsAgents;
        [SerializeField] private Dictionary<AgentBase, FoeRelationship> foesAgents;
        [SerializeField] private Dictionary<AgentBase, FriendRelationship> friendsAgents;
        [SerializeField] private Dictionary<AgentBase, EnemyRelationship> enemiesAgents;
        [SerializeField] private Dictionary<AgentBase, PoorKnownRelation> poorKnownAgents;
        [SerializeField] private AgentBase thisAgent;
        public bool IsComrade(AgentBase ab) => comradesAgents.ContainsKey(ab);

        /// <summary>
        /// Является ли <paramref name="agent"/> знакомым для агента?
        /// </summary>
        /// <param name="agent"></param>
        /// <returns></returns>
        public bool IsFamiliar(AgentBase ab) => familiarAgents.ContainsKey(ab);

        /// <summary>
        /// Текущее отношение thisAgent к <paramref name="ab"/>.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        public RelationshipBase GetCurrentRelationTo(AgentBase ab)
        {
            if (IsPoorKnown(ab))
                return poorKnownAgents[ab];
            if (IsFamiliar(ab))
                return familiarAgents[ab];
            else if (IsFellow(ab))
                return fellowsAgents[ab];
            else if (IsFoe(ab))
                return foesAgents[ab];
            else if (IsComrade(ab))
                return comradesAgents[ab];
            else if (IsEnemy(ab))
                return enemiesAgents[ab];
            else if (IsFriend(ab))
                return friendsAgents[ab];
            return default;
        }

        private bool IsPoorKnown(AgentBase ab) => poorKnownAgents.ContainsKey(ab);

        /// <summary>
        /// Приятель
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        public bool IsFellow(AgentBase ab) => fellowsAgents.ContainsKey(ab);

        public bool IsEnemy(AgentBase ab) => enemiesAgents.ContainsKey(ab);

        /// <summary>
        /// Непрятель
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        public bool IsFoe(AgentBase ab) => foesAgents.ContainsKey(ab);

        public bool IsFriend(AgentBase ab) => friendsAgents.ContainsKey(ab);

        /// <summary>
        /// Добавляет информацию о известной черте характера для <paramref name="agent"/> 
        /// если она ещё не известна.
        /// </summary>
        /// <param name="agent"></param>
        /// <param name="tr"></param>
        public void AddInfoAboutAgentIfNew(AgentBase agent, CharacterTraitBase tr)
        {
            var relation = GetCurrentRelationTo(agent);
            if (relation != null)//знакомы хоть как-то
                relation.KnownCharacterTraits.AddIfNotContains(tr);
            else
            {
                if (!poorKnownAgents.ContainsKey(agent))
                    poorKnownAgents.Add(agent, new PoorKnownRelation(thisAgent, agent));
                poorKnownAgents[agent].KnownCharacterTraits.AddIfNotContains(tr);
            }
        }
    }
}