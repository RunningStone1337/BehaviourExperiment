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
    /// »ерархи€ типов мест размещени€ интерьера.
    /// </summary>
    public abstract class InterierPlaceBase : MonoBehaviour, ICurrentStateHandler, IPointerClickHandler
    {
        [SerializeField] SpriteRenderer spriteRenderer;
        [SerializeField] Collider2D collider2d;
        [SerializeField] List<InterierBase> interier;
        [SerializeField] Entrance entrance;
        [Space]
        [SerializeField] FreeInterierPlaceState freeInterierPlaceState;
        [SerializeField] NotAvailableForPlacingInterierPlaceState occupedInterierPlaceState;
        [SerializeField] AvailableForPlacingInterierPlaceState availableForPlacingInterier;
        [SerializeField] InterierPlaceStateBase currentState;
        public FreeInterierPlaceState FreeInterierPlaceState { get => freeInterierPlaceState; }
        public NotAvailableForPlacingInterierPlaceState NotAvailableForPlacingInterierState { get => occupedInterierPlaceState; }
        public AvailableForPlacingInterierPlaceState AvailableForPlacingInterierPlaceState { get => availableForPlacingInterier; }
        public Entrance Entrance { get => entrance; protected set => entrance = value; }
        public Collider2D Collider2D { get => collider2d; }
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

        protected List<InterierBase> Interier => interier;
        public bool InterierContains<T>(T inter) where T : InterierBase => Interier.Contains(inter);
        public int InterierCount<T>() where T : InterierBase =>
            Interier.Count<InterierBase, T>();
        public int InterierCount() =>
            Interier.Count;
        public InterierBase GetInterier() => Interier.Count >0? Interier[0]: null;
        public static void ActivateAvailableInterierPlaces(InterierBase interier)
        {
            var entrances = EntranceRoot.Root.Entrances;
            foreach (var entr in entrances)
            {
                var places = new List<InterierPlaceBase>(entr.MiddlePlaces);
                places.AddRange(entr.Corners);
                places.AddRange(entr.Underwalls);
                foreach (var pl in places)
                    pl.ResetCurrentState(interier);
            }
        }          

        public void SetNotAvailForPlacingState() => CurrentState = NotAvailableForPlacingInterierState;
        public void SetFreePlaceState() => CurrentState = FreeInterierPlaceState;
        public void SetAvailForPlacingState() => CurrentState = AvailableForPlacingInterierPlaceState;
        public void RemoveInterier(InterierBase interier)
        {
            Interier.Remove(interier);            
            Destroy(interier.gameObject);
        }

        public List<InterierBase> InterierWhere<T>() where T: InterierBase =>
            Interier.Where(x => x is T).ToList();
      
        public void HandleInterierPlaceClick(PointerEventData eventData) =>
            currentState.HandleInterierPlaceClick(eventData);


        public void AddInterier(InterierBase newInterier)
        {
            Interier.Add(newInterier);
            ResetCurrentStateWithDependentPlaces(newInterier);
        }

        public void ResetCurrentStateWithDependentPlaces(InterierBase newInterier)
        {
            ResetCurrentState(newInterier);
            if (newInterier.HaveInfluenceOnOtherPlaces())
                ResetDependentPlaces(newInterier);
        }

        public void ResetDependentPlaces(InterierBase interier)
        {
            interier.ResetDependentPlaces(this);
        }

        /// <summary>
        /// ќпредел€ет, нужно ли мен€ть состо€ние в текущих услови€х.
        /// </summary>
        /// <param name="interier">»нтерьер, дл€ которого определ€етс€, нужно ли мен€ть состо€ние</param>
        public void ResetCurrentState(InterierBase inter)
        {
            currentState.ResetState(inter);            
        }

        public void OnPointerClick(PointerEventData eventData)=>
            InputSystem.InputListener.Listener.HandleInterierPlaceClick(this, eventData);

        private void Awake()
        {
            currentState = FreeInterierPlaceState;
            Entrance = GetComponentInParent<Entrance>();
        }
    }
}