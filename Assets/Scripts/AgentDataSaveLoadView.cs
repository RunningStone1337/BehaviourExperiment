using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class AgentDataSaveLoadView : MonoBehaviour, ISelectableUIComponent
    {
        [SerializeField] bool isSelected;
        [SerializeField] Color defaultColor;
        [SerializeField] Image backgroundImage;
        public object DefaultToken { get => defaultColor; set => defaultColor = (Color)value; }
        public bool IsSelected { get => isSelected; set => isSelected = value; }

        public void SetDisabledState()
        {
            backgroundImage.color = (Color)DefaultToken;
        }

        public void SetHighlightedState()
        {
            backgroundImage.color = Color.yellow;
        }
    }
}