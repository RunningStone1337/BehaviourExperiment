using UnityEngine;

namespace Core
{
    public abstract class GlobalEvent : ScriptableObject, IContext
    {
        [SerializeField] protected int eventDuration;

        public abstract void Initiate(ScheduleHandler schedule);
    }
}