namespace BehaviourModel
{
    public class PupilAgreementPupilSpeech : SpeakAction<PupilAgent, PupilAgent>, IExpression
    {
        public PupilAgreementPupilSpeech():base()
        {
            actionType = ActionType.Agree;
        }
    }
}