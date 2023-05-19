using Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class TeacherTryRemarkPupilAction : SpeakAction<TeacherAgent, PupilAgent>, ICompletedAction
    {
        public override IEnumerator TryPerformAction()
        {
            var cast = (TeacherAgent)ActionActor;
            var reason = ReactionSource as PupilAgent;
            if (reason != null && cast.CurrentEvent is LessonEvent)
            {
                var state = reason.CurrentState;
                if (!(state is TimingAttentionToAgentState<PupilAgent,TeacherAgent> || state is AttentionToPhenomStateBase<PupilAgent, LessonEvent>))
                {
                    yield return base.TryPerformAction();
                }
            }
        }
    }
}
