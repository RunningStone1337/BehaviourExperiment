using Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class WriteLessonToNoteAction : PositivePhysicAction, ICompletedAction
    {
        public WriteLessonToNoteAction() : base() { }

        public override IEnumerator TryPerformAction()
        {
            var actor = (PupilAgent)ActionActor;
            var source = ReactionSource as LessonEvent;
            if (source != null && actor.AgentEnvironment.ChairInfo != null)
            {
                actor.SetState<AttentionToPhenomStateBase<PupilAgent, LessonEvent>>();
                var cast = (AttentionToPhenomStateBase<PupilAgent, LessonEvent>)actor.CurrentState;
                cast.Initiate(actor, source, 10f);
                yield return cast.StartState();
                WasPerformed = true;
            }
        }
    }
}
