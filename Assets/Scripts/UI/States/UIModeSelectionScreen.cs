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
            Controller.CurrentState = Controller.MainState;
            ActiveButton = null;
        }

        public void SetBuildingState()
        {
            Controller.CurrentState = Controller.BuildingState;
            ActiveButton = buttonBuildingMode;
        }
        public void SetNavigationState()
        {
            SceneMaster.CurrentState = SceneMaster.NavigationState;
            ActiveButton = buttonNavigationMode;
        }

    }
}