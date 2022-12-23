using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class CharacterRect : MonoBehaviour
    {
        [SerializeField] SliderButtonPair closenessSociabilitySlider;
        [SerializeField] SliderButtonPair calmnessAnxietySlider;
        [SerializeField] SliderButtonPair conformismNonconformismSlider;
        [SerializeField] SliderButtonPair conservatismRadicalismSlider;
        [SerializeField] SliderButtonPair credulitySuspicionSlider;
        [SerializeField] SliderButtonPair emotionalInstabilityStabilitySlider;
        [SerializeField] SliderButtonPair intelligenceSlider;
        [SerializeField] SliderButtonPair normativityOfBehaviourSlider;
        [SerializeField] SliderButtonPair practicalityDreaminessSlider;
        [SerializeField] SliderButtonPair relaxationTensionSlider;
        [SerializeField] SliderButtonPair restraintExpressivenessSlider;
        [SerializeField] SliderButtonPair rigiditySensetivitySlider;
        [SerializeField] SliderButtonPair selfcontrolSlider;
        [SerializeField] SliderButtonPair straightforwardnessDiplomacySlider;
        [SerializeField] SliderButtonPair subordinationDominationSlider;
        [SerializeField] SliderButtonPair timidityCourageSlider;
        [SerializeReference] List<SliderButtonPair> characterSliders;
        public List<SliderButtonPair> CharacterSliders { get => characterSliders; }
        public SliderButtonPair ClosenessSociabilitySlider { get => closenessSociabilitySlider; }
        public SliderButtonPair CalmnessAnxietySlider { get => calmnessAnxietySlider; }
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
    }
}