using System.Collections;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class SpeakAction<TSpeaker, TCompanion> : IndividualAction
        where TSpeaker : SchoolAgentBase<TSpeaker>
        where TCompanion : SchoolAgentBase<TCompanion>
    {
        
        protected SpeakAction() : base()
        {
        }
        public override void Initiate(IReactionSource reactSource, IAgent reactionActor)
        {
            base.Initiate(reactSource, reactionActor);
            BarShowingTime = ((TSpeaker)reactionActor).CharacterSystem.ClosenessSociability.RawCharacterValue;
        }
        public virtual IEnumerator ReactAtSpeech(SpeakAction<TCompanion, TSpeaker> speechToReact)
        {
            var thisAgent = (TSpeaker)ActionActor;
            var speechOwner = (TCompanion)ReactionSource;
            thisAgent.AddRelationsChangesToSpeech(speechToReact, speechOwner);
            yield return null;
        }

        public override IEnumerator TryPerformAction()
        {
            var actorCast = (TSpeaker)ActionActor;
            var secondCast = (TCompanion)ReactionSource;
            var state = actorCast.SetState<IndividualSpeechState<TSpeaker, TCompanion>>();
            state.Initiate(actorCast, secondCast, this);
            yield return state.StartState();
            WasPerformed = true;
            actorCast.SetDefaultState();
        }
    }
}