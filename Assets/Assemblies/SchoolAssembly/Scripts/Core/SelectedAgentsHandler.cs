using BehaviourModel;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class SelectedAgentsHandler : MonoBehaviour
    {
        [SerializeField] private List<PupilRawData> agents;
        private TeacherRawData teacher;
        /// <summary>
        /// Только дя перечисления.
        /// </summary>
        public List<PupilRawData> Agents => agents;
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