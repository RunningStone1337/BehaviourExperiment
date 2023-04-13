using Common;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class InterierListScreen : UIScreenBase, ISelectableUIComponentHandler
    {
        [SerializeField] private RectTransform contentTransform;
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