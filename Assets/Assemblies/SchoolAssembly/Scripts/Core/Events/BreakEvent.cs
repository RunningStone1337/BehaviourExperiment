using Core;
using UnityEngine;

namespace Events
{
    [CreateAssetMenu(menuName = "Events/Global/Break", fileName = "Break")]
    public class BreakEvent : GlobalEvent
    {
        public override void Initiate(ScheduleHandler schedule)
        {
            eventType = EventType.Break;
            eventDuration = schedule.BreaksLengthMins;
        }
    }
}