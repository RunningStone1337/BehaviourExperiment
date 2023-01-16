using Events;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace Core
{
    public class ScheduleHandler : MonoBehaviour
    {
        [SerializeField] private int breaksLength;
        [SerializeField] private LengthConfigurator breaksLengthSlider;
        [SerializeField] private int experimentLength;
        [SerializeField] private LengthConfigurator experimentLengthSlider;
        [SerializeField] private List<DaySwitcher> workDays;
        [SerializeField] private WorkDaysSelector workDaysSelector;

        private void Awake()
        {
            experimentLengthSlider.ValueChangedEvent += OnExperimentLengthChangedCallback;
            breaksLengthSlider.ValueChangedEvent += OnBreaksLengthChangedCallback;
            workDaysSelector.DaySelectionChangedEvent += OnDaySelectionChangedCallback;
        }

        private void OnBreaksLengthChangedCallback(int newVal)
        {
            breaksLength = newVal;
        }

        private void OnDaySelectionChangedCallback(DaySwitcher sender, bool newValue)
        {
            if (newValue)
                workDays.Add(sender);
            else
                workDays.Remove(sender);
        }

        private void OnDestroy()
        {
            experimentLengthSlider.ValueChangedEvent -= OnExperimentLengthChangedCallback;
            breaksLengthSlider.ValueChangedEvent -= OnBreaksLengthChangedCallback;
            workDaysSelector.DaySelectionChangedEvent -= OnDaySelectionChangedCallback;
        }

        private void OnExperimentLengthChangedCallback(int newVal)
        {
            experimentLength = newVal;
        }

        public int BreaksLength => breaksLength;
        public int ExperimentLength => experimentLength;
        public List<DaySwitcher> WorkDays => workDays;
        public WorkDaysSelector WorkDaysSelector => workDaysSelector;
    }
}