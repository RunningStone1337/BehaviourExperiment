using BuildingModule;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Common
{
    public class NavigationState : SceneStateBase
    {
        public override void BeforeChangeOldState()
        {
            CanvasController.Controller.CurrentState = CanvasController.Controller.ModeSelectionState;
        }

        public override void HandleBuildingPlaceClick(BuildingPlace buildingPlace, PointerEventData eventData){}

        public override void HandleEntranceClick(Entrance entrance, PointerEventData eventData) { }

        public override void HandlePlaceableUIViewClick(PlaceableUIView placeableUIView, PointerEventData eventData)
        {
        }

        public override void HandleWallClick(Wall wall, PointerEventData eventData) { }

        public override void Initiate(){}

      
    }
}