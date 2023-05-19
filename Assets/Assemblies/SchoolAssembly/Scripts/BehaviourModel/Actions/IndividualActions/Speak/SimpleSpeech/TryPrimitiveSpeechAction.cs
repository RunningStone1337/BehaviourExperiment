using System;
using System.Collections;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class TryPrimitiveSpeechAction<TSpeaker, TCompanion> : SpeakAction<TSpeaker, TCompanion>
        where TSpeaker : SchoolAgentBase<TSpeaker>
        where TCompanion : SchoolAgentBase<TCompanion>
    {
        protected TSpeaker actor;
        protected TCompanion paricipiant;

        public TryPrimitiveSpeechAction() : base()
        {
        }
        public override IEnumerator TryPerformAction()
        {
            actor = ActionActor as TSpeaker;
            paricipiant = ReactionSource as TCompanion;
            if (actor != null && paricipiant != null)
            {
                yield return base.TryPerformAction();
                actor.SetDefaultState();
            }
        }
    }
}