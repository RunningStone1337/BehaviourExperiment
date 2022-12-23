using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class AgentsSelectionScreen : UIScreenBase
    {
        [SerializeField] AgentCreationScreen agentCreationScreen;
        [SerializeField] AgentSaveScreen agentSaveScreen;
        [SerializeField] AgentLoadScreen agentLoadScreen;
        public AgentCreationScreen AgentCreationScreen { get => agentCreationScreen; }
        public AgentSaveScreen AgentSaveScreen { get => agentSaveScreen; }
        public AgentLoadScreen AgentLoadScreen { get => agentLoadScreen; }
        public void CreateAgentButtonClick()
        {
            agentCreationScreen.InitiateState();
        }
    }
}