using BehaviourModel;
using Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Events
{
    [CreateAssetMenu(menuName = "Events/Global/Break", fileName = "Break")]
    public class BreakEvent : GlobalEvent
    {
       

        //public override List<ActionBase> CreateActions()
        //{
        //    //TODO ��������� ������ ������� ������ ��������
        //    return new List<ActionBase>() { 
        //        new ContactSpeech(this),
        //        new DiscussThingSpeech(this),
        //        new EmotionalSpeech(this),
        //        new MotivationSpeech(this),
        //        new PlayPhysic(this) };
        //}

        public override void Initiate(ScheduleHandler schedule)
        {
            eventType = EventType.Break;
            eventDuration = schedule.BreaksLength;
        }

       
    }
}