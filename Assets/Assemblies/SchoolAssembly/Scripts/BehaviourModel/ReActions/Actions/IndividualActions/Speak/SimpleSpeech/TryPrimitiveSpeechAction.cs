using System;
using System.Collections;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class TryPrimitiveSpeechAction<TSpeaker, TCompanion> : SpeakAction<TSpeaker, TCompanion>
        where TSpeaker : SchoolAgentBase<TSpeaker>
        where TCompanion : SchoolAgentBase<TCompanion>
    {
        TSpeaker actor;
        TCompanion paricipiant;
        //protected bool moveToParticipiant = true;

        public TryPrimitiveSpeechAction() : base()
        {
        }
        public override IEnumerator TryPerformAction()
        {
            actor = ActionActor as TSpeaker;
            paricipiant = ReactionSource as TCompanion;
            if (actor != null && paricipiant != null)
            {
                //if (moveToParticipiant)
                //{
                //    yield return MoveToParticipiant();
                //}
                yield return base.TryPerformAction();
                actor.SetDefaultState();
            }
        }

        //private IEnumerator MoveToParticipiant()
        //{
        //    var dist = Vector3.Distance(actor.transform.position, paricipiant.transform.position);
        //    //подойти к собеседнику
        //    if (dist > 0.5f)
        //    {
        //        actor.MovementTarget = paricipiant;
        //        var state = actor.SetState<MoveToTargetState<TSpeaker>>();
        //        yield return state.StartState();
        //    }
        //}
    }
}