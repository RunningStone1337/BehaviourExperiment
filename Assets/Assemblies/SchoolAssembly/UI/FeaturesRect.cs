using BehaviourModel;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UI.CanvasController;

namespace UI
{
    public class FeaturesRect : MonoBehaviour, ISelectableUIComponentHandler
    {
        [SerializeField] private ISelectableUIComponent activeComponent;
        [SerializeField] private RectTransform contentRect;
        [SerializeField] private List<DropdownButtonPair> dropdowns;
        [SerializeField] private GameObject featureDropPrefab;
        [SerializeField] private Button removeButton;
        [SerializeField] private UnicValuesDropdownHandler<DropdownButtonPair, FeatureBase> unicValuesHandler;

        private DropdownButtonPair CreateNewDropdown()
        {
            var drop = Instantiate(featureDropPrefab, contentRect).GetComponent<DropdownButtonPair>();
            dropdowns.Add(drop);
            return drop;
        }

        private void EqualDropdownsCountOnFeaturesCount(HumanRawData rawData)
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

        private DropdownButtonPair TryAddFeatureSelectorDropdown(FeatureBase feature = null)
        {
            if (unicValuesHandler.HasFreeContent())
            {
                var drop = CreateNewDropdown();
                unicValuesHandler.AddContentHandler(drop, (x) => { ActiveComponent = x; });
                if (feature != null)
                    drop.DropdownValue = feature.Name;
                drop.AddPointerClickCallback((x) => { ActiveComponent = drop; });
                drop.AddButtonClickCallback(() =>
                {
                    drop.DropdownValue = drop.RandomValue;
                });
                ActiveComponent = drop;
                return drop;
            }
            return default;
        }

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

        public List<FeatureBase> SelectedFeatures { get => unicValuesHandler.SelectedContent; }

        [ContextMenu("TryAddFeatureSelectorDropdown")]
        public void OnAddButtonClick()
        {
            TryAddFeatureSelectorDropdown();
        }

        public void OnButtonRemoveClick()
        {
            RemoveSelectedFeatureDrop();
        }

        public void RandomizeControlsValues()
        {
            foreach (var d in dropdowns)
                d.PushButton();
        }

        public void SetControlsValues(HumanRawData rawData)
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

        public void SetDefaultValues()
        {
            if (dropdowns.Count > 0)
            {
                ActiveComponent = dropdowns[dropdowns.Count - 1];
                var count = dropdowns.Count;
                for (int i = 0; i < count; i++)
                    RemoveSelectedFeatureDrop();
            }
        }
    }
}