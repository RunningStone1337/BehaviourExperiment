using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class CanvasController : MonoBehaviour
    {
        [SerializeField]  UIStateBase currentState;
        [SerializeField]  UIModeSelectionState modeSelectionState;
        [SerializeField]  UIMainState mainState;
        [SerializeField]  UIBuildingState buildingState;
        static CanvasController canvasController;
        public UIModeSelectionState ModeSelectionState { get => modeSelectionState; }
        public UIMainState MainState { get => mainState; }
        public UIBuildingState BuildingState { get => buildingState; }
        public static CanvasController Controller { get => canvasController; private set => canvasController = value; }
        private void Awake()
        {
            if (Controller == null)
            {
                Controller = this;
                return;
            }
            Destroy(this);
        }
        public UIStateBase CurrentState { get => currentState;
            set 
            {
                currentState.DeactivateUI();
                currentState = value;
                currentState.ActivateUI();
            }
        }
    }
}