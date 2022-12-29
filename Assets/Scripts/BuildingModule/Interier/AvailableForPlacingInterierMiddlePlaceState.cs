using UnityEngine;
using static Common.SceneMaster;

namespace BuildingModule {
    public class AvailableForPlacingInterierMiddlePlaceState : AvailableForPlacingInterierPlaceState
    {
        public MiddlePlace ThisPlace { get => (MiddlePlace)thisPlace; }
        public override void ResetState(InterierBase interier)
        {
            if (!interier.IsAvailForPlacing(this))
                ThisPlace.SetNotAvailForPlacingState();
        }
        public override void InitializeState()
        {
            base.InitializeState();
        }  
    }
}