using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class EventsPlanningScreen : UIScreenBase
    {
        public void ButtonBackClick()
        {
            CanvasController.Controller.CurrentState = CanvasController.Controller.ModeSelectionState;
            ActiveComponent = null;
        }
    }
}