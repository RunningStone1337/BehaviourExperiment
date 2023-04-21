using UnityEngine;

namespace BehaviourModel
{
    public class SchoolObservationsSystem<TAgent>
        : ObservationsSystem<TAgent, ReactionBase, FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>
        where TAgent : SchoolAgentBase<TAgent>
    {
        [SerializeField] private EventsSensor eventsSensor;
        public EventsSensor EventsSensor => eventsSensor;
    }
}