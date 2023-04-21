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
       
    }
}