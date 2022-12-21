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
        [Header("Основные контролы")]
        [SerializeField] Image agentImage;
        [SerializeField] TextButtonPair nameInputFieldButtonPair;
        [SerializeField] DropdownButtonPair sexDropButtonPair;
        [SerializeField] DropdownButtonPair ageDropButtonPair;
        [SerializeField] DropdownButtonPair weightDropButtonPair;
        [SerializeField] DropdownButtonPair heightDropButtonPair;
        public DropdownButtonPair WeightDropButtonPair { get => weightDropButtonPair; }
        public DropdownButtonPair HeightDropButtonPair { get => heightDropButtonPair; }
        public DropdownButtonPair AgeDropButtonPair { get => ageDropButtonPair; }
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
        
        public void OnAgeSelectionChanged()
        {
            var ageChangeHandler = new AgeChangeHandler(SelectedAge, this);
            ageChangeHandler.ResetCharacterExtremeValues();
            ageChangeHandler.ResetWieghtAndHeightDropdowns();           
        }
    }
}