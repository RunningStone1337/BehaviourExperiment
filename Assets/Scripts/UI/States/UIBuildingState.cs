using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

namespace UI
{
    public class UIBuildingState : UIStateBase
    {
        public override void ActivateUI()
        {
            rootObject.SetActive(true);
        }

        public override void DeactivateUI()
        {
            rootObject.SetActive(false);
        }
        public void SetBuildingEntranceState()
        {
            SceneMaster.Master.CurrentState = SceneMaster.Master.BuildingModeState;
        } 
        public void SetPreviousScreen()
        {
            canvasController.CurrentState = canvasController.ModeSelectionState;
        } 
        public void SetPlacingInterierState()
        {
            SceneMaster.Master.CurrentState = SceneMaster.Master.PlacingInterierState;
        }
    }
}