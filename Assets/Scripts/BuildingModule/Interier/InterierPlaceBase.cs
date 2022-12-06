using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Extensions;
using System.Linq;

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
                //if ((InterierPlaceStateBase)value == currentState) return;
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

        public static void ActivateAvailableInterierPlaces(InterierBase interier)
        {
            var entrances = EntranceRoot.Root.Entrances;
            foreach (var entr in entrances)
            {
                List<InterierPlaceBase> places = new List<InterierPlaceBase>(entr.MiddlePlaces);
                places.AddRange(entr.Corners);
                places.AddRange(entr.Underwalls);
                foreach (var pl in places)
                    pl.SetPlaceStateAccordingInterierPlaceability(interier);
            }
        }

        public void SetPlaceStateAccordingInterierPlaceability(InterierBase interier)
        {
            ///при переключении активного итема места, которые не должны светиться(в центре) светятся, нужно обработать 
            if (interier.IsAvailableForPlacing(this))
                CurrentState = AvailableForPlacingInterierPlaceState;
            else
                CurrentState = FreeInterierPlaceState;
        }

        public void HandleInterierPlaceClick(PointerEventData eventData)
        {
            ((InterierPlaceStateBase)CurrentState).HandleInterierPlaceClick(eventData);
        }
        public virtual bool IsAvailableForPlacingInterier(TableInterier tableInterier)=>default;

        public void OnPointerClick(PointerEventData eventData)
        {
            InputSystem.InputListener.Listener.HandleInterierPlaceClick(this, eventData);
        }
        private void Awake()
        {
            currentState = FreeInterierPlaceState;
        }
    }
}