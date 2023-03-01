using BehaviourModel;
using BuildingModule;
using UI;
using UnityEngine.EventSystems;

namespace Common
{
    public class EntranceRoleEditingState : SceneStateBase
    {
        #region Public Methods

        public override void BeforeChangeOldState()
        {
            CanvasController.Controller.RolesScreen.BeforeChangeState();
        }

        public override void HandleEntranceClick(Entrance entrance, PointerEventData eventData)
        {
            var currentView = (EntranceRoleBase)SceneMaster.Master.LastSelectedViewObject;
            if (entrance.CurrentRoom.Role != currentView)
            {
                entrance.CurrentRoom.Role = currentView;
                entrance.CurrentRoom.StartEntrancesRoutine();
            }
        }

        public override void HandlePlaceableUIViewClick(PlaceableUIView placeableUIView, PointerEventData eventData)
        {
            CanvasController.Controller.RolesScreen.ActiveComponent = placeableUIView;
            SceneMaster.Master.LastSelectedViewObject = placeableUIView.CorrespondingObjectPrefab;
        }

        public override void Initiate()
        {
            CanvasController.Controller.RolesScreen.InitiateState();
            EntranceRoot.Root.Entrances.StartVisualEffect();
        }

        #endregion Public Methods
    }
}