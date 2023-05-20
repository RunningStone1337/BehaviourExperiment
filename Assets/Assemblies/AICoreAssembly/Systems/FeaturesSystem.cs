using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class FeaturesSystem<TAgent, TFeature> :
        SystemBase<TAgent>, IEnumerable<TFeature>
        where TAgent :  IAgent
        where TFeature : IFeature
    {
        [SerializeField] private List<TFeature> features;
       
        public IEnumerator<TFeature> GetEnumerator()
        {
            return features.GetEnumerator();
        }

        public void Initiate(IFeaturesHandler<TFeature> data)
        {
            features = new List<TFeature>(data.Features);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return features.GetEnumerator();
        }
        public void AddFeature(TFeature feature)
        {
            features.Add(feature);
        }
        public List<TFeature> GetAllFeatures() => features;
    }
}