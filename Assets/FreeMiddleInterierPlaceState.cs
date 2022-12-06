using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingModule
{
    public class FreeMiddleInterierPlaceState : FreeInterierPlaceState
    {
        public override bool IsAvailableForPlacingInterier(TableInterier tableInterier)
        {
            return true;
        }
    }
}