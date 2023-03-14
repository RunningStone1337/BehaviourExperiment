using System.Collections;

namespace BehaviourModel
{
    public abstract class ListenToAgentActionBase<TStateHandler, TListenTarget> : IndividualPerciptionActionBase
        where TStateHandler : SchoolAgentBase<TStateHandler>
        where TListenTarget : SchoolAgentBase<TListenTarget>
    {
        public override IEnumerator TryPerformAction()
        {
            var actor = (TStateHandler)ActionActor;
            var listeningAgent = ReactionSource as TListenTarget;
            if (listeningAgent != null)
            {
                var state = actor.SetState<TimingAttentionToAgentState<TStateHandler, TListenTarget>>();
                state.Initiate(actor, listeningAgent, actionMakingTime);
                yield return actor.CurrentState.StartState();
                WasPerformed = true;
            }
            actor.SetDefaultState();
        }
        public override void Initiate(IReactionSource reactSource, IAgent reactionActor)
        {
            base.Initiate(reactSource, reactionActor);
            var actor = (TStateHandler)ActionActor;
            actionMakingTime = 12 - actor.CharacterSystem.PracticalityDreaminess.RawCharacterValue;
        }
    }
}