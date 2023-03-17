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
        [SerializeField] Image progressFillImage;
        public void SetProgress(float newValue)
        {
            progressFillImage.fillAmount = newValue / maxValue;
        }

        public void Reset(float newMaxVal, float currentValue = 0)
        {
            maxValue = newMaxVal;
            progressFillImage.fillAmount = currentValue;
        }
    }
}
