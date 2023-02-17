using System;
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
        //[SerializeField] private List<ClassSelectionDropdown> selectedOptions;
        [SerializeField] private DaySwitcher daySwitcher;
        [SerializeField] private Text titleText;
        [SerializeField] private List<DisciplineBase> dayLessons;
        [SerializeField] private DisciplineBase currentLesson;
        public List<DisciplineBase> Lessons { get => dayLessons; private set => dayLessons = value; }
        public DisciplineBase CurrentLesson { get=> currentLesson; set=> currentLesson = value; }
        private void Awake()
        {
            //class1Dropdown.ClassSelectionToggleChangedEvent += OnClassSelectionChangedCallback;
            //class2Dropdown.ClassSelectionToggleChangedEvent += OnClassSelectionChangedCallback;
            //class3Dropdown.ClassSelectionToggleChangedEvent += OnClassSelectionChangedCallback;
            //class4Dropdown.ClassSelectionToggleChangedEvent += OnClassSelectionChangedCallback;
            //class5Dropdown.ClassSelectionToggleChangedEvent += OnClassSelectionChangedCallback;
        }

        public void CreateSchedule()
        {
            var drops = new List<ClassSelectionDropdown>() {
                class1Dropdown,
                class2Dropdown,
                class3Dropdown,
                class4Dropdown,
                class5Dropdown
            };
            Lessons.Clear();
            foreach (var drop in drops)
            {
                if (drop.IsLessonSelected)
                    Lessons.Add(drop.SelectedLesson);
            }
            CurrentLesson = Lessons[0];
        }

        //private void OnClassSelectionChangedCallback(ClassSelectionDropdown sender, bool toggleState)
        //{
        //    if (toggleState)
        //    {
        //        //selectedOptions.Add(sender);
        //        Lessons.Add(sender.SelectedLesson);
        //    }
        //    else
        //    {
        //        //selectedOptions.Remove(sender);
        //        Lessons.Remove(sender.SelectedLesson);
        //    }
        //}

        private void OnDestroy()
        {
            //class1Dropdown.ClassSelectionToggleChangedEvent -= OnClassSelectionChangedCallback;
            //class2Dropdown.ClassSelectionToggleChangedEvent -= OnClassSelectionChangedCallback;
            //class3Dropdown.ClassSelectionToggleChangedEvent -= OnClassSelectionChangedCallback;
            //class4Dropdown.ClassSelectionToggleChangedEvent -= OnClassSelectionChangedCallback;
            //class5Dropdown.ClassSelectionToggleChangedEvent -= OnClassSelectionChangedCallback;
        }

        private void Start()
        {
            titleText.text += daySwitcher.DayName;
        }

        //public List<ClassSelectionDropdown> SelectedOptions => selectedOptions;

        
    }
}