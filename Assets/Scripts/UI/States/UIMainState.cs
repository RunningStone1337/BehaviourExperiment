using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// Стейт стартового экрана
    /// </summary>
    public class UIMainState : UIStateBase
    {
        public override void ActivateUI()
        {
            rootObject.SetActive(true);
        }

        public override void DeactivateUI()
        {
            rootObject.SetActive(false);
        }

        public void ChangeScreen()
        {
            canvasController.CurrentState = canvasController.ModeSelectionState;
        }
    }
}