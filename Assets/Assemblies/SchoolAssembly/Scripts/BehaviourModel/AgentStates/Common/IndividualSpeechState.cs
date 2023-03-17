using System.Collections;

namespace BehaviourModel
{
    public class IndividualSpeechState<TAgent, TCompanion, TAttractAttentionStateType> : SchoolAgentStateBase<TAgent>
        where TAgent : SchoolAgentBase<TAgent>
        where TCompanion : SchoolAgentBase<TCompanion>
        where TAttractAttentionStateType : TryAttractAttentionStateBase<TAgent, TCompanion>
    {
        TCompanion secondSpeechAgent;
        SpeakAction<TAgent, TCompanion> thisStateSpeech;
        public delegate TAttractAttentionStateType SetAndInitAttractState<TAttrAttentionStateType>(TAgent agent, TCompanion companion) where TAttrAttentionStateType: TAttractAttentionStateType;

        SetAndInitAttractState<TAttractAttentionStateType> setAndInitAttractAttStateAction;
        public override IEnumerator StartState()
        {
            var direction = thisAgent.transform.up;
            var rotator = new RotationHandler();
            yield return rotator.RotateToFaceDirection(secondSpeechAgent.transform,
                thisAgent.AgentRigidbody, RotationHandler.QuickRotation);
            var state = setAndInitAttractAttStateAction.Invoke(thisAgent, secondSpeechAgent);
            yield return state.StartState();
            thisAgent.SetState(this);

            //внимание привлечено
            if (secondSpeechAgent.CurrentState is AttentionToPhenomStateBase<TCompanion, TAgent> ats 
                && ats.AttentionSubject == thisAgent)
            {
                var dialog = new DialogProcess<TAgent, TCompanion>(thisAgent, secondSpeechAgent);
                yield return dialog.StartDialog(thisStateSpeech);
            }
            yield return rotator.RotateToFaceDirection(direction, thisAgent.AgentRigidbody,  RotationHandler.QuickRotation);
            //thisAgent.SetDefaultState();
        }

        public void Initiate(TAgent actorCast, TCompanion secondCast, SpeakAction<TAgent, TCompanion> speech, 
            SetAndInitAttractState<TAttractAttentionStateType> setAndInitStateAction)
        {
            base.Initiate(actorCast);
            secondSpeechAgent = secondCast;
            thisStateSpeech = speech;
            setAndInitAttractAttStateAction = setAndInitStateAction;
        }
    }
}
