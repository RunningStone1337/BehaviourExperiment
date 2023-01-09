using BuildingModule;
using Extensions;
using UI;
using UnityEngine.EventSystems;

namespace Common
{
    public class RoomSplittingState : SceneStateBase
    {
        #region Public Methods

        public override void BeforeChangeOldState()
        {
            CanvasController.Controller.RolesScreen.BeforeChangeState();

            //SceneMaster.Master.CurrentState = SceneMaster.Master.EntranceRoleEditingState;
        }

        public override void HandleEntranceClick(Entrance entrance, PointerEventData eventData)
        {
            if (entrance.TrySeparateRoom())
            {
                entrance.ThisRoom.StartEntrancesRoutine();
            }
        }

        public override void HandlePlaceableUIViewClick(PlaceableUIView placeableUIView, PointerEventData eventData)
        {
            SceneMaster.Master.CurrentState = SceneMaster.Master.EntranceRoleEditingState;
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