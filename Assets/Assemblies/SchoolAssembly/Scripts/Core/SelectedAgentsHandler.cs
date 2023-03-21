using BehaviourModel;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Core
{
    public class AgentsSelectionEventArgs : EventArgs
    {
        internal List<PupilRawData> newSelection;
    }
    public class SelectedAgentsHandler : MonoBehaviour
    {
        [SerializeField] private TeacherRawData teacherData;
        [SerializeField] private List<PupilRawData> agentsData;
        [SerializeField] UnityEvent<AgentsSelectionEventArgs> onAgentsSelectionChangedEvent;

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
            {
                agentsData.Add(currentData);
                onAgentsSelectionChangedEvent?.Invoke(new AgentsSelectionEventArgs() {newSelection = new List<PupilRawData>(agentsData) });
            }
        }

        public void RemoveAgentData(PupilRawData agentInitializator)
        {
            agentsData.Remove(agentInitializator);
            onAgentsSelectionChangedEvent?.Invoke(new AgentsSelectionEventArgs() {newSelection = new List<PupilRawData>(agentsData) });
        }

        public int AgentsCount() => agentsData.Count;
    }
}