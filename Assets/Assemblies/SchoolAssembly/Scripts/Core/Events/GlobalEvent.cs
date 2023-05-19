using BehaviourModel;
using Core;
using UI;
using UnityEngine;

namespace Events
{
    public enum EventType
    {
        Lesson,
        Break,
        DayEnd,
        None
    }

    public abstract class GlobalEvent : ScriptableObject, IPhenomenon, INameHandler
    {
        [SerializeField] private float eventImportance;
        [SerializeField] private string eventName;
        [SerializeField] protected int eventDuration;
        [SerializeField] [HideInInspector] protected EventType eventType;
        public int EventDuration => eventDuration;
        public EventType EventType => eventType;
        public string Name => eventName;
        public float PhenomValue { get => eventImportance; set => eventImportance = value; }

        public abstract void Initiate(ScheduleHandler schedule);
    }
}