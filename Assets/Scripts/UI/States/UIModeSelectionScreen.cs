using Common;
using UnityEngine;
using static UI.CanvasController;

namespace UI
{
    public class UIModeSelectionScreen : UIScreenBase
    {
        [SerializeField] private SelectableButton buttonAgentsCreationMode;
        [SerializeField] private SelectableButton buttonBuildingMode;
        [SerializeField] private SelectableButton buttonEventsPlanningMode;

        public void SetAgentsCreationState()
        {
            SceneMaster.Master.CurrentState = SceneMaster.Master.NavigationState;
            Controller.CurrentState = Controller.AgentsConfigureScreen;
            ActiveComponent = buttonAgentsCreationMode;
        }

        public void SetBuildingState()
        {
            Controller.CurrentState = Controller.BuildingState;
            ActiveComponent = buttonBuildingMode;
        }

        public void SetEventsPlanningState()
        {
            SceneMaster.Master.CurrentState = SceneMaster.Master.EventsPlanningState;
            ActiveComponent = buttonEventsPlanningMode;
        }

        public void SetPreviousScreen()
        {
            Controller.CurrentState = Controller.MainScreen;
            ActiveComponent = null;
        }
    }
}