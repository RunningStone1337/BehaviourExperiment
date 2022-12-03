using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    /// <summary>
    /// Стейт стартового экрана
    /// </summary>
    public class UIMainState : UIStateBase
    {
        [SerializeField] Button buttonChooseMode;
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
            ActiveButton = null;
        }
    }
}