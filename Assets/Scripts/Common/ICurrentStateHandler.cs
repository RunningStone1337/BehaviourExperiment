namespace Common
{
    public interface ICurrentStateHandler
    {
        IState CurrentState { get; set; }

        void SetState<S2>() where S2 : IState;
    }
}