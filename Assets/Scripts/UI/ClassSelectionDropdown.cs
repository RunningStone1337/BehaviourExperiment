using Events;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;

namespace UI
{
    public class ClassSelectionDropdown : MonoBehaviour
    {
        [SerializeField] private OptionsDropdown classDropdown;
        [SerializeField] private Toggle classToggle;
        [SerializeField] private List<DisciplineBase> disciplines;
        [SerializeField] private ClassSelectionDropdown nextDropdown;
        [SerializeField] private DisciplineBase selectedDiscipline;
        public bool IsLessonSelected => classToggle.isOn;
        private void Activate()
        {
            gameObject.SetActive(true);
        }

        private void Awake()
        {
            foreach (var d in disciplines)
                classDropdown.AddOption(d.DisciplineName, d);
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

        //public Action<ClassSelectionDropdown, bool> ClassSelectionToggleChangedEvent;

        public DisciplineBase SelectedLesson => (DisciplineBase)classDropdown.SelectedOptionValue;

        public void HandleSelectingToggleChanged()
        {
            if (classToggle.isOn && nextDropdown != null)
                nextDropdown.Activate();
            else if (nextDropdown != null)
                nextDropdown.SetNextDropsState(false);
            //ClassSelectionToggleChangedEvent?.Invoke(this, classToggle.isOn);
        }
       
    }
}