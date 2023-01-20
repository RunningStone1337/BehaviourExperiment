using BehaviourModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(menuName = "Events/Global/Lesson", fileName = "Lesson")]
    public class LessonEvent : GlobalEvent
    {
        [SerializeField] int defaultEventDuration;

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
            eventDuration = defaultEventDuration;
        }
    }
}