using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UI.CanvasController;

namespace UI
{
    public abstract class UIScreenBase : MonoBehaviour
    {
        [SerializeField] protected GameObject rootObject;
        [SerializeField] SceneMaster sceneMaster;
        public SceneMaster SceneMaster
        {
            get
            {
                if (sceneMaster == null)
                    sceneMaster = FindObjectOfType<SceneMaster>();
                return sceneMaster;

            }
            private set => sceneMaster = value;
        }
        [SerializeField] ISelectableUIComponent activeButton;
        protected ISelectableUIComponent ActiveButton
        {
            get => activeButton;
            set
            {
                activeButton = ResetSelectableComponent(activeButton, value);
            }
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