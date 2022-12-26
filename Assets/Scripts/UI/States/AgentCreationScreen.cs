using BehaviourModel;
using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class AgentCreationScreen : UIScreenBase
    {
        [SerializeField] ContentOrderHandler cardsOrderHandler;
        [SerializeField] AgentRawData сurrentData;
        [SerializeField] AgentCardPreview currentPreview;
        [SerializeField] AgentsSelectionScreen agentsSelectionScreen;
        [Header("Основные контролы")]
        [SerializeField] AgentImageHandler agentImageHandler;
        [SerializeField] TextButtonPair nameInputFieldButtonPair;
        [SerializeField] DropdownButtonPair sexDropButtonPair;
        [SerializeField] DropdownButtonPair ageDropButtonPair;
        [SerializeField] DropdownButtonPair weightDropButtonPair;
        [SerializeField] DropdownButtonPair heightDropButtonPair;
        public AgentImageHandler AgentImageHandler { get => agentImageHandler; }
        public TextButtonPair NameInputFieldButtonPair { get => nameInputFieldButtonPair; }
        public DropdownButtonPair SexDropButtonPair { get => sexDropButtonPair; }  
        public DropdownButtonPair AgeDropButtonPair { get => ageDropButtonPair; }
        public DropdownButtonPair WeightDropButtonPair { get => weightDropButtonPair; }
        public DropdownButtonPair HeightDropButtonPair { get => heightDropButtonPair; }
        [Space]
        [Header("Основные параметры")]
        [SerializeField] int minAge;
        [SerializeField] int maxAge;
        public int MinAge => minAge;
        public int MaxAge => maxAge;
        [Space]
        [Header("Настройки ЦНС")]
        [SerializeField] SliderButtonPair nsPowerSlider;
        [SerializeField] SliderButtonPair nsMoveabilitySlider;
        [SerializeField] SliderButtonPair nsActivitySlider;
        [SerializeField] SliderButtonPair nsReactivitySlider;
        [SerializeField] DropdownButtonPair nsBalanceDropButtonPair;
        public SliderButtonPair NsPowerSlider { get => nsPowerSlider; }
        public SliderButtonPair NsMoveabilitySlider { get => nsMoveabilitySlider; }
        public SliderButtonPair NsActivitySlider { get => nsActivitySlider; }
        public SliderButtonPair NsReactivitySlider { get => nsReactivitySlider; }
        public DropdownButtonPair NsBalanceDropButtonPair { get => nsBalanceDropButtonPair; }
        [Space]
        [Header("Настройки характера")]
        [SerializeField] CharacterRect characterRect;
        public CharacterRect CharacterRect => characterRect;
        [Space]
        [Header("Контроллеры диапазонов значений веса и роста")]
        [SerializeField] KeyValuesHandler ageWeightsHandler;
        [SerializeField] KeyValuesHandler ageHeightsHandler;
        public KeyValuesHandler AgeWeightsHandler { get => ageWeightsHandler; }
        public KeyValuesHandler AgeHeightsHandler { get => ageHeightsHandler; }
        public int SelectedAge { get => int.Parse(ageDropButtonPair.DropdownValue); }
        public AgentRawData CurrentData { get => сurrentData; private set => сurrentData = value; }
        public AgentCardPreview CurrentPreview { get => currentPreview; private set => currentPreview = value; }

        private void Awake()
        {
            
            for (int age = minAge; age <= maxAge; age++)
                ageDropButtonPair.AddDropdownOption(age.ToString());
            var ageChangeHandler = new AgeChangeHandler(minAge, this);
            ageChangeHandler.ResetCharacterExtremeValues();
            ageChangeHandler.ResetWieghtAndHeightDropdowns();
        }
        public override void InitiateState()
        {
            base.InitiateState();
            ResetControlls();
        }
        public void InitiateState(AgentRawData ard, AgentCardPreview acp)
        {
            InitiateState(ard);
            CurrentPreview = acp;
        }
        public void InitiateState(AgentRawData ard)
        {
            base.InitiateState();
            ResetControlls(ard);
            CurrentData = ard;
        }

        public void ResetControlls(AgentRawData rawData = null)
        {
            if (rawData != null)
                SetExistDataControls(rawData);
            else
                SetDefaultControls();
        }

        private void SetExistDataControls(AgentRawData rawData)
        {
            var helper = new AgentCreationScreenInitializer(this);
            helper.SetControlsValues(rawData);           
        }

        private void SetDefaultControls()
        {
            var helper = new AgentCreationScreenInitializer(this);
            helper.SetDefaultControlsValues();           
        }

        public void OnAgeSelectionChanged()
        {
            var ageChangeHandler = new AgeChangeHandler(SelectedAge, this);
            ageChangeHandler.ResetCharacterExtremeValues();
            ageChangeHandler.ResetWieghtAndHeightDropdowns();           
        }

        public void SaveButtonClick()
        {
            CanvasController.Controller.AgentsConfigureScreen.AgentSaveScreen.InitiateState();
        }

        public void LoadAgentButtonClick()
        {
            CanvasController.Controller.AgentsConfigureScreen.AgentLoadScreen.InitiateState();
        }

        public void SetFullRandomValuesButtonClick()
        {
            var helper = new AgentCreationScreenInitializer(this);
            helper.RandomizeControlsValues();           
        }

        public void OnConfirmCreationButtonClick()
        {
            AgentRawData rawData;
            AgentCardPreview newCard;
            if (CurrentPreview == null)//новый агент
            {
                //создать карточку на панели выбора
                newCard = Instantiate(SceneDataStorage.Storage.AgentCardPrafab,
                    cardsOrderHandler.transform).GetComponent<AgentCardPreview>();
                CurrentPreview = newCard;
            }

            //создаём новую или редактируем существующую?
            if (CurrentData == null)
            {
                rawData = new AgentRawData();
                //сохранить дату с выбранными параметрами в класс для инициализации GO с этими параметрами
                rawData.Initiate(this);
                CurrentData = rawData;
            }
            else
                CurrentData.Initiate(this);
            CurrentPreview.Initiate(this, CurrentData);
            agentsSelectionScreen.AddAgentData(CurrentData);
            BeforeChangeState();
        }

        public override void BeforeChangeState()
        {
            base.BeforeChangeState();
            cardsOrderHandler.ReorderContent();
            CurrentData = null;
            CurrentPreview = null;
        }
    }
}