using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BuildingModule
{
    public abstract class InterierDecoratorBase : InterierBase
    {
        [SerializeField] protected InterierBase interier;
        //public override void OnPointerClick(PointerEventData eventData) { }
    }
}