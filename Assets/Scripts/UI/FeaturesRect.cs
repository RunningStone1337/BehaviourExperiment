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
        [SerializeField] List<FeatureBase> availFeatures;
        [SerializeField] List<FeatureBase> selectedFeatures;
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

        [ContextMenu("TryAddFeatureSelectorDropdown")]
        public void OnAddButtonCLick()
        {
            TryAddFeatureSelectorDropdown();
        }

        private void TryAddFeatureSelectorDropdown()
        {
            if (availFeatures.Count>0)
            {
                var drop = CreateNewDropdown();
                var feature = availFeatures.FirstOrDefaultSelectedFeature(drop);
                drop.ValueObject = feature;
                AddSelectedRemoveAvail(feature);
                ResetAnotherDropdowns(drop, feature);
                drop.AddPointerClickCallback((x) => { ActiveComponent = drop; });
                drop.AddOnValueChangedCallback(OnDropdownSelectionChanged);
                ActiveComponent = drop;
            }
        }

        private void ResetAnotherDropdowns(DropdownButtonPair drop, FeatureBase excepdedFeature)
        {
            var drops = dropdowns.Where(x => x != drop);
            foreach (var d in drops)
            {
                d.RemoveOnValueChangedCallbacks();
                d.RemoveDropdownOption(excepdedFeature.FeatureName);
                d.AddOnValueChangedCallback(OnDropdownSelectionChanged);
            }
        }

        private DropdownButtonPair CreateNewDropdown()
        {
            var drop = Instantiate(featureDropPrefab, contentRect).GetComponent<DropdownButtonPair>();
            dropdowns.Add(drop);
            foreach (var f in availFeatures)
                drop.AddDropdownOption(f.FeatureName);
            return drop;
        }
        private void AddAvailRemoveSelected(FeatureBase prevFeature)
        {
            selectedFeatures.Remove(prevFeature);
            availFeatures.Add(prevFeature);
        }
        private void AddSelectedRemoveAvail(FeatureBase feature)
        {
            selectedFeatures.Add(feature);
            availFeatures.Remove(feature);
        }

        private void OnDropdownSelectionChanged(int newIndex)
        {
            DropdownButtonPair sender = GetSenderWithFeatures(availFeatures, out FeatureBase newFeature, out FeatureBase prevFeature);
            AddAvailRemoveSelected(prevFeature);
            AddSelectedRemoveAvail(newFeature);
            var drops = dropdowns.Where(x => x != sender);
            foreach (var d in drops)
            {
                d.RemoveOnValueChangedCallbacks();
                d.AddDropdownOption(prevFeature.FeatureName);
                d.RemoveDropdownOption(newFeature.FeatureName);
                d.AddOnValueChangedCallback(OnDropdownSelectionChanged);
            }
            ActiveComponent = sender;
        }

        private DropdownButtonPair GetSenderWithFeatures(List<FeatureBase> source, out FeatureBase newFeature, out FeatureBase prevFeature)
        {
            DropdownButtonPair sender = default;
            newFeature = default;
            prevFeature = default;
            foreach (var d in dropdowns)
            {
                ///определить предыдущий выбор и свапнуть его в списках
                newFeature = source.FirstOrDefaultSelectedFeature(d);
                if (newFeature != null)
                {
                    sender = d;
                    prevFeature = (FeatureBase)d.ValueObject;
                    sender.ValueObject = newFeature;
                    break;
                }
            }
            return sender;
        }   
        
        public void OnButtonRemoveClick()
        {
            HandleFeatureRemoving();
        }

        private void HandleFeatureRemoving()
        {
            var activeDrop = (DropdownButtonPair)ActiveComponent;
            var currentFeature = selectedFeatures.FirstOrDefaultSelectedFeature(activeDrop);
            var drops = dropdowns.Where(x => x != activeDrop);
            foreach (var d in drops)
            {
                d.RemoveOnValueChangedCallbacks();
                d.AddDropdownOption(currentFeature.FeatureName);
                d.AddOnValueChangedCallback(OnDropdownSelectionChanged);
            }
            AddAvailRemoveSelected(currentFeature);
            var sender = (DropdownButtonPair)activeComponent;
            var index = dropdowns.IndexOf(sender);
            dropdowns.Remove(sender);
            Destroy(sender.gameObject);
            if (dropdowns.Count>0)
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