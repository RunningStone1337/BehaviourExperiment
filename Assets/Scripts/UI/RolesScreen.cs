using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UI.CanvasController;

namespace UI
{
    public class RolesScreen : UIScreenBase, ISelectableUIComponentHandler
    {
        [SerializeField] PlaceableUIView classRoleView;
        [SerializeField] PlaceableUIView corridorRoleView;
        [SerializeField] ISelectableUIComponent activeComponent;
        public ISelectableUIComponent ActiveComponent { get => activeComponent;
            set
            {
                activeComponent = ResetSelectableComponent(activeComponent, value);
            }
        }
    }
}