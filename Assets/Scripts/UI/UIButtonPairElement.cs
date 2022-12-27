using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public abstract class UIButtonPairElement : MonoBehaviour, IButtonHandler, ISelectableUIComponent, IPointerClickHandler
    {
        [SerializeField] Button button;
        [SerializeField] Color defaultColor;
        [SerializeField] bool isSelected;
        [SerializeField] Image backImage;
        public Button Button => button;
        protected Action<PointerEventData> onElementClick;
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