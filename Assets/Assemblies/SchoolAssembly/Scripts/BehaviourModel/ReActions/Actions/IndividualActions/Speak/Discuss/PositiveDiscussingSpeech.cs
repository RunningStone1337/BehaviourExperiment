using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class PositiveDiscussingSpeech : DiscussThingSpeech
    {
        public PositiveDiscussingSpeech(IAgent actionActor, IReactionSource reactionSource)
        {
            ActionActor = actionActor;
            ReactionSource = reactionSource;
        }

        public override IEnumerator Speak<TInitiator, TResponder>(DialogProcess<TInitiator, TResponder> dialog)
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerator TryPerformAction()
        {
            throw new System.NotImplementedException();
        }
    }
}
