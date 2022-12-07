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
        public InterierPlaceBase ThisInterierPlace { get => thisInterierPlace; }
        private void Awake()
        {
            thisInterierPlace = GetComponentInParent<InterierPlaceBase>();
        }

        /// <summary>
        /// Определяет, может ли данный предмет размещаться на месте с текущим состоянием
        /// </summary>
        /// <param name="interierPlace"></param>
        /// <returns></returns>
        public virtual bool IsAvailableForPlacing(InterierPlaceBase interierPlace) { return default; }

        public virtual void OnPointerClick(PointerEventData eventData)
        {
            InputSystem.InputListener.Listener.HandleInterierClick(this, eventData);
        }

        public virtual void Initiate(InterierPlaceBase ipb)
        {
            ipb.Interier.Add(this);
            ipb.CurrentState = ipb.OccupedInterierPlaceState;
        }
    }
}