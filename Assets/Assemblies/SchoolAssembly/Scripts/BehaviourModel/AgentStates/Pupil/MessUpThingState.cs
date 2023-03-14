using BuildingModule;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class MessUpThingState : SchoolAgentStateBase<PupilAgent>
    {
        PlacedInterier interierToBreak;
        float stateDuration;
        public override IEnumerator StartState()
        {
            yield return new WaitForSeconds(stateDuration);
        }

        public void Initiate(PupilAgent cast, PlacedInterier thingCast, float actionMakingTime)
        {
            base.Initiate(cast);
            interierToBreak = thingCast;
            stateDuration = actionMakingTime;
        }
    }
}
