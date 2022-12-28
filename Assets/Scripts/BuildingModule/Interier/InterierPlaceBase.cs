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
    /// �������� ����� ���� ���������� ���������.
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

        public List<InterierBase> Interier => interier;

        public static void ActivateAvailableInterierPlaces(InterierBase interier)
        {
            var entrances = EntranceRoot.Root.Entrances;
            foreach (var entr in entrances)
            {
                var places = new List<InterierPlaceBase>(entr.MiddlePlaces);
                places.AddRange(entr.Corners);
                places.AddRange(entr.Underwalls);
                foreach (var pl in places)
                    pl.SetStateForPlacing(interier);
            }
        }

        /// <summary>
        /// ������������� ����� ����� ���������� � ����������� �� ������� ������� �����
        /// </summary>
        /// <param name="interier"></param>
        public virtual void SetStateForPlacing(InterierBase interier)
        {
            ///��� ������������ ��������� ����� �����, ������� �� ������ ���������(� ������) ��������, ����� ���������� 
            SetAvailableStateIfAvailForPlacing(interier);
        }

        public void RemoveInterier(InterierBase interier)
        {
           Interier.Remove(interier);
            var count = Interier.Count;
            if (count == 0)
                CurrentState = FreeInterierPlaceState;
            Destroy(interier.gameObject);
        }

        /// <summary>
        /// ������������� ��������� ��� ���������� ��������� ���� ������� ������� ���� ����� �����������
        /// ������������ �� ��������� ����� �����
        /// </summary>
        /// <param name="interier"></param>
        protected void SetAvailableStateIfAvailForPlacing(InterierBase interier)
        {
            if (IsAvailableForPlacingInterier(interier))
                CurrentState = AvailableForPlacingInterierPlaceState;
        }

        public void HandleInterierPlaceClick(PointerEventData eventData)=>
            currentState.HandleInterierPlaceClick(eventData);

        public virtual bool IsAvailableForPlacingInterier(InterierBase interier) => currentState.IsAvailableForPlacingInterier(interier);

        public void OnPointerClick(PointerEventData eventData)=>
            InputSystem.InputListener.Listener.HandleInterierPlaceClick(this, eventData);

        private void Awake()
        {
            currentState = FreeInterierPlaceState;
            Entrance = GetComponentInParent<Entrance>();
        }
    }
}