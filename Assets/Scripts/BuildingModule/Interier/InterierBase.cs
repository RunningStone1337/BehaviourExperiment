using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Common;
using System;

namespace BuildingModule
{
    public abstract class InterierBase : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] SpriteRenderer spriteRenderer;
        [SerializeField] Collider2D collider2d;
        [SerializeField] InterierPlaceBase thisInterierPlace;
        [SerializeField] ObjectUniqIdentifier thisIdentifier;


        public ObjectUniqIdentifier ThisIdentifier { get => thisIdentifier; }
        public SpriteRenderer Renderer { get => spriteRenderer; }

        public virtual bool IsPrincipAvailableForPlacing<T>(T interier) where T: InterierPlaceBase
            => default;

        public virtual bool IsAvailForPlacing(AvailableForPlacingInterierMiddlePlaceState state) => default;
        public virtual bool IsAvailForPlacing(NotAvailableForPlacingInterierMiddlePlaceState state) => default;
        public virtual bool IsAvailForPlacing(FreeInterierMiddlePlaceState state) => default;
        public virtual bool IsAvailForPlacing(MiddlePlace place) => default;
        public bool IsAvailForPlacing(InterierPlaceBase place) {
            if (place is MiddlePlace m)
                return IsAvailForPlacing(m);
            return default;
        }

        public virtual bool IsAvailForPlacing(InterierPlaceStateBase state)
        {
            if (state is AvailableForPlacingInterierMiddlePlaceState a)
                return IsAvailForPlacing(a);
            if (state is NotAvailableForPlacingInterierMiddlePlaceState n)
                return IsAvailForPlacing(n);
            if (state is FreeInterierMiddlePlaceState f)
                return IsAvailForPlacing(f);
            return default;
        }

        public InterierPlaceBase ThisInterierPlace { get => thisInterierPlace; }

        private void Awake()
        {
            thisInterierPlace = GetComponentInParent<InterierPlaceBase>();
        }

        public virtual void OnPointerClick(PointerEventData eventData)
        {
            InputSystem.InputListener.Listener.HandleInterierClick(this, eventData);
        }

        public virtual void Initiate(InterierPlaceBase ipb) { }
        protected void ResetOppositeAndSidePlaces(MiddlePlace mp)
        {
            if (mp.InterierContains(this))
            {
                mp.LeftMiddlePlace.SetFreePlaceState();
                mp.RightMiddlePlace.SetFreePlaceState();
            }
            else
            {
                mp.LeftMiddlePlace.ResetCurrentState(this);
                mp.RightMiddlePlace.ResetCurrentState(this);
            }
            mp.OppositeMiddlePlace.ResetCurrentState(this);
        }
        public virtual bool HaveInfluenceOnOtherPlaces() => default;
        public virtual void ResetDependentPlaces(InterierPlaceBase interierPlaceBase) { }       
    }
}