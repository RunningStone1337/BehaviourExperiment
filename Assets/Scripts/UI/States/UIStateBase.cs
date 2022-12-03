using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public abstract class UIStateBase : MonoBehaviour
    {
        [SerializeField] protected GameObject rootObject;
        [SerializeField] protected CanvasController canvasController;
        [SerializeField] Button activeButton;
        protected Button ActiveButton
        {
            get => activeButton;
            set
            {
                if (activeButton != null)
                    activeButton.GetComponent<Image>().color = activeButton.colors.normalColor;
                if (value != null)
                    value.GetComponent<Image>().color = Color.yellow;
                if (value == null && activeButton != null)
                    activeButton.GetComponent<Image>().color = activeButton.colors.normalColor;
                activeButton = value;
            }
        }
        private void Awake()
        {
            canvasController = GetComponentInParent<CanvasController>();
        }

        public virtual void DeactivateUI()
        {
            rootObject.SetActive(false);

        }
        public virtual void ActivateUI()
        {
            rootObject.SetActive(true);

        }
    }
}