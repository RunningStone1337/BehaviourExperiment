using Common;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class RolesScreen : UIScreenBase
    {
        #region Public Properties

        public PlaceableUIView ClassRoleView { get => classRoleView; }
        public PlaceableUIView CorridorRoleView { get => corridorRoleView; }
        public SelectableButton RoomsSplitterButton { get => roomsSplitterButton; }

        #endregion Public Properties

        #region Public Methods

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

        #endregion Public Methods

        #region Private Fields

        [SerializeField] private PlaceableUIView classRoleView;
        [SerializeField] private PlaceableUIView corridorRoleView;
        [SerializeField] private SelectableButton roomsSplitterButton;

        #endregion Private Fields
    }
}