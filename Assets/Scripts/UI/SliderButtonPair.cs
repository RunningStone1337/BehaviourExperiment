using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SliderButtonPair : UIButtonPairElement
    {
        [SerializeField] LengthConfigurator lengthConfigurator;
        public int Value { get => lengthConfigurator.Value; set => lengthConfigurator.Value = value; }
        public int MinValue { get => lengthConfigurator.MinValue; set => lengthConfigurator.MinValue = value; }

        public void RandomizeValue()
        {
            var min = lengthConfigurator.MinValue;
            var max = lengthConfigurator.MaxValue;
            lengthConfigurator.Value = Random.Range(min, max + 1);
        }

        public void SetExtremes(int v1 = 1, int v2 = 10)
        {
            lengthConfigurator.SetExtremes(v1, v2);
        }

        public void SetMinValue()
        {
            Value = MinValue;
        }
    }
}