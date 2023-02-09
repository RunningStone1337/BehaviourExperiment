using BehaviourModel;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class CharacterRect : MonoBehaviour
    {
        #region builder
        [SerializeField] RawCharacterValuesHandler characterBuilder;
        public RawCharacterValuesHandler CharacterBuilder => characterBuilder;
        #endregion
        [Space]
        [SerializeField] private SliderButtonPair calmnessAnxietySlider;
        [SerializeReference] private List<SliderButtonPair> characterSliders;
        [SerializeField] private SliderButtonPair closenessSociabilitySlider;
        [SerializeField] private SliderButtonPair conformismNonconformismSlider;
        [SerializeField] private SliderButtonPair conservatismRadicalismSlider;
        [SerializeField] private SliderButtonPair credulitySuspicionSlider;
        [SerializeField] private SliderButtonPair emotionalInstabilityStabilitySlider;
        [SerializeField] private SliderButtonPair intelligenceSlider;
        [SerializeField] private SliderButtonPair normativityOfBehaviourSlider;
        [SerializeField] private SliderButtonPair practicalityDreaminessSlider;
        [SerializeField] private SliderButtonPair relaxationTensionSlider;
        [SerializeField] private SliderButtonPair restraintExpressivenessSlider;
        [SerializeField] private SliderButtonPair rigiditySensetivitySlider;
        [SerializeField] private SliderButtonPair selfcontrolSlider;
        [SerializeField] private SliderButtonPair straightforwardnessDiplomacySlider;
        [SerializeField] private SliderButtonPair subordinationDominationSlider;
        [SerializeField] private SliderButtonPair timidityCourageSlider;
        public SliderButtonPair CalmnessAnxietySlider { get => calmnessAnxietySlider; }
        public List<SliderButtonPair> CharacterSliders { get => characterSliders; }
        public SliderButtonPair ClosenessSociabilitySlider { get => closenessSociabilitySlider; }
        public SliderButtonPair ConformismNonconformismSlider { get => conformismNonconformismSlider; }
        public SliderButtonPair ConservatismRadicalismSlider { get => conservatismRadicalismSlider; }
        public SliderButtonPair CredulitySuspicionSlider { get => credulitySuspicionSlider; }
        public SliderButtonPair EmotionalInstabilityStabilitySlider { get => emotionalInstabilityStabilitySlider; }
        public SliderButtonPair IntelligenceSlider { get => intelligenceSlider; }
        public SliderButtonPair NormativityOfBehaviourSlider { get => normativityOfBehaviourSlider; }
        public SliderButtonPair PracticalityDreaminessSlider { get => practicalityDreaminessSlider; }

        public SliderButtonPair RelaxationTensionSlider { get => relaxationTensionSlider; }
        public SliderButtonPair RestraintExpressivenessSlider { get => restraintExpressivenessSlider; }
        public SliderButtonPair RigiditySensetivitySlider { get => rigiditySensetivitySlider; }
        public SliderButtonPair SelfcontrolSlider { get => selfcontrolSlider; }
        public SliderButtonPair StraightforwardnessDiplomacySlider { get => straightforwardnessDiplomacySlider; }
        public SliderButtonPair SubordinationDominationSlider { get => subordinationDominationSlider; }
        public SliderButtonPair TimidityCourageSlider { get => timidityCourageSlider; }

        public void RandomizeControlsValues()
        {
            foreach (var s in CharacterSliders)
                s.PushButton();
        }

        public void SetControlsValues(HumanRawData rawData)
        {
            CharacterBuilder.ClosenessSociability = ClosenessSociabilitySlider.Value = rawData.ClosenessSociability;
            CharacterBuilder.CalmnessAnxiety = CalmnessAnxietySlider.Value = rawData.CalmnessAnxiety;
            CharacterBuilder.ConformismNonconformism = ConformismNonconformismSlider.Value = rawData.ConformismNonconformism;
            CharacterBuilder.ConservatismRadicalism = ConservatismRadicalismSlider.Value = rawData.ConservatismRadicalism;
            CharacterBuilder.CredulitySuspicion = CredulitySuspicionSlider.Value = rawData.CredulitySuspicion;
            CharacterBuilder.EmotionalInstabilityStability = EmotionalInstabilityStabilitySlider.Value = rawData.EmotionalInstabilityStability;
            CharacterBuilder.Intelligence = IntelligenceSlider.Value = rawData.Intelligence;
            CharacterBuilder.NormativityOfBehaviour = NormativityOfBehaviourSlider.Value = rawData.NormativityOfBehaviour;
            CharacterBuilder.PracticalityDreaminess = PracticalityDreaminessSlider.Value = rawData.PracticalityDreaminess;
            CharacterBuilder.RelaxationTension = RelaxationTensionSlider.Value = rawData.RelaxationTension;
            CharacterBuilder.RestraintExpressiveness = RestraintExpressivenessSlider.Value = rawData.RestraintExpressiveness;
            CharacterBuilder.RigiditySensetivity = RigiditySensetivitySlider.Value = rawData.RigiditySensetivity;
            CharacterBuilder.Selfcontrol = SelfcontrolSlider.Value = rawData.Selfcontrol;
            CharacterBuilder.StraightforwardnessDiplomacy = StraightforwardnessDiplomacySlider.Value = rawData.StraightforwardnessDiplomacy;
            CharacterBuilder.SubordinationDomination = SubordinationDominationSlider.Value = rawData.SubordinationDomination;
            CharacterBuilder.TimidityCourage = TimidityCourageSlider.Value = rawData.TimidityCourage;
        }

        public void SetDefaultValues()
        {
            ClosenessSociabilitySlider.SetMinValue();
            CalmnessAnxietySlider.SetMinValue();
            ConformismNonconformismSlider.SetMinValue();
            ConservatismRadicalismSlider.SetMinValue();
            CredulitySuspicionSlider.SetMinValue();
            EmotionalInstabilityStabilitySlider.SetMinValue();
            IntelligenceSlider.SetMinValue();
            NormativityOfBehaviourSlider.SetMinValue();
            PracticalityDreaminessSlider.SetMinValue();
            RelaxationTensionSlider.SetMinValue();
            RestraintExpressivenessSlider.SetMinValue();
            RigiditySensetivitySlider.SetMinValue();
            SelfcontrolSlider.SetMinValue();
            StraightforwardnessDiplomacySlider.SetMinValue();
            SubordinationDominationSlider.SetMinValue();
            TimidityCourageSlider.SetMinValue();
        }
    }
}