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
        [Space]
        [Header("Настройки ЦНС")]
        [SerializeField] LengthConfigurator nsPowerSlider;
        [SerializeField] LengthConfigurator nsMoveabilitySlider;
        [SerializeField] LengthConfigurator nsActivitySlider;
        [SerializeField] LengthConfigurator nsReactivitySlider;
        [SerializeField] DropdownButtonPair nsBalanceDropButtonPair;
        public LengthConfigurator NsPowerSlider { get => nsPowerSlider; }
        public LengthConfigurator NsMoveabilitySlider { get => nsMoveabilitySlider; }
        public LengthConfigurator NsActivitySlider { get => nsActivitySlider; }
        public LengthConfigurator NsReactivitySlider { get => nsReactivitySlider; }
        public DropdownButtonPair NsBalanceDropButtonPair { get => nsBalanceDropButtonPair; }
        [Space]
        [Header("Настройки характера")]
        [SerializeField] LengthConfigurator closenessSociabilitySlider;
        [SerializeField] LengthConfigurator calmnessAnxietySlider;
        [SerializeField] LengthConfigurator conformismNonconformismSlider;
        [SerializeField] LengthConfigurator conservatismRadicalismSlider;
        [SerializeField] LengthConfigurator credulitySuspicionSlider;
        [SerializeField] LengthConfigurator emotionalInstabilityStabilitySlider;
        [SerializeField] LengthConfigurator intelligenceSlider;
        [SerializeField] LengthConfigurator normativityOfBehaviourSlider;
        [SerializeField] LengthConfigurator practicalityDreaminessSlider;
        [SerializeField] LengthConfigurator relaxationTensionSlider;
        [SerializeField] LengthConfigurator restraintExpressivenessSlider;
        [SerializeField] LengthConfigurator rigiditySensetivitySlider;
        [SerializeField] LengthConfigurator selfcontrolSlider;
        [SerializeField] LengthConfigurator straightforwardnessDiplomacySlider;
        [SerializeField] LengthConfigurator subordinationDominationSlider;
        [SerializeField] LengthConfigurator timidityCourageSlider;
        [SerializeField] List<LengthConfigurator> characterSliders;
        public List<LengthConfigurator> CharacterSliders { get => characterSliders; }
        public LengthConfigurator ClosenessSociabilitySlider { get => closenessSociabilitySlider; }
        public LengthConfigurator CalmnessAnxietySlider { get => calmnessAnxietySlider; }
        public LengthConfigurator ConformismNonconformismSlider { get => conformismNonconformismSlider; }
        public LengthConfigurator ConservatismRadicalismSlider { get => conservatismRadicalismSlider; }
        public LengthConfigurator CredulitySuspicionSlider { get => credulitySuspicionSlider; }
        public LengthConfigurator EmotionalInstabilityStabilitySlider { get => emotionalInstabilityStabilitySlider; }
        public LengthConfigurator IntelligenceSlider { get => intelligenceSlider; }
        public LengthConfigurator NormativityOfBehaviourSlider { get => normativityOfBehaviourSlider; }
        public LengthConfigurator PracticalityDreaminessSlider { get => practicalityDreaminessSlider; }
        public LengthConfigurator RelaxationTensionSlider { get => relaxationTensionSlider; }
        public LengthConfigurator RestraintExpressivenessSlider { get => restraintExpressivenessSlider; }
        public LengthConfigurator RigiditySensetivitySlider { get => rigiditySensetivitySlider; }
        public LengthConfigurator SelfcontrolSlider { get => selfcontrolSlider; }
        public LengthConfigurator StraightforwardnessDiplomacySlider { get => straightforwardnessDiplomacySlider; }
        public LengthConfigurator SubordinationDominationSlider { get => subordinationDominationSlider; }
        public LengthConfigurator TimidityCourageSlider { get => timidityCourageSlider; }
        [Space]
        [Header("Контроллеры диапазонов знаечний веса и роста")]
        [SerializeField] KeyValuesHandler ageWeightsHandler;
        [SerializeField] KeyValuesHandler ageHeightsHandler;
        public KeyValuesHandler AgeWeightsHandler { get => ageWeightsHandler; }
        public KeyValuesHandler AgeHeightsHandler { get => ageHeightsHandler; }
        public int SelectedAge { get => int.Parse(ageDropButtonPair.DropdownValue); }

        private void Start()
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

        public void ResetControlls(AgentRawData rawData = null)
        {
            if (rawData)
                SetExistDataControls(rawData);
            else
                SetDefaultControls();
        }

        private void SetExistDataControls(AgentRawData rawData)
        {
            AgentImageHandler.Image.sprite = AgentImageHandler.GetImage(rawData.ImageID);
            NameInputFieldButtonPair.Text = rawData.AgentName;
            SexDropButtonPair.DropdownValue = rawData.Sex ? "м" : "ж";
            AgeDropButtonPair.DropdownValue = rawData.Age.ToString();
            WeightDropButtonPair.DropdownValue = rawData.Weight.ToString();
            HeightDropButtonPair.DropdownValue = rawData.Height.ToString();
            NsPowerSlider.Value = rawData.NsPower;
            NsMoveabilitySlider.Value = rawData.NsMoveability;
            NsBalanceDropButtonPair.DropdownIndex = (int)rawData.NsType;
            NsActivitySlider.Value = rawData.NsActivity;
            NsReactivitySlider.Value = rawData.NsReactivity;

            ClosenessSociabilitySlider.Value = rawData.ClosenessSociability;
            CalmnessAnxietySlider.Value = rawData.CalmnessAnxiety;
            ConformismNonconformismSlider.Value = rawData.ConformismNonconformism;
            ConservatismRadicalismSlider.Value = rawData.ConservatismRadicalism;
            CredulitySuspicionSlider.Value = rawData.CredulitySuspicion;
            EmotionalInstabilityStabilitySlider.Value = rawData.EmotionalInstabilityStability;
            IntelligenceSlider.Value = rawData.Intelligence;
            NormativityOfBehaviourSlider.Value = rawData.NormativityOfBehaviour;
            PracticalityDreaminessSlider.Value = rawData.PracticalityDreaminess;
            RelaxationTensionSlider.Value = rawData.RelaxationTension;
            RestraintExpressivenessSlider.Value = rawData.RestraintExpressiveness;
            RigiditySensetivitySlider.Value = rawData.RigiditySensetivity;
            SelfcontrolSlider.Value = rawData.Selfcontrol;
            StraightforwardnessDiplomacySlider.Value = rawData.StraightforwardnessDiplomacy;
            SubordinationDominationSlider.Value = rawData.SubordinationDomination;
            TimidityCourageSlider.Value = rawData.TimidityCourage;
        }

        private void SetDefaultControls()
        {
            AgentImageHandler.Image.sprite = AgentImageHandler.DefaultImage;
            NameInputFieldButtonPair.Text = string.Empty;
            AgeDropButtonPair.DropdownValue = minAge.ToString();
            OnAgeSelectionChanged();
            //WeightDropButtonPair.DropdownValue = ;
            //HeightDropButtonPair.DropdownValue = rawData.Height.ToString();
            NsPowerSlider.Value = NsPowerSlider.MinValue;
            NsMoveabilitySlider.Value = NsPowerSlider.MinValue;
            NsBalanceDropButtonPair.DropdownIndex = 0;
            NsActivitySlider.Value = NsActivitySlider.MinValue;
            NsReactivitySlider.Value = NsReactivitySlider.MinValue;

            ClosenessSociabilitySlider.Value = ClosenessSociabilitySlider.MinValue;
            CalmnessAnxietySlider.Value = CalmnessAnxietySlider.MinValue;
            ConformismNonconformismSlider.Value = ConformismNonconformismSlider.MinValue;
            ConservatismRadicalismSlider.Value = ConservatismRadicalismSlider.MinValue;
            CredulitySuspicionSlider.Value = CredulitySuspicionSlider.MinValue;
            EmotionalInstabilityStabilitySlider.Value = EmotionalInstabilityStabilitySlider.MinValue;
            IntelligenceSlider.Value = IntelligenceSlider.MinValue;
            NormativityOfBehaviourSlider.Value = NormativityOfBehaviourSlider.MinValue;
            PracticalityDreaminessSlider.Value = PracticalityDreaminessSlider.MinValue;
            RelaxationTensionSlider.Value = RelaxationTensionSlider.MinValue;
            RestraintExpressivenessSlider.Value = RestraintExpressivenessSlider.MinValue;
            RigiditySensetivitySlider.Value = RigiditySensetivitySlider.MinValue;
            SelfcontrolSlider.Value = SelfcontrolSlider.MinValue;
            StraightforwardnessDiplomacySlider.Value = StraightforwardnessDiplomacySlider.MinValue;
            SubordinationDominationSlider.Value = SubordinationDominationSlider.MinValue;
            TimidityCourageSlider.Value = TimidityCourageSlider.MinValue;
        }

        public void OnAgeSelectionChanged()
        {
            var ageChangeHandler = new AgeChangeHandler(SelectedAge, this);
            ageChangeHandler.ResetCharacterExtremeValues();
            ageChangeHandler.ResetWieghtAndHeightDropdowns();           
        }

        public void SaveCurrentAgent()
        {

        }

        public void LoadAgentFromStorage()
        {

        }

        public void ConfirmCreation()
        {
            //создать карточку на панели выбора
            var newCard = Instantiate(SceneDataStorage.Storage.AgentCardPrafab, cardsOrderHandler.transform).GetComponent<AgentCardPreview>();
            newCard.Initiate(this);
            newCard.CardData = newCard.gameObject.AddComponent<AgentRawData>();
            //сохранить дату с выбранными параметрами в класс для инициализации GO с этими параметрами
            newCard.CardData.Initiate(this);
            cardsOrderHandler.ReorderContent();
            BeforeChangeState();
        }
    }
}