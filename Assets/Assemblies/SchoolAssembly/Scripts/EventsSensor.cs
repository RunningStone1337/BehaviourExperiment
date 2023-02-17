using Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class EventsSensor : Sensor
    {
        [SerializeField] GlobalEvent currentEvent;
        public GlobalEvent CurrentEvent { get => currentEvent; set => currentEvent = value; }
        public override List<IPhenomenon> CollectObservations()
        {
            return new List<IPhenomenon>() { currentEvent };
        }
    }
}
