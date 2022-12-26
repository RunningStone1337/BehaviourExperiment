using BehaviourModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class FeaturesRect : MonoBehaviour
    {
        [SerializeField] GameObject featureDropPrefab;
        [SerializeField] List<FeatureBase> features;
        [SerializeField] List<FeatureBase> selectedFeatures;
        [SerializeField] RectTransform contentRect;
        public void OnAddButtonCLick()
        {

        }
    }
}