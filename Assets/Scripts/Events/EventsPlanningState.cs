using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace Common
{
    public class EventsPlanningState : SceneStateBase
    {
        public override void Initiate()
        {
            CanvasController.Controller.CurrentState = CanvasController.Controller.EventsPlanningScreen;
        }
    }
}