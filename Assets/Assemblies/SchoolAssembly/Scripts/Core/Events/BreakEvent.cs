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
        public override void Initiate(ScheduleHandler schedule)
        {
            eventType = EventType.Break;
            eventDuration = schedule.BreaksLengthMins;
        }
    }
}