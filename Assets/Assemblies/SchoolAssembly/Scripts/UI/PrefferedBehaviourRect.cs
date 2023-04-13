using BehaviourModel;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class PrefferedBehaviourRect : MonoBehaviour
    {
        [SerializeField] private List<BehaviourPatternBase> behaviours;
        [SerializeField] private DropdownButtonPair modelDropdownPair;

        private void Awake()
        {
            FillDropdownOptions();
        }

        public DropdownButtonPair ModelDropdownPair => modelDropdownPair;

        public BehaviourPatternBase SelectedModel => (BehaviourPatternBase)ModelDropdownPair.SelectedOptionValue;

        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }

        public void FillDropdownOptions()
        {
            foreach (var b in behaviours)
                modelDropdownPair.AddOption(b.Name, b);
        }

        public void RandomizeControlsValues()
        {
            modelDropdownPair.PushButton();
        }
    }
}