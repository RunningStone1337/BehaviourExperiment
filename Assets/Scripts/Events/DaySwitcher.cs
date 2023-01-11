using System;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Events
{
    public class DaySwitcher : MonoBehaviour
    {
        [SerializeField] private string dayName;
        [SerializeField] private Toggle dayToggle;
        [SerializeField] private DaySchedule thisDaySchedule;

        private void Start()
        {
            HandleToggleClick();
        }

        public Action<DaySwitcher, bool> ValueChangedEvent;
        public string DayName { get => dayName; }
        public List<ClassSelectionDropdown> EnabledOptions { get => thisDaySchedule.SelectedOptions; }

        public void HandleToggleClick()
        {
            if (dayToggle.isOn)
            {
                thisDaySchedule.gameObject.SetActive(true);
                ValueChangedEvent?.Invoke(this, true);
            }
            else
            {
                thisDaySchedule.gameObject.SetActive(false);
                ValueChangedEvent?.Invoke(this, false);
            }
        }
    }
}