using System;
using UI;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class FeatureBase : ScriptableObject, INameHandler, IPhenomenon, IFeature
    {
        [SerializeField] [Range(1f, 5f)] private float categoricalMatchMultiplier = 1.5f;
        [SerializeField] [Range(1f, 5f)] private float exactMatchMultiplier = 3f;
        [SerializeField] private string featureName;
        [SerializeField] [Range(1f, 10f)] private float featurePower;

        protected abstract Type GetHierarchyBaseClass();
        public string Name { get => featureName; }
        public float PhenomValue { get => featurePower; set => featurePower = value; }

    }
}