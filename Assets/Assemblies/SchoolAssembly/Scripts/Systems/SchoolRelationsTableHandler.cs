using UnityEngine;

namespace BehaviourModel
{
    public class SchoolRelationsTableHandler : RelationsTablesHandlerBase
    {
        #region tables
        #region to agents 

        [Header("Reactions")]
        #region reactions
        [SerializeField] private CharacterToPhenomReactionsLists characterToPupilReactionsTable;
        [SerializeField] private CharacterToPhenomReactionsLists characterToEventsReactionsTable;
        [SerializeField] private CharacterToSpeechReactionsLists agentToSpeechResponsesTable;
        [SerializeField] private CharacterToSpeechInfluenceLists agentToSpeechRelationsInfluenceTable;
        public CharacterToPhenomReactionsLists CharacterToPupilReactionsTable => characterToPupilReactionsTable;
        public CharacterToPhenomReactionsLists CharacterToEventsReactionsTable => characterToEventsReactionsTable;
        public CharacterToSpeechReactionsLists AgentToSpeechResponsesTable => agentToSpeechResponsesTable;

        public CharacterToSpeechInfluenceLists AgentToSpeechRelationsInfluenceTable => agentToSpeechRelationsInfluenceTable;
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