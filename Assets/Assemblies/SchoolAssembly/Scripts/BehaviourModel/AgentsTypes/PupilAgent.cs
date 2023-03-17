using BuildingModule;
using Core;
using Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BehaviourModel
{
    public class PupilAgent : SchoolAgentBase<PupilAgent>
        
    {
        public override GlobalEvent CurrentEvent => ((SchoolObservationsSystem<PupilAgent>)ObservationsSystem).EventsSensor.CurrentEvent;

        protected override void Awake()
        {
            if (currentState == null)
            {
                SetState<PupilChooseActionState>();
            }
        }
        public override void SetDefaultState()
        {
            SetState<IdleState<PupilAgent>>();
        }
    }
}