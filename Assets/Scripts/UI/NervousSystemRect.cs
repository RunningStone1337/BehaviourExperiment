using BehaviourModel;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class NervousSystemRect : MonoBehaviour
    {
        [SerializeField] SliderButtonPair nsPowerSlider;
        [SerializeField] SliderButtonPair nsMoveabilitySlider;
        [SerializeField] SliderButtonPair nsActivitySlider;
        [SerializeField] SliderButtonPair nsReactivitySlider;
        [SerializeField] DropdownButtonPair nsBalanceDropButtonPair;
        public SliderButtonPair NsPowerSlider { get => nsPowerSlider; }
        public SliderButtonPair NsMoveabilitySlider { get => nsMoveabilitySlider; }
        public SliderButtonPair NsActivitySlider { get => nsActivitySlider; }
        public SliderButtonPair NsReactivitySlider { get => nsReactivitySlider; }

        public void SetDefaultValues()
        {
            NsPowerSlider.SetMinValue();
            NsMoveabilitySlider.SetMinValue();
            NsBalanceDropButtonPair.DropdownIndex = 0;
            NsActivitySlider.SetMinValue();
            NsReactivitySlider.SetMinValue();
        }

        public DropdownButtonPair NsBalanceDropButtonPair { get => nsBalanceDropButtonPair; }

        public void RandomizeControlsValues()
        {
            NsPowerSlider.PushButton();
            NsMoveabilitySlider.PushButton();
            NsActivitySlider.PushButton();
            NsReactivitySlider.PushButton();
            NsBalanceDropButtonPair.PushButton();
        }

        public void SetControlsValues(AgentRawData rawData)
        {
            NsPowerSlider.Value = rawData.NsPower;
            NsMoveabilitySlider.Value = rawData.NsMoveability;
            NsBalanceDropButtonPair.DropdownIndex = (int)rawData.NsType;
            NsActivitySlider.Value = rawData.NsActivity;
            NsReactivitySlider.Value = rawData.NsReactivity;
        }
    }
}