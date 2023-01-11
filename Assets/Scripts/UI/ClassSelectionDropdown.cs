using Events;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ClassSelectionDropdown : MonoBehaviour
    {
        [SerializeField] private Dropdown classDropdown;
        [SerializeField] private Toggle classToggle;
        [SerializeField] private List<DisciplineBase> disciplines;
        [SerializeField] private ClassSelectionDropdown nextDropdown;

        private void Activate()
        {
            gameObject.SetActive(true);
        }

        private void Awake()
        {
            //TODO заменить нативный дропдаун на свой
            foreach (var d in disciplines)
            {
                classDropdown.options.Add(new Dropdown.OptionData(d.DisciplineName));
            }
        }

        private void SetNextDropsState(bool state)
        {
            classDropdown.value = 0;
            classToggle.isOn = false;
            gameObject.SetActive(false);
            if (nextDropdown != null)
            {
                nextDropdown.SetNextDropsState(state);
            }
        }

        public Action<ClassSelectionDropdown, bool> ClassSelectionChangedEvent;

        public void HandleSelectingToggleChanged()
        {
            if (classToggle.isOn && nextDropdown != null)
                nextDropdown.Activate();
            else if (nextDropdown != null)
                nextDropdown.SetNextDropsState(false);
            ClassSelectionChangedEvent?.Invoke(this, classToggle.isOn);
        }
    }
}