using Events;
using System;
using System.Collections;
using UnityEngine;

namespace BehaviourModel
{
    [Serializable]
    public class PupilAskTeacherToComeToBoardAction : TryPrimitiveSpeechAction<PupilAgent, TeacherAgent>, ICompletedAction, IRequest
    {
        PupilAgent cast;
        TeacherAgent teacher;
        public override IEnumerator ReactAtSpeech(SpeakAction<TeacherAgent, PupilAgent> speech)
        {
            yield return base.ReactAtSpeech(speech);
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
                //������������� ������
            }
        }

        public override IEnumerator TryPerformAction()
        {
            cast = ActionActor as PupilAgent;
            teacher = ReactionSource as TeacherAgent;
            if (cast != null && cast.CurrentEvent is LessonEvent &&//��� ����
                teacher!= null && cast.AgentEnvironment.ChairInfo != null &&//������ �����
                teacher.CurrentState is LessonExplainingState<TeacherAgent>)//������� ���������
            {
                //moveToParticipiant = false;
                cast.StartActionVisual(this);
                var state = cast.SetState<IndividualSpeechState<PupilAgent, TeacherAgent,
                    //�����, ������� ����� ���������� ������� ��� ����������� �������� � IndividualSpeechState
                    TryAttractConditionalState<PupilAgent, TeacherAgent>>>();
                    state.Initiate(cast, teacher, this, 
                    //�������, ����������� � ������ ������� ����������� ��������
                    (cast, teach)=> {
                    var state = cast.SetState<TryAttractConditionalState<PupilAgent, TeacherAgent>>();
                    state.Initiate(cast, teach, TeacherAttentionToPupilWhileAtBoardOrSpeech);
                    return state;
                });
                yield return state.StartState();
                //cast.EndActionVisualForce();
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
            {
                //Debug.Log("Condition true");
                return true;
            }
            //Debug.Log("Condition false");
            return default;
        }
        public override void Initiate(IReactionSource reactSource, IAgent reactionActor)
        {
            base.Initiate(reactSource, reactionActor);
            actionMakingTime = 2f;
        }
    }
}