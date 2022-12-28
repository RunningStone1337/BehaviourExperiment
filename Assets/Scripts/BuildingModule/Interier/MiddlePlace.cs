using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingModule
{
    public class MiddlePlace : InterierPlaceBase
    {
        [SerializeField] MiddlePlace oppositeMiddlePlace;
        [SerializeField] MiddlePlace leftMiddlePlace;
        [SerializeField] MiddlePlace rightMiddlePlace;
        public MiddlePlace OppositeMiddlePlace { get => oppositeMiddlePlace; }
        public MiddlePlace LeftMiddlePlace { get => leftMiddlePlace; }
        public MiddlePlace RightMiddlePlace { get => rightMiddlePlace; }       

        public override void SetStateForPlacing(InterierBase interier)
        {
            if (IsAvailableForPlacingInterier(interier))
                CurrentState = AvailableForPlacingInterierPlaceState;
            SetFreeStateForOtherMiddlePlaces(interier);
        }

        private void SetFreeStateForOtherMiddlePlaces(InterierBase selected)
        {
            LeftMiddlePlace.SetAvailableStateIfAvailForPlacing(selected);
            RightMiddlePlace.SetAvailableStateIfAvailForPlacing(selected);
            OppositeMiddlePlace.SetAvailableStateIfAvailForPlacing(selected);
        }
    }
}