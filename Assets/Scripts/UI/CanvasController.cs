using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class CanvasController : MonoBehaviour
    {
        [SerializeField]  UIScreenBase currentState;
        [SerializeField]  UIModeSelectionScreen modeSelectionState;
        [SerializeField]  UIMainScreen mainState;
        [SerializeField]  UIBuildingScreen buildingState;
        [SerializeField]  InterierListScreen interierCollectionScreen;
        static CanvasController canvasController;
        public UIModeSelectionScreen ModeSelectionState { get => modeSelectionState; }
        public UIMainScreen MainState { get => mainState; }
        public UIBuildingScreen BuildingState { get => buildingState; }
        public InterierListScreen InterierListScreen { get => interierCollectionScreen; }
        public static CanvasController Controller { get => canvasController; private set => canvasController = value; }
        public UIScreenBase CurrentState
        {
            get => currentState;
            set
            {
                currentState.DeactivateUI();
                currentState = value;
                currentState.ActivateUI();
            }
        }

        public static ISelectableUIComponent ResetSelectableComponent(ISelectableUIComponent oldValue, ISelectableUIComponent newValue)
        {
            if (oldValue != null)
                oldValue.IsSelected = false;
            if (newValue != null)
                newValue.IsSelected = true;
            if (newValue == null && oldValue != null)
                oldValue.IsSelected = false;
            return newValue;
        }

        private void Awake()
        {
            if (Controller == null)
            {
                Controller = this;
                return;
            }
            Destroy(this);
        }
    }
}