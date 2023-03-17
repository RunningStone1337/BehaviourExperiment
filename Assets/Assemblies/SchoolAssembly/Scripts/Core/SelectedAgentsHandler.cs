using BehaviourModel;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class SelectedAgentsHandler : MonoBehaviour
    {
        [SerializeField] private List<PupilRawData> agentsData;
        [SerializeField] private TeacherRawData teacherData;
        /// <summary>
        /// Только дя перечисления.
        /// </summary>
        public List<PupilRawData> AgentsData => agentsData;
        public TeacherRawData TeacherData
        {
            get => teacherData; 
            set => teacherData = value;
        }

        public void AddAgent(PupilRawData currentData)
        {
            if (currentData != null && !agentsData.Contains(currentData))
                agentsData.Add(currentData);
        }

        public void RemoveAgentData(PupilRawData agentInitializator)
        {
            agentsData.Remove(agentInitializator);
        }

        public int AgentsCount() => agentsData.Count;
    }
}