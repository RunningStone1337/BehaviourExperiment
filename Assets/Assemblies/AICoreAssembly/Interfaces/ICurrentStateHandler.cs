namespace BehaviourModel
{
    public interface ICurrentStateHandler<TStateBase> where TStateBase : IState
    {
        TStateBase CurrentState { get; set; }

        void SetState<TNewState>() where TNewState : TStateBase;
    }
}