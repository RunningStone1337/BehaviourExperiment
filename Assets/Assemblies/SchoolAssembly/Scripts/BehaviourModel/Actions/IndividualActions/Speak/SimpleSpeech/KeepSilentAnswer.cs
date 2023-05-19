namespace BehaviourModel
{
    public class KeepSilentAnswer<TAgent, TInitiator> : TryPrimitiveSpeechAction<TAgent, TInitiator>
        where TAgent : SchoolAgentBase<TAgent>
        where TInitiator : SchoolAgentBase<TInitiator>
    {
    }
}