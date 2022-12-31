using Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UI.CanvasController;

namespace UI
{
    /// <summary>
    /// Стейт стартового экрана
    /// </summary>
    public class UIMainScreen : UIScreenBase
    {
        [SerializeField] Button buttonChooseMode;
        [SerializeField] ExperimentValidator validator;
        public override void InitiateState()
        {
            rootObject.SetActive(true);
        }

        public override void BeforeChangeState()
        {
            rootObject.SetActive(false);
        }

        public void ChangeScreen()
        {
            Controller.CurrentState = Controller.ModeSelectionState;
            ActiveComponent = null;
        }
        public void OnStartButtonClick()
        {
            var s = Controller.ConfirmSelectionScreen;
            s.InitiateState();
            s.InitiateButtonsCallbacks(
                new List<Action>() {
                    validator.Validate,
                    s.BeforeChangeState
                },
                new List<Action>() { 
                    s.BeforeChangeState
                }); ;
        }
    }
}