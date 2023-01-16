using BehaviourModel;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class FeaturesSystem : MonoBehaviour
    {
        [SerializeField] List<FeatureBase> features;

        public void Initiate(HumanRawData data)
        {
            features = new List<FeatureBase>(data.features);
        }
    }
}