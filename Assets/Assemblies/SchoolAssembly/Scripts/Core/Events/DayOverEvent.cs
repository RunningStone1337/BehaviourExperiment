using Core;
using UnityEngine;

namespace Events
{
    [CreateAssetMenu(menuName = "Events/Global/DayOver", fileName = "DayOver")]
    public class DayOverEvent : GlobalEvent
    {
        public override void Initiate(ScheduleHandler schedule)
        {
            eventType = EventType.DayEnd;
        }
    }
}