using System.Collections;
using System.Collections.Generic;
using UI;
using Extensions;

namespace BuildingModule
{
    public class OccupedMiddleInterierPlaceState : OccupedInterierPlaceState
    {
        protected MiddlePlace ThisPlace { get => (MiddlePlace)thisPlace; }
        public override bool IsAvailableForPlacingInterier<T>()
        {
            if (typeof(T).Equals<Chair>())
            {
                var chairsCount = ThisPlace.GetComponentsInChildren<Chair>().Length;
                if (chairsCount <= 1)
                    return true;
                return false;
            }
            return base.IsAvailableForPlacingInterier<T>();
        }
        public override void InitializeState()
        {
            base.InitializeState();
            var tp = (MiddlePlace)thisPlace;
            tp.LeftMiddlePlace.CurrentState = tp.LeftMiddlePlace.FreeInterierPlaceState;
            tp.RightMiddlePlace.CurrentState = tp.RightMiddlePlace.FreeInterierPlaceState;
            SetOppositePlaceStateAccordingSelectedInterier<TableInterier>();
        }
    }
}