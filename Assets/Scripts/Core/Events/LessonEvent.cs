using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(menuName = "Events/Global/Lesson", fileName = "Lesson")]
    public class LessonEvent : GlobalEvent
    {
        [SerializeField] int defaultEventDuration;
        public override void Initiate(ScheduleHandler schedule)
        {
            eventDuration = defaultEventDuration;
        }
    }
}