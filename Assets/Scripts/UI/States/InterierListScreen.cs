using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UI.CanvasController;
using static BuildingModule.EntranceBuilder;
using UnityEngine.EventSystems;
using Common;

namespace UI
{
    public class InterierListScreen : UIScreenBase, ISelectableUIComponentHandler
    {
        [SerializeField] RectTransform contentTransform;
        public RectTransform ContentTransform => contentTransform;
        public override void BeforeChangeState()
        {
            SceneMaster.Master.DeactivateAllInterierPlaces();
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
    }
}