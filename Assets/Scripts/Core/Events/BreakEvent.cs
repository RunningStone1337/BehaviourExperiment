using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [CreateAssetMenu(menuName = "Events/Global/Break", fileName = "Break")]
    public class BreakEvent : GlobalEvent
    {
        public override void Initiate(ScheduleHandler schedule)
        {
            eventDuration = schedule.BreaksLength;
        }
    }
}