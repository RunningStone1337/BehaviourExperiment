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
        private void Awake()
        {
            inputField.text = ((int)slider.value).ToString();
        }
    }
}