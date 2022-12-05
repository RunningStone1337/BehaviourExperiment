using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BuildingModule
{
    /// <summary>
    /// Иерархия типов мест размещения интерьера.
    /// </summary>
    public abstract class InterierPlaceBase : MonoBehaviour, ICanBeOccuped, ICurrentStateHandler, IPointerClickHandler
    {
        [SerializeField] SpriteRenderer spriteRenderer;
        [SerializeField] Collider2D collider2d;
        [SerializeField] InterierBase interier;
        [SerializeField] bool isOccuped;
        [Space]
        [SerializeField] FreeInterierPlaceState freeInterierPlaceState;
        [SerializeField] OccupedInterierPlaceState occupedInterierPlaceState;
        [SerializeField] AvailableForPlacingInterierPlaceState availableForPlacingInterier;
        [SerializeField] InterierPlaceStateBase currentState;
        public Collider2D Collider2D { get => collider2d; }
        public FreeInterierPlaceState FreeInterierPlaceState { get => freeInterierPlaceState; }
        public OccupedInterierPlaceState OccupedInterierPlaceState { get => occupedInterierPlaceState; }
        public AvailableForPlacingInterierPlaceState AvailableForPlacingInterierPlaceState { get => availableForPlacingInterier; }
        public bool IsOccuped { get => isOccuped; set => isOccuped = value; }
        public IState CurrentState
        {
            get => currentState;
            set
            {
                currentState.BeforeChangeState();
                currentState = (InterierPlaceStateBase)value;
                currentState.InitializeState();
            }
        }

        public InterierBase Interier
        {
            get => interier;
            set
            {
                interier = value;
                if (interier != null)
                    IsOccuped = true;
                else
                    IsOccuped = false;
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            InputSystem.InputListener.Listener.HandleInterierPlaceClick(this, eventData);
        }
        //public void SetColliderEnableIfFree(bool val)
        //{
        //    if (!IsOccuped)
        //        Collider2D.enabled = val;
        //}
        private void Awake()
        {
            currentState = FreeInterierPlaceState;
        }
    }
}