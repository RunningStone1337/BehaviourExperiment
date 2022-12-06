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

        public override bool IsAvailableForPlacingInterier(TableInterier tableInterier)
        {
            return ((InterierPlaceStateBase)CurrentState).IsAvailableForPlacingInterier(tableInterier);
        }

        public void SetFreeStateForOtherMiddlePlaces()
        {
            var selected = SceneMaster.Master.LastSelectedViewObject;
            LeftMiddlePlace.SetPlaceStateAccordingInterierPlaceability(selected);
            RightMiddlePlace.SetPlaceStateAccordingInterierPlaceability(selected);
            OppositeMiddlePlace.SetPlaceStateAccordingInterierPlaceability(selected);
        }
    }
}