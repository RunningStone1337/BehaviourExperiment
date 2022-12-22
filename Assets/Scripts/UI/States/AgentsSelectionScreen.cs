using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class AgentsSelectionScreen : UIScreenBase
    {
        [SerializeField] AgentCreationScreen agentCreationScreen;
        public void CreateAgentButtonClick()
        {
            agentCreationScreen.InitiateState();
        }
    }
}