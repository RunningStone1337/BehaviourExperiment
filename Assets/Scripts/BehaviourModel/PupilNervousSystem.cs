using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class PupilNervousSystem : NervousSystem<EmotionBase, FeatureBase, SchoolAgentStateBase>
    {
        public override float CalculateCurrentImportance<T>(T ph)
        {
            throw new System.NotImplementedException();
        }
    }
}
