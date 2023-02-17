using UnityEngine;

namespace UI
{
    public class SliderButtonPair : UIButtonPairElement
    {
        [SerializeField] private LengthConfigurator lengthConfigurator;
        public int MinValue { get => lengthConfigurator.MinValue; set => lengthConfigurator.MinValue = value; }
        public int Value { get => lengthConfigurator.Value; set => lengthConfigurator.Value = value; }

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