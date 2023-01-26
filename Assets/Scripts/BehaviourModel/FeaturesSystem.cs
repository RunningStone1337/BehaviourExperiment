using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class FeaturesSystem : MonoBehaviour, IEnumerable<FeatureBase>
    {
        [SerializeField] private List<FeatureBase> features;

        public IEnumerator<FeatureBase> GetEnumerator()
        {
            return features.GetEnumerator();
        }

        public void Initiate(HumanRawData data)
        {
            features = new List<FeatureBase>(data.features);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return features.GetEnumerator();
        }
    }
}