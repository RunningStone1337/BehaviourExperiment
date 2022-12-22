using BehaviourModel;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class AgentCardPreview : MonoBehaviour
    {
        [SerializeField] AgentRawData agentInitializator;
        [SerializeField] Image agentImage;
        [SerializeField] Text agentNameText;

        public AgentRawData CardData { get => agentInitializator; set => agentInitializator = value; }

        public void Initiate(AgentCreationScreen acs)
        {
            
            agentImage.sprite = acs.AgentImageHandler.Image.sprite;
            agentNameText.text = acs.NameInputFieldButtonPair.InputField.text;
        }
    }
}