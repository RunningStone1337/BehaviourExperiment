using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public abstract class UIButtonPairElement : MonoBehaviour, IButtonHandler, ISelectableUIComponent, IPointerClickHandler
    {
        [SerializeField] private Image backImage;
        [SerializeField] private Button button;
        [SerializeField] private Color defaultColor;
        [SerializeField] private bool isSelected;
        protected Action<PointerEventData> onElementClick;
        public Button Button => button;
        public object DefaultToken { get => defaultColor; set => defaultColor = (Color)value; }
        public bool IsSelected
        {
            get => isSelected;
            set
            {
                isSelected = value;
                if (isSelected)
                    SetHighlightedState();
                else
                    SetDisabledState();
            }
        }

        public virtual void OnPointerClick(PointerEventData eventData)
        {
            onElementClick?.Invoke(eventData);
        }

        public virtual void PushButton()
        {
            Button.onClick.Invoke();
        }

        public void SetDisabledState()
        {
            backImage.color = defaultColor;
        }

        public void SetHighlightedState()
        {
            backImage.color = Color.yellow;
        }
    }
}