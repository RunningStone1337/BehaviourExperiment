using Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    [Serializable]
    public class PupilDreamAction : NonDirectedAction, ICompletedAction
    {
        public PupilDreamAction():base()
        {
            actionType = ActionType.Dream;
        }
        public override IEnumerator TryPerformAction()
        {
            var cast = ActionActor as PupilAgent;
            if (cast != null && 
                (cast.CurrentEvent is LessonEvent && cast.AgentEnvironment.ChairInfo != null 
                || cast.CurrentEvent is BreakEvent))
            {
                cast.StartActionVisual(this);
                var state = cast.SetState<DreamState>();
                yield return state.StartState();
                WasPerformed = true;
            }
        }
    }
}
