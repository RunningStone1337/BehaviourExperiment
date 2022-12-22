using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SliderButtonPair : MonoBehaviour
    {
        [SerializeField] LengthConfigurator lengthConfigurator;
        [SerializeField] Button button;
        public void RandomizeValue()
        {
            var min = lengthConfigurator.MinValue;
            var max = lengthConfigurator.MaxValue;
            lengthConfigurator.Value = Random.Range(min, max + 1);
        }
    }
}