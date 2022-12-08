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
    }
}