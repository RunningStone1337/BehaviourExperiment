using BuildingModule;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Common
{
    public class NavigationState : SceneStateBase
    {
        public override void BeforeChangeOldState()
        {
            //CanvasController.Controller.CurrentState = CanvasController.Controller.ModeSelectionState;
        }
      
    }
}