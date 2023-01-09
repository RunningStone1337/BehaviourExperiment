using BehaviourModel;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class CharacterRect : MonoBehaviour
    {
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

        public void SetControlsValues(PupilRawData rawData)
        {
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