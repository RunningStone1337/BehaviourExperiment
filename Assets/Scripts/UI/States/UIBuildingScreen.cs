using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using UnityEngine.UI;
using System;

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
            ActiveComponent = buttonEntranceBuildMode;
        } 
        public void SetPreviousScreen()
        {
            SceneMaster.Master.CurrentState = SceneMaster.Master.NavigationState;
            CanvasController.Controller.CurrentState = CanvasController.Controller.ModeSelectionState;
            ActiveComponent = null;
        }
        public void SetPlacingInterierState()
        {
            SceneMaster.Master.CurrentState = SceneMaster.Master.PlacingInterierState;
            ActiveComponent = buttonInterierBuildMode;
        } 
        public void SetBuildingWallsState()
        {
            SceneMaster.Master.CurrentState = SceneMaster.Master.BuildingWallsState;
            ActiveComponent = buttonWallsBuildMode;
        }
        public void SetEntranceRoleEditingState()
        {
            SceneMaster.Master.CurrentState = SceneMaster.Master.EntranceRoleEditingState;
            ActiveComponent = buttonEntranceRoleMode;
        }

        public void ClearSceneButton()
        {
            var confirm = CanvasController.Controller.ConfirmSelectionScreen;
            confirm.InitiateState();
            confirm.InitiateButtonsCallbacks(
                new List<Action> {
                SceneMaster.Master.ClearEntrances,confirm.BeforeChangeState 
                },
                new List<Action> {
                () => { confirm.BeforeChangeState(); 
                }});
        }
        
    }
}