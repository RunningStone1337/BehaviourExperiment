using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class FeatureBase : ScriptableObject, INameHandler
    {
        [SerializeField] string featureName;
        public string Name { get => featureName; }
    }
}