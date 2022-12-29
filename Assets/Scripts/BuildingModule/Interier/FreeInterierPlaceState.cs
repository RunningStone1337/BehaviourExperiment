using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingModule
{
    /// <summary>
    /// Состояние неопределённой свободы, место не занято в принципе, 
    /// но требует уточнения для конкретного типа интерьера.
    /// </summary>
    public class FreeInterierPlaceState : InterierPlaceStateBase
    {
     
        public override void ResetState(InterierBase interier)
        {
            var princCOnd = interier.IsPrincipAvailableForPlacing(thisPlace);
            var intCount = thisPlace.InterierCount();
            if (intCount == 0 && princCOnd)
                thisPlace.SetAvailForPlacingState();
            else
                thisPlace.SetNotAvailForPlacingState();
        }
        void OnDrawGizmos()
        {
            DrawSphereGizmo(Color.yellow);
        }
    }
}