namespace BehaviourModel
{
    public interface ICurrentStateHandler<TStateBase, TAgent> 
        where TStateBase : IState<TAgent>
        where TAgent : IAgent
    {
        TStateBase CurrentState { get; set; }

        TNewState SetState<TNewState>()where TNewState: TStateBase, new();
    }
}