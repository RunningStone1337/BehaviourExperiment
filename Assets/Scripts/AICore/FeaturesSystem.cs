using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class FeaturesSystem<TReaction, TFeature, TState> :
        SystemBase<TReaction, TFeature, TState>, IEnumerable<TFeature>
        where TReaction : IReaction
        where TFeature : IFeature
        where TState : IState
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
    }
}