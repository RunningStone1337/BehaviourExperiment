using Core;
using UnityEngine;

namespace Events
{
    [CreateAssetMenu(menuName = "Events/Global/Lesson", fileName = "Lesson")]
    public class LessonEvent : GlobalEvent
    {
        [SerializeField] private DisciplineBase currentDiscipline;
        [SerializeField] private int defaultEventDuration;
        public DisciplineBase CurrentDiscipline { get => currentDiscipline; }

        public override void Initiate(ScheduleHandler schedule)
        {
            eventType = EventType.Lesson;
            eventDuration = defaultEventDuration;
            currentDiscipline = schedule.CurrentLesson;
        }
    }
}