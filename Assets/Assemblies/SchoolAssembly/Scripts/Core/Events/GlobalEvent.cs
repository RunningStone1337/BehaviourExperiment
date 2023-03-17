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
    public abstract class GlobalEvent : ScriptableObject, IReactionSource, INameHandler
    {
        [SerializeField] protected int eventDuration;
        [SerializeField] float eventImportance;
        [SerializeField] string eventName;
        [SerializeField] [HideInInspector] protected EventType eventType;
        public EventType EventType => eventType;
        public int EventDuration => eventDuration;
        public float PhenomenonPower { get => eventImportance; set => eventImportance = value; }

        public string Name => eventName;

        public abstract void Initiate(ScheduleHandler schedule);
    }
}