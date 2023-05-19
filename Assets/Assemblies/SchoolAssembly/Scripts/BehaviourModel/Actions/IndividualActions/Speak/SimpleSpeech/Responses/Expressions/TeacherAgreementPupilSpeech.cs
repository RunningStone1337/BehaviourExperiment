using System.Collections;
using UnityEngine;

namespace BehaviourModel
{
    public class TeacherAgreementPupilSpeech : SpeakAction<TeacherAgent, PupilAgent>, IExpression
    {
        PupilAgent pupilToReact;
        public override IEnumerator ReactAtAction(SpeakAction<PupilAgent, TeacherAgent> speechToReact)
        {
            //if (speechToReact is PupilAskTeacherToComeToBoardAction)
            //{
            //    pupilToReact =(PupilAgent)speechToReact.ActionActor;
            //    //устанавливаем стейт ожидания
            //    var tTeacher = (TeacherAgent)ActionActor;
            //    var state = tTeacher.SetState<ConditionalAttentionToAgentState<TeacherAgent, PupilAgent>>();
            //    state.Initiate(tTeacher, (PupilAgent)speechToReact.ActionActor, TeacherAttentionToPupilWhileAtBoard);
            //}
            return base.ReactAtAction(speechToReact);
        }
        bool TeacherAttentionToPupilWhileAtBoard()
        {
            var state = pupilToReact.CurrentState;
            if ((state is MoveToTargetState<PupilAgent> && pupilToReact.MovementTarget != null) ||
                state is LessonExplainingState<PupilAgent>)
            {
                //Debug.Log("Condition true");
                return true;
            }
            //Debug.Log("Condition false");
            return default;
        }
        public TeacherAgreementPupilSpeech():base()
        {
            actionType = ActionType.Agree;
        }
    }
}