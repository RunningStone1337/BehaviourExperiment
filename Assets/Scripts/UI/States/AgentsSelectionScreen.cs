using BehaviourModel;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class AgentsSelectionScreen : UIScreenBase
    {
        [SerializeField] AgentCreationScreen agentCreationScreen;
        [SerializeField] AgentSaveLoadScreen agentSaveScreen;
        [SerializeField] AgentSaveLoadScreen agentLoadScreen;
        [SerializeField] List<AgentRawData> agents;
        public AgentCreationScreen AgentCreationScreen { get => agentCreationScreen; }
        public AgentSaveLoadScreen AgentSaveScreen { get => agentSaveScreen; }
        public AgentSaveLoadScreen AgentLoadScreen { get => agentLoadScreen; }
        public void CreateAgentButtonClick()
        {
            agentCreationScreen.InitiateState();
        }

        public void AddAgentData(AgentRawData currentData)
        {
            if (currentData != null && !agents.Contains(currentData))
                agents.Add(currentData);
        }

        public void RemoveAgentData(AgentRawData agentInitializator)
        {
            agents.Remove(agentInitializator);
        }
    }
}