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
        public override IEnumerator ReactAtSpeech(SpeakAction<TeacherAgent, PupilAgent> speech)
        {
            yield return base.ReactAtSpeech(speech);
            if (speech is TeacherAgreementPupilSpeech)
            {
                var chair = cast.AgentEnvironment.ChairInfo;
                var exitToBoard = new GoToBoardToStudyAction(cast);
                yield return exitToBoard.TryPerformAction();

                var rotator = new RotationHandler();
                yield return rotator.RotateToFaceDirection(exitToBoard.BoardToGo.transform.position - cast.transform.position, cast.AgentRigidbody, 2f);

                var boardStanding = new PupilLookAroudAction(cast);
                yield return boardStanding.TryPerformAction();

                cast.MovementTarget = chair.ThisInterier.transform;
                var returning = cast.SetState<MoveToTargetPupilState>();
                yield return returning.StartState();
            }
            else if (speech is TeacherDeclinesPupilSpeech)
            {
                //отрицательаня реация
            }
        }

        public override IEnumerator TryPerformAction()
        {
            cast = ActionActor as PupilAgent;
            teacher = ReactionSource as TeacherAgent;
            if (cast != null && cast.CurrentEvent is LessonEvent &&
                teacher!= null && cast.AgentEnvironment.ChairInfo != null &&
                teacher.CurrentState is LessonExplainingState<TeacherAgent>)
            {
                //moveToParticipiant = false;
                cast.StartActionVisual(this);
                var state = cast.SetState<IndividualSpeechState<PupilAgent, TeacherAgent>>();
                state.Initiate(cast, teacher, this);
                yield return state.StartState();
                //cast.EndActionVisualForce();
                WasPerformed = true;
                cast.SetDefaultState();
            }
        }
        public override void Initiate(IReactionSource reactSource, IAgent reactionActor)
        {
            base.Initiate(reactSource, reactionActor);
            actionMakingTime = 2f;
        }
    }
}