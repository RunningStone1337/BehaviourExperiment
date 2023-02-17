using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class PupilObservationsSystem : ObservationsSystem<PupilAgent, ReactionBase, FeatureBase, SchoolAgentStateBase<PupilAgent>, Sensor>
    {
        [SerializeField] EventsSensor eventsSensor;
        public EventsSensor EventsSensor => eventsSensor;
    }
}
