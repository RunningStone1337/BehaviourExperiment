using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    /// <summary>
    /// UI слайдер+инпут филд, взаимосвязанные вводимым значением
    /// </summary>
    public class LengthConfigurator : MonoBehaviour
    {
        [SerializeField] Slider slider;
        [SerializeField] InputField inputField;

        public int MinValue { get => (int)slider.minValue; set => slider.minValue = value; }
        public int MaxValue { get => (int)slider.maxValue; set => slider.maxValue = value; }
        public int Value { get => (int)slider.value;set { slider.value = value; SliderValueChanded(); } }

        public void SliderValueChanded()
        {
            inputField.text = ((int)slider.value).ToString();
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

        private void Awake()
        {
            inputField.text = ((int)slider.value).ToString();
        }
    }
}