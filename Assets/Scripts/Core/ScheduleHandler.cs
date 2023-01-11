using Events;
using System;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace Core
{
    public class ScheduleHandler : MonoBehaviour
    {
        [SerializeField] private int breaksLength;
        [SerializeField] private int experimentLength;
        [SerializeField] List<DaySwitcher> workDays;
        [SerializeField] private LengthConfigurator breaksLengthSlider;
        [SerializeField] private LengthConfigurator experimentLengthSlider;
        [SerializeField] private WorkDaysSelector workDaysSelector;
        public List<DaySwitcher> WorkDays => workDays;

        private void Awake()
        {
            experimentLengthSlider.ValueChangedEvent += OnExperimentLengthChangedCallback;
            breaksLengthSlider.ValueChangedEvent += OnBreaksLengthChangedCallback;
            workDaysSelector.DaySelectionChangedEvent += OnDaySelectionChangedCallback;
        }

        private void OnDaySelectionChangedCallback(DaySwitcher sender, bool newValue)
        {
            if (newValue)
                workDays.Add(sender);
            else
                workDays.Remove(sender);
        }

        private void OnBreaksLengthChangedCallback(int newVal)
        {
            breaksLength = newVal;
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
        public WorkDaysSelector WorkDaysSelector => workDaysSelector;
    }
}