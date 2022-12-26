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

        public void Initiate(AgentCreationScreen acs, AgentRawData rawData)
        {
            
            agentImage.sprite = acs.AgentImageHandler.Image.sprite;
            agentNameText.text = acs.NameInputFieldButtonPair.InputField.text;
            CardData = rawData;
        }

        public void OnButtonChangeClick()
        {
            AgentCreationScreen acs = GameObject.FindGameObjectWithTag("AgentConfigureScreen").GetComponent<AgentsSelectionScreen>().AgentCreationScreen;
            acs.InitiateState(agentInitializator, this);
        }

        public void OnButtonDeleteClick()
        {
            var confirm = CanvasController.Controller.ConfirmSelectionScreen;
            var configurator = CanvasController.Controller.AgentsConfigureScreen;
            confirm.InitiateState();
            confirm.InitiateButtonsCallbacks(
                new List<Action> {
                    ()=>{ configurator.RemoveAgentData(agentInitializator); },
                    ()=>{
                        agentInitializator = null;
                        Destroy(gameObject);
                    },
                    () => { confirm.BeforeChangeState(); }
                },
                new List<Action> {
                () => { confirm.BeforeChangeState();
                }});
        }
    }
}