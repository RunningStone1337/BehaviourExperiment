using UI;
using UnityEngine;

namespace Common
{
    public sealed class DependentDropdownRandomizer : DropdownRandomizer
    {
        [SerializeField] private ListVector3IntHandler femaleValues;
        [SerializeField] private DropdownButtonPair influenceDropdown;
        [SerializeField] private ListVector3IntHandler maleValues;

        public override void SetRandomValue()
        {
            var normal = new NormalDistribution();
            var handler = influenceDropdown.DropdownValue == "ì" ? maleValues : femaleValues;
            var meanDispersion = handler.GetYZForXValue(int.Parse(influenceDropdown.DropdownValue));
            var value = Mathf.RoundToInt((float)normal.Next(meanDispersion.x, meanDispersion.y));
            optionsDropdown.DropdownValue = value.ToString();
        }
    }
}