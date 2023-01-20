using BehaviourModel;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(menuName = "Events/Global/Break", fileName = "Break")]
    public class BreakEvent : GlobalEvent
    {
        //public override List<ActionBase> CreateActions()
        //{
        //    //TODO дополнить список другими типами действий
        //    return new List<ActionBase>() { 
        //        new ContactSpeech(this),
        //        new DiscussThingSpeech(this),
        //        new EmotionalSpeech(this),
        //        new MotivationSpeech(this),
        //        new PlayPhysic(this) };
        //}

        public override void Initiate(ScheduleHandler schedule)
        {
            eventDuration = schedule.BreaksLength;
        }
    }
}