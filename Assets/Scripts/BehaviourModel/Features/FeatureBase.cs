using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class FeatureBase : ScriptableObject
    {
        [SerializeField] string featureName;
        public string FeatureName { get => featureName; }
    }
}