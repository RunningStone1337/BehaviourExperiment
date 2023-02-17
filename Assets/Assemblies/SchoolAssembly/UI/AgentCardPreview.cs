using BehaviourModel;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class AgentCardPreview : MonoBehaviour
    {
        [SerializeField] private Image agentImage;
        [SerializeField] private HumanRawData cardData;
        [SerializeField] private Text agentNameText;

        public HumanRawData CardData { get => cardData; set => cardData = value; }

        public void Initiate(AgentCreationScreen acs, HumanRawData rawData)
        {
            agentImage.sprite = acs.AgentImageHandler.Image.sprite;
            agentNameText.text = acs.NameInputFieldButtonPair.InputField.text;
            CardData = rawData;
        }

        public void OnButtonChangeClick()
        {
            AgentCreationScreen acs = GameObject.FindGameObjectWithTag("AgentConfigureScreen")
                .GetComponent<AgentsSelectionScreen>().AgentCreationScreen;
            acs.InitiateState(cardData, this);
        }

        public void OnButtonDeleteClick()
        {
            var confirm = CanvasController.Controller.ConfirmSelectionScreen;
            var configurator = CanvasController.Controller.AgentsConfigureScreen;
            confirm.InitiateState();
            List<Action> yesCallbacks;;
            if (CardData is TeacherRawData t)
            {
                yesCallbacks = new List<Action>()
                {
                    () =>{ 
                        configurator.SelectedTeacher = null;
                        cardData = null;
                        Destroy(gameObject);
                        confirm.BeforeChangeState();
                    }
                };
            }
            else
            {
                yesCallbacks = new List<Action> {
                    ()=>{ 
                        configurator.RemoveAgentData((PupilRawData)cardData);
                        cardData = null;
                        Destroy(gameObject);
                        confirm.BeforeChangeState();}
                };
            }
            confirm.InitiateButtonsCallbacks(
                yesCallbacks,
                new List<Action> {
                () => { confirm.BeforeChangeState();
                }});
        }
    }
}