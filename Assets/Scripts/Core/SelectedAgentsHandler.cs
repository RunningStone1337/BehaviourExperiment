using BehaviourModel;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class SelectedAgentsHandler : MonoBehaviour
    {
        [SerializeField] private List<PupilRawData> agents;
        [SerializeField] private TeacherRawData teacher;

        public TeacherRawData Teacher
        {
            get => teacher; 
            set => teacher = value;
        }

        public void AddAgent(PupilRawData currentData)
        {
            if (currentData != null && !agents.Contains(currentData))
                agents.Add(currentData);
        }

        public void RemoveAgentData(PupilRawData agentInitializator)
        {
            agents.Remove(agentInitializator);
        }

        public int AgentsCount() => agents.Count;
    }
}