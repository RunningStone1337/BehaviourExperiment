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
        SpeakAction thisStateSpeech;
        public override IEnumerator StartState()
        {
            thisAgent.SetState<TryAttractAttentionState<TAgent, TCompanion>>();
            ((TryAttractAttentionState<TAgent, TCompanion>)thisAgent.CurrentState).Initiate(thisAgent, secondSpeechAgent);
            yield return thisAgent.CurrentState.StartState();

            //внимание привлечено
            if (secondSpeechAgent.CurrentState is AttentionToAgentState<TCompanion, TAgent> ats && ats.AttentionSubject == thisAgent)
            {
                thisAgent.SetState<IndividualSpeechState<TAgent, TCompanion>>();
                var dialog = new DialogProcess<TAgent, TCompanion>(thisAgent, secondSpeechAgent);
                yield return thisStateSpeech.Speak(dialog);
                if (dialog.DialogResult!= null)
                {
                    yield return dialog.DialogResult.TryPerformAction();
                }
            }
            //отрицательная реакци если не получилось?
        }

        public void Initiate(TAgent actorCast, TCompanion secondCast, SpeakAction speech)
        {
            thisAgent = actorCast;
            secondSpeechAgent = secondCast;
            thisStateSpeech = speech;
        }
    }
}
