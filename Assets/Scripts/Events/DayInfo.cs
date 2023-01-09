using UnityEngine;
using UnityEngine.UI;

namespace Events
{
    public class DayInfo : MonoBehaviour
    {
        [SerializeField] private string dayName;
        [SerializeField] private Toggle dayToggle;
        [SerializeField] private DaySchedule thisDaySchedule;

        private void Start()
        {
            HandleToggleClick();
        }

        public string DayName { get => dayName; }

        public void HandleToggleClick()
        {
            if (dayToggle.isOn)
                thisDaySchedule.gameObject.SetActive(true);
            else
                thisDaySchedule.gameObject.SetActive(false);
        }
    }
}