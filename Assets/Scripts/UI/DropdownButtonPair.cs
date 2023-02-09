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
        [SerializeField] OptionsDropdown customDrop;

        private void OnDestroy()
        {
            onElementClick = null;
        }

        public int DropdownIndex
        {
            set
            {
                customDrop.DropdownIndex = value;
                
            }
            get => customDrop.DropdownIndex;
        }
        public int DropdownLength { get => customDrop.DropdownLength; }
        public string DropdownValue
        {
            get => customDrop.DropdownValue;

            set => customDrop.DropdownValue = value;
        }

        public string RandomValue
        {
            get => customDrop.RandomValue;
        }

        public string SelectedOptionKey { get => customDrop.SelectedOptionKey; set => customDrop.SelectedOptionKey = value; }
        public object SelectedOptionValue { get => customDrop.SelectedOptionValue; }

        public void AddButtonClickCallback(Action callback)
        {
            Button.onClick.AddListener(new UnityAction(callback));
        }

        public void AddOnValueChangedCallback(Action<int> action)
            => customDrop.AddOnValueChangedCallback(action);

        public void AddOption(string key, object value)
        {
            customDrop.AddOption(key, value);
        }

        public void AddPointerClickCallback(Action<PointerEventData> p)
        {
            onElementClick += p;
        }

        public void ClearDropdown()
        {
            customDrop.ClearDropdown();
        }

        public void RemoveOnValueChangedCallbacks()
        {
            customDrop.RemoveOnValueChangedCallbacks();
        }

        public void RemoveOption(string key)
        {
            customDrop.RemoveOption(key);
        }

        public void ResetVisualDropdown()
            => customDrop.ResetVisualDropdown();
    }
}