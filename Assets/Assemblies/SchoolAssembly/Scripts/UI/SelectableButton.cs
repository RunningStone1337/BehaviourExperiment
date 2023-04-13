using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SelectableButton : Button, ISelectableUIComponent
    {
        [SerializeField] Color selectedColor = Color.green;
        [SerializeField] private bool isSelected;
        public object DefaultToken { get; set; }
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

        public void SetDisabledState()
        {
            GetComponent<Image>().color = (Color)DefaultToken;
        }
        protected override void Awake()
        {
            base.Awake();
            DefaultToken = GetComponent<Image>().color;
        }
        public void SetHighlightedState()
        {
            GetComponent<Image>().color = selectedColor;
        }
    }
}