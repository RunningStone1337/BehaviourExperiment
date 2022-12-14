using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Events
{
    public class DayInfo : MonoBehaviour
    {
        [SerializeField] Toggle dayToggle;
        [SerializeField] DaySchedule thisDaySchedule;
        [SerializeField] string dayName;
        public string DayName { get => dayName; }
        public void HandleToggleClick()
        {
            if (dayToggle.isOn)
                thisDaySchedule.gameObject.SetActive(true);
            else
                thisDaySchedule.gameObject.SetActive(false);
        }
        private void Start()
        {
            HandleToggleClick();
        }

    }
}