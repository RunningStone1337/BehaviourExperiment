using BehaviourModel;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class SelectedAgentsHandler : MonoBehaviour
    {
        [SerializeField] private List<PupilRawData> agents;

        public void AddAgent(PupilRawData currentData)
        {
            if (currentData != null && !agents.Contains(currentData))
                agents.Add(currentData);
        }

        public void RemoveAgentData(PupilRawData agentInitializator)
        {
            agents.Remove(agentInitializator);
        }
    }
}