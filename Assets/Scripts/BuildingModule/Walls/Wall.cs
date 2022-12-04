using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BuildingModule
{
    public class Wall : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] SpriteRenderer spriteRenderer;
        [SerializeField] WallStateBase currentState;
        [SerializeField] InactiveState inactiveState;
        [SerializeField] ActiveState activeState;
        [SerializeField] AvailForBuildState availForBuildState;
        public WallStateBase CurrentState { get => currentState;
            private set {
                currentState = value;
                currentState.Initiate();
            }
        }
        public SpriteRenderer Renderer { get => spriteRenderer; }
        public void SetActiveState()
        {
            CurrentState = activeState;
        }
        public void SetInactiveState()
        {
            CurrentState = inactiveState;
        }
        public void SetBuildingState()
        {
            CurrentState = availForBuildState;
        }
        private void Awake()
        {
            currentState.Initiate();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            InputSystem.InputListener.Listener.HandleWallClick(this, eventData);
        }
    }
}