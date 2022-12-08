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
            SceneMaster.CurrentState = SceneMaster.NavigationState;
            ActiveComponent = buttonNavigationMode;
        }

    }
}