using BehaviourModel;
using Core;
using UnityEngine;

namespace UI
{
    public class AgentsSelectionScreen : UIScreenBase
    {
        [SerializeField] private AgentCreationScreen agentCreationScreen;
        [SerializeField] private AgentSaveLoadScreen agentLoadScreen;
        [SerializeField] private AgentSaveLoadScreen agentSaveScreen;
        [SerializeField] private SelectedAgentsHandler agentsHandler;
        public AgentCreationScreen AgentCreationScreen { get => agentCreationScreen; }
        public AgentSaveLoadScreen AgentLoadScreen { get => agentLoadScreen; }
        public AgentSaveLoadScreen AgentSaveScreen { get => agentSaveScreen; }

        public void AddAgentData(PupilRawData currentData)
        {
            agentsHandler.AddAgent(currentData);
        }

        public void CreateAgentButtonClick()
        {
            agentCreationScreen.InitiateState<PupilAgent>();
        }

        public void CreateTeacherButtonClick()
        {
            agentCreationScreen.InitiateState<TeacherAgent>();
        }

        public void RemoveAgentData(PupilRawData agentInitializator)
        {
            agentsHandler.RemoveAgentData(agentInitializator);
        }
    }
}