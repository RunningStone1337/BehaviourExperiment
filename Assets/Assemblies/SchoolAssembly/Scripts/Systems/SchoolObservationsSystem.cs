using UnityEngine;

namespace BehaviourModel
{
    public class SchoolObservationsSystem<TAgent>
        : ObservationsSystem<TAgent, ActionBase, FeatureBase, Sensor>
        where TAgent : SchoolAgentBase<TAgent>
    {
        [SerializeField] private EventsSensor eventsSensor;
        public EventsSensor EventsSensor => eventsSensor;
    }
}