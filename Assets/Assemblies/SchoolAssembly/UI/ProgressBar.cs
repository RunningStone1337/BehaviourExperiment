using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ProgressBar : MonoBehaviour
    {
        float maxValue;
        float tagetValue;
        [SerializeField, Range(0f, 1f)] float fillingRate = 1f;
        [SerializeField] Image progressFillImage;
        public void SetProgress(float newValue)
        {
            tagetValue = newValue;
        }

        public void Reset(float newMaxVal, float currentValue = 0)
        {
            maxValue = newMaxVal;
            tagetValue = currentValue;
        }

        private void Update()
        {
            progressFillImage.fillAmount = CalculateCurrentAmount();
        }

        private float CalculateCurrentAmount()
        {
            return Mathf.Lerp(progressFillImage.fillAmount, tagetValue / maxValue, fillingRate);
        }
    }
}
