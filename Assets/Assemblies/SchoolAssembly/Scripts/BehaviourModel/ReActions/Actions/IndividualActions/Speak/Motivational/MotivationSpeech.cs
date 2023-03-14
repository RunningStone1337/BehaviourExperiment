namespace BehaviourModel
{
    public abstract class MotivationSpeech<TSpeaker, TCompanion> : SpeakAction<TSpeaker, TCompanion>
        where TSpeaker : SchoolAgentBase<TSpeaker>
        where TCompanion : SchoolAgentBase<TCompanion>
    {
        public MotivationSpeech() : base()
        {
        }
    }
}