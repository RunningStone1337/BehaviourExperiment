using BehaviourModel;
using Core;
using System.Collections.Generic;
using UnityEngine;

namespace Events
{
    public enum EventType
    {
        Lesson,
        Break,
        None
    }
    public abstract class GlobalEvent : ScriptableObject, IPhenomenon
    {
        [SerializeField] protected int eventDuration;
        [SerializeField] int eventImportance;
        [SerializeField] [HideInInspector] protected EventType eventType;
        public EventType EventType => eventType;
        public int PhenomenonPower { get => eventImportance; set => eventImportance = value; }

        /// <summary>
        /// Приемлемые для данного события действия
        /// </summary>
        /// <returns></returns>

        /// <summary>
        /// Неприемлемые для события действия
        /// </summary>
        /// <returns></returns>
        public abstract void Initiate(ScheduleHandler schedule);
    }
}