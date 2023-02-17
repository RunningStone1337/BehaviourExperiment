using UI;
using UnityEngine;

namespace Common
{
    /// <summary>
    /// –андомайзер выпадающего списка, значение определ€етс€ на основании выбранного пола и возраста
    /// </summary>
    public sealed class DependentSexAgeDropdownRandomizer : DropdownRandomizer
    {
        [SerializeField] private DropdownButtonPair ageDropdown;
        [SerializeField] private ListVector3IntHandler femaleValues;
        [SerializeField] private ListVector3IntHandler maleValues;
        [SerializeField] private DropdownButtonPair sexDropdown;

        public override void SetRandomValue()
        {
            var normal = new NormalDistribution();
            var handler = sexDropdown.DropdownValue == "м" ? maleValues : femaleValues;
            var meanDispersion = handler.GetYZForXValue(int.Parse(ageDropdown.DropdownValue));
            var value = Mathf.RoundToInt((float)normal.Next(meanDispersion.x, meanDispersion.y));
            optionsDropdown.DropdownValue = value.ToString();
        }
    }
}