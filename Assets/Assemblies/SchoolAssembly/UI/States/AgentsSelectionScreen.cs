using BehaviourModel;
using Common;
using Core;
using UnityEngine;

namespace UI
{
    public class AgentsSelectionScreen : UIScreenBase
    {
        [SerializeField] private AgentCreationScreen agentCreationScreen;
        [SerializeField] private AgentSaveLoadScreen agentLoadScreen;
        [SerializeField] private AgentSaveLoadScreen agentSaveScreen;
        [SerializeField] private SelectedAgentsHandler agentsHandler;
        [SerializeField] private AgentsPreviewsRect agentsPreviewsRect;
        public AgentCreationScreen AgentCreationScreen { get => agentCreationScreen; }
        public AgentSaveLoadScreen AgentLoadScreen { get => agentLoadScreen; }
        public AgentSaveLoadScreen AgentSaveScreen { get => agentSaveScreen; }
        public TeacherRawData SelectedTeacher
        {
            get => agentsHandler.Teacher;
            set
            {
                agentsHandler.Teacher = value;
                if (value == null)
                {
                    //включить кнопку создания
                    agentsPreviewsRect.SetTeacherButtonOn();
                }
                else
                {
                    //скрыть кнопку создания
                    agentsPreviewsRect.SetTeacherButtonOff();
                }
            }
        }

        public void AddAgentData(PupilRawData currentData)
        {
            agentsHandler.AddAgent(currentData);
        }

        public void CreateAgentButtonClick()
        {
            agentCreationScreen.InitiateState(typeof(PupilAgent));
        }

        public void CreateTeacherButtonClick()
        {
            agentCreationScreen.InitiateState(typeof(TeacherAgent));
        }

        public void RemoveAgentData(PupilRawData agentInitializator)
        {
            agentsHandler.RemoveAgentData(agentInitializator);
        }

        public void SetPreviousScreen()
        {
            SceneMaster.Master.CurrentState = SceneMaster.Master.NavigationState;
            CanvasController.Controller.CurrentState = CanvasController.Controller.ModeSelectionState;
            ActiveComponent = null;
        }
    }
}