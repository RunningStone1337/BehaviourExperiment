using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UI.CanvasController;
using static BuildingModule.EntranceBuilder;

namespace UI
{
    public class InterierListScreen : UIScreenBase, ISelectableUIComponentHandler
    {
        [SerializeField] PlaceableUIView simpleTableView;
        [SerializeField] PlaceableUIView oldTableView;
        [SerializeField] PlaceableUIView newTableView;
        [SerializeField] ISelectableUIComponent activeComponent;
        public ISelectableUIComponent ActiveComponent
        {
            get => activeComponent;
            set
            {
                activeComponent = ResetSelectableComponent(activeComponent, value);
            }
        }
        public override void BeforeChangeState()
        {
            SceneMaster.DeactivateAllInterierPlaces();
            ActiveComponent = null;
            base.BeforeChangeState();
        }
    }
}