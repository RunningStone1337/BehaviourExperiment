using Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    [Serializable]
    public class DreamAction : NonDirectedAction, ICompletedAction
    {
        public DreamAction():base()
        {

        }
        public override IEnumerator TryPerformAction()
        {
            var cast = (PupilAgent)ActionActor;
            if (cast.CurrentEvent is LessonEvent)
            {
                if (cast.AgentEnvironment.ChairInfo != null)
                {
                    cast.SetState<DreamState>();
                }
            }
            else
                cast.SetState<DreamState>();
            yield return cast.CurrentState.StartState();
            WasPerformed = true;
        }
    }
}
