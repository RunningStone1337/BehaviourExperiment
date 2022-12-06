using Common;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace BuildingModule {
    public class AvailableForPlacingMiddleInterierPlaceState : AvailableForPlacingInterierPlaceState
    {
        public override bool IsAvailableForPlacingInterier(TableInterier tableInterier)
        {
            return !IsOppositeOccupedByTable();
        }
    }
}