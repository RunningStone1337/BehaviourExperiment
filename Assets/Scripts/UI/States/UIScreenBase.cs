using Common;
using UnityEngine;
using UnityEngine.EventSystems;
using static UI.CanvasController;

namespace UI
{
    /// <summary>
    /// Иерархия экранов контроллера UI.
    /// </summary>
    public abstract class UIScreenBase : MonoBehaviour, IState,
        ISelectableUIComponentHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        #region Public Properties

        public virtual ISelectableUIComponent ActiveComponent
        {
            get => selectedUIComponent;
            set
            {
                selectedUIComponent = ResetSelectableComponent(selectedUIComponent, value);
            }
        }

        public bool IsInitialized => isInitialized;

        #endregion Public Properties

        [SerializeField] [HideInInspector] private bool isInitialized;
        [SerializeField] protected GameObject rootObject;
        [SerializeField] protected ISelectableUIComponent selectedUIComponent;

        protected virtual void Awake()
        {
            isInitialized = true;
        }

        public virtual void BeforeChangeState()
        {
            rootObject.SetActive(false);
        }

        public virtual void InitiateState()
        {
            rootObject.SetActive(true);
        }

        public virtual void OnPointerDown(PointerEventData eventData)
        { }

        public virtual void OnPointerEnter(PointerEventData eventData)
        { }

        public virtual void OnPointerExit(PointerEventData eventData)
        { }

        public virtual void OnPointerUp(PointerEventData eventData)
        { }
    }
}