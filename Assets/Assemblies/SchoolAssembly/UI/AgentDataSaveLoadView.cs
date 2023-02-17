using BehaviourModel;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class AgentDataSaveLoadView : MonoBehaviour, ISelectableUIComponent, IPointerClickHandler
    {
        [SerializeField] private Text agentNameText;
        [SerializeField] private Text agentPathText;
        [SerializeField] private HumanRawData agentRawData;
        [SerializeField] private AgentSaveLoadScreen agentSaveScreen;
        [SerializeField] private Image backgroundImage;
        [SerializeField] private Color defaultColor;
        [SerializeField] private bool isSelected;

        private void Awake()
        {
            agentSaveScreen = GetComponentInParent<AgentSaveLoadScreen>();
        }

        public HumanRawData AgentRawData => agentRawData;
        public string DataPath { get => agentPathText.text; }
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

        public void Initiate(HumanRawData ard, string savePath)
        {
            agentRawData = ard;
            agentNameText.text = ard.AgentName;
            agentPathText.text = savePath;
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