using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class FeatureBase : ScriptableObject, IOption
    {
        [SerializeField] string featureName;
        public string OptionName { get => featureName; }
    }
}