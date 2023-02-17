using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    public class OptionsDropdown : Dropdown
    {
        private Dictionary<string, object> optionsDict = new Dictionary<string, object>();

        public int DropdownIndex
        {
            set
            {
                this.value = value;
                ResetVisualDropdown();
            }
            get => value;
        }
        public int DropdownLength { get => options.Count; }
        public string DropdownValue
        {
            get
            {
                if (options.Count > 0 && DropdownIndex < options.Count)
                    return options[DropdownIndex].text;
                else
                    return null;
            }

            set
            {
                int index = -1;
                for (int i = 0; i < options.Count; i++)
                {
                    if (options[i].text.Equals(value))
                    {
                        index = i;
                        break;
                    }
                }
                if (index != -1)
                {
                    this.value = index;
                    ResetVisualDropdown();
                }
            }
        }

        public string RandomValue
        {
            get
            {
                if (options.Count > 0)
                    return options[UnityEngine.Random.Range(0, options.Count)].text;
                return default;
            }
        }

        public string SelectedOptionKey { get => DropdownValue; set => DropdownValue = value; }
        public object SelectedOptionValue { get => optionsDict[DropdownValue]; }

       

        public void AddOnValueChangedCallback(Action<int> action)
            => onValueChanged.AddListener(new UnityAction<int>(action));

        public void AddOption(string key, object value)
        {
            var current = DropdownValue;
            options.Add(new OptionData(key));
            DropdownValue = current;
            optionsDict.Add(key, value);
        }

        public void ClearDropdown()
        {
            options.Clear();
            optionsDict.Clear();
        }

        public void RemoveOnValueChangedCallbacks()
        {
            onValueChanged.RemoveAllListeners();
        }

        public void RemoveOption(string key)
        {
            var current = DropdownValue;
            options.Remove(options.FirstOrDefault(x => x.text.Equals(key)));
            DropdownValue = current;
            optionsDict.Remove(key);
        }

        public void ResetVisualDropdown()
            => RefreshShownValue();
    }
}