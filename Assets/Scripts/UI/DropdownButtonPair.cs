using BehaviourModel;
using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class DropdownButtonPair : UIButtonPairElement
    {
        [SerializeField] Dropdown dropdown;
        [SerializeField] object valueObject;
        Dropdown Dropdown { get => dropdown; }
        public string DropdownValue
        {
            get
            {
                if (dropdown.options.Count > 0)
                    return Dropdown.options[DropdownIndex].text;
                else
                    return null;
            }

            set
            {
                int index = -1;
                for (int i = 0; i < Dropdown.options.Count; i++)
                {
                    if (Dropdown.options[i].text.Equals(value))
                    {
                        index = i;
                        break;
                    }
                }
                if (index != -1)
                {
                    Dropdown.value = index;
                    ResetVisualDropdown();
                }
            }
        }        
       
        public int DropdownLength { get=>dropdown.options.Count;  }
        public int DropdownIndex { set => dropdown.value = value; get => dropdown.value; }
        public object ValueObject { get=> valueObject; set=> valueObject = value; }
        public Dropdown.DropdownEvent OnValueChangedCallbacks { get=>dropdown.onValueChanged; }

        public void AddDropdownOption(string value)
        {
            var current = DropdownValue;
            dropdown.options.Add(new Dropdown.OptionData(value));
            DropdownValue = current;
        }

        public void AddPointerClickCallback(Action<PointerEventData> p)
        {
            onElementClick += p;
        }

        private void OnDestroy()
        {
            onElementClick = null;
        }
        public void AddOnValueChangedCallback(Action<int> onDropdownSelectionChanged)
        => dropdown.onValueChanged.AddListener(new UnityAction<int>(onDropdownSelectionChanged));

        public void ClearDropdown()=>
            Dropdown.options.Clear();

        public void ResetVisualDropdown()=>
            dropdown.RefreshShownValue();

        public void RemoveDropdownOption(string removeValue)
        {
            var current = DropdownValue;
            dropdown.options.Remove(dropdown.options.FirstOrDefault(x => x.text.Equals(removeValue)));
            DropdownValue = current;
        }

        public void RemoveOnValueChangedCallbacks()
        {
            dropdown.onValueChanged.RemoveAllListeners();
        }
    }
}