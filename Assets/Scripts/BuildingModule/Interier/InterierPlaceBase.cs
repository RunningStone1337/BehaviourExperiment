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
        [SerializeField] List<InterierBase> interier;
        [SerializeField] Entrance entrance;

        [Space]
        [SerializeField] FreeInterierPlaceState freeInterierPlaceState;
        [SerializeField] OccupedInterierPlaceState occupedInterierPlaceState;
        [SerializeField] AvailableForPlacingInterierPlaceState availableForPlacingInterier;
        [SerializeField] InterierPlaceStateBase currentState;
        public Entrance Entrance { get => entrance; protected set => entrance = value; }
        public Collider2D Collider2D { get => collider2d; }
        public FreeInterierPlaceState FreeInterierPlaceState { get => freeInterierPlaceState; }
        public OccupedInterierPlaceState OccupedInterierPlaceState { get => occupedInterierPlaceState; }
        public AvailableForPlacingInterierPlaceState AvailableForPlacingInterierPlaceState { get => availableForPlacingInterier; }
        public bool IsOccuped { get => Interier.Count>0; set { } }
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

        public List<InterierBase> Interier
        {
            get => interier;
            set
            {
                interier = value;
                //if (interier != null)
                //    IsOccuped = true;
                //else
                //    IsOccuped = false;
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
        public virtual void SetPlaceStateAccordingInterierPlaceability(InterierBase interier)
        {
            ///при переключении активного итема места, которые не должны светиться(в центре) светятся, нужно обработать 
            if (interier.IsAvailableForPlacing(this))
                CurrentState = AvailableForPlacingInterierPlaceState;
        }

        public void HandleInterierPlaceClick(PointerEventData eventData)
        {
            ((InterierPlaceStateBase)CurrentState).HandleInterierPlaceClick(eventData);
        }
        public virtual bool IsAvailableForPlacingInterier<T>() where T : InterierBase 
        { return default; }

        public void OnPointerClick(PointerEventData eventData)
        {
            InputSystem.InputListener.Listener.HandleInterierPlaceClick(this, eventData);
        }
        private void Awake()
        {
            currentState = FreeInterierPlaceState;
            Entrance = GetComponentInParent<Entrance>();
        }
    }
}