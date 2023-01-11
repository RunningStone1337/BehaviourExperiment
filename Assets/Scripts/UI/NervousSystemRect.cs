using BehaviourModel;
using UnityEngine;

namespace UI
{
    public class NervousSystemRect : MonoBehaviour
    {
        [SerializeField] private SliderButtonPair nsActivitySlider;
        [SerializeField] private NervousBalanceRect nsBalanceRect;
        [SerializeField] private SliderButtonPair nsMoveabilitySlider;
        [SerializeField] private SliderButtonPair nsPowerSlider;
        [SerializeField] private SliderButtonPair nsReactivitySlider;
        public SliderButtonPair NsActivitySlider { get => nsActivitySlider; }
        public NervousBalanceRect NsBalanceRect { get => nsBalanceRect; }
        public SliderButtonPair NsMoveabilitySlider { get => nsMoveabilitySlider; }
        public SliderButtonPair NsPowerSlider { get => nsPowerSlider; }
        public SliderButtonPair NsReactivitySlider { get => nsReactivitySlider; }

        public void RandomizeControlsValues()
        {
            NsPowerSlider.PushButton();
            NsMoveabilitySlider.PushButton();
            NsActivitySlider.PushButton();
            NsReactivitySlider.PushButton();
            NsBalanceRect.BalanceDropdownButtonPair.PushButton();
        }

        public void SetControlsValues(HumanRawData rawData)
        {
            NsPowerSlider.Value = rawData.NsPower;
            NsMoveabilitySlider.Value = rawData.NsMoveability;
            NsBalanceRect.BalanceDropdownButtonPair.DropdownValue = rawData.NsType.Name;
            NsActivitySlider.Value = rawData.NsActivity;
            NsReactivitySlider.Value = rawData.NsReactivity;
        }

        public void SetDefaultValues()
        {
            NsPowerSlider.SetMinValue();
            NsMoveabilitySlider.SetMinValue();
            NsBalanceRect.BalanceDropdownButtonPair.DropdownIndex = 0;
            NsActivitySlider.SetMinValue();
            NsReactivitySlider.SetMinValue();
        }
    }
}