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
        Dropdown Dropdown { get => dropdown; }
        Button Button { get => button; }
        public string DropdownValue
        {
            get
            {
                var index = Dropdown.value;
                return Dropdown.options[index].text;
            }
            set
            {
                int index = -1;
                for (int i = 0; i < Dropdown.options.Count; i++)
                {
                    if (Dropdown.options[i].text == value)
                    {
                        index = i;
                        break;
                    }
                }
                if (index != -1)
                    Dropdown.value = index;
            }
        }        
       
        public int DropdownLength { get=>dropdown.options.Count;  }
        public int DropdownIndex { set => dropdown.value = value; get => dropdown.value; }

        public void AddDropdownOption(string value)
        {
            Dropdown.options.Add(new Dropdown.OptionData(value));
        }

        public void ClearDropdown()
        {
            Dropdown.options.Clear();
        }

        public void ResetVisualDropdown()
        {
            dropdown.RefreshShownValue();
        }
    }
}