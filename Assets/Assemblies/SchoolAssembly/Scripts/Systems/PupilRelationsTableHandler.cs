using BuildingModule;
using Events;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class PupilRelationsTableHandler : RelationsTablesHandlerBase
    {
        #region tables
        #region to agents 
        [Header("Attention")]
        #region attention

        [SerializeField] private CharacterToPhenomFloatRelationsLists characterToTeacherAttentionTable;
        [SerializeField] private CharacterToPhenomFloatRelationsLists characterToPupilAttentionTable;
        [SerializeField] private CharacterToPhenomFloatRelationsLists characterToInterierAttentionTable;
        [SerializeField] private CharacterToPhenomFloatRelationsLists characterToEventsAttentionTable;
        public CharacterToPhenomFloatRelationsLists CharacterToInterierAttentionTable => characterToInterierAttentionTable;
        public CharacterToPhenomFloatRelationsLists CharacterToEventsAttentionTable => characterToEventsAttentionTable;
        public CharacterToPhenomFloatRelationsLists CharacterToPupilAttentionTable => characterToPupilAttentionTable;
        public CharacterToPhenomFloatRelationsLists CharacterToTeacherAttentionTable => characterToTeacherAttentionTable;

        #endregion attention
      

        //[Header("Reactions")]
        #region reactions
        //[SerializeField] private CharacterToPhenomReactionsTable characterToPupilReactionsTable;
        //[SerializeField] private CharacterToPhenomReactionsTable characterToTeacherReactionsTable;
        //public CharacterToPhenomReactionsTable CharacterToPupilReactionsTable => characterToPupilReactionsTable;
        //public CharacterToPhenomReactionsTable CharacterToTeacherReactionsTable => characterToTeacherReactionsTable;
        #endregion reactions

        #endregion to agents
        #endregion tables

        #region attention
        //internal float CalculateAttentionForRelation(
        //    RelationshipBase<PupilAgent, IAgent, SchoolAgentStateBase<PupilAgent>> rel,
        //    CharacterTraitBase<PupilAgent, ReactionBase, FeatureBase, SchoolAgentStateBase<PupilAgent>, Sensor> trait,
        //    GlobalEvent currentEvent)
        //{
            

        //    return table.GetTableValueFor(currentEvent.GetType().Name, trait.ThisConcreteCharType, relationKey)
        //        * trait.SpecializedCharacterValue * table.ScallingValue;
        //}

      

        internal float CalculateAttentionForInterier(PlacedInterier phenom,
            CharacterTraitBase<PupilAgent, ReactionBase, FeatureBase, SchoolAgentStateBase<PupilAgent>, Sensor> trait,
            GlobalEvent currentEvent)
        {
            var t = characterToInterierAttentionTable;
            return t.GetTableValueFor(currentEvent.GetType().Name, trait.ThisConcreteCharType, 0)
                * phenom.PhenomenonPower * t.TableScallingValue;
        }

        #endregion

        #region reactions

        
       
        #endregion
    }
}