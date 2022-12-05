using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Common;

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

        public virtual void ActivateAvailableInterierPlaces(IEnumerable<BuildingPlace> places) { }

        public virtual void OnPointerClick(PointerEventData eventData)
        {
            InputSystem.InputListener.Listener.HandleInterierClick(this, eventData);
        }
    }
}