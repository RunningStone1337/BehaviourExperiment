using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class CanvasController : MonoBehaviour, ICurrentStateHandler
    {
        [SerializeField]  UIScreenBase currentState;
        [SerializeField]  UIModeSelectionScreen modeSelectionState;
        [SerializeField]  UIMainScreen mainState;
        [SerializeField]  UIBuildingScreen buildingState;
        [SerializeField]  InterierListScreen interierCollectionScreen;
        [SerializeField]  RolesScreen rolesScreen;
        [SerializeField]  EventsPlanningScreen eventsPlanningScreen;
        static CanvasController canvasController;
        public UIModeSelectionScreen ModeSelectionState { get => modeSelectionState; }
        public EventsPlanningScreen EventsPlanningScreen { get => eventsPlanningScreen; }
        public UIMainScreen MainScreen { get => mainState; }
        public UIBuildingScreen BuildingState { get => buildingState; }
        public InterierListScreen InterierListScreen { get => interierCollectionScreen; }
        public RolesScreen RolesScreen { get => rolesScreen; }
        public static CanvasController Controller { get => canvasController; private set => canvasController = value; }
        public IState CurrentState
        {
            get => currentState;
            set
            {
                currentState.BeforeChangeState();
                currentState = (UIScreenBase)value;
                currentState.InitiateState();
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