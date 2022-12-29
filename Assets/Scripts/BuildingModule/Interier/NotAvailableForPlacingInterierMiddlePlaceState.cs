using Common;
using UnityEngine;
using static Common.SceneMaster;
namespace BuildingModule
{
    public class NotAvailableForPlacingInterierMiddlePlaceState : NotAvailableForPlacingInterierPlaceState
    {
        public MiddlePlace ThisPlace { get => (MiddlePlace)thisPlace; }
        public override void InitializeState()
        {
            base.InitializeState();
        }
        public override void ResetState(InterierBase interier)
        {
            if (interier.IsAvailForPlacing(this))
            {
                ThisPlace.SetAvailForPlacingState();
            }
        }

       
    }
}