using Core;
using Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class EventsSensor : Sensor
    {
        [SerializeField] GlobalEvent currentEvent;
        public GlobalEvent CurrentEvent {
            get
            {
                if (currentEvent == null)
                    currentEvent = GlobalEventsHandler.Instance.CurrentGlobalEvent;
                return currentEvent;
            }
            set => currentEvent = value; }
        public override List<IPhenomenon> CollectObservations()
        {
            return new List<IPhenomenon>() { CurrentEvent };
        }
        public void OnGlobalEventChangedCallback(CurrentEventChangedEventArgs args)
        {
            CurrentEvent = args.newEvent;
        }

    }
}
