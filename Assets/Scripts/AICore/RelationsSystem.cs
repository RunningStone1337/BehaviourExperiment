using System;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class RelationsSystem<TReaction, TFeature, TState> : SystemBase<TReaction, TFeature, TState>
        where TReaction : IReaction
        where TFeature: IFeature
        where TState : IState
    {
        //[SerializeField] private Dictionary<AgentBase<TFeatureBase, TStateBase>, ComradeRelationship> comradesAgents;
        //[SerializeField] private Dictionary<AgentBase<TFeatureBase, TStateBase>, FamiliarRelationship<TFeatureBase, TStateBase>> familiarAgents;
        //[SerializeField] private Dictionary<AgentBase<TFeatureBase, TStateBase>, FellowRelationship<TFeatureBase, TStateBase>> fellowsAgents;
        //[SerializeField] private Dictionary<AgentBase<TFeatureBase, TStateBase>, FoeRelationship<TFeatureBase, TStateBase>> foesAgents;
        //[SerializeField] private Dictionary<AgentBase<TFeatureBase, TStateBase>, FriendRelationship<TFeatureBase, TStateBase>> friendsAgents;
        //[SerializeField] private Dictionary<AgentBase<TFeatureBase, TStateBase>, EnemyRelationship<TFeatureBase, TStateBase>> enemiesAgents;
        //[SerializeField] private Dictionary<AgentBase, PoorKnownRelation> poorKnownAgents;
        private void Awake()
        {
            //comradesAgents = new Dictionary<AgentBase<TFeatureBase, TStateBase>, ComradeRelationship>();
            //familiarAgents = new Dictionary<AgentBase<TFeatureBase, TStateBase>, FamiliarRelationship<TFeatureBase, TStateBase>>();
            //fellowsAgents = new Dictionary<AgentBase<TFeatureBase, TStateBase>, FellowRelationship<TFeatureBase, TStateBase>>();
            //foesAgents = new Dictionary<AgentBase<TFeatureBase, TStateBase>, FoeRelationship<TFeatureBase, TStateBase>>();
            //friendsAgents = new Dictionary<AgentBase<TFeatureBase, TStateBase>, FriendRelationship<TFeatureBase, TStateBase>>();
            //enemiesAgents = new Dictionary<AgentBase<TFeatureBase, TStateBase>, EnemyRelationship<TFeatureBase, TStateBase>>();
            //poorKnownAgents = new Dictionary<AgentBase, PoorKnownRelation>();
        }
        //public bool IsComrade(AgentBase ab) => comradesAgents.ContainsKey(ab);

        /// <summary>
        /// Является ли <paramref name="agent"/> знакомым для агента?
        /// </summary>
        /// <param name="agent"></param>
        /// <returns></returns>
        //public bool IsFamiliar(AgentBase<IFeature> ab) => familiarAgents.ContainsKey(ab);

        public void RemoveRelations()
        {
            //poorKnownAgents.Clear();
            //enemiesAgents.Clear();
            //friendsAgents.Clear();
            //foesAgents.Clear();
            //fellowsAgents.Clear();
            //familiarAgents.Clear();
            //comradesAgents.Clear();
        }

        /// <summary>
        /// Текущее отношение thisAgent к <paramref name="ab"/>.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        public RelationshipBase<TReaction, TFeature, TState>  GetCurrentRelationTo<TAgent, TFeat>(TAgent ab) 
            where TAgent : AgentBase<TReaction, TFeature, TState>
        {
            //if (IsPoorKnown(ab))
            //    return poorKnownAgents[ab];
            //if (IsFamiliar(ab))
            //    return familiarAgents[ab];
            //else if (IsFellow(ab))
            //    return fellowsAgents[ab];
            //else if (IsFoe(ab))
            //    return foesAgents[ab];
            ////else if (IsComrade(ab))
            ////    return comradesAgents[ab];
            //else if (IsEnemy(ab))
            //    return enemiesAgents[ab];
            //else if (IsFriend(ab))
            //    return friendsAgents[ab];
            return default;
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

        private void ReplaceOldRelationship(RelationshipBase<TReaction, TFeature, TState> newRelation)
        {
            var sa = newRelation.SecondAgent;
            //RelationshipBase<AgentBase<IFeature>> oldRelation;
                /*  if (IsPoorKnown(sa))
                  {
                      oldRelation = poorKnownAgents[sa];
                      poorKnownAgents.Remove(sa);
                  }
                  ////else if (IsFamiliar(sa))*/
                //{
                //    oldRelation = familiarAgents[sa];
                //    familiarAgents.Remove(sa);
                //}
                //else if (IsFellow(sa))
                //{
                //    oldRelation = fellowsAgents[sa];
                //    fellowsAgents.Remove(sa);
                //}
                //else if (IsFoe(sa))
                //{
                //    oldRelation = foesAgents[sa];
                //    foesAgents.Remove(sa);
                //}
                ////else if (IsComrade(sa))
                ////{
                ////    oldRelation = comradesAgents[sa];
                ////    comradesAgents.Remove(sa);
                ////}
                //else if (IsEnemy(sa))
                //{
                //    oldRelation = enemiesAgents[sa];
                //    enemiesAgents.Remove(sa);
                //}
                //else if (IsFriend(sa))
                //{
                //    oldRelation = friendsAgents[sa];
                //    friendsAgents.Remove(sa);
                //}
            throw new Exception("Undefined relationship");
            //newRelation.InitFrom(oldRelation);
        }

        private void CreateNew(RelationshipBase<TReaction, TFeature, TState> newRelation)
        {
            //if (newRelation is PoorKnownRelation pkr)
            //    poorKnownAgents.Add(newRelation.SecondAgent, pkr);
            //if (newRelation is FamiliarRelationship<AgentBase<IFeature>> fam)
            //    familiarAgents.Add(newRelation.SecondAgent, fam);
            //else if (newRelation is FellowRelationship<TFeatureBase, TStateBase> fel)
            //    fellowsAgents.Add(newRelation.SecondAgent, fel);
            //else if (newRelation is FoeRelationship<TFeatureBase, TStateBase> foe)
            //    foesAgents.Add(newRelation.SecondAgent, foe);
            ////else if (newRelation is ComradeRelationship com)
            ////    comradesAgents.Add(newRelation.SecondAgent, com);
            //else if (newRelation is EnemyRelationship<TFeatureBase, TStateBase> en)
            //    enemiesAgents.Add(newRelation.SecondAgent, en);
            //else if (newRelation is FriendRelationship<TFeatureBase, TStateBase> fr)
            //    friendsAgents.Add(newRelation.SecondAgent, fr);
        }

        //private bool IsPoorKnown(AgentBase ab) => poorKnownAgents.ContainsKey(ab);

        /// <summary>
        /// Приятель
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        //public bool IsFellow(AgentBase<TFeatureBase, TStateBase> ab) => fellowsAgents.ContainsKey(ab);

        //public bool IsEnemy(AgentBase<TFeatureBase, TStateBase> ab) => enemiesAgents.ContainsKey(ab);

        /// <summary>
        /// Непрятель
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        //public bool IsFoe(AgentBase<TFeatureBase, TStateBase> ab) => foesAgents.ContainsKey(ab);

        //public bool IsFriend(AgentBase<TFeatureBase, TStateBase> ab) => friendsAgents.ContainsKey(ab);

        /// <summary>
        /// Добавляет информацию о известной черте характера для <paramref name="agent"/> 
        /// если она ещё не известна.
        /// </summary>
        /// <param name="agent"></param>
        /// <param name="tr"></param>
        //public void AddInfoAbouAgentBase<IFeature>IfNew(AgentBase<TFeatureBase, TStateBase> agent, CharacterTraitBase<TReaction, TFeature, TState> tr)
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