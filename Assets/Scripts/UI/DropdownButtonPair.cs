using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class DropdownButtonPair : UIButtonPairElement, IKeysValuesHandler, IValueChangedEventHandler
    {
        [SerializeField] private Dropdown dropdown;
        private Dictionary<string, object> optionsDict = new Dictionary<string, object>();
        private Dropdown Dropdown => dropdown;


        private void OnDestroy()
        {
            onElementClick = null;
        }

        public int DropdownIndex { set => dropdown.value = value; get => dropdown.value; }
        public int DropdownLength { get => dropdown.options.Count; }
        public string DropdownValue
        {
            get
            {
                if (dropdown.options.Count > 0 && DropdownIndex < dropdown.options.Count)
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

        public string RandomValue
        {
            get
            {
                if (dropdown.options.Count > 0)
                    return dropdown.options[UnityEngine.Random.Range(0, dropdown.options.Count)].text;
                return default;
            }
        }

        public string SelectedOptionKey { get => DropdownValue; set => DropdownValue = value; }
        public object SelectedOptionValue { get => optionsDict[DropdownValue]; }

        public void AddButtonClickCallback(Action callback)
        {
            Button.onClick.AddListener(new UnityAction(callback));
        }

        public void AddOnValueChangedCallback(Action<int> action)
            => dropdown.onValueChanged.AddListener(new UnityAction<int>(action));

        public void AddOption(string key, object value)
        {
            var current = DropdownValue;
            dropdown.options.Add(new Dropdown.OptionData(key));
            DropdownValue = current;
            optionsDict.Add(key, value);
        }

        public void AddPointerClickCallback(Action<PointerEventData> p)
        {
            onElementClick += p;
        }

        public void ClearDropdown()
        {
            Dropdown.options.Clear();
            optionsDict.Clear();
        }

        public void RemoveOnValueChangedCallbacks()
        {
            dropdown.onValueChanged.RemoveAllListeners();
        }

        public void RemoveOption(string key)
        {
            var current = DropdownValue;
            dropdown.options.Remove(dropdown.options.FirstOrDefault(x => x.text.Equals(key)));
            DropdownValue = current;
            optionsDict.Remove(key);
        }

        public void ResetVisualDropdown()
                            => dropdown.RefreshShownValue();
    }
}