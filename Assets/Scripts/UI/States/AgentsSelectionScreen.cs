using BehaviourModel;
using Core;
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
        [SerializeField] SelectedAgentsHandler agentsHandler;
        public AgentCreationScreen AgentCreationScreen { get => agentCreationScreen; }
        public AgentSaveLoadScreen AgentSaveScreen { get => agentSaveScreen; }
        public AgentSaveLoadScreen AgentLoadScreen { get => agentLoadScreen; }
        public void CreateAgentButtonClick()
        {
            agentCreationScreen.InitiateState<PupilAgent>();
        }

        public void AddAgentData(AgentRawData currentData)
        {
            agentsHandler.AddAgent(currentData);
        }

        public void CreateTeacherButtonClick()
        {
            agentCreationScreen.InitiateState<TeacherAgent>();
        }

        public void RemoveAgentData(AgentRawData agentInitializator)
        {
            agentsHandler.RemoveAgentData(agentInitializator);
        }
    }
}