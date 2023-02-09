using Common;
using System;
using UnityEngine;

namespace UI
{
    public class CanvasController : MonoBehaviour, ICurrentStateHandler<UIScreenBase>
    {
        private static CanvasController canvasController;
        [SerializeField] private AgentsSelectionScreen agentsConfigureScreen;
        [SerializeField] private UIBuildingScreen buildingState;
        [SerializeField] private ConfirmSelectionScreen confirmSelectionScreen;
        [SerializeField] private UIScreenBase currentState;
        [SerializeField] private EventsPlanningScreen eventsPlanningScreen;
        [SerializeField] private InterierListScreen interierCollectionScreen;
        [SerializeField] private UIMainScreen mainState;
        [SerializeField] private UIModeSelectionScreen modeSelectionState;
        [SerializeField] private RolesScreen rolesScreen;

        private void Awake()
        {
            if (Controller == null)
            {
                Controller = this;
                return;
            }
            Destroy(this);
        }

        public static CanvasController Controller { get => canvasController; private set => canvasController = value; }
        public AgentsSelectionScreen AgentsConfigureScreen { get => agentsConfigureScreen; }
        public UIBuildingScreen BuildingScreen { get => buildingState; }
        public ConfirmSelectionScreen ConfirmSelectionScreen { get => confirmSelectionScreen; }
        public UIScreenBase CurrentState
        {
            get => currentState;
            set
            {
                currentState.BeforeChangeState();
                currentState = (UIScreenBase)value;
                currentState.InitiateState();
            }
        }

        public EventsPlanningScreen EventsPlanningScreen { get => eventsPlanningScreen; }
        public InterierListScreen InterierListScreen { get => interierCollectionScreen; }
        public UIMainScreen MainScreen { get => mainState; }
        public UIModeSelectionScreen ModeSelectionState { get => modeSelectionState; }
        public RolesScreen RolesScreen { get => rolesScreen; }

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

        public void SetState<S2>() where S2 : UIScreenBase
        {
            throw new NotImplementedException();
        }
    }
}