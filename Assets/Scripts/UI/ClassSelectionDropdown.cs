using Events;
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
        private void Awake()
        {
            foreach (var d in disciplines)
            {
                classDropdown.options.Add(new Dropdown.OptionData(d.DisciplineName));
            }
        }
    }
}