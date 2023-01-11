using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    /// <summary>
    /// UI слайдер+инпут филд, взаимосвязанные вводимым значением
    /// </summary>
    public class LengthConfigurator : MonoBehaviour
    {
        [SerializeField] private InputField inputField;
        [SerializeField] private Slider slider;

        private void Start()
        {
            inputField.text = ((int)slider.value).ToString();
        }

        public Action<int> ValueChangedEvent;
        public int MaxValue { get => (int)slider.maxValue; set => slider.maxValue = value; }
        public int MinValue { get => (int)slider.minValue; set => slider.minValue = value; }
        public int Value
        {
            get => (int)slider.value;
            set
            {
                slider.value = value;
                SliderValueChanded();
            }
        }

        public void InputValueChanded()
        {
            if (int.TryParse(inputField.text, out int res))
            {
                slider.value = res;
            }
        }

        public void SetExtremes(int min = 1, int max = 10)
        {
            slider.minValue = min;
            slider.maxValue = max;
        }

        public void SliderValueChanded()
        {
            inputField.text = ((int)slider.value).ToString();
            ValueChangedEvent?.Invoke((int)slider.value);
        }
    }
}