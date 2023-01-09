using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Events
{
    public class DaySchedule : MonoBehaviour
    {
        [SerializeField] private ClassSelectionDropdown class1Dropdown;
        [SerializeField] private ClassSelectionDropdown class2Dropdown;
        [SerializeField] private ClassSelectionDropdown class3Dropdown;
        [SerializeField] private ClassSelectionDropdown class4Dropdown;
        [SerializeField] private ClassSelectionDropdown class5Dropdown;
        [SerializeField] private DayInfo thisDayInfo;
        [SerializeField] private Text titleText;

        private void Start()
        {
            titleText.text += thisDayInfo.DayName;
        }
    }
}