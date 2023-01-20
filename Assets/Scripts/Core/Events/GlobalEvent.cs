using BehaviourModel;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public abstract class GlobalEvent : ScriptableObject, IPhenomenon
    {
        [SerializeField] protected int eventDuration;
        [SerializeField] int eventImportance;
        public int PhenomenonPower { get => eventImportance; set => eventImportance = value; }


        public abstract void Initiate(ScheduleHandler schedule);
    }
}