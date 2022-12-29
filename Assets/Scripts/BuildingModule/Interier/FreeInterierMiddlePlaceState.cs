using Extensions;
using UnityEngine;

namespace BuildingModule
{
    public class FreeInterierMiddlePlaceState : FreeInterierPlaceState
    {
        public MiddlePlace ThisPlace { get => (MiddlePlace)thisPlace; }

        public override void ResetState(InterierBase interier)
        {
            if (interier.IsAvailForPlacing(this))
                ThisPlace.SetAvailForPlacingState();
            else
                ThisPlace.SetNotAvailForPlacingState();
        }
       
    }
}