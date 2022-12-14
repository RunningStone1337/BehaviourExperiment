using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Events
{

    public class DaySchedule : MonoBehaviour
    {
        [SerializeField] DayInfo thisDayInfo;
        [SerializeField] ClassSelectionDropdown class1Dropdown;
        [SerializeField] ClassSelectionDropdown class2Dropdown;
        [SerializeField] ClassSelectionDropdown class3Dropdown;
        [SerializeField] ClassSelectionDropdown class4Dropdown;
        [SerializeField] ClassSelectionDropdown class5Dropdown;
        [SerializeField] Text titleText;

        private void Start()
        {
            titleText.text += thisDayInfo.DayName;
        }
    }
}