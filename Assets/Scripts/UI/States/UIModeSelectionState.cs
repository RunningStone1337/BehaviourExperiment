using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIModeSelectionState : UIStateBase
    {
        [SerializeField] SceneMaster sceneMaster;
        [SerializeField] Button buttonBuildingMode;
        [SerializeField] Button buttonNavigationMode;
        public SceneMaster SceneMaster
        {
            get
            {
                if (sceneMaster == null)
                    sceneMaster = FindObjectOfType<SceneMaster>();
                return sceneMaster;

            }
            private set => sceneMaster = value;
        }

        public override void ActivateUI()
        {
            rootObject.SetActive(true);
        }

        public override void DeactivateUI()
        {
            rootObject.SetActive(false);
        }

        public void SetPreviousScreen()
        {
            canvasController.CurrentState = canvasController.MainState;
            ActiveButton = null;
        }

        public void SetBuildingState()
        {
            canvasController.CurrentState = canvasController.BuildingState;
            ActiveButton = buttonBuildingMode;
        }
        public void SetNavigationState()
        {
            SceneMaster.CurrentState = SceneMaster.NavigationState;
            ActiveButton = buttonNavigationMode;
        }

    }
}