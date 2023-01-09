using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class UIPanelPointerHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            InputSystem.InputListener.Listener.HandleUIScreenPointerDown(this, eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            InputSystem.InputListener.Listener.HandleUIScreenPointerUp(this, eventData);
        }
    }
}