using BehaviourModel;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class SelectedAgentsHandler : MonoBehaviour
    {
        [SerializeField] private List<AgentRawData> agents;

        public void AddAgent(AgentRawData currentData)
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