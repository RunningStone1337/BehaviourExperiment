using BuildingModule;
using System.Collections;
using System.Collections.Generic;
using UI;
using Extensions;
using UnityEngine.EventSystems;

namespace Common
{
    public class EntranceRoleEditingState : SceneStateBase
    {
        public override void Initiate()
        {
            CanvasController.Controller.RolesScreen.InitiateState();
            EntranceRoot.Root.Entrances.StartVisualEffect();
        }
        public override void HandleEntranceClick(Entrance entrance, PointerEventData eventData)
        {
            var currentView = (EntranceRoleBase)SceneMaster.Master.LastSelectedViewObject;
            if (entrance.ThisRoom.Role != currentView)
            {
                entrance.ThisRoom.Role = currentView;
                entrance.ThisRoom.StartEntrancesRoutine();
            }
        }
        public override void BeforeChangeOldState()
        {
            CanvasController.Controller.RolesScreen.BeforeChangeState();
        }
        public override void HandlePlaceableUIViewClick(PlaceableUIView placeableUIView, PointerEventData eventData)
        {
            CanvasController.Controller.RolesScreen.ActiveComponent = placeableUIView;
            SceneMaster.Master.LastSelectedViewObject = placeableUIView.CorrespondingObjectPrefab;
        }
    }
}