using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Events
{
    public class DaySchedule : MonoBehaviour
    {
        [SerializeField] private ClassSelectionDropdown class1Dropdown;
        [SerializeField] private ClassSelectionDropdown class2Dropdown;
        [SerializeField] private ClassSelectionDropdown class3Dropdown;
        [SerializeField] private ClassSelectionDropdown class4Dropdown;
        [SerializeField] private ClassSelectionDropdown class5Dropdown;
        [SerializeField] private List<ClassSelectionDropdown> selectedOptions;
        [SerializeField] private DaySwitcher thisDayInfo;
        [SerializeField] private Text titleText;

        private void Awake()
        {
            class1Dropdown.ClassSelectionChangedEvent += OnClassSelectionChangedCallback;
            class2Dropdown.ClassSelectionChangedEvent += OnClassSelectionChangedCallback;
            class3Dropdown.ClassSelectionChangedEvent += OnClassSelectionChangedCallback;
            class4Dropdown.ClassSelectionChangedEvent += OnClassSelectionChangedCallback;
            class5Dropdown.ClassSelectionChangedEvent += OnClassSelectionChangedCallback;
        }

        private void OnClassSelectionChangedCallback(ClassSelectionDropdown sender, bool state)
        {
            if (state)
                selectedOptions.Add(sender);
            else
                selectedOptions.Remove(sender);
        }

        private void OnDestroy()
        {
            class1Dropdown.ClassSelectionChangedEvent -= OnClassSelectionChangedCallback;
            class2Dropdown.ClassSelectionChangedEvent -= OnClassSelectionChangedCallback;
            class3Dropdown.ClassSelectionChangedEvent -= OnClassSelectionChangedCallback;
            class4Dropdown.ClassSelectionChangedEvent -= OnClassSelectionChangedCallback;
            class5Dropdown.ClassSelectionChangedEvent -= OnClassSelectionChangedCallback;
        }

        private void Start()
        {
            titleText.text += thisDayInfo.DayName;
        }

        public List<ClassSelectionDropdown> SelectedOptions => selectedOptions;
    }
}