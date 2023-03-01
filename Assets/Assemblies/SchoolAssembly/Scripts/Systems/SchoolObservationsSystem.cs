using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class SchoolObservationsSystem<TAgent> 
        : ObservationsSystem<TAgent, ReactionBase, FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
        where TAgent: SchoolAgentBase<TAgent>
    {
        [SerializeField] EventsSensor eventsSensor;
        public EventsSensor EventsSensor => eventsSensor;
    }
}
