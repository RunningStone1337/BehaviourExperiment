using UI;
using UnityEngine;

namespace Common
{
    public class DropdownRandomizer : MonoBehaviour
    {
        [SerializeField] protected DropdownButtonPair optionsDropdown;

        public virtual void SetRandomValue()
        {
            optionsDropdown.DropdownIndex = Random.Range(0, optionsDropdown.DropdownLength);
        }
    }
}