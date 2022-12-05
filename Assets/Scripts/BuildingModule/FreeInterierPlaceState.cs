using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingModule
{
    public class FreeInterierPlaceState : InterierPlaceStateBase
    {
        public override void InitializeState()
        {
            //thisPlace.IsOccuped = false;
            thisPlace.Interier = null;
        }
    }
}