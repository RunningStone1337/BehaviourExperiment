using Events;
using System;
using System.Collections;

namespace BehaviourModel
{
    [Serializable]
    public class PupilAskTeacherToComeToBoardAction : TryPrimitiveSpeechAction<PupilAgent, TeacherAgent>, ICompletedAction, IRequest
    {
        PupilAgent cast;
        TeacherAgent teacher;
        public override IEnumerator ReactAtAction(SpeakAction<TeacherAgent, PupilAgent> speech)
        {
            yield return base.ReactAtAction(speech);
            if (speech is TeacherAgreementPupilSpeech)
            {
                var chair = cast.AgentEnvironment.ChairInfo;
                var exitToBoard = new GoToBoardToStudyAction(cast);
                while (!exitToBoard.WasPerformed)
                    yield return exitToBoard.TryPerformAction();

                var state = cast.SetState<LessonExplainingState<PupilAgent>>();
                yield return state.StartState();

                cast.MovementTarget = chair.ThisInterier.transform;
                while (cast.AgentEnvironment.ChairInfo != chair)
                {
                    var returning = cast.SetState<MoveToTargetPupilState>();
                    yield return returning.StartState();
                }
            }
            else if (speech is TeacherDeclinesPupilSpeech)
            {
                //отрицательан€ реаци€
            }
        }

        public override IEnumerator TryPerformAction()
        {
            cast = ActionActor as PupilAgent;
            teacher = ReactionSource as TeacherAgent;
            if (cast != null && cast.CurrentEvent is LessonEvent &&//идЄт урок
                teacher!= null && cast.AgentEnvironment.ChairInfo != null &&//ученик сидит
                teacher.CurrentState is LessonExplainingState<TeacherAgent>)//учитель объ€сн€ет
            {
                cast.StartActionVisual(this);
                var state = cast.SetState<IndividualSpeechState<PupilAgent, TeacherAgent,
                    //стейт, который будет установлен ученику дл€ привлечени€ внимани€ в IndividualSpeechState
                    TryAttractConditionalState<PupilAgent, TeacherAgent>>>();
                    state.Initiate(cast, teacher, this, 
                    //делегат, выполн€емый в стейте попытки привлечени€ внимани€
                    (cast, teach)=> {
                    var state = cast.SetState<TryAttractConditionalState<PupilAgent, TeacherAgent>>();
                    state.Initiate(cast, teach, TeacherAttentionToPupilWhileAtBoardOrSpeech);
                    return state;
                });
                yield return state.StartState();
                WasPerformed = true;
                cast.SetDefaultState();
            }
        }
        bool TeacherAttentionToPupilWhileAtBoardOrSpeech()
        {
            var state = cast.CurrentState;
            if ((state is IndividualSpeechState<PupilAgent, TeacherAgent, TryAttractConditionalState<PupilAgent, TeacherAgent>>) ||
                (state is TryAttractConditionalState<PupilAgent, TeacherAgent>) ||
                (state is MoveToTargetState<PupilAgent>) ||
                state is LessonExplainingState<PupilAgent>)
                return true;
            return default;
        }
        public PupilAskTeacherToComeToBoardAction():base()
        {
            actionType = ActionType.AskGoToBoard;
        }
        public override void Initiate(IPhenomenon reactSource, IAgent reactionActor)
        {
            base.Initiate(reactSource, reactionActor);
            actionMakingTime = 2f;
        }
    }
}