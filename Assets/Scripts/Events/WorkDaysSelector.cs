using System;
using UnityEngine;

namespace Events
{
    public class WorkDaysSelector : MonoBehaviour
    {
        [SerializeField] private DaySwitcher friday;
        [SerializeField] private DaySwitcher monday;
        [SerializeField] private DaySwitcher saturday;
        [SerializeField] private DaySwitcher sunday;
        [SerializeField] private DaySwitcher thursday;
        [SerializeField] private DaySwitcher tuesday;
        [SerializeField] private DaySwitcher wednesday;
        [SerializeField] private DaySwitcher[] week;

        private void Awake()
        {
            foreach (var day in week)
            {
                day.ValueChangedEvent += OnDaySelectionChangedCallback;
            }
        }

        private void OnDaySelectionChangedCallback(DaySwitcher sender, bool newState)
        {
            DaySelectionChangedEvent?.Invoke(sender, newState);
        }

        private void OnDestroy()
        {
            foreach (var day in week)
            {
                day.ValueChangedEvent -= OnDaySelectionChangedCallback;
            }
        }

        public Action<DaySwitcher, bool> DaySelectionChangedEvent;
    }
}