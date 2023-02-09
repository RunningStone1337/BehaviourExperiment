using BehaviourModel;
using Core;
using Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Events
{
    [CreateAssetMenu(menuName = "Events/Global/Lesson", fileName = "Lesson")]
    public class LessonEvent : GlobalEvent
    {
        [SerializeField] int defaultEventDuration;
        [SerializeField] DisciplineBase currentDiscipline;
        public DisciplineBase CurrentDiscipline => currentDiscipline;
       
        //public override List<ActionBase> CreateActions()
        //{
        //    //TODO дополнить список другими типами действий
        //    return new List<ActionBase>() {
        //        new DiscussThingSpeech(this),
        //        new EmotionalSpeech(this),
        //        new MotivationSpeech(this),
        //        new PlayPhysic(this) };
        //}

        public override void Initiate(ScheduleHandler schedule)
        {
            eventType = EventType.Lesson;
            eventDuration = defaultEventDuration;
        }
    }
}