using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class IndividualSpeechState<TAgent, TCompanion> : SchoolAgentStateBase<TAgent>
        where TAgent : SchoolAgentBase<TAgent>
        where TCompanion : SchoolAgentBase<TCompanion>
    {
        TCompanion secondSpeechAgent;
        SpeakAction<TAgent, TCompanion> thisStateSpeech;
        public override IEnumerator StartState()
        {
            var angle = thisAgent.transform.rotation.eulerAngles.z%360f;
            var rotator = new RotationHandler();
            yield return rotator.RotateToFaceDirection(secondSpeechAgent.transform.position - thisAgent.transform.position,
                thisAgent.AgentRigidbody, RotationHandler.QuickRotation);

            var state = thisAgent.SetState<TryAttractAttentionState<TAgent, TCompanion>>();
            state.Initiate(thisAgent, secondSpeechAgent);
            yield return state.StartState();
            thisAgent.SetState(this);

            //внимание привлечено
            if (secondSpeechAgent.CurrentState is AttentionToPhenomStateBase<TCompanion, TAgent> ats 
                && ats.AttentionSubject == thisAgent)
            {
                var dialog = new DialogProcess<TAgent, TCompanion>(thisAgent, secondSpeechAgent);
                yield return dialog.StartDialog(thisStateSpeech);
            }
            yield return rotator.RotateToAngle(thisAgent.AgentRigidbody, angle, RotationHandler.QuickRotation);
            thisAgent.SetDefaultState();
        }

        public void Initiate(TAgent actorCast, TCompanion secondCast, SpeakAction<TAgent, TCompanion> speech)
        {
            base.Initiate(actorCast);
            secondSpeechAgent = secondCast;
            thisStateSpeech = speech;
        }
    }
}
