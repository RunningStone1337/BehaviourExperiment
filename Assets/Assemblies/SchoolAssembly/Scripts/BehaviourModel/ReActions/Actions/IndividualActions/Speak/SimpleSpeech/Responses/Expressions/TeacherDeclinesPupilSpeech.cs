namespace BehaviourModel
{
    public class TeacherDeclinesPupilSpeech : SpeakAction<TeacherAgent, PupilAgent>, IExpression
    {
        public TeacherDeclinesPupilSpeech():base()
        {
            actionType = ActionType.Decline;
        }
    }
}