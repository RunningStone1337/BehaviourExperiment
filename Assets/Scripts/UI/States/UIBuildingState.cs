using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using UnityEngine.UI;

namespace UI
{
    public class UIBuildingState : UIStateBase
    {
        [SerializeField] Button buttonEntranceBuildMode;
        [SerializeField] Button buttonWallsBuildMode;
        [SerializeField] Button buttonInterierBuildMode;
     
        public void SetBuildingEntranceState()
        {
            SceneMaster.Master.CurrentState = SceneMaster.Master.BuildingModeState;
            ActiveButton = buttonEntranceBuildMode;
        } 
        public void SetPreviousScreen()
        {
            canvasController.CurrentState = canvasController.ModeSelectionState;
            ActiveButton = null;
        }
        public void SetPlacingInterierState()
        {
            SceneMaster.Master.CurrentState = SceneMaster.Master.PlacingInterierState;
            ActiveButton = buttonInterierBuildMode;
        } 
        public void SetBuildingWallsState()
        {
            SceneMaster.Master.CurrentState = SceneMaster.Master.BuildingWallsState;
            ActiveButton = buttonWallsBuildMode;
        }
    }
}