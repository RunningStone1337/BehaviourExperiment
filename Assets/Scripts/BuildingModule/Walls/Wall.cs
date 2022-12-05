using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BuildingModule
{
    public class Wall : MonoBehaviour, IPointerClickHandler, ICurrentStateHandler
    {
        [SerializeField] SpriteRenderer spriteRenderer;
        [SerializeField] WallStateBase currentState;
        [SerializeField] InactiveState inactiveState;
        [SerializeField] ActiveState activeState;
        [SerializeField] AvailForBuildState availForBuildState;
     
        public SpriteRenderer Renderer { get => spriteRenderer; }
        public IState CurrentState
        {
            get => currentState;
            set
            {
                currentState = (WallStateBase)value;
                currentState.Initiate();
            }
        }

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