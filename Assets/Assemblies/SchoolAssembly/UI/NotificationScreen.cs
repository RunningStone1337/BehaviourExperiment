using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class NotificationScreen : UIScreenBase
    {
        [SerializeField] private Animator animator;
        [SerializeField] private bool isPointerEntered;
        [SerializeField] private Image notifyImage;
        [SerializeField] private Text notifyText;

        public void InitiateState(string message)
        {
            base.InitiateState();
            notifyText.text = message;
            animator.Play("Show");
        }

        public void OnButtonCloseClick()
        {
            animator.Play("Hided");
            BeforeChangeState();
        }

        public void OnHidingLastFrameReached()
        {
            BeforeChangeState();
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            isPointerEntered = true;
            animator.Play("Showing");
            //animator.SetBool("Hide", false);
            //animator.SetTrigger("Show");
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            isPointerEntered = false;
        }

        public void OnShowingAnimCycleLastFrameReached()
        {
            if (!isPointerEntered)
                animator.Play("Hide");
        }
    }
}