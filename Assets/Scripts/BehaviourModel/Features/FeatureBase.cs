using UI;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class FeatureBase : ScriptableObject, INameHandler
    {
        [SerializeField] private string featureName;
        public string Name { get => featureName; }
    }
}