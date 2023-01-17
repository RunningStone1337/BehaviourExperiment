using BehaviourModel;
using Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class FeaturesSystem : MonoBehaviour, IContextCreator
    {
        [SerializeField] List<FeatureBase> features;

        public void Initiate(HumanRawData data)
        {
            features = new List<FeatureBase>(data.features);
        }

        public List<IContext> CreateContext()
        {
            throw new NotImplementedException();
        }
    }
}