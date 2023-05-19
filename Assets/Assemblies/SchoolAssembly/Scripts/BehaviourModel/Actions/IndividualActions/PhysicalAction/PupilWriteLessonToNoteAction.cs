using Events;
using System.Collections;

namespace BehaviourModel
{
    public class PupilWriteLessonToNoteAction : PhysicalAction, ICompletedAction
    {
        public PupilWriteLessonToNoteAction() : base()
        {
            actionType = ActionType.WriteLesson;
        }

        public override IEnumerator TryPerformAction()
        {
            var actor = ActionActor as PupilAgent;
            var source = ReactionSource as LessonEvent;
            if (actor && source && actor.AgentEnvironment.ChairInfo != null)
            {
                actor.StartActionVisual(this);
                var state = actor.SetState<TimingAttentionToPhenomState<PupilAgent, LessonEvent>>();
                state.Initiate(actor, source, actionMakingTime);
                yield return state.StartState();
                WasPerformed = true;
                actor.SetDefaultState();
            }
        }
        public override void Initiate(IPhenomenon reactSource, IAgent reactionActor)
        {
            base.Initiate(reactSource, reactionActor);
            var actor = ActionActor as PupilAgent;
            actionMakingTime = actor.CharacterSystem.Intelligence.RawCharacterValue*1.5f;
        }
    }
}