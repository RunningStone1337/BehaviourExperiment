using BehaviourModel;
using UnityEngine;

namespace UI
{
    public class NervousSystemRect : MonoBehaviour
    {
        [SerializeField] private SliderButtonPair nsActivitySlider;
        [SerializeField] private DropdownButtonPair nsBalanceDropButtonPair;
        [SerializeField] private SliderButtonPair nsMoveabilitySlider;
        [SerializeField] private SliderButtonPair nsPowerSlider;
        [SerializeField] private SliderButtonPair nsReactivitySlider;
        public SliderButtonPair NsActivitySlider { get => nsActivitySlider; }
        public DropdownButtonPair NsBalanceDropButtonPair { get => nsBalanceDropButtonPair; }
        public SliderButtonPair NsMoveabilitySlider { get => nsMoveabilitySlider; }
        public SliderButtonPair NsPowerSlider { get => nsPowerSlider; }
        public SliderButtonPair NsReactivitySlider { get => nsReactivitySlider; }

        public void RandomizeControlsValues()
        {
            NsPowerSlider.PushButton();
            NsMoveabilitySlider.PushButton();
            NsActivitySlider.PushButton();
            NsReactivitySlider.PushButton();
            NsBalanceDropButtonPair.PushButton();
        }

        public void SetControlsValues(PupilRawData rawData)
        {
            NsPowerSlider.Value = rawData.NsPower;
            NsMoveabilitySlider.Value = rawData.NsMoveability;
            NsBalanceDropButtonPair.DropdownIndex = (int)rawData.NsType;
            NsActivitySlider.Value = rawData.NsActivity;
            NsReactivitySlider.Value = rawData.NsReactivity;
        }

        public void SetDefaultValues()
        {
            NsPowerSlider.SetMinValue();
            NsMoveabilitySlider.SetMinValue();
            NsBalanceDropButtonPair.DropdownIndex = 0;
            NsActivitySlider.SetMinValue();
            NsReactivitySlider.SetMinValue();
        }
    }
}