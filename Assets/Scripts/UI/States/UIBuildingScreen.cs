using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using UnityEngine.UI;

namespace UI
{
    public class UIBuildingScreen : UIScreenBase
    {
        [SerializeField] SelectableButton buttonEntranceBuildMode;
        [SerializeField] SelectableButton buttonWallsBuildMode;
        [SerializeField] SelectableButton buttonInterierBuildMode;
        [SerializeField] SelectableButton buttonEntranceRoleMode;
     
        public void SetBuildingEntranceState()
        {
            SceneMaster.Master.CurrentState = SceneMaster.Master.BuildingModeState;
            ActiveButton = buttonEntranceBuildMode;
        } 
        public void SetPreviousScreen()
        {
            SceneMaster.Master.CurrentState = SceneMaster.Master.NavigationState;
            //canvasController.CurrentState = canvasController.ModeSelectionState;
            CanvasController.Controller.CurrentState = CanvasController.Controller.ModeSelectionState;
            ActiveButton = null;
        }
        public void SetPlacingInterierState()
        {
            SceneMaster.Master.CurrentState = SceneMaster.Master.PlacingInterierState;
            ActiveButton = buttonInterierBuildMode;
            //interierCollection.ActivateUI();
        } 
        public void SetBuildingWallsState()
        {
            SceneMaster.Master.CurrentState = SceneMaster.Master.BuildingWallsState;
            ActiveButton = buttonWallsBuildMode;
        }
        public void SetEntranceRoleEditingState()
        {
            SceneMaster.Master.CurrentState = SceneMaster.Master.EntranceRoleEditingState;
            ActiveButton = buttonEntranceRoleMode;
        }
    }
}