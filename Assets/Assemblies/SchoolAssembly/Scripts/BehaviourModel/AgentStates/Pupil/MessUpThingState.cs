using BuildingModule;
using System.Collections;
using UnityEngine;

namespace BehaviourModel
{
    public class MessUpThingState : SchoolAgentStateBase<PupilAgent>
    {
        private PlacedInterier interierToBreak;
        private float stateDuration;

        public void Initiate(PupilAgent cast, PlacedInterier thingCast, float actionMakingTime)
        {
            base.Initiate(cast);
            interierToBreak = thingCast;
            stateDuration = actionMakingTime;
        }

        public override IEnumerator StartState()
        {
            yield return new WaitForSeconds(stateDuration);
        }
    }
}