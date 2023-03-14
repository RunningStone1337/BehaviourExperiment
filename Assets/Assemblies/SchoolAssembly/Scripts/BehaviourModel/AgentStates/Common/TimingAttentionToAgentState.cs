namespace BehaviourModel
{
    public class TimingAttentionToAgentState<TStateHandler, TAttentionTarget> : TimingAttentionToPhenomState<TStateHandler, TAttentionTarget>
        where TStateHandler : SchoolAgentBase<TStateHandler>
        where TAttentionTarget : SchoolAgentBase<TAttentionTarget>
    {
    }
}