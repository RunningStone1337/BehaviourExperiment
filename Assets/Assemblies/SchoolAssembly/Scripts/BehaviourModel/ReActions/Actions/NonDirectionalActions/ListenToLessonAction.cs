using Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class ListenToLessonAction : NonDirectedAction
    {
        public override IEnumerator TryPerformAction()
        {
            var cast = (PupilAgent)ActionActor;
            if (cast.AgentEnvironment.ChairInfo != null && cast.CurrentEvent is LessonEvent)
                cast.SetState<ListenToLessonState>();
            yield return cast.CurrentState.StartState();
        }
    }
}
