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

        public void FillDropdownOptions()
        {
            foreach (var b in behaviours)
                modelDropdownPair.AddOption(b.Name, b);
        }
    }
}