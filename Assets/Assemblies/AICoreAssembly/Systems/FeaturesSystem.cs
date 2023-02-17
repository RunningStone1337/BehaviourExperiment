using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class FeaturesSystem<TAgent, TReaction, TFeature, TState, TSensor> :
        SystemBase<TAgent, TReaction, TFeature, TState, TSensor>, IEnumerable<TFeature>
        where TAgent : ICurrentStateHandler<TState>
        where TReaction : IReaction
        where TFeature : IFeature
        where TState : IState
        where TSensor : ISensor
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