using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UI.CanvasController;

namespace UI
{
    public class InterierListScreen : UIScreenBase
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
    }
}