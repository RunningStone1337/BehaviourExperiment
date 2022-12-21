using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;

namespace Common
{
    public sealed class DependentDropdownRandomizer : DropdownRandomizer
    {
        [SerializeField] DropdownButtonPair influenceDropdown;
        [SerializeField] KeyValuesHandler maleValues;
        [SerializeField] KeyValuesHandler femaleValues;
        public override void SetRandomValue()
        {
            var normal = new NormalDistribution();
            var handler = influenceDropdown.DropdownValue == "ì" ? maleValues : femaleValues;
            var meanDispersion = handler.GetYZForValue(int.Parse(influenceDropdown.DropdownValue));
            var value = Mathf.RoundToInt((float)normal.Next(meanDispersion.x, meanDispersion.y));
            optionsDropdown.DropdownValue = value.ToString();
        }
    }
}