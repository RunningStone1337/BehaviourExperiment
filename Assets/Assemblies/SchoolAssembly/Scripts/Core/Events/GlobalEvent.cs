using BehaviourModel;
using Core;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace Events
{
    public enum EventType
    {
        Lesson,
        Break,
        None
    }
    public abstract class GlobalEvent : ScriptableObject, IReactionSource, INameHandler
    {
        [SerializeField] protected int eventDuration;
        [SerializeField] float eventImportance;
        [SerializeField] string eventName;
        [SerializeField] [HideInInspector] protected EventType eventType;
        public EventType EventType => eventType;
        public float PhenomenonPower { get => eventImportance; set => eventImportance = value; }

        public string Name => eventName;

        public abstract void Initiate(ScheduleHandler schedule);
    }
}