using BehaviourModel;
using Common;
using DTT.Utils.Extensions;
using Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static UI.CanvasController;

namespace UI
{
    public class FeaturesRect : MonoBehaviour, ISelectableUIComponentHandler
    {
        [SerializeField] GameObject featureDropPrefab;
        [SerializeField] Button removeButton;
        [SerializeField] UnicValuesDropdownHandler<DropdownButtonPair, FeatureBase> unicValuesHandler;
        [SerializeField] List<DropdownButtonPair> dropdowns;
        [SerializeField] RectTransform contentRect;
        [SerializeField] ISelectableUIComponent activeComponent;

        public ISelectableUIComponent ActiveComponent
        {
            get => activeComponent;
            set
            {
                activeComponent = ResetSelectableComponent(activeComponent, value);
                if (activeComponent != null)
                    removeButton.interactable = true;
                else
                    removeButton.interactable = false;
            }
        }
        
        public List<FeatureBase> SelectedFeatures { get=> unicValuesHandler.SelectedContent;}

        [ContextMenu("TryAddFeatureSelectorDropdown")]
        public void OnAddButtonClick()
        {
            TryAddFeatureSelectorDropdown();
        }
        public void OnButtonRemoveClick()
        {
            RemoveSelectedFeatureDrop();
        }
        public void SetDefaultValues()
        {
            if (dropdowns.Count>0)
            {
                ActiveComponent = dropdowns[dropdowns.Count-1];
                for (int i = 0; i < dropdowns.Count; i++)
                    RemoveSelectedFeatureDrop();
            }
        }

        public void RandomizeControlsValues()
        {
            foreach (var d in dropdowns)
                d.PushButton();
        }

       
        private DropdownButtonPair TryAddFeatureSelectorDropdown(FeatureBase feature = null)
        {
            if (unicValuesHandler.HasFreeValues())
            {
                var drop = CreateNewDropdown();
                unicValuesHandler.AddContentHandler(drop, (x) => { ActiveComponent = x; });
                if (feature != null)
                    drop.DropdownValue = feature.OptionName;
                drop.AddPointerClickCallback((x) => { ActiveComponent = drop; });
                drop.AddButtonClickCallback(() => {
                    drop.DropdownValue = drop.RandomValue;                
                });
                ActiveComponent = drop;
                return drop;
            }
            return default;
        }

        private DropdownButtonPair CreateNewDropdown()
        {
            var drop = Instantiate(featureDropPrefab, contentRect).GetComponent<DropdownButtonPair>();
            dropdowns.Add(drop);
            return drop;
        }

        public void SetControlsValues(AgentRawData rawData)
        {
            var c = dropdowns.Count;
            for (int i = 0; i < c; i++)
            {
                ActiveComponent = dropdowns[0];
                RemoveSelectedFeatureDrop();
            }
            var f = rawData.features;
            for (int i = 0; i < f.Count; i++)
            {
                TryAddFeatureSelectorDropdown(f[i]);
            }
        }

        private void EqualDropdownsCountOnFeaturesCount(AgentRawData rawData)
        {
            var existedDrops = dropdowns.Count;
            var featuresCount = rawData.features.Count;
            if (existedDrops < featuresCount)
            {
                var c = featuresCount - existedDrops;
                for (int i = 0; i < c; i++)
                    TryAddFeatureSelectorDropdown();
            }
            else if (existedDrops > featuresCount)
            {
                var c = existedDrops - featuresCount;
                for (int i = 0; i < c; i++)
                {
                    ActiveComponent = dropdowns[0];
                    RemoveSelectedFeatureDrop();
                }
            }
        }

        private void RemoveSelectedFeatureDrop()
        {
            var activeDrop = (DropdownButtonPair)ActiveComponent;
            unicValuesHandler.RemoveContentHandler(activeDrop);
            var index = dropdowns.IndexOf(activeDrop);
            dropdowns.Remove(activeDrop);
            Destroy(activeDrop.gameObject);
            ResetActiveComponent(index);
        }

        private void ResetActiveComponent(int index)
        {
            if (dropdowns.Count > 0)
            {
                while (index >= 0)
                {
                    if (index < dropdowns.Count)
                    {
                        ActiveComponent = dropdowns[index];
                        return;
                    }
                    else
                        index--;
                }
            }
            else
                ActiveComponent = null;
        }
    }
}