using BuildingModule;
using Extensions;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Common
{
    public class RoomSplittingState : SceneStateBase
    {
        public override void Initiate()
        {
            CanvasController.Controller.RolesScreen.InitiateState();
            EntranceRoot.Root.Entrances.StartVisualEffect();
        }
        public override void BeforeChangeOldState()
        {
            CanvasController.Controller.RolesScreen.BeforeChangeState();
        }
        public override void HandleEntranceClick(Entrance entrance, PointerEventData eventData)
        {
            entrance.TrySeparateRoom();
        }
        public override void HandlePlaceableUIViewClick(PlaceableUIView placeableUIView, PointerEventData eventData)
        {
            CanvasController.Controller.RolesScreen.ActiveComponent = placeableUIView;
            SceneMaster.Master.LastSelectedViewObject = placeableUIView.CorrespondingObjectPrefab;
        }
    }
}