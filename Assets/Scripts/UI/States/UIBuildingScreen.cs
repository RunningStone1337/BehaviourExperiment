using Common;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class UIBuildingScreen : UIScreenBase
    {
        [SerializeField] private SelectableButton buttonEntranceBuildMode;
        [SerializeField] private SelectableButton buttonEntranceRoleMode;
        [SerializeField] private SelectableButton buttonInterierBuildMode;
        [SerializeField] private SelectableButton buttonWallsBuildMode;

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

        public void OnCreateTemplateEntrancesClick()
        {
            var confirm = CanvasController.Controller.ConfirmSelectionScreen;
            confirm.InitiateState();
            confirm.InitiateButtonsCallbacks(
                new List<Action> {
                    SceneMaster.Master.ClearEntrances,
                    SceneMaster.Master.CreateTemplateEntrances,
                    confirm.BeforeChangeState
                },
                new List<Action> {
                    () => { confirm.BeforeChangeState();
                }});
        }

        public void SetBuildingEntranceState()
        {
            SceneMaster.Master.CurrentState = SceneMaster.Master.BuildingModeState;
            ActiveComponent = buttonEntranceBuildMode;
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

        public void SetPlacingInterierState()
        {
            SceneMaster.Master.CurrentState = SceneMaster.Master.PlacingInterierState;
            ActiveComponent = buttonInterierBuildMode;
        }

        public void SetPreviousScreen()
        {
            SceneMaster.Master.CurrentState = SceneMaster.Master.NavigationState;
            CanvasController.Controller.CurrentState = CanvasController.Controller.ModeSelectionState;
            ActiveComponent = null;
        }
    }
}