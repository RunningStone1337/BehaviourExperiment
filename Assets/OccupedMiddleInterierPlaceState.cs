using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace BuildingModule
{
    public class OccupedMiddleInterierPlaceState : OccupedInterierPlaceState
    {        
        //public override bool IsAvailableForPlacingInterier(TableInterier tableInterier)
        //{
        //    return !IsOppositeOccupedByTable();
        //}
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