using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class DropdownButtonPair : MonoBehaviour
    {
        [SerializeField] Dropdown dropdown;
        [SerializeField] Button button;
        public Dropdown Dropdown { get => dropdown; }
        public Button Button { get => button; }

        public void AddDropdownOption(string value)
        {
            Dropdown.options.Add(new Dropdown.OptionData(value));
        }
    }
}