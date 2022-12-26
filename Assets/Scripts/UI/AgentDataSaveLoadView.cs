using BehaviourModel;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class AgentDataSaveLoadView : MonoBehaviour, ISelectableUIComponent, IPointerClickHandler
    {
        [SerializeField] Text agentNameText;
        [SerializeField] Text agentPathText;
        [SerializeField] AgentSaveLoadScreen agentSaveScreen;
        [SerializeField] bool isSelected;
        [SerializeField] Color defaultColor;
        [SerializeField] Image backgroundImage;
        [SerializeField] AgentRawData agentRawData;
        public AgentRawData AgentRawData => agentRawData;
        public object DefaultToken { get => defaultColor; set => defaultColor = (Color)value; }
        public bool IsSelected
        {
            get => isSelected; set
            {
                isSelected = value;
                if (isSelected)
                    SetHighlightedState();
                else
                    SetDisabledState();
            }
        }

        public string DataPath { get=> agentPathText.text;  }

        public void Initiate(AgentRawData ard, string savePath)
        {
            agentRawData = ard;
            agentNameText.text = ard.AgentName;
            agentPathText.text = savePath;
        }

        private void Awake()
        {
            agentSaveScreen = GetComponentInParent<AgentSaveLoadScreen>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            agentSaveScreen.ActiveComponent = this;
        }

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