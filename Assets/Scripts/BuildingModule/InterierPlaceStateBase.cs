using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BuildingModule
{
    /// <summary>
    /// »ерархи€ состо€ний дл€ мест размещени€ интерьера.
    /// </summary>
    public abstract class InterierPlaceStateBase : MonoBehaviour, IState
    {
        [SerializeField] protected InterierPlaceBase thisPlace;
        private void Awake()
        {
            thisPlace = GetComponent<InterierPlaceBase>();
        }
        public virtual void InitializeState() { }

        public virtual void BeforeChangeState() { }

        public virtual void HandleInterierPlaceClick(PointerEventData eventData) { }
    }
}