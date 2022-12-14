using Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ClassSelectionDropdown : MonoBehaviour
    {
        [SerializeField] Dropdown classDropdown;
        [SerializeField] Toggle classToggle;
        [SerializeField] List<DisciplineBase> disciplines;
        [SerializeField] ClassSelectionDropdown nextDropdown;

        private void Awake()
        {
            foreach (var d in disciplines)
            {
                classDropdown.options.Add(new Dropdown.OptionData(d.DisciplineName));
            }
        }
        public void HandleDropdownSelectionChanged()
        {
        }
        public void HandleSelectingToggleChanged()
        {
            if (classToggle.isOn && nextDropdown != null)
                nextDropdown.Activate();
            else if (nextDropdown != null)
                nextDropdown.SetNextDropsState(false);
        }

        private void Activate()
        {
            gameObject.SetActive(true);
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
    }
}