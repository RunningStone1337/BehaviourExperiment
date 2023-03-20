using Events;
using System.Collections;
using UnityEngine;

namespace BehaviourModel
{
    public class PupilWriteLessonToNoteAction : PositivePhysicAction, ICompletedAction
    {
        public PupilWriteLessonToNoteAction() : base()
        {
        }

        public override IEnumerator TryPerformAction()
        {
            var actor = ActionActor as PupilAgent;
            var source = ReactionSource as LessonEvent;
            if (actor && source && actor.AgentEnvironment.ChairInfo != null)
            {
                //Debug.Log("Start wtiting lesson");
                actor.StartActionVisual(this);
                var state = actor.SetState<TimingAttentionToPhenomState<PupilAgent, LessonEvent>>();
                state.Initiate(actor, source, actionMakingTime);
                yield return state.StartState();
                WasPerformed = true;
                actor.SetDefaultState();
                //Debug.Log("End wtiting lesson");
            }
        }
        public override void Initiate(IReactionSource reactSource, IAgent reactionActor)
        {
            base.Initiate(reactSource, reactionActor);
            var actor = ActionActor as PupilAgent;
            actionMakingTime = actor.CharacterSystem.Intelligence.RawCharacterValue*1.5f;
        }
    }
}