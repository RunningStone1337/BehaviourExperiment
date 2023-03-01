using BuildingModule;
using Events;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class SchoolRelationsTableHandler : RelationsTablesHandlerBase
    {
        #region tables
        #region to agents 
        //[Header("Attention")]
        //#region attention

        //[SerializeField] private CharacterToPhenomFloatRelationsMatrix characterToTeacherAttentionTable;
        //[SerializeField] private CharacterToPhenomFloatRelationsMatrix characterToPupilAttentionTable;
        //[SerializeField] private CharacterToPhenomFloatRelationsMatrix characterToInterierAttentionTable;
        //[SerializeField] private CharacterToPhenomFloatRelationsMatrix characterToEventsAttentionTable;
        //public CharacterToPhenomFloatRelationsMatrix CharacterToInterierAttentionTable => characterToInterierAttentionTable;
        //public CharacterToPhenomFloatRelationsMatrix CharacterToEventsAttentionTable => characterToEventsAttentionTable;
        //public CharacterToPhenomFloatRelationsMatrix CharacterToPupilAttentionTable => characterToPupilAttentionTable;
        //public CharacterToPhenomFloatRelationsMatrix CharacterToTeacherAttentionTable => characterToTeacherAttentionTable;

        //#endregion attention


        [Header("Reactions")]
        #region reactions
        [SerializeField] private CharacterToPhenomReactionsLists characterToPupilReactionsTable;
        [SerializeField] private CharacterToPhenomReactionsLists characterToTeacherReactionsTable;
        [SerializeField] private CharacterToPhenomReactionsLists characterToEventsReactionsTable;
        [SerializeField] private CharacterToPhenomReactionsLists characterToInterierReactionsTable;
        [SerializeField] private CharacterToSpeechReactionsLists agentToSpeechResponsesTable;
        public CharacterToPhenomReactionsLists CharacterToPupilReactionsTable => characterToPupilReactionsTable;
        public CharacterToPhenomReactionsLists CharacterToTeacherReactionsTable => characterToTeacherReactionsTable;
        public CharacterToPhenomReactionsLists CharacterToEventsReactionsTable => characterToEventsReactionsTable;
        public CharacterToPhenomReactionsLists CharacterToInterierReactionsTable => characterToInterierReactionsTable;
        public CharacterToSpeechReactionsLists AgentToSpeechResponsesTable => agentToSpeechResponsesTable;
        #endregion reactions

        #endregion to agents
        #endregion tables

        #region attention calculations

        //internal float CalculateAttentionForInterier(PlacedInterier phenom,
        //    CharacterTraitBase<PupilAgent, ReactionBase, FeatureBase, SchoolAgentStateBase<PupilAgent>, Sensor> trait,
        //    GlobalEvent currentEvent)
        //{
        //    var t = characterToInterierAttentionTable;
        //    return t.GetTableValueFor(currentEvent.GetType().Name, trait.ThisConcreteCharType, 0)
        //        * phenom.PhenomenonPower * t.TableScallingValue;
        //}

        #endregion

        #region reactions calculations

        
       
        #endregion
    }
}