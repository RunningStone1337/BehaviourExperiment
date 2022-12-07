using Common;
using System.Collections;
using System.Collections.Generic;
using UI;
using Extensions;

namespace BuildingModule {
    public class AvailableForPlacingMiddleInterierPlaceState : AvailableForPlacingInterierPlaceState
    {
        public override bool IsAvailableForPlacingInterier<T>()
        {
            if (typeof(TableInterier).Equals<T>())
                return !IsOppositeOccupedByTable();
            else if (typeof(Chair).Equals<T>())
                return true;
            return base.IsAvailableForPlacingInterier<T>();
        }
    }
}