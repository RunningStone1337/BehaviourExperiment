using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class Sensor : MonoBehaviour, IPhenomenonsCreator, ISensor
    {
        public abstract List<IPhenomenon> CreatePhenomenons();
    }
}
