using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class Sensor : MonoBehaviour, ISensor
    {
        public abstract List<IPhenomenon> CollectObservations();
    }
}