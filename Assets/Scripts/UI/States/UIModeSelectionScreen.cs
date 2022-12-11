using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UI.CanvasController;

namespace UI
{
    public class UIModeSelectionScreen : UIScreenBase
    {
        [SerializeField] SelectableButton buttonBuildingMode;
        [SerializeField] SelectableButton buttonNavigationMode;
        [SerializeField] SelectableButton buttonEventsPlanningMode;

        public void SetPreviousScreen()
        {
            Controller.CurrentState = Controller.MainScreen;
            ActiveComponent = null;
        }

        public void SetBuildingState()
        {
            Controller.CurrentState = Controller.BuildingState;
            ActiveComponent = buttonBuildingMode;
        }
        public void SetNavigationState()
        {
            SceneMaster.Master.CurrentState = SceneMaster.Master.NavigationState;
            ActiveComponent = buttonNavigationMode;
        }
        public void SetEventsPlanningState()
        {
            SceneMaster.Master.CurrentState = SceneMaster.Master.EventsPlanningState;
            ActiveComponent = buttonEventsPlanningMode;
        }

    }
}