using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UI.CanvasController;

namespace UI
{
    /// <summary>
    /// Иерархия экранов контроллера UI.
    /// </summary>
    public abstract class UIScreenBase : MonoBehaviour,IState, ISelectableUIComponentHandler
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
        //protected ISelectableUIComponent ActiveButton
        //{
        //    get => activeButton;
        //    set
        //    {
        //        activeButton = ResetSelectableComponent(activeButton, value);
        //    }
        //}
        public ISelectableUIComponent ActiveComponent
        {
            get => activeButton;
            set
            {
                activeButton = ResetSelectableComponent(activeButton, value);
            }
        }
        public virtual void BeforeChangeState()
        {
            rootObject.SetActive(false);
        }
        public virtual void InitiateState()
        {
            rootObject.SetActive(true);
        }
    }
}