namespace BehaviourModel
{
    public class PupilDeclinesPupilSpeech : SpeakAction<PupilAgent, PupilAgent>, IExpression
    {
        public PupilDeclinesPupilSpeech():base()
        {
            actionType = ActionType.Decline;
        }
    }
}