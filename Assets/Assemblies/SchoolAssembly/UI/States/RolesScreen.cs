using Common;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class RolesScreen : UIScreenBase
    {
        [SerializeField] private PlaceableUIView classRoleView;
        [SerializeField] private PlaceableUIView corridorRoleView;
        [SerializeField] private SelectableButton roomsSplitterButton;
        public PlaceableUIView ClassRoleView { get => classRoleView; }
        public PlaceableUIView CorridorRoleView { get => corridorRoleView; }
        public SelectableButton RoomsSplitterButton { get => roomsSplitterButton; }

        public override void BeforeChangeState()
        {
            ActiveComponent = null;
            base.BeforeChangeState();
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            InputSystem.InputListener.Listener.HandleUIScreenPointerDown(this, eventData);
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            InputSystem.InputListener.Listener.HandleUIScreenPointerUp(this, eventData);
        }

        public void SplitButtonClick()
        {
            SceneMaster.Master.CurrentState = SceneMaster.Master.RoomSplittingState;
            ActiveComponent = roomsSplitterButton;
        }
    }
}