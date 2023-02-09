namespace Common
{
    public interface ICurrentStateHandler<T> where T: IState
    {
        T CurrentState { get; set; }

        void SetState<S2>() where S2 : T;
    }
}