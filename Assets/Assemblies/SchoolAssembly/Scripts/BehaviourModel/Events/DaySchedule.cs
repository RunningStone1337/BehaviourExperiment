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
        [SerializeField] private DaySwitcher daySwitcher;
        [SerializeField] private Text titleText;
        [SerializeField] private List<DisciplineBase> dayLessons;
        public List<DisciplineBase> Lessons { get => dayLessons; private set => dayLessons = value; }
        public DaySchedule NextDay { get; internal set; }
        public string DayName => daySwitcher.DayName;
        public int DayIndex { get; internal set; }

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
        }


        private void Start()
        {
            titleText.text += daySwitcher.DayName;
        }

        
    }
}