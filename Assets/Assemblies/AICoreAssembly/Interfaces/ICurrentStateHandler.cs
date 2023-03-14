namespace BehaviourModel
{
    public interface ICurrentStateHandler<TStateBase> 
        where TStateBase : IState
    {
        TStateBase CurrentState { get; set; }

        TNewState SetState<TNewState>()where TNewState: TStateBase, new();
    }
}