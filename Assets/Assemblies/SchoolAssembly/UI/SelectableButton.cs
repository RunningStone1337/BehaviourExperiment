using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SelectableButton : Button, ISelectableUIComponent
    {
        [SerializeField] private bool isSelected;
        public object DefaultToken
        { get => colors.normalColor; set { } }
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

        public void SetHighlightedState()
        {
            GetComponent<Image>().color = Color.yellow;
        }
    }
}