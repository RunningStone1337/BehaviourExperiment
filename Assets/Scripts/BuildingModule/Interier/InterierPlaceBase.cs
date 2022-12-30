using Common;
using Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BuildingModule
{
    /// <summary>
    /// »ерархи€ типов мест размещени€ интерьера.
    /// </summary>
    public abstract class InterierPlaceBase : MonoBehaviour, ICurrentStateHandler, IPointerClickHandler
    {
        [SerializeField] private AvailableForPlacingInterierPlaceState availableForPlacingInterier;
        [SerializeField] private Collider2D collider2d;
        [SerializeField] private InterierPlaceStateBase currentState;
        [SerializeField] private Entrance entrance;
        [Space]
        [SerializeField] private FreeInterierPlaceState freeInterierPlaceState;

        [SerializeField] private List<PlacedInterier> interier;
        [SerializeField] private NotAvailableForPlacingInterierPlaceState occupedInterierPlaceState;
        [SerializeField] private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            currentState = FreeInterierPlaceState;
            Entrance = GetComponentInParent<Entrance>();
        }

        protected List<PlacedInterier> Interier => interier;
        public AvailableForPlacingInterierPlaceState AvailableForPlacingInterierPlaceState { get => availableForPlacingInterier; }
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

        public Entrance Entrance { get => entrance; protected set => entrance = value; }

        public FreeInterierPlaceState FreeInterierPlaceState { get => freeInterierPlaceState; }

        public NotAvailableForPlacingInterierPlaceState NotAvailableForPlacingInterierState { get => occupedInterierPlaceState; }

        public static void ActivateAvailableInterierPlaces(PlacedInterier interier)
        {
            var entrances = EntranceRoot.Root.Entrances;
            foreach (var entr in entrances)
            {
                var places = new List<InterierPlaceBase>(entr.MiddlePlaces);
                places.AddRange(entr.Corners);
                places.AddRange(entr.Underwalls);
                foreach (var pl in places)
                    pl.SetStateForInterier(interier);
            }
        }

        public void AddInterier(PlacedInterier newInterier)
        {
            Interier.Add(newInterier);
            ResetCurrentStateWithDependentPlaces(newInterier);
        }

        public PlacedInterier GetInterier() => Interier.Count > 0 ? Interier[0] : null;

        public void HandleInterierPlaceClick(PointerEventData eventData) =>
            currentState.HandleInterierPlaceClick(eventData);

        public bool InterierContains<T>(T inter) where T : PlacedInterier => Interier.Contains(inter);

        public int InterierCount<T>() where T : PlacedInterier =>
            Interier.Count<PlacedInterier, T>();

        public int InterierCount() =>
            Interier.Count;

        public List<PlacedInterier> InterierWhere<T>() where T : PlacedInterier =>
            Interier.Where(x => x is T).ToList();

        public void OnPointerClick(PointerEventData eventData) =>
            InputSystem.InputListener.Listener.HandleInterierPlaceClick(this, eventData);

        public void RemoveInterier(PlacedInterier interier)
        {
            Interier.Remove(interier);
            Destroy(interier.gameObject);
        }

        public void ResetCurrentStateWithDependentPlaces(PlacedInterier newInterier)
        {
            SetStateForInterier(newInterier);
            if (newInterier is IDependentFromChanges dep)
                dep.ResetIfConditionsChanged(this);
        }

        public void SetAvailForPlacingState() => CurrentState = AvailableForPlacingInterierPlaceState;

        public void SetFreePlaceState() => CurrentState = FreeInterierPlaceState;

        public void SetNotAvailForPlacingState() => CurrentState = NotAvailableForPlacingInterierState;

        public void SetState<S>() where S : IState
        {
            if (FreeInterierPlaceState is S)
                SetFreePlaceState();
            else if (AvailableForPlacingInterierPlaceState is S)
                SetAvailForPlacingState();
            else if (NotAvailableForPlacingInterierState is S)
                SetNotAvailForPlacingState();
            else throw new Exception($"Unexpected type {typeof(S)}");
        }

        /// <summary>
        /// ќпредел€ет, нужно ли мен€ть состо€ние в текущих услови€х.
        /// </summary>
        /// <param name="interier">»нтерьер, дл€ которого определ€етс€, нужно ли мен€ть состо€ние</param>
        public void SetStateForInterier(PlacedInterier inter) =>
            currentState.SetStateForInterier(inter);
    }
}