using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using static UI.CanvasController;

namespace UI
{
    public class RolesScreen : UIScreenBase
    {
        [SerializeField] PlaceableUIView classRoleView;
        [SerializeField] PlaceableUIView corridorRoleView;
        [SerializeField] SelectableButton roomsSplitterButton;
        public SelectableButton RoomsSplitterButton { get => roomsSplitterButton; }
        public PlaceableUIView ClassRoleView { get => classRoleView; }
        public PlaceableUIView CorridorRoleView { get => corridorRoleView; }
        
        public void SplitButtonClick()
        {
            SceneMaster.Master.CurrentState = SceneMaster.Master.RoomSplittingState;
            ActiveComponent = roomsSplitterButton;
        }
        
    }
}