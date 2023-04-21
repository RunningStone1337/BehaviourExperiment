using System;
using UnityEngine;
using UnityEngine.UI;

namespace Events
{
    public class DaySwitcher : MonoBehaviour
    {
        [SerializeField] private string dayName;
        [SerializeField] private Toggle dayToggle;
        [SerializeField] private DaySchedule thisDaySchedule;
        public DaySchedule ThisDaySchedule => thisDaySchedule;
        public bool IsDayEnabled => dayToggle.isOn;
        private void Start()
        {
            HandleToggleClick();
        }

        public string DayName { get => dayName; }
        public Action<DaySwitcher, bool> ValueChangedEvent { get; set; }

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